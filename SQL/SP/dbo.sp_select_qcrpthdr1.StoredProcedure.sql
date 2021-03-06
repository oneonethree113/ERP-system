/****** Object:  StoredProcedure [dbo].[sp_select_qcrpthdr1]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_qcrpthdr1]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_qcrpthdr1]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_select_qcrpthdr1] 
                @TmpRPTNo as nvarchar(30)



                AS
                begin

-------------------------------------------------------
----------

---------------------------------------------
-------------------------------------------------------

declare @_itmno  nvarchar(30)
declare @cusitm nvarchar(30)



set @_itmno  = (select qrh_itmno from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
if ltrim(rtrim(@_itmno )) = '' 
begin
set @_itmno  = (select qrh_othitmno from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
end
set @_itmno  =Replace(@_itmno,'–','-')


                set @cusitm = (select qrh_cusitm from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
                set @cusitm = Ltrim(Rtrim(@cusitm))
                                set @cusitm  =Replace(@cusitm,'–','-')


declare @_po_str nvarchar(300)
declare @_po_str_split nvarchar(1000)

declare @_cuspo_str_split nvarchar(1000)
declare @_cusitm_str_split nvarchar(1000)

declare @_shpqty_str_split nvarchar(1000)

declare @_morepo  nvarchar(1000)
declare @_morepo_ori  nvarchar(1000)

declare @_morepo_shpqty  nvarchar(1000)

declare @_qrd_mtrpc int

set @_po_str = (select qrh_postr from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
set @_po_str =Replace(@_po_str , ',' , ''',''')
set @_po_str = '''' + @_po_str  + ''''

set @_po_str_split = (select qrh_postr from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
SET @_po_str_split = LTRIM(RTRIM(@_po_str_split))
SET @_po_str_split = REPLACE(@_po_str_split,'，',',')
IF SUBSTRING(@_po_str_split,LEN(@_po_str_split),LEN(@_po_str_split)) = ',' 
BEGIN
SET @_po_str_split =SUBSTRING(@_po_str_split,1,LEN(@_po_str_split)-1)
END

set @_cuspo_str_split = (select qrh_cuspostr from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
SET @_cuspo_str_split = LTRIM(RTRIM(@_cuspo_str_split))
SET @_cuspo_str_split = REPLACE(@_cuspo_str_split,'，',',')
IF SUBSTRING(@_cuspo_str_split,LEN(@_cuspo_str_split),LEN(@_cuspo_str_split)) = ',' 
BEGIN
SET @_cuspo_str_split =SUBSTRING(@_cuspo_str_split,1,LEN(@_cuspo_str_split)-1)
END

set @_cusitm_str_split = (select qrh_cusitm from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
SET @_cusitm_str_split = LTRIM(RTRIM(@_cusitm_str_split))
SET @_cusitm_str_split = REPLACE(@_cusitm_str_split,'，',',')
IF SUBSTRING(@_cusitm_str_split,LEN(@_cusitm_str_split),LEN(@_cusitm_str_split)) = ',' 
BEGIN
SET @_cusitm_str_split =SUBSTRING(@_cusitm_str_split,1,LEN(@_cusitm_str_split)-1)
END

set @_shpqty_str_split = (select qrd_poqty from  QCRPTDTL where qrd_tmprptno=@TmpRPTNo )
SET @_shpqty_str_split = LTRIM(RTRIM(@_shpqty_str_split))
SET @_shpqty_str_split = REPLACE(@_shpqty_str_split,'，',',')
IF SUBSTRING(@_shpqty_str_split,LEN(@_shpqty_str_split),LEN(@_shpqty_str_split)) = ',' 
BEGIN
SET @_shpqty_str_split =SUBSTRING(@_shpqty_str_split,1,LEN(@_shpqty_str_split)-1)
END

set @_qrd_mtrpc  = (select isnull(qrd_mtrpc,1) from  QCRPTDTL where qrd_tmprptno=@TmpRPTNo )

set @_morepo   = (select qrh_morepo from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
if rtrim(ltrim(@_morepo  )) = ''
begin
set @_morepo   = (select qrh_othpostr from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
end
SET @_morepo = LTRIM(RTRIM(@_morepo))

SET @_morepo = REPLACE(@_morepo,'；',';')

IF SUBSTRING(@_morepo,LEN(@_morepo),LEN(@_morepo)) = ';' 
BEGIN

SET @_morepo =SUBSTRING(@_morepo,1,LEN(@_morepo)-1)
END

set @_morepo_ori = @_morepo  

set @_morepo_shpqty = (select qrd_morepoqty from  QCRPTDTL where qrd_tmprptno=@TmpRPTNo )

SET @_morepo_shpqty = LTRIM(RTRIM(@_morepo_shpqty))

SET @_morepo_shpqty = REPLACE(@_morepo_shpqty,'；',';')

IF SUBSTRING(@_morepo_shpqty,LEN(@_morepo_shpqty),LEN(@_morepo_shpqty)) = ';' 
BEGIN

SET @_morepo_shpqty =SUBSTRING(@_morepo_shpqty,1,LEN(@_morepo_shpqty)-1)
END



-------------------------
-------------------------
create table #ponum
(
tmp_po nvarchar(30),
tmp_cuspo nvarchar(30),
tmp_cusitm nvarchar(30),
tmp_shpqty int
)

DECLARE @_CIndex smallint
DECLARE @_CIndex2 smallint
DECLARE @_CIndex3 smallint
DECLARE @_CIndex4 smallint

WHILE (@_po_str_split<>''  )

BEGIN
--select @_po_str_split as '@_po_str_split'
SET @_CIndex=CHARINDEX(',',@_po_str_split)
SET @_CIndex2=CHARINDEX(',',@_shpqty_str_split)
SET @_CIndex3=CHARINDEX(',',@_cuspo_str_split)
--SET @_CIndex4=CHARINDEX(',',@_cusitm_str_split)


IF @_CIndex=0 SET @_CIndex=LEN(@_po_str_split)+1
IF @_CIndex2=0 SET @_CIndex2=LEN(@_shpqty_str_split)+1
IF @_CIndex3=0 SET @_CIndex3=LEN(@_cuspo_str_split)+1
--IF @_CIndex4=0 SET @_CIndex4=LEN(@_cusitm_str_split)+1

--select @_shpqty_str_split as '@_shpqty_str_split'
--select @_CIndex2-1 as '@_CIndex2-1'
--select SUBSTRING('3996',1,4)

INSERT INTO #ponum (tmp_po,tmp_cuspo,tmp_cusitm,tmp_shpqty)
values (SUBSTRING(@_po_str_split,1,@_CIndex-1), 
                        SUBSTRING(@_cuspo_str_split,1,@_CIndex3-1), 
                        @_cusitm_str_split,
                SUBSTRING(@_shpqty_str_split,1,@_CIndex2-1))
   
IF @_CIndex=LEN(@_po_str_split)+1 BREAK
IF CHARINDEX(',',@_po_str_split) = 0   BREAK

SET @_po_str_split=SUBSTRING(@_po_str_split,@_CIndex+1,LEN(@_po_str_split)-@_CIndex)
SET @_cuspo_str_split=SUBSTRING(@_cuspo_str_split,@_CIndex3+1,LEN(@_cuspo_str_split)-@_CIndex3)
--SET @_cusitm_str_split=SUBSTRING(@_cusitm_str_split,@_CIndex4+1,LEN(@_cusitm_str_split)-@_CIndex4)
SET @_shpqty_str_split=SUBSTRING(@_shpqty_str_split,@_CIndex2+1,LEN(@_shpqty_str_split)-@_CIndex2)

END



--select * from #ponum


Declare @_SQL VarChar(4500)
        


----------------------
------------------





----------------------------
-------------------------
create table #ponum2
(
tmp_po nvarchar(30),
tmp_shpqty int
)

DECLARE @_CIndexmore smallint
DECLARE @_CIndexmore2 smallint

WHILE (@_morepo <>''  )

BEGIN

SET @_CIndexmore=CHARINDEX(';',@_morepo )
SET @_CIndexmore2=CHARINDEX(';',@_morepo_shpqty)


IF @_CIndexmore=0 SET @_CIndexmore=LEN(@_morepo )+1
IF @_CIndexmore2=0 SET @_CIndexmore2=LEN(@_morepo_shpqty)+1

INSERT INTO #ponum2 (tmp_po,tmp_shpqty)
values (SUBSTRING(@_morepo ,1,@_CIndexmore-1), SUBSTRING(@_morepo_shpqty,1,@_CIndexmore2-1))

IF @_CIndexmore=LEN(@_morepo )+1 BREAK
IF CHARINDEX(';',@_morepo ) = 0 BREAK

SET @_morepo =SUBSTRING(@_morepo ,@_CIndexmore+1,LEN(@_morepo )-@_CIndexmore)
SET @_morepo_shpqty=SUBSTRING(@_morepo_shpqty,@_CIndexmore2+1,LEN(@_morepo_shpqty)-@_CIndexmore2)

END



--  select * from #ponum2

--select  @_morepo_ori
----------------------
-------------------------
------------------
create table #ttt
(
pod_purord nvarchar(30) ,
pod_cuspno  nvarchar(30) ,
pod_cusitm  nvarchar(30) ,
pod_ordqty int,
  tmp_shpqty int,
  tmp_perctn  int
) 
insert into #ttt
select  pod_purord pod_purord ,pod_cuspno pod_cuspno,pod_cusitm pod_cusitm , pod_ordqty pod_ordqty, tmp_shpqty tmp_shpqty , tmp_perctn tmp_perctn
from
(
select  tmp_po as  'pod_purord',
                        isnull(tmp_cuspo,'') as 'pod_cuspno',
                        isnull(tmp_cusitm,'') as 'pod_cusitm' ,pod_ordqty*@_qrd_mtrpc as  'pod_ordqty', tmp_shpqty as 'tmp_shpqty ',
                        cast(pod_ordqty/pod_ttlctn as int ) as 'tmp_perctn'
from POORDDTL  
 left join  #ponum
                                on pod_purord =tmp_po
                                                                        AND pod_cusitm = CASE LEN(@cusitm)
                                        WHEN 0 THEN pod_cusitm
                                                        ELSE @cusitm
                                        END 

                             --     and pod_cusitm = tmp_cusitm
WHERE pod_itmno = @_itmno  
                        and  @_po_str   like '%' +   pod_purord + '%'      
                                                   
                        and tmp_shpqty is not null
                        and pod_ttlctn <> 0                               
                        and pod_ttlctn is not null
---                   and pod_ordqty <> 0
---                   and pod_ttlctn  is not null

union


select tmp_po as  'pod_purord',
                        isnull(poh_cuspno,'') as 'pod_cuspno',
                        isnull(pod_cusitm,'') as 'pod_cusitm' ,
                        isnull(pod_ordqty,0)*@_qrd_mtrpc as  'pod_ordqty', tmp_shpqty as 'tmp_shpqty '                  ,
                        cast(pod_ordqty/pod_ttlctn as int ) as 'tmp_perctn'
from #ponum2
left join   POORDDTL  
                                on pod_purord =tmp_po 
                                 and  pod_itmno = @_itmno
                             AND pod_cusitm = CASE LEN(@cusitm)
                                        WHEN 0 THEN pod_cusitm
                                                        ELSE @cusitm
                                        END 

left join poordhdr on pod_purord = poh_purord
                                and  pod_itmno = @_itmno

WHERE pod_itmno = @_itmno  
                        and @_morepo_ori      like '%' +   pod_purord + '%'    
                        and tmp_shpqty  is not null             
                        and pod_ttlctn <> 0                                 --and pod_ordqty <> 0        
                        and pod_ttlctn is not null   
        ---           and pod_ordqty <> 0  
        ) t2

        
--select * from #ponum
--select * from  #ponum2


-------------------------------------------------------
-------------------------------------------------------
-------------------------------------------------------



                declare @itmno  nvarchar(30)
                
                declare  @po_flag nvarchar(1) 

                set @po_flag  =''   -- normal

                set @itmno  = (select qrh_itmno from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
                
        if ltrim(rtrim(@itmno )) = '' 
        begin
        set @itmno  = (select qrh_othitmno from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
                if ltrim(rtrim(@itmno )) <> '' 
                begin
                        set @po_flag= 'M'  -- more po
                end
        end
        
--     select @itmno 

--     select @po_flag 

        declare @qrd_mtrpc int

                set @qrd_mtrpc  = (select isnull(qrd_mtrpc,1) from  QCRPTDTL where qrd_tmprptno=@TmpRPTNo )

                declare @po_str nvarchar(300)
                
                if  @po_flag= 'M' 
                begin
                        set @po_str = (select qrh_morepo from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
                                                        if  ltrim(Rtrim(@po_str )) <> ''
                                                        begin
                                                        set @po_str =Replace(@po_str , ';' , ''',''')
                                                        set @po_str = '''' + @po_str  + ''''
                                                        end

                        if ltrim(Rtrim(@po_str )) = ''
                        begin
                                        set @po_str = (select qrh_othpostr from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
                                        set @po_str =Replace(@po_str , ';' , ''',''')
                                        set @po_str = '''' + @po_str  + ''''
                        end
                end
                else
                begin
                        set @po_str = (select qrh_postr from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
                                        set @po_str =Replace(@po_str , ',' , ''',''')
                                set @po_str = '''' + @po_str  + ''''
        
                end

        
--             select @po_str  as 'test'



                Declare @a_total  decimal(13,4)
                Declare @a_ctn  decimal(13,4)

                Declare @SQL VarChar(4500)

                create table #sum_total
                (
                a_total   decimal(13,4)
                )
                create table #sum_ctn
                (
                a_ctn   decimal(13,4)
                )                if  @po_flag= 'M' 
                begin
                                                        if @cusitm <> ''  
                                                        begin
                                                             SELECT @SQL =' insert into  #sum_total select sum(pod_ordqty*' + cast(@qrd_mtrpc  as nvarchar(10) )+ '  )  as a_total from POORDDTL  WHERE ( pod_itmno = ''' + @itmno + ''' or  pod_cusitm  = '''+  @cusitm   + '''  )  and pod_purord in ('+   @po_str +  ') and pod_ttlctn <> 0 group by pod_itmno'
                                                        end 
                                                        else
                                                        begin
                                                             SELECT @SQL =' insert into  #sum_total select sum(pod_ordqty*' + cast(@qrd_mtrpc  as nvarchar(10) )+ '  )  as a_total from POORDDTL  WHERE ( pod_itmno = ''' + @itmno + '''  )  and pod_purord in ('+   @po_str +  ') and pod_ttlctn <> 0 group by pod_itmno'
                                                        end
                end
                else
                begin
                                                        if @cusitm <> ''  
                                                        begin
                                                               SELECT @SQL =' insert into  #sum_total select sum(pod_ordqty*' + cast(@qrd_mtrpc  as nvarchar(10) )+ '  )  as a_total from POORDDTL  WHERE ( pod_itmno = ''' + @itmno  + ''' or  pod_cusitm = '''+  @cusitm   + '''  )  and  pod_purord in ('+   @po_str +  ')  and pod_ttlctn <> 0  group by pod_itmno'
                                                        end 
                                                        else
                                                        begin
                                                               SELECT @SQL =' insert into  #sum_total select sum(pod_ordqty*' + cast(@qrd_mtrpc  as nvarchar(10) )+ '  )  as a_total from POORDDTL  WHERE ( pod_itmno = ''' + @itmno      + '''  )  and  pod_purord in ('+   @po_str +  ')  and pod_ttlctn <> 0  group by pod_itmno'
                                                        end
                              
                end
                --select  @SQL
                Exec (@SQL)

                set @a_total  =   (select a_total    from #sum_total)
                set @a_total  =   (select sum(tmp_shpqty)    from #ttt)

                --
                SELECT @SQL =' insert into  #sum_ctn select sum(pod_ttlctn)  as a_ctn from POORDDTL  WHERE ( pod_itmno = ''' + @itmno  + ''' or  pod_cusitm = '''+  @cusitm   + '''   ) and  pod_purord in ('+   @po_str +  ') group by pod_itmno,pod_cusitm'

                Exec (@SQL)

                set @a_ctn  =       (select sum(tmp_shpqty/tmp_perctn)    from #ttt)
                set @a_ctn  =     @a_ctn/@qrd_mtrpc

--             set @a_ctn  =   (select a_ctn   from #sum_ctn)
        --     if @qrd_mtrpc > 1 
                --begin
                        --set @a_ctn  =           @a_total/@qrd_mtrpc
                --end
                --else
                --begin

                --end


                ---select * from #ttt

                --------------------------------
                DECLARE @BusinessEntityID as INT;
                declare @yal_lotfm  as int ;
               declare @yal_lotto  as int ;
                declare @yal_sample  as int ;
                declare @yal_aql15  as int ;
                declare @yal_aql25  as int ;

                                declare  @sample   as int ;
                                declare  @aql1a   as int ;
                                declare  @aql15a   as int ;
                                declare  @aql25a as int ;
                                declare  @aql1   as int ;
                                declare  @aql15   as int ;
                                declare  @aql25   as int ;

                DECLARE @BusinessCursor as CURSOR;

                SET @BusinessCursor = CURSOR FOR
                SELECT yal_lotfm,yal_lotto,yal_sample,yal_aql15,yal_aql25
                FROM SYMAQL;

                OPEN @BusinessCursor;
                FETCH NEXT FROM @BusinessCursor INTO 
        @yal_lotfm  ,@yal_lotto  ,@yal_sample  ,@yal_aql15  ,@yal_aql25  ;


                WHILE @@FETCH_STATUS = 0
                BEGIN
                if @a_total   >= @yal_lotfm and @a_total  <=@yal_lotto   
                        begin
                                set @sample = @yal_sample 
                --             select @a_total   as '@a_total'
                --             select @yal_lotfm as '@yal_lotfm'
                --             select @yal_lotto as '@yal_lotto'
                --             select @yal_sample  as '@yal_sample '
                --             select @qrd_mtrpc  as '@qrd_mtrpc '
                                

                --             set @aql15 = @yal_aql15 
                --             set @aql25 = @yal_aql25  

                        end 
                -- PRINT cast(@BusinessEntityID as VARCHAR (50)) + ' ' + @BusinessName;
                FETCH NEXT FROM @BusinessCursor INTO @yal_lotfm  ,@yal_lotto  ,@yal_sample  ,@yal_aql15  ,@yal_aql25  
                END

                CLOSE @BusinessCursor;
                DEALLOCATE @BusinessCursor;


                --------------------------------

                drop table #sum_total
                drop table #sum_ctn

                ----------------------------------------------------------
                ----------------------------------------------------------
                set @aql1a = (select  sum(qrd_dftcrtalw) from qcrptdtl where qrd_tmprptno=@TmpRPTNo ) 
                set @aql15a = (select  sum(qrd_dftmajalw) from qcrptdtl where qrd_tmprptno=@TmpRPTNo ) 
                set @aql25a = (select  sum(qrd_dftminalw) from qcrptdtl where qrd_tmprptno=@TmpRPTNo ) 

                set @aql1 = (select  sum(qdt_dftcrt) from qcrptdft where qdt_tmprptno=@TmpRPTNo ) 
                set @aql15 = (select  sum(qdt_dftmaj) from qcrptdft where qdt_tmprptno=@TmpRPTNo ) 
                set @aql25 = (select  sum(qdt_dftmin) from qcrptdft where qdt_tmprptno=@TmpRPTNo ) 

                ----------------------------------------------------------
                ----------------------------------------------------------

                                declare  @count_sub1   as int ;
                                declare  @count_sub2   as int ;
                                declare  @count_sub3   as int ;


                set @count_sub1    = 
                (SELECT 
                count(*)
                from qcrptimg   
                                LEFT JOIN QCRPTCDE 
                                ON qri_inspcde =qrc_inspcde
                where  qri_tmprptno = @TmpRPTNo 
                                and qrc_rptimgdis_group <= 50
                )


                set @count_sub2    = (
                SELECT 
                count(*)
                from qcdftimg  bb
                                        left join QCRPTDFT aa
                                                on bb.qdt_tmprptno = aa.qdt_tmprptno
                                                and  bb.qdt_dftseq  = aa.qdt_dftseq  
                where  bb.qdt_tmprptno = @TmpRPTNo 
                )

                set @count_sub3    = 
                (SELECT 
                count(*)
                from qcrptimg   
                                LEFT JOIN QCRPTCDE 
                                ON qri_inspcde =qrc_inspcde
                where  qri_tmprptno = @TmpRPTNo 
                                and qrc_rptimgdis_group > 50
                )


                ----------------------------------------------------------
        
                ----------------------------------------------------------
                ----------------------------------------------------------



                SELECT 
                REPLACE(CONVERT(CHAR(15), qrh_inspdat, 6),' ','-') date,
                qrh_tmprptno reportNo,
                qrh_rpttyp,
                vbi_Vensna factory,
                case 
                        when secCust.cbi_cussna IS NULL OR secCust.cbi_cussna = '' 
                                then priCust.cbi_cussna 
                                else secCust.cbi_cussna 
                                end customer,
                qrh_qcno requestNo,
                qrh_postr po,
                @itmno as  'ucpItem',
                qrh_cuspostr custPo,
                qrh_cusitm custItem, 
                qrh_finalstatus qrh_finalstatus,
                LTrim(Rtrim(cast(ISNULL(qrh_insptime,'') as nvarchar(4) ))) AS  'qrh_insptime',
                qrd_sysnwt qrd_sysnwt,
                qrd_sysgwt qrd_sysgwt,
                qrd_actnwt qrd_actnwt,
                qrd_actgwt qrd_actgwt,
                qrd_sysmtrl qrd_sysmtrl,
                qrd_sysmtrw qrd_sysmtrw,
                qrd_sysmtrh qrd_sysmtrh,
                qrd_syscft qrd_syscft,
                qrd_actmtrl qrd_actmtrl,
                qrd_actmtrw qrd_actmtrw,
                qrd_actmtrh qrd_actmtrh,
                qrd_actcft qrd_actcft,
                qrd_prdrmk qrd_prdrmk,

                        case (DATEDIFF(year, qrd_prdexpdat, '1970')  ) 
                          WHEN 0 THEN ''
                          else CONVERT(VARCHAR(10), qrd_prdexpdat,101)
                          END as 'qrd_prdexpdat',

                --Convert(nvarchar(20), qrd_prdexpdat, 106)  qrd_prdexpdat,
                case (DATEDIFF(year, qrd_reinspdat, '1970')  ) 
                  WHEN 0 THEN ''
                  else CONVERT(VARCHAR(10), qrd_reinspdat,101)
                  END as 'qrd_reinspdat',
                --Convert(nvarchar(20), qrd_reinspdat, 106)  qrd_reinspdat,
                                  @a_total as 'aql_total',
                                        @a_ctn as 'aql_ctn', 
                                        @sample as 'aql_sample',
                                        

                                        case 
                                        when (SQRT(@a_ctn)*(@a_total /@a_ctn ) <@sample)  then
                                        round(@sample/(@a_total /@a_ctn )+0.49999999,0,0)  
                                        else
                                        round(SQRT(@a_ctn)+0.49999999,0,0) 
                                                                                end as 'aql_samplectn',

--                                     round(SQRT(@a_ctn),0) + 1 as 'aql_samplectn',


                                        @aql1a as 'aql_aql1a',
                                        @aql15a as 'aql_aql15a',
                                        @aql25a as 'aql_aql25a',
                                        @aql1 as 'aql_aql1',
                                        @aql15 as 'aql_aql15',
                                        @aql25 as 'aql_aql25',
                                        @count_sub1   as 'count_sub1',
                                        @count_sub2   as 'count_sub2',
                                        @count_sub3   as 'count_sub3' ,
                                        qrh_inspresult  qrd_inspresult,
                                        qrd_qcpredsc qrd_qcpredsc,
                                        qrd_disptyp1 qrd_disptyp1,
                                        qrd_disptyp2 qrd_disptyp2,
                                        qrh_itmdsc qrh_itmdsc,
                                qrd_pckitr    as 'qrd_pckitr',
                                        tbl_insp_accor.qrg_result as 'insp_accor',
                                        tbl_check_p3Doth.qrg_detail 
                                         as 'check_p3Doth',
                                        tbl_check_p3Epack.qrg_detail as 'check_p3Epack',
                                        tbl_check_p3Fprdchk.qrg_detail as 'check_p3Fprdchk',

                                        tbl_check_p3Fprdspc.qrg_detail as 'check_p3Fprdspc',
                                        
                                         tbl_result_p5remark.qrg_detail as 'result_p5remark',
                                        tbl_result_followup.qrg_detail as 'result_followup',

                                       tbl_test_dropbox.qrg_detail as 'test_dropbox',
                                        tbl_test_adhesion.qrg_detail as 'test_adhesion',
                                        tbl_test_humidity.qrg_detail as 'test_humidity',
                                        tbl_test_tilt.qrg_detail as 'test_tilt',
                                       tbl_test_function.qrg_detail as 'test_function',
                                        tbl_test_barcode.qrg_detail as 'test_barcode',
                                        tbl_test_mattyp.qrg_detail as 'test_mattyp',
                                        tbl_test_prdprog.qrg_detail as 'test_prdprog',
                                        tbl_test_p4oth.qrg_detail as 'test_p4oth',
                                        CASE Ltrim(Rtrim(        tbl_check_p3Fprdchk.qrg_detail )) 
                                  WHEN '' THEN
                                  ''
                                  ELSE 
                                  '備注:  '+              Ltrim(Rtrim(  
                                        case when
                                        isnull(tbl_check_p3Fprdchk.qrg_detail  ,'') = ''
                                        then ''
                                        else
                                                '產品檢查: ' +  tbl_check_p3Fprdchk.qrg_detail  
                                        end   

                                  )) 
                                  END as 'p3_rmk' ,


                                        CASE                              Ltrim(Rtrim(        tbl_test_dropbox.qrg_detail + '   ' +
                                        tbl_test_adhesion.qrg_detail  + '   ' +
                                        tbl_test_humidity.qrg_detail  + '   ' +
                                        tbl_test_tilt.qrg_detail  + '   ' +
                                        tbl_test_function.qrg_detail  + '   ' +
                                        tbl_test_barcode.qrg_detail  + '   ' +
                                        tbl_test_mattyp.qrg_detail    + '   ' +
                                        tbl_test_prdprog.qrg_detail + '   ' +
                                        tbl_test_p4oth.qrg_detail)) 
                                  WHEN '' THEN
                                  ''
                                  ELSE 
                                  '備注:  '+                                              Ltrim(Rtrim(  
                                        case when
                                        isnull(tbl_test_dropbox.qrg_detail,'') = ''
                                        then ''
                                        else
                                                'A. 摔箱測試: ' +  tbl_test_dropbox.qrg_detail
                                        end   
                                         + '   ' +
                                                                                case when
                                        isnull(tbl_test_adhesion.qrg_detail,'') = ''
                                        then ''
                                        else
                                        'B. 3M附著力測試: ' +  tbl_test_adhesion.qrg_detail
                                        end   

                                        + '   ' +
                                                                                case when
                                        isnull(tbl_test_humidity.qrg_detail,'') = ''
                                        then ''
                                        else
                                                'C. 濕度測試: ' +  tbl_test_humidity.qrg_detail
                                        end   
  
                                        + '   ' +
                                                                                case when
                                        isnull(tbl_test_tilt.qrg_detail,'') = ''
                                        then ''
                                        else
                                                'D. 斜度測試: ' +  tbl_test_tilt.qrg_detail
                                        end   
  
                                        + '   ' +
                                                                                case when
                                        isnull(tbl_test_function.qrg_detail,'') = ''
                                        then ''
                                        else
                                                'E. 功能測試: ' +  tbl_test_function.qrg_detail
                                        end   
 
                                         + '   ' +
                                                                                case when
                                        isnull(tbl_test_barcode.qrg_detail,'') = ''
                                        then ''
                                        else
                                                'F. 條碼測試: ' +  tbl_test_barcode.qrg_detail
                                        end   
  
                                        + '   ' +
                                                                                case when
                                        isnull(tbl_test_mattyp.qrg_detail,'') = ''
                                        then ''
                                        else
                                                'G. 材料種類: ' +  tbl_test_mattyp.qrg_detail
                                        end   
    
                                        + '   ' +
                                                                                case when
                                        isnull(tbl_test_prdprog.qrg_detail ,'') = ''
                                        then ''
                                        else
                                                'H. 生產進度/人數: ' +  tbl_test_prdprog.qrg_detail 
                                        end   

                                        + '   ' +
                                                                                case when
                                        isnull(tbl_test_p4oth.qrg_detail ,'') = ''
                                        then ''
                                        else
                                                'Z. 其他: ' +  tbl_test_p4oth.qrg_detail 
                                        end   

                                        )) 
                                  END as 'p4_rmk'  ,
                                  ttt.qri_file as 'sign',
                                  tttt.qri_file as 'suppliersign'
                                
                from QCRPTHDR QCH 
                                LEFT JOIN VNBASINF ON qrh_venno = vbi_venno 
                                LEFT JOIN CUBASINF priCust on qrh_cus1no = priCust.cbi_cusno 
                                LEFT JOIN CUBASINF secCust on qrh_cus2no = secCust.cbi_cusno 
                                LEFT JOIN qcrptdtl on qrh_tmprptno = qrd_tmprptno 
                                left join qcrptgnl tbl_insp_accor
                                        on qrg_tmprptno = qrd_tmprptno    
                                                                and  qrg_inspcde='insp_accor'
                                left join qcrptgnl tbl_check_p3Doth
                                        on tbl_check_p3Doth.qrg_tmprptno = qrd_tmprptno    
                                                                and  tbl_check_p3Doth.qrg_inspcde='check_p3Doth'
                                left join qcrptgnl tbl_check_p3Epack
                                        on tbl_check_p3Epack.qrg_tmprptno = qrd_tmprptno    
                                                                and  tbl_check_p3Epack.qrg_inspcde='check_p3Epack'
                                left join qcrptgnl tbl_result_p5remark
                                        on tbl_result_p5remark.qrg_tmprptno = qrd_tmprptno    
                                                                and  tbl_result_p5remark.qrg_inspcde='result_p5remark'
                                left join qcrptgnl tbl_result_followup
                                        on tbl_result_followup.qrg_tmprptno = qrd_tmprptno    
                                                                and  tbl_result_followup.qrg_inspcde='result_followup'

                                left join qcrptgnl tbl_check_p3Fprdchk
                                        on tbl_check_p3Fprdchk.qrg_tmprptno = qrd_tmprptno    
                                                                and  tbl_check_p3Fprdchk.qrg_inspcde='check_p3Fprdchk'

                                left join qcrptgnl tbl_check_p3Fprdspc
                                        on tbl_check_p3Fprdspc.qrg_tmprptno = qrd_tmprptno    
                                                                and  tbl_check_p3Fprdspc.qrg_inspcde='check_p3Fprdspc'


                                left join qcrptgnl tbl_test_dropbox
                                        on tbl_test_dropbox.qrg_tmprptno = qrd_tmprptno    
                                                                and  tbl_test_dropbox.qrg_inspcde='test_dropbox'
                                left join qcrptgnl tbl_test_adhesion
                                        on tbl_test_adhesion.qrg_tmprptno = qrd_tmprptno    
                                                                and  tbl_test_adhesion.qrg_inspcde='test_adhesion'
                                left join qcrptgnl tbl_test_humidity
                                        on tbl_test_humidity.qrg_tmprptno = qrd_tmprptno    
                                                                and  tbl_test_humidity.qrg_inspcde='test_humidity'
                                left join qcrptgnl tbl_test_tilt
                                        on tbl_test_tilt.qrg_tmprptno = qrd_tmprptno    
                                                                and  tbl_test_tilt.qrg_inspcde='test_tilt'
                                left join qcrptgnl tbl_test_function
                                        on tbl_test_function.qrg_tmprptno = qrd_tmprptno    
                                                                and  tbl_test_function.qrg_inspcde='test_function'
                                left join qcrptgnl tbl_test_barcode
                                        on tbl_test_barcode.qrg_tmprptno = qrd_tmprptno    
                                                                and  tbl_test_barcode.qrg_inspcde='test_barcode'
                                left join qcrptgnl tbl_test_mattyp
                                        on tbl_test_mattyp.qrg_tmprptno = qrd_tmprptno    
                                                                and  tbl_test_mattyp.qrg_inspcde='test_mattyp'
                                left join qcrptgnl tbl_test_prdprog
                                        on tbl_test_prdprog.qrg_tmprptno = qrd_tmprptno    
                                                                and  tbl_test_prdprog.qrg_inspcde='test_prdprog'
                                left join qcrptgnl tbl_test_p4oth
                                        on tbl_test_p4oth.qrg_tmprptno = qrd_tmprptno    
                                                                and  tbl_test_p4oth.qrg_inspcde='test_p4oth'


left join (SELECT 
qri_file
from qcrptimg   
                LEFT JOIN QCRPTCDE 
                ON qri_inspcde =qrc_inspcde
where  qri_tmprptno = @TmpRPTNo 
                and qrc_rptimgdis_group <= 50
                        and qri_inspcde = 'result_qcsign'
                                ) ttt                         on 1=1

left join          (               SELECT 
qri_file
from qcrptimg   
                LEFT JOIN QCRPTCDE 
                ON qri_inspcde =qrc_inspcde
where  qri_tmprptno = @TmpRPTNo 
                and qrc_rptimgdis_group <= 50
                                and qri_inspcde = 'result_suppliersign'
                                ) tttt on 1=1

                                --left join qcrptcde 
                                --             on tbl_insp_accor.qrg_inspcde=qcrptcde.qrc_inspcde
                where  qrh_tmprptno = @TmpRPTNo 
                                                                


drop table #ponum
drop table #ponum2
drop table #ttt

                END








GO
GRANT EXECUTE ON [dbo].[sp_select_qcrpthdr1] TO [ERPUSER] AS [dbo]
GO
