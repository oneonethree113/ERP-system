/****** Object:  StoredProcedure [dbo].[sp_select_SAM00005]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SAM00005]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SAM00005]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




------------------------------------------------- 
CREATE procedure [dbo].[sp_select_SAM00005]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@code nvarchar(6) ,
@qut_no nvarchar(20) 
                                               
---------------------------------------------- 

AS
begin

declare @gen nvarchar(1)
declare @seq int 
declare @TtlAmtI numeric(13,4)
declare @NetAmtI  numeric(13,4)
declare @Status nvarchar(30)
set @gen = 'N'



create table #TEMP_RESULT (r_sas_itmno nvarchar(50),r_sas_itmnotmp nvarchar(50),r_sas_itmnoven nvarchar(50),r_sas_itmnovenno nvarchar(50),r_sas_colcde nvarchar(50),r_sad_untcde nvarchar(10),r_sad_inrqty int , r_sad_mtrqty int , r_sad_credat datetime)
insert into #TEMP_RESULT
select sas_itmno as 'r_sas_itmno', sas_itmnotmp as 'r_sas_itmnotmp' , sas_itmnoven as 'r_sas_itmnoven' , sas_itmnovenno as 'r_sas_itmnovenno',sas_colcde as 'r_sas_colcde', sad_untcde as 'r_sad_untcde', sad_inrqty as 'r_sad_inrqty', sad_mtrqty as 'r_sad_mtrqty', max(sad_credat) 'r_sad_credat'
from SAORDDTL
left join SAORDSUM on sas_cocde = sad_cocde and sas_cus1no = sad_cus1no and sas_itmno = sad_itmno and sad_colcde = sas_colcde and sad_itmnotmp = sas_itmnotmp and sad_itmnoven = sas_itmnoven and sad_itmnovenno = sas_itmnovenno
left join QUOTNHDR on quh_qutno = sad_qutno
left join IMBASINF on ibi_itmno = sas_itmno
where sad_qutno = @qut_no
and sas_cocde is not null
and sas_cocde = @code
and sas_cusqty - sas_shpqty > 0
--and (ibi_itmsts = 'CMP' or ibi_itmsts = 'INC') 
group by sas_itmno, sas_itmnotmp , sas_itmnoven , sas_itmnovenno , sas_colcde, sad_untcde, sad_inrqty, sad_mtrqty

union

select sas_itmno as 'r_sas_itmno', sas_itmnotmp as 'r_sas_itmnotmp' , sas_itmnoven as 'r_sas_itmnoven' , sas_itmnovenno as 'r_sas_itmnovenno',sas_colcde as 'r_sas_colcde', sad_untcde as 'r_sad_untcde', sad_inrqty as 'r_sad_inrqty', sad_mtrqty as 'r_sad_mtrqty', max(sad_credat) 'r_sad_credat'
from SAORDDTL
left join SAORDSUM on sas_cocde = sad_cocde and sas_cus1no = sad_cus1no and sas_itmno = sad_itmno and sad_colcde = sas_colcde and sad_itmnotmp = sas_itmnotmp and sad_itmnoven = sas_itmnoven and sad_itmnovenno = sas_itmnovenno
left join QUOTNHDR on quh_qutno = sad_qutno
left join IMBASINF bas on bas.ibi_alsitmno = sas_itmno and bas.ibi_itmsts <> 'CLO'
left join IMBASINF als on bas.ibi_alsitmno = als.ibi_itmno
where sad_qutno =@qut_no
and sas_cocde is not null
and sas_cocde = @code
and sas_cusqty - sas_shpqty > 0
--and (bas.ibi_itmsts = 'CMP' or bas.ibi_itmsts = 'INC') 
--and isnull(als.ibi_itmsts, '') <> 'OLD' 
group by sas_itmno, sas_itmnotmp , sas_itmnoven , sas_itmnovenno , sas_colcde, sad_untcde, sad_inrqty, sad_mtrqty
 

select  @Gen as 'gen',  quh_cus1no, quh_cus2no, @seq as 'sad_seqno', sas_itmno, 
sas_itmnotmp,sas_itmnovenno,sas_itmnoven,sas_itmdsc,
sas_colcde, 
sad_untcde + ' / ' + ltrim(str(sad_inrqty)) + ' / ' + ltrim(str(sad_mtrqty)) + ' / ' + sad_imu_hkprctrm + ' / ' + sad_imu_ftyprctrm + ' / ' +  sad_imu_trantrm + ' / ' + quh_qutno as 'Packing & Terms'
,sas_cusqty - sas_shpqty as 'sas_osdqty', sas_chgqty - sas_shpchgqty as 'sas_chgqty', sas_freqty - sas_shpfreqty as 'sas_shipfreqty' ,
sas_freqty as 'sas_balfreqty',
 sad_untcde, sad_inrqty, sad_mtrqty, sad_cft,sad_imu_cus1no, sad_imu_cus2no, sad_imu_hkprctrm, sad_imu_ftyprctrm, sad_imu_trantrm,
sas_smpunt,sad_smpftyprc,sad_smpselprc,sas_chgqty - sas_shpchgqty as 'sas_outchgqty' , sas_cusqty - sas_shpqty as 'sas_outshqty',
sas_freqty - sas_shpfreqty as 'sas_outFreqty' ,sas_freqty, sas_shpqty , sas_shpchgqty,
sad_imu_effdat,sad_imu_expdat,sad_fcurcde,quh_qutno , sad_cusven , sad_cussub,quh_cocde ,
cpi_curcde,sad_curcde,@TtlAmtI as 'ttlamt' , @NetAmtI as 'netamt',
case c.yst_charge when 'Q' then 100 else  100-isnull(c.yst_chgval,0) end as 'yst_chgval' ,@Status as 'status',
cpi_smpprd,cpi_smpfgt,cpi_prctrm,
isnull(a.cci_cntcty,'')as 'cci_cntcty',isnull(a.cci_cntadr,'') as 'cci_cntadr' ,	isnull(a.cci_cntstt,'')as 'cci_cntstt',isnull(a.cci_cntpst,'')as 'cci_cntpst'
,sad_alscolcde,sad_alsitmno,sad_cuscol,sad_coldsc ,sad_smpuntcde ,sad_itmtyp,sad_reqno,sad_reqseq ,sad_qutseq,sad_venno
,sad_subcde,sad_cusven,sad_cussub,sad_fcurcde,sad_imu_effdat , sad_imu_expdat , isnull(c1.cbi_cussna,'') as 'quh_cus1na' , isnull(c2.cbi_cussna,'') as 'quh_cus2na'
,quh_saldivtem,quh_srname,
isnull(a2.cci_cntcty,'')as 'cci_cntcty2',isnull(a2.cci_cntadr,'') as 'cci_cntadr2' ,isnull(a2.cci_cntstt,'')as 'cci_cntstt2',isnull(a2.cci_cntpst,'')as 'cci_cntpst2'
,sad_credat
,sad_upddat
,sad_updusr
from 
#TEMP_RESULT
left join SAORDDTL on r_sas_itmno = sad_itmno and r_sas_colcde = sad_colcde and r_sad_untcde = sad_untcde and r_sad_inrqty = sad_inrqty and r_sad_mtrqty = sad_mtrqty 
and r_sad_credat = sad_credat and r_sas_itmnotmp = sad_itmnotmp and r_sas_itmnoven = sad_itmnoven and r_sas_itmnovenno = sad_itmnovenno
left join SAORDSUM on sas_cocde = sad_cocde and sas_cus1no = sad_cus1no and sas_itmno = sad_itmno and sad_colcde = sas_colcde and sas_itmnotmp = sad_itmnotmp and sas_itmnoven = sad_itmnoven and sas_itmnovenno = sad_itmnovenno
left join QUOTNHDR on quh_qutno = sad_qutno
left join IMBASINF on ibi_itmno = sas_itmno
left join cuprcinf on cpi_cusno = quh_cus1no
left join SYSMPTRM c
on c.yst_cocde = ' ' --@cocde 
 and c.yst_trmcde = cpi_smpprd
left join 	CUCNTINF a
on quh_cus1no = a.cci_cusno and -- a.cci_cocde = @cocde  and
 a.cci_cnttyp = 'M' and a.cci_cntseq = 1
left join Cucntinf a2
on quh_cus2no = a2.cci_cusno and -- a.cci_cocde = @cocde  and
 a2.cci_cnttyp = 'M' and a2.cci_cntseq = 1
left join cubasinf c1
on  c1.cbi_cusno = quh_cus1no
left join cubasinf c2
on  c2.cbi_cusno = quh_cus2no
where sad_qutno = @qut_no
and sas_cocde is not null
and sas_cusqty - sas_shpqty > 0
--and ibi_itmsts = 'CMP'



drop table #TEMP_RESULT

end
 
 
 



GO
GRANT EXECUTE ON [dbo].[sp_select_SAM00005] TO [ERPUSER] AS [dbo]
GO
