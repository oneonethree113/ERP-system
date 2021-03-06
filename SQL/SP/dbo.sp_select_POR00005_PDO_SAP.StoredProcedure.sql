/****** Object:  StoredProcedure [dbo].[sp_select_POR00005_PDO_SAP]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_POR00005_PDO_SAP]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_POR00005_PDO_SAP]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

/**************************************************************************************************************        
Modification History        
**************************************************************************************************************        
Modified on Modified by Description        
**************************************************************************************************************        
        
***************************************************************************************************************/        
        
        
-- sp_select_POR00005_PDO_SAP 'UCP','BJ0700026-0058'      
-- sp_select_POR00005_PDO_SAP 'UCP','BJ0700026-0060'      
-- sp_select_POR00005_PDO_SAP 'UCP','BJ0700025-0012'      
-- sp_select_POR00005_PDO_SAP 'UCP','BJ0700025-0013'       
        
-- select * from SAPZPCKINF where zpi_zmatnr = '06BF36FG72B03'        
        
-- select * from POJBBDTL where pjd_jobord like 'US0700520%' order by pjd_credat        
-- select * from POJBBSAP where pjs_credat >= '2007-04-13'        
        

CREATE    PROCEDURE [dbo].[sp_select_POR00005_PDO_SAP]        
        
@cocde  nvarchar(6),         
@batch  nvarchar(23),        
@img  char(1) = 'X'        
        
        
AS        
        
        
declare @STRDUMMY as varchar(3200)      
set @STRDUMMY = 'X'      
      
      
-- Read Company Information --        
declare         
 @yco_conam varchar(50), @yco_addr nvarchar(200), @yco_logoimgpth varchar(100), @yco_phoneno varchar(50), @yco_faxno varchar(50)        
        
declare         
 @dummy varchar(20)        
        
set @dummy = ''        
        
SELECT         
 @yco_conam = yco_conam,         
 @yco_addr = yco_addr,        
 @yco_logoimgpth = yco_logoimgpth,         
 @yco_phoneno = yco_phoneno,        
 @yco_faxno = yco_faxno         
FROM        
 SYCOMINF  (nolock)      
WHERE        
 YCO_COCDE = @cocde        
---------------------------------------------        
        
DECLARE        
@batno  nvarchar(20),        
@batseq  nvarchar(4)        
        
SET @batno = left(@batch,9)        
SET @batseq = right(@batch,4)        
        
CREATE TABLE #tmpjob (        
tmp_cocde nvarchar(6) not null,        
tmp_jobord nvarchar(20) not null,        
tmp_shpdtl nvarchar(2000) null,        
tmp_ctndtl nvarchar(1000) null,        
tmp_Assort ntext null,        
tmp_shpdtl2 ntext null,        
tmp_ctndtl2 ntext null)  on [PRIMARY]        
      
--==============================      
-- Lester Wu 2007-05-15      
--==============================      
declare       
 @pjd_zutyp varchar(20)     
-- Added by Mark Lau 2009125
 declare       
 @pjd_upd_rea varchar(255)   
      
set @pjd_zutyp = ''  
-- Added by Mark Lau 2009125
set @pjd_upd_rea = ''    
      
select @pjd_zutyp = pjd_zutyp       
-- Added by Mark Lau 2009125
,@pjd_upd_rea=pjd_upd_rea
FROM POJBBDTL  (nolock)      
WHERE pjd_cocde = @cocde        
AND pjd_batno = @batno        
AND pjd_batseq = @batseq        
AND  PJd_confrm = 'Y'        
--==============================      
      
Declare        
@pjd_jobord nvarchar(20)        




-- 1. cur_SHPDTL
declare @cur_SHPDTL_count int
declare @cur_SHPDTL_count_start int = 0
declare @cur_SHPDTL_i int =1
declare @cur_SHPDTL nvarchar(20)


declare @TMP_cur_SHPDTL table (
cur_SHPDTL_sno	int identity(1,1),
tmp_cur_SHPDTL_1 nvarchar(100),
tmp_cur_SHPDTL_2 nvarchar(4000)
)

-- 2. cur_CTNDTL
declare @cur_CTNDTL_count int
declare @cur_CTNDTL_count_start int = 0
declare @cur_CTNDTL_i int =1
declare @cur_CTNDTL nvarchar(20)


declare @TMP_cur_CTNDTL table (
cur_CTNDTL_sno	int identity(1,1),
tmp_cur_CTNDTL_1 nvarchar(100),
tmp_cur_CTNDTL_2 nvarchar(4000)
)



      
DECLARE cur_batno CURSOR        
FOR        
SELECT pjd_jobord        
FROM POJBBDTL  (nolock)      
WHERE pjd_cocde = @cocde        
AND pjd_batno = @batno        
AND pjd_batseq = @batseq        
AND  PJd_confrm = 'Y'
        
OPEN cur_batno        
FETCH NEXT FROM cur_batno INTO        
@pjd_jobord        
        
WHILE @@fetch_status = 0        
BEGIN        
      
 Declare        
 @StrDetail  nvarchar(100),         
 @StrDetail2 nvarchar(4000),         
 @StrShpDtl nvarchar(4000),        
 @StrCtnDtl nvarchar(4000),        
 @StrShpDtl2 nvarchar(4000),         
 @StrCtnDtl2 nvarchar(4000)         
        
------------------------------------------------------------------------------------------------------------------------------------        
 -- Cursor to get Shipment Detail        
        
insert into @TMP_cur_SHPDTL       
 SELECT         
  Case pds_from when pds_to         
  then         
	replace(convert(char(10), pds_from, 121),'-','') + ' (' + replace(convert(char(10), pds_from - 14, 121),'-','') + ')' + right('       ' +  ysi_dsc,7) +  str(pds_ordqty,7,0)
  Else         
	replace(convert(char(10), pds_from, 121),'-','') + ' (' + replace(convert(char(10), pds_from - 14, 121),'-','') + ')' + right('       ' +  ysi_dsc,7) +  str(pds_ordqty,7,0)
  end,        
        
  Case pds_from when pds_to         
  then         
   '<SubShpDtl>' +         
   '<pod_shpstr>' + replace(convert(char(10), pds_from, 121),'-','') + '</pod_shpstr>'  +         
   '<pod_shpend>' + replace(convert(char(10), pds_to, 121),'-','') + '</pod_shpend>'  +         
   '<ysi_dsc>' + ysi_dsc + '</ysi_dsc>' +        
   '<pod_ordqty>' +  ltrim(rtrim(str(pds_ordqty,7,0))) + '</pod_ordqty>' +    
   '</SubShpDtl>'          
  Else         
   '<SubShpDtl>' +         
   '<pod_shpstr>' + replace(convert(char(10), pds_from, 121),'-','') + '</pod_shpstr>' +         
   '<pod_shpend>' + replace(convert(char(10), pds_to, 121),'-','') + '</pod_shpend>' +         
   '<ysi_dsc>' +  ysi_dsc + '</ysi_dsc>' +         
   '<pod_ordqty>' + ltrim(rtrim(str(pds_ordqty,7,0))) + '</pod_ordqty>' +        
   '</SubShpDtl>'          
  end        
        
 FROM PODTLSHP (nolock), POORDDTL (nolock), SYSETINF  (nolock)      
 WHERE          
  pod_untcde = ysi_cde and ysi_typ = '05'        
 AND pds_purord = pod_purord and pds_seq = pod_purseq        
 AND  pds_cocde = @cocde and pod_jobord = @pjd_jobord        
 --ORDER BY        
  --replace(convert(char(10), pds_from, 121),'-','')        
  order by pds_purord, pds_seq, pds_shpseq

 SET @StrDetail = ''        
 SET @StrDetail2 = ''    

 SET @StrShpDtl = ''        
 SET @StrShpDtl2 = '' 
        
select @cur_SHPDTL_count = count(cur_SHPDTL_sno) from @TMP_cur_SHPDTL while (@cur_SHPDTL_i <= @cur_SHPDTL_count)
begin
  select @StrDetail = tmp_cur_SHPDTL_1, @StrDetail2 = tmp_cur_SHPDTL_2  from @TMP_cur_SHPDTL where cur_SHPDTL_sno = @cur_SHPDTL_i + @cur_SHPDTL_count_start

  SET @StrShpDtl = @StrShpDtl + @StrDetail + char(10)        
  SET @StrShpDtl2 = @StrShpDtl2 + @StrDetail2   

  select @cur_SHPDTL_i = @cur_SHPDTL_i + 1
end

------------------------------------------------------------------------------------------------------------------------------------        
        
 IF @StrShpDtl = ''        
  BEGIN        
   Select @StrShpDtl = Case pod_shpstr when pod_shpend         
      then         
	replace(convert(char(10), pod_shpstr, 121),'-','') + ' (' + replace(convert(char(10), pod_shpstr - 14, 121),'-','') + ')' + right('       ' +  ysi_dsc,7) +  str(pod_ordqty,7,0)
      Else         
	replace(convert(char(10), pod_shpstr, 121),'-','') + ' (' + replace(convert(char(10), pod_shpstr - 14, 121),'-','') + ')' + right('       ' +  ysi_dsc,7) +  str(pod_ordqty,7,0)
      End,        
         
    @StrShpDtl2 = Case pod_shpstr when pod_shpend         
      then         
       '<SubShpDtl>' +         
       '<pod_shpstr>' + replace(convert(char(10), pod_shpstr, 121),'-','')  + '</pod_shpstr>' +         
       '<pod_shpend>' + replace(convert(char(10), pod_shpend, 121),'-','')  + '</pod_shpend>' +         
       '<ysi_dsc>' + ysi_dsc + '</ysi_dsc>' +         
       '<pod_ordqty>' + ltrim(rtrim( str(pod_ordqty,7,0))) + '</pod_ordqty>' +        
       '</SubShpDtl>'          
      Else         
       '<SubShpDtl>' +         
       '<pod_shpstr>' + replace(convert(char(10), pod_shpstr, 121),'-','')  + '</pod_shpstr>' +         
       '<pod_shpend>' + replace(convert(char(10), pod_shpend, 121),'-','')  + '</pod_shpend>' +         
       '<ysi_dsc>' +  ysi_dsc + '</ysi_dsc>' +         
       '<pod_ordqty>' + ltrim(rtrim(str(pod_ordqty,7,0)))  + '</pod_ordqty>' +         
       '</SubShpDtl>'          
      end        
         
   FROM POORDDTL (nolock), SYSETINF  (nolock)      
   WHERE pod_untcde = ysi_cde and ysi_typ = '05'        
   AND pod_cocde = @cocde and pod_jobord = @pjd_jobord        
   ORDER BY         
    replace(convert(char(10), pod_shpstr, 121),'-','')        
  END        
 ELSE        
  BEGIN        
   SET @StrShpDtl = LEFT(@StrShpDtl, LEN(@StrShpDtl) - 1)        
  END        
        
 INSERT INTO         
  #tmpjob         
   (tmp_cocde, tmp_jobord, tmp_shpdtl, tmp_ctndtl, tmp_shpdtl2, tmp_ctndtl2)        
  values         
   (@cocde, @pjd_jobord, @strShpDtl, '', @strShpDtl2, '' )        
 


insert into @TMP_cur_CTNDTL       
 SELECT         
  str(pds_ctnstr,6,0) + ' - ' + str(pds_ctnend,6,0) + ' (' + ltrim(str(pds_ttlctn,5,0)) + ')',        
  -- Generate XML ---        
  '<SubCtnNo>' +         
  '<pod_ctnstr>' + ltrim(rtrim(str(pds_ctnstr,6,0))) + '</pod_ctnstr>' +        
  '<pod_ctnend>' +  ltrim(rtrim(str(pds_ctnend,6,0))) + '</pod_ctnend>' +        
  '<pod_subttlctn>' + '(' + rtrim(ltrim(str(pds_ttlctn,5,0))) + ')' + '</pod_subttlctn>' +    
  '<pds_dest>' + rtrim(ltrim(pds_dest)) + '</pds_dest>' +    
  '<pds_rmk>' + '' + '</pds_rmk>' +    
  '</SubCtnNo>'         
  ------------------------        
        
 FROM  PODTLSHP (nolock), POORDDTL  (nolock)      
 WHERE  pod_cocde = pds_cocde and pod_purord = pds_purord and pod_purseq = pds_seq        
 AND pds_cocde = @cocde and pod_jobord = @pjd_jobord        
-- ORDER BY        
  --str(pds_ctnstr,7,0)        
  order by pds_purord, pds_seq, pds_shpseq



 SET @StrDetail = ''        
 SET @StrDetail2 = ''    

 SET @StrCtnDtl = ''        
 SET @StrCtnDtl2 = '' 
        
select @cur_CTNDTL_count = count(cur_CTNDTL_sno) from @TMP_cur_CTNDTL while (@cur_CTNDTL_i <= @cur_CTNDTL_count)
begin
  select @StrDetail = tmp_cur_CTNDTL_1, @StrDetail2 = tmp_cur_CTNDTL_2  from @TMP_cur_CTNDTL where cur_CTNDTL_sno = @cur_CTNDTL_i + @cur_CTNDTL_count_start

  SET @StrCtnDtl = @StrCtnDtl + @StrDetail + char(10)        
  SET @StrCtnDtl2 = @StrCtnDtl2 + @StrDetail2 

  select @cur_CTNDTL_i = @cur_CTNDTL_i + 1
end
        
       
 IF @StrCtnDtl = ''        
 BEGIN        
  SELECT         
   @StrCtnDtl = str(pod_ctnstr,6,0) + ' - ' + str(pod_ctnend,6,0)+ ' (' + ltrim(str(pod_ttlctn,5,0)) + ')',        
   --- Generate XML ---        
   @StrCtnDtl2 =         
    '<SubCtnNo>' +         
    '<pod_ctnstr>' + ltrim(rtrim(str(pod_ctnstr,6,0)))  + '</pod_ctnstr>' +        
    '<pod_ctnend>' + ltrim(rtrim(str(pod_ctnend,6,0)))  + '</pod_ctnend>' +        
    '<pod_subttlctn>' + '(' + rtrim(ltrim(str(pod_ttlctn,5,0))) + ')' + '</pod_subttlctn>' +        
	'<pds_dest>' + '' + '</pds_dest>' +    
	'<pds_rmk>' + '' + '</pds_rmk>' +    
    '</SubCtnNo>'         
   --------------------------        
        
  FROM POORDDTL  (nolock)      
  WHERE pod_cocde = @cocde and pod_jobord = @pjd_jobord        
  ORDER BY        
   str(pod_ctnstr,7,0)        
 
 END        
 ELSE        
 BEGIN        
  SET @StrCtnDtl = LEFT(@StrCtnDtl, LEN(@StrCtnDtl) - 1)        
 END        
        
 UPDATE         
  #tmpjob         
 SET         
  tmp_ctndtl = @StrCtnDtl,        
  tmp_ctndtl2 = @StrCtnDtl2        
 WHERE         
  tmp_cocde = @cocde        
 AND tmp_jobord = @pjd_jobord        
      
 FETCH NEXT FROM cur_batno INTO        
 @pjd_jobord        
END        
CLOSE cur_batno        
DEALLOCATE cur_batno        
        
        
Declare @nCountAss int        
Select @nCountAss = count(*) from PODTLASS (nolock), POORDDTL (nolock), #tmpjob  (nolock)      
Where  pod_cocde = pda_cocde and pod_purord = pda_purord and pod_purseq = pda_seq        
and pod_jobord = tmp_jobord  and pod_cocde = tmp_cocde        
        
Set @nCountAss = @nCountAss * 4 + 3        
        
select         
 @cocde as '@cocde',        
 'X' as '@yco_conam',        
 'X' as '@yco_addr',        
 'X' as '@yco_logoimgpth',        
 'X' as '@yco_phoneno',        
 'X' as '@yco_faxno',        
 @batch as '@batch',        
 aa.vbi_vennam as 'vbi_vennam', aa.vbi_vensna as 'vbi_vensna',        
 bb.vbi_vennam as 'prd_vennam', bb.vbi_vensna as 'prd_vensna',        
 pri.cbi_cussna,         
 poh_porctp,  poh_prmcus, poh_venno,        
 poh_credat = ltrim(str(datepart(mm, poh_credat))) + '/' + ltrim(str(datepart(dd, poh_credat))) + '/' + ltrim(str(datepart(yyyy, poh_credat))),        
 poh_issdat = ltrim(str(datepart(mm, poh_issdat))) + '/' + ltrim(str(datepart(dd, poh_issdat))) + '/' + ltrim(str(datepart(yyyy, poh_issdat))),        
 poh_pocdat = ltrim(str(datepart(mm, poh_pocdat))) + '/' + ltrim(str(datepart(dd, poh_pocdat))) + '/' + ltrim(str(datepart(yyyy, poh_pocdat))),        
 poh_cuspno,  poh_reppno,         
 poh_purord,  poh_curcde,        
@STRDUMMY  as 'poh_rmk' ,       
@STRDUMMY as 'poh_rmk_Memo' ,       
 pod_typcode, pod_cuscol,         
 pod_scno,  pod_itmno, pod_venitm,          
@STRDUMMY as pod_engdsc, @STRDUMMY  as pod_engdsc_Memo  , --pod_engdsc,        
@STRDUMMY as pod_chndsc, @STRDUMMY  as pod_chndsc_Memo  , --pod_chndsc,        
 pod_inrctn,         
 pod_mtrctn, pod_cubcft,         
@STRDUMMY as 'pod_rmk',       
@STRDUMMY as 'pod_rmk_Memo',         
 pod_jobord, pod_cusitm, pod_cussku,        
 pod_code1,  pod_code2,  pod_code3,        
 pod_hrmcde, pod_cususd,  pod_cuscad,        
 pod_vencol,         
 pod_coldsc, pod_coldsc_Memo = 'X' , -- pod_coldsc,        
 pod_purseq,        
 pod_key = pod_itmno + ltrim(pod_engdsc) +  ysi_dsc + str(pod_inrctn,10,0) + str(pod_mtrctn,10,0) + str(pod_cubcft,10,2),        
 pod_ctnstr,  pod_ctnend, pod_ttlctn = str(pod_ttlctn),        
 pod_shpstr = ltrim(str(datepart(mm, pod_shpstr))) + '/' + ltrim(str(datepart(dd, pod_shpstr))) + '/' + ltrim(str(datepart(yyyy, pod_shpstr))),         
 pod_shpend = ltrim(str(datepart(mm, pod_shpstr))) + '/' + ltrim(str(datepart(dd, pod_shpstr))) + '/' + ltrim(str(datepart(yyyy, pod_shpstr))),         
 pod_untcde,        
 pod_ordqty, pod_pckitr,        
 pod_prdven,        
 pod_prdsubcde,        
 pod_seccusitm,        
case when sod_dvftyprc > 0 then sod_dvftyprc else sod_ftyprc end as 'pod_ftyprc',

@STRDUMMY as  MainMrk ,@STRDUMMY as InnerMrk ,@STRDUMMY as SideMrk ,        
@STRDUMMY as MainEng  , -- Case isNull(mrk1.psm_engdsc, '') When '' then '' Else '?' + replace(mrk1.psm_engdsc, char(13)+char(10), char(13)+char(10)+ '?') end,        
@STRDUMMY as InnerEng , --  Case isNull(mrk2.psm_engdsc, '') When '' then '' Else '?' + replace(mrk2.psm_engdsc, char(13)+char(10), char(13)+char(10)+ '?') end,        
@STRDUMMY as SideEng  , --  Case isNull(mrk3.psm_engdsc, '') When '' then '' Else  '?' + replace(mrk3.psm_engdsc, char(13)+char(10), char(13)+char(10)+ '?') end,        

@STRDUMMY as MainEng_Memo  ,       
@STRDUMMY as InnerEng_Memo  ,       
@STRDUMMY as SideEng_Memo  ,       
       
@STRDUMMY as MainChn  , --  Case isNull(mrk1.psm_chndsc, '') When '' then '' Else '?' + replace(mrk1.psm_chndsc, char(13)+char(10), char(13)+char(10)+ '?') end,        
@STRDUMMY as InnerChn  , --  Case isNull(mrk2.psm_chndsc, '') When '' then '' Else '?' + replace(mrk2.psm_chndsc, char(13)+char(10), char(13)+char(10)+ '?') end,        
@STRDUMMY as SideChn  , --  Case isNull(mrk3.psm_chndsc, '') When '' then '' Else  '?' + replace(mrk3.psm_chndsc, char(13)+char(10), char(13)+char(10)+ '?') end,        
      
@STRDUMMY as MainChn_Memo  ,       

@STRDUMMY as InnerChn_Memo  ,       
@STRDUMMY as SideChn_Memo  ,       
        
@STRDUMMY as MainChnRmk ,@STRDUMMY as InnerChnRmk  ,@STRDUMMY as SideChnRmk ,       
@STRDUMMY as MainEngRmk , @STRDUMMY as InnerEngRmk  , @STRDUMMY  as SideEngRmk  ,       

poh_venno as '@poh_venno',        
isnull(ysr_dsc,'') as 'ysr_dsc',        
sod_subcde,        
pod_dept,        
pod_dtyrat,        
tmp_shpdtl,        
tmp_ctndtl,        
tmp_Assort,        
RmkLen = @nCountAss + 2 + len(isnull(sod_pjobno,'') + pod_rmk)/30 +        
Case when (len(poh_rmk) - len(replace(poh_rmk, char(13), ''))+1> len(poh_rmk)/80)then        
len(poh_rmk) - len(replace(poh_rmk, char(13), ''))+1 else        
len(poh_rmk)/80 end +         
Case when (len(mrk1.psm_engrmk) - len(replace(mrk1.psm_engrmk, char(13), ''))+1> len(mrk1.psm_engrmk)/80)then        
len(mrk1.psm_engrmk) - len(replace(mrk1.psm_engrmk, char(13), ''))+1 else        
len(mrk1.psm_engrmk)/80 end +         
Case when (len(mrk1.psm_chnrmk) - len(replace(mrk1.psm_chnrmk, char(13), ''))+1 > len(mrk1.psm_chnrmk)/80) then        
len(mrk1.psm_chnrmk) - len(replace(mrk1.psm_chnrmk, char(13), ''))+1 else        
len(mrk1.psm_chnrmk)/80 end,        
poh_cpodat,        

tmp_shpdtl2,        
tmp_ctndtl2,        
pod_runno,        
pod_cuspno ,         
pod_alsitmno ,         
pod_alscolcde,        
poh_seccus ,         
@dummy as 'ipi_sappckid',        
soh_zshpcusno as 'soh_zshpcusno' ,         
'3041' as 'ipt_plant',
isnull(yum_msehi,'') as 'yum_msehi',        
isnull(yum_zaehl,-1) as 'yum_zaehl',        
datediff(day, pod_shpstr, pod_shpend) as 'zdlvblk',        
isnull(sod_ztnvbeln,'') as 'sod_ztnvbeln',        
isnull(sod_ztnposnr,'') as 'sod_ztnposnr',        
isnull(sod_zorvbeln,'') as 'sod_zorvbeln',        
isnull(sod_zorposnr,'') as 'sod_zorposnr',        
isnull(pod_respno,'') as 'sod_resppo'  ,       
isnull(@pjd_zutyp,'') as 'ZUTYPE'       ,
isnull(sod_dv,'')  as 'sod_dv',
isnull(sod_dvftycst,0)  as 'sod_dvftycst',
isnull(sod_dvftyprc,0)  as 'sod_dvftyprc',
isnull(sod_dvbomcst,0)  as 'sod_dvbomcst' ,
isnull(sod_dvfcurcde ,'')  as 'sod_dvfcurcde',
isnull(sod_itmcstcur,'')  as 'sod_itmcstcur',
isnull(sod_dvitmcst,0)  as 'sod_dvitmcst',
replace(replace(convert(char(10), isnull(sod_qutdat,'1900-01-01'), 121),'-',''), '19000101', '')  as 'sod_imqutdat',
replace(replace(convert(char(10), isnull(sod_imqutdat,'1900-01-01'), 121),'-',''),'19000101', '')  as 'sod_qutdat',
isnull(sod_dvftyunt ,'')  as 'sod_dvftyunt',
isnull(soh_rplmnt,'') as 'soh_rplmnt',
isnull(sod_cusven,'') as 'sod_cusven',
isnull( sec.cbi_cussna,'') as 'seccussna',    
sod_ordseq,
sod_cbm,
isnull(sod_conftr,1) as 'sod_conftr',
isnull(sod_colcde ,'') as 'sod_colcde', 
isnull(sod_coldsc ,'') as 'sod_coldsc',       
cast(sod_ordqty * isnull(ycf_value,1) * isnull(sod_conftr,1) as int) as 'PCQty', 
sod_ttlctn,
replace(convert(char(10), isnull(pod_shpstr,'1900-01-01'), 121),'-','') as 'shpstr',
replace(isnull(@pjd_upd_rea,''),'/',',') as 'reason',
sod_tordno, 
case sod_tordseq when 0 then '' else convert(varchar(10), sod_tordseq) end as 'sod_tordseq'
into #tmp_PDO_SAP        
From         
#tmpjob (nolock)
left join POORDDTL (nolock) on pod_jobord = tmp_jobord and pod_cocde = tmp_cocde        
left join POORDHDR (nolock) on poh_cocde = pod_cocde and poh_purord = pod_purord
left join SCORDDTL (nolock) on pod_cocde = sod_cocde and pod_scno = sod_ordno and pod_scline = sod_ordseq
left join SCORDHDR (nolock) on sod_cocde = soh_cocde and sod_ordno = soh_ordno
left join VNBASINF aa (nolock) on poh_venno = aa.vbi_venno
left join VNBASINF bb (nolock) on pod_prdven = bb.vbi_venno
left join CUBASINF pri (nolock) on poh_prmcus = pri.cbi_cusno
left join CUBASINF sec (nolock) on poh_seccus = sec.cbi_cusno
left join SYSETINF (nolock) on pod_untcde = ysi_cde and ysi_typ = '05'        
left join SYSALREP (nolock) on poh_porctp = ysr_code        
left join IMPNTINF (nolock) on pod_itmno = ipt_itmno        
left join SYUM (nolock) on pod_untcde = yum_msehte
left join SYCONFTR (nolock) on pod_untcde = ycf_code1
left join POSHPMRK mrk1 (nolock) on poh_cocde = mrk1.psm_cocde and poh_purord = mrk1.psm_purord and mrk1.psm_shptyp = 'M'
left join POSHPMRK mrk2 (nolock) on poh_cocde = mrk2.psm_cocde and poh_purord = mrk2.psm_purord and mrk2.psm_shptyp = 'I'
left join POSHPMRK mrk3 (nolock) on poh_cocde = mrk3.psm_cocde and poh_purord = mrk3.psm_purord and mrk3.psm_shptyp = 'S'
WHERE         
pod_cocde is not null and
sod_cocde is not null





        
if @img = 'Y'        
begin        
 --=============================================================================================        
 select pod_scno , pod_scline, pod_purord, pod_purseq, pod_jobord        
 into #tmp_PO        
 from POORDDTL dtl (nolock)      
 where pod_jobord in (        
  select pod_jobord from #tmp_PDO_SAP  (nolock)      
 )        
         
 --=============================================================================================-- sp_help POORDHDR        

 delete SAPPOHDR  from SAPPOHDR , #tmp_po tmp         
 where  poh_purord = tmp.pod_purord        
         
 insert into SAPPOHDR         
 (poh_cocde,poh_purord,poh_pursts,poh_issdat,poh_venno,poh_puradr,poh_purstt,poh_purcty,poh_purpst,poh_porctp,        
 poh_puragt,poh_salrep,poh_prmcus,poh_seccus,poh_shpadr,poh_shpstt,poh_shpcty,poh_shppst,poh_prctrm,poh_paytrm,poh_ttlcbm,poh_ttlctn,        
 poh_curcde,poh_ttlamt,poh_discnt,poh_netamt,poh_spoflg,poh_cuspno,poh_cpodat,poh_reppno,poh_pocdat,poh_shpstr,poh_shpend,poh_lbldue,        
 poh_lblven,poh_subcde,poh_rmk,poh_ordno,poh_creusr,poh_updusr,poh_credat,poh_upddat        
 )        
 select         
 poh_cocde,poh_purord,poh_pursts,poh_issdat,poh_venno,poh_puradr,poh_purstt,poh_purcty,poh_purpst,poh_porctp,        
 poh_puragt,poh_salrep,poh_prmcus,poh_seccus,poh_shpadr,poh_shpstt,poh_shpcty,poh_shppst,poh_prctrm,poh_paytrm,poh_ttlcbm,poh_ttlctn,        
 poh_curcde,poh_ttlamt,poh_discnt,poh_netamt,poh_spoflg,poh_cuspno,poh_cpodat,poh_reppno,poh_pocdat,poh_shpstr,poh_shpend,poh_lbldue,        
 poh_lblven,poh_subcde,
case poh_cusctn when 0 then '' else 'TOTAL CTN# - ' + ltrim(rtrim(str(poh_cusctn))) + char(10) + char(13) end 
+ case poh_dest when '' then '' else 'DESTINATION: ' + ltrim(rtrim(poh_dest)) + char(10) + char(13) end + poh_rmk
,poh_ordno,'PDOSAP',poh_updusr,getdate(),poh_upddat         
 from         
 POORDHDR (nolock) , #tmp_po tmp   (nolock)      
 where  poh_purord = tmp.pod_purord        
         
 --=============================================================================================-- sp_help POORDDTL        
 delete SAPPODTL from SAPPODTL dtl , #tmp_PO tmp        
 where dtl.pod_purord = tmp.pod_purord and dtl.pod_purseq = tmp.pod_purseq        
         
 insert into SAPPODTL (pod_cocde,pod_purord,pod_purseq,pod_prdven,pod_prdsubcde,pod_itmno,pod_itmsts,pod_seccusitm,pod_venitm,pod_cusitm,pod_cussku,        
 pod_engdsc,pod_chndsc,pod_vencol,pod_cuscol,pod_coldsc,pod_pckseq,pod_untcde,pod_inrctn,pod_mtrctn,pod_cubcft,pod_cbm,pod_dept,pod_ordqty,        
 pod_recqty,pod_ftyprc,pod_cuspno,pod_respno,pod_hrmcde,pod_lblcde,pod_cususd,pod_cuscad,pod_shpstr,pod_shpend,pod_candat,pod_ctnstr,pod_ctnend,        
 pod_scno,pod_ttlctn,pod_lneamt,pod_lnecub,pod_ttlqty,pod_scline,pod_jobord,pod_runno,pod_assflg,pod_dtyrat,pod_typcode,pod_code1,pod_code2,pod_code3,        
 pod_rmk,pod_pckitr,pod_alsitmno,pod_alscolcde,
 pod_ftyprctrm,
 pod_hkprctrm,
 pod_trantrm,
 pod_creusr,pod_updusr,pod_credat,pod_upddat        
 )        
 select          
 pod_cocde,dtl.pod_purord,dtl.pod_purseq,pod_prdven,pod_prdsubcde,pod_itmno,pod_itmsts,pod_seccusitm,pod_venitm,pod_cusitm,pod_cussku,        
 pod_engdsc,pod_chndsc,pod_vencol,pod_cuscol,pod_coldsc,pod_pckseq,pod_untcde,pod_inrctn,pod_mtrctn,pod_cubcft,pod_cbm,pod_dept,pod_ordqty,        
 pod_recqty,pod_ftyprc,pod_cuspno,pod_respno,pod_hrmcde,pod_lblcde,pod_cususd,pod_cuscad,pod_shpstr,pod_shpend,pod_candat,pod_ctnstr,pod_ctnend,        
 dtl.pod_scno,pod_ttlctn,pod_lneamt,pod_lnecub,pod_ttlqty,dtl.pod_scline,dtl.pod_jobord,pod_runno,pod_assflg,pod_dtyrat,pod_typcode,pod_code1,pod_code2,pod_code3,        
 pod_rmk,pod_pckitr,pod_alsitmno,pod_alscolcde,
 pod_ftyprctrm,
 pod_hkprctrm,
 pod_trantrm,
 'PDOSAP',pod_updusr,getdate(),pod_upddat        
 from POORDDTL dtl (nolock), #tmp_PO tmp  (nolock)      
 where dtl.pod_purord = tmp.pod_purord and dtl.pod_purseq = tmp.pod_purseq        
         
 --=============================================================================================-- sp_help SCORDHDR        
 delete SAPSCHDR        
 from SAPSCHDR , #tmp_PO tmp        
 where soh_ordno = tmp.pod_scno        
         
 insert into SAPSCHDR        
 (        
 soh_cocde,soh_ordno,soh_verno,soh_smpsc,soh_canflg,soh_clsout,soh_rplmnt,soh_issdat,soh_rvsdat,soh_ordsts,soh_cus1no,soh_cus2no,soh_biladr,soh_bilstt,soh_bilcty,        
 soh_bilzip,soh_zshpcusno,soh_shpadr,soh_shpstt,soh_shpcty,soh_shpzip,soh_cttper,soh_salrep,soh_agt,soh_prctrm,soh_paytrm,soh_sfigtrm,soh_sprdtrm,soh_resppo,soh_ttlvol,        
 soh_cft,soh_curcde,soh_ttlctn,soh_ttlamt,soh_netamt,soh_rmk,soh_cuspo,soh_cpodat,soh_shpstr,soh_shpend,soh_candat,soh_lbldue,soh_lblven,soh_creusr,soh_updusr,        
 soh_credat,soh_upddat
        
 )        
 select         
 soh_cocde,soh_ordno,soh_verno,soh_smpsc,soh_canflg,soh_clsout,soh_rplmnt,soh_issdat,soh_rvsdat,soh_ordsts,soh_cus1no,soh_cus2no,soh_biladr,soh_bilstt,soh_bilcty,        
 soh_bilzip,soh_zshpcusno,soh_shpadr,soh_shpstt,soh_shpcty,soh_shpzip,soh_cttper,soh_salrep,soh_agt,soh_prctrm,soh_paytrm,soh_sfigtrm,soh_sprdtrm,soh_resppo,soh_ttlvol,        
 soh_cft,soh_curcde,soh_ttlctn,soh_ttlamt,soh_netamt,soh_rmk,soh_cuspo,soh_cpodat,soh_shpstr,soh_shpend,soh_candat,soh_lbldue,soh_lblven,'PDOSAP',soh_updusr,        
 getdate(),soh_upddat 
 from SCORDHDR(nolock) , #tmp_PO tmp  (nolock)      
 where soh_ordno = tmp.pod_scno        
         
 --=============================================================================================-- sp_help SCORDDTL        
 delete SAPSCDTL from SAPSCDTL , #tmp_PO tmp        
 where sod_ordno = tmp.pod_scno and sod_ordseq = pod_scline        
         
 insert into SAPSCDTL        
 (        
 sod_cocde,sod_ordno,sod_ordseq,sod_updpo,sod_chgfty,sod_itmno,sod_itmsts,sod_itmtyp,sod_itmdsc,sod_colcde,sod_cuscol,sod_coldsc,sod_pckseq,sod_pckunt,        
 sod_inrctn,sod_mtrctn,sod_cft,sod_cbm,sod_qutno,sod_refdat,sod_cusitm,sod_cussku,sod_resppo,sod_cuspo,sod_ordqty,sod_discnt,sod_orgmoqchg,sod_moqchg,        
 sod_oneprc,sod_curcde,sod_untprc,sod_netuntprc,sod_selprc,sod_hrmcde,sod_dtyrat,sod_dept,sod_typcode,sod_code1,sod_code2,sod_code3,sod_cususd,sod_cuscad,        
 sod_inrdin,sod_inrwin,sod_inrhin,sod_mtrdin,sod_mtrwin,sod_mtrhin,sod_inrdcm,sod_inrwcm,sod_inrhcm,sod_mtrdcm,sod_mtrwcm,sod_mtrhcm,sod_shpstr,sod_shpend,        
 sod_candat,sod_ctnstr,sod_ctnend,sod_ttlctn,sod_rmk,sod_invqty,sod_shpqty,sod_venno,sod_oldven,sod_purord,sod_purseq,sod_oldpurord,sod_oldpurseq,sod_ftycst,        
 sod_ftyprc,sod_bomcst,sod_fcurcde,sod_ftyunt,sod_venitm,sod_itmprc,sod_subcde,sod_moq,sod_moa,sod_apprve,sod_clmno,sod_pckitr,sod_orgvenno,sod_assitmcount,        
 sod_cusmoqchg,sod_venmoqchg,sod_runno,sod_fmlopt,sod_fml,sod_mubasprc,sod_cusven,sod_cussub,sod_pjobno,sod_seccusitm,sod_alsitmno,sod_alscolcde,        
 sod_ztnvbeln,sod_ztnposnr,sod_zorvbeln,sod_zorposnr,sod_creusr,sod_updusr,sod_credat,sod_upddat ,
-- Added by Mark Lau 20090310
sod_conftr,
sod_contopc,
sod_pcprc,
sod_custum,
sod_dv,
sod_dvftycst,
sod_dvftyprc,
sod_dvbomcst,
sod_dvfcurcde,
sod_dvftyunt,
sod_cusstyno,
-- Added by Joe 20110113
sod_itmcstcur,
sod_dvitmcst,
sod_imqutdat,
sod_qutdat,
sod_ftyprctrm,
sod_hkprctrm,
sod_trantrm,
sod_tordno,
sod_tordseq
 )        
 select         
 sod_cocde,sod_ordno,sod_ordseq,sod_updpo,sod_chgfty,sod_itmno,sod_itmsts,sod_itmtyp,sod_itmdsc,sod_colcde,sod_cuscol,sod_coldsc,sod_pckseq,sod_pckunt,        
 sod_inrctn,sod_mtrctn,sod_cft,sod_cbm,sod_qutno,sod_refdat,sod_cusitm,sod_cussku,sod_resppo,sod_cuspo,sod_ordqty,sod_discnt,sod_orgmoqchg,sod_moqchg,        
 sod_oneprc,sod_curcde,sod_untprc,sod_netuntprc,sod_selprc,sod_hrmcde,sod_dtyrat,sod_dept,sod_typcode,sod_code1,sod_code2,sod_code3,sod_cususd,sod_cuscad,        
 sod_inrdin,sod_inrwin,sod_inrhin,sod_mtrdin,sod_mtrwin,sod_mtrhin,sod_inrdcm,sod_inrwcm,sod_inrhcm,sod_mtrdcm,sod_mtrwcm,sod_mtrhcm,sod_shpstr,sod_shpend,        
 sod_candat,sod_ctnstr,sod_ctnend,sod_ttlctn,sod_rmk,sod_invqty,sod_shpqty,sod_venno,sod_oldven,sod_purord,sod_purseq,sod_oldpurord,sod_oldpurseq,sod_ftycst,        
 sod_ftyprc,sod_bomcst,sod_fcurcde,sod_ftyunt,sod_venitm,sod_itmprc,sod_subcde,sod_moq,sod_moa,sod_apprve,sod_clmno,sod_pckitr,sod_orgvenno,sod_assitmcount,        
 sod_cusmoqchg,sod_venmoqchg,sod_runno,sod_fmlopt,sod_fml,sod_mubasprc,sod_cusven,sod_cussub,sod_pjobno,sod_seccusitm,sod_alsitmno,sod_alscolcde,        
 sod_ztnvbeln,sod_ztnposnr,sod_zorvbeln,sod_zorposnr,'PDOSAP',sod_updusr,getdate(),sod_upddat,
-- Added by Mark Lau 20090310
sod_conftr,
sod_contopc,
sod_pcprc,
sod_custum,
sod_dv,
sod_dvftycst,
sod_dvftyprc,
sod_dvbomcst,
sod_dvfcurcde,
sod_dvftyunt,
sod_cusstyno,
-- Added by Joe 20110113
sod_itmcstcur,
sod_dvitmcst,
--sod_imqutdat,
-- changed by mc 20131030
sod_qutdat,
sod_qutdat,
sod_ftyprctrm,
sod_hkprctrm,
sod_trantrm,
sod_tordno,
sod_tordseq
 from SCORDDTL(nolock) , #tmp_PO tmp  (nolock)      
 where sod_ordno = tmp.pod_scno and sod_ordseq = pod_scline        
         
 --=============================================================================================-- sp_help POSHPMRK        
         
 delete SAPSHPMRK from SAPSHPMRK, #tmp_PO tmp        
 where psm_purord = tmp.pod_purord --and psm_shptyp in ( 'M', 'I', 'S' )        
         
 insert into SAPSHPMRK        
 (        
 psm_cocde,psm_purord,psm_shptyp,psm_engdsc,psm_chndsc,psm_engrmk,psm_chnrmk,psm_imgpth,psm_imgnam,psm_creusr,psm_updusr,psm_credat,psm_upddat        
 )        
 select psm_cocde,psm_purord,psm_shptyp,psm_engdsc,psm_chndsc,psm_engrmk,psm_chnrmk,psm_imgpth,psm_imgnam,'PDOSAP',psm_updusr,getdate(),psm_upddat        
 from POSHPMRK(nolock), #tmp_PO tmp  (nolock)      
 where psm_purord = tmp.pod_purord --and psm_shptyp in ( 'M', 'I', 'S' )        
         
 --=============================================================================================-- sp_help PODTLCTN         
       
 delete SAPDTLCTN from SAPDTLCTN , #tmp_PO tmp        
 where pdc_purord = tmp.pod_purord and pdc_seq = tmp.pod_purseq        

 insert into SAPDTLCTN        
 (        
 pdc_cocde,pdc_purord,pdc_seq,pdc_ctnseq,pdc_from,pdc_to,pdc_ttlctn,pdc_creusr,pdc_updusr,pdc_credat,pdc_upddat        
 )        
 select         
 pds_cocde,pds_purord,pds_seq,pds_shpseq,pds_ctnstr,pds_ctnend,pds_ttlctn,'PDOSAP',pds_updusr,getdate(),pds_upddat        
 from PODTLSHP(nolock) , #tmp_PO tmp  (nolock)      
 where pds_purord = tmp.pod_purord and pds_seq = tmp.pod_purseq        

 --=============================================================================================        
 -- sp_help PODTLSHP        
 delete SAPDTLSHP from SAPDTLSHP , #tmp_PO tmp        
 where pds_purord = tmp.pod_purord and pds_seq = tmp.pod_purseq        
         
 insert into SAPDTLSHP        
 (        
 pds_cocde,pds_purord,pds_seq,pds_shpseq,pds_from,pds_to,pds_ttlctn,pds_creusr,pds_updusr,pds_credat,pds_upddat        
 )        
 select
 pds_cocde,pds_purord,pds_seq,pds_shpseq,pds_from,pds_to,pds_ordqty,'PDOSAP',pds_updusr,getdate(),pds_upddat        
 from PODTLSHP (nolock), #tmp_PO tmp  (nolock)      
 where pds_purord = tmp.pod_purord and pds_seq = tmp.pod_purseq        
 --=============================================================================================        

 delete SAPPOASS from SAPPOASS , #tmp_PO tmp        
 where pda_purord = tmp.pod_purord and pda_seq = tmp.pod_purseq        
         
 insert into SAPPOASS        
 (  pda_cocde,pda_purord,pda_seq,pda_itmno,pda_assitm,pda_assdsc,
	pda_cusitm,pda_colcde,pda_coldsc,pda_cussku,pda_cusstyno,
	pda_upcean,pda_cusrtl,pda_pckunt,pda_inrqty,pda_mtrqty,
	pda_imperiod,pda_creusr,pda_updusr,pda_credat,pda_upddat
 )        
 select
 pda_cocde,pda_purord,pda_seq,pda_itmno,pda_assitm,pda_assdsc,
	pda_cusitm,pda_colcde,pda_coldsc,pda_cussku,pda_cusstyno,
	pda_upcean,pda_cusrtl,pda_pckunt,pda_inrqty,pda_mtrqty,
	pda_imperiod,
'PDOSAP',pda_updusr,getdate(),pda_upddat        
 from PODTLASS (nolock), #tmp_PO tmp  (nolock)      
 where pda_purord = tmp.pod_purord and pda_seq = tmp.pod_purseq        


 drop table #tmp_PO        
end        
        
        
select * from #tmp_PDO_SAP  (nolock)      
        
drop table  #tmp_PDO_SAP        
drop table #tmpjob        



GO
GRANT EXECUTE ON [dbo].[sp_select_POR00005_PDO_SAP] TO [ERPUSER] AS [dbo]
GO
