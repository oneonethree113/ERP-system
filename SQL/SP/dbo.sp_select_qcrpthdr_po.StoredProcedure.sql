/****** Object:  StoredProcedure [dbo].[sp_select_qcrpthdr_po]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_qcrpthdr_po]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_qcrpthdr_po]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  PROCEDURE [dbo].[sp_select_qcrpthdr_po] 
@TmpRPTNo as nvarchar(30)

AS

BEGIN


SET NOCOUNT  OFF   
  
SET ANSI_WARNINGS   OFF   


declare @itmno  nvarchar(30)
declare @cus_itmno  nvarchar(30)




set @itmno  = (select qrh_itmno from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
if ltrim(rtrim(@itmno )) = '' 
begin
set @itmno  = (select qrh_othitmno from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
end

set @itmno  =Replace(@itmno,'–','-')


set @cus_itmno  = (select qrh_cusitm from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
set @cus_itmno  = ltrim(rtrim(@cus_itmno ))
set @cus_itmno  =Replace(@cus_itmno,'–','-')


declare @po_str nvarchar(300)
declare @po_str_split nvarchar(1000)

declare @cuspo_str_split nvarchar(1000)
declare @cusitm_str_split nvarchar(1000)

declare @shpqty_str_split nvarchar(1000)

declare @morepckqty_str nvarchar(30)
declare @pckqty_str_split nvarchar(30)

declare @morepo  nvarchar(1000)
declare @morepo_ori  nvarchar(1000)

declare @morepo_shpqty  nvarchar(1000)

declare @qrd_mtrpc int

set @po_str = (select qrh_postr from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
set @po_str =Replace(@po_str , ',' , ''',''')
set @po_str = '''' + @po_str  + ''''

set @po_str_split = (select qrh_postr from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
SET @po_str_split = LTRIM(RTRIM(@po_str_split))
SET @po_str_split = REPLACE(@po_str_split,'，',',')
IF SUBSTRING(@po_str_split,LEN(@po_str_split),LEN(@po_str_split)) = ',' 
BEGIN
SET @po_str_split =SUBSTRING(@po_str_split,1,LEN(@po_str_split)-1)
END


set @cuspo_str_split = (select qrh_cuspostr from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
SET @cuspo_str_split = LTRIM(RTRIM(@cuspo_str_split))
SET @cuspo_str_split = REPLACE(@cuspo_str_split,'，',',')
IF SUBSTRING(@cuspo_str_split,LEN(@cuspo_str_split),LEN(@cuspo_str_split)) = ',' 
BEGIN
SET @cuspo_str_split =SUBSTRING(@cuspo_str_split,1,LEN(@cuspo_str_split)-1)
END


set @cusitm_str_split = (select qrh_cusitm from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
SET @cusitm_str_split = LTRIM(RTRIM(@cusitm_str_split))
SET @cusitm_str_split = REPLACE(@cusitm_str_split,'，',',')
IF SUBSTRING(@cusitm_str_split,LEN(@cusitm_str_split),LEN(@cusitm_str_split)) = ',' 
BEGIN
SET @cusitm_str_split =SUBSTRING(@cusitm_str_split,1,LEN(@cusitm_str_split)-1)
END

set @shpqty_str_split = (select qrd_poqty from  QCRPTDTL where qrd_tmprptno=@TmpRPTNo )
SET @shpqty_str_split = LTRIM(RTRIM(@shpqty_str_split))
SET @shpqty_str_split = REPLACE(@shpqty_str_split,'，',',')
IF SUBSTRING(@shpqty_str_split,LEN(@shpqty_str_split),LEN(@shpqty_str_split)) = ',' 
BEGIN
SET @shpqty_str_split =SUBSTRING(@shpqty_str_split,1,LEN(@shpqty_str_split)-1)
END

set @pckqty_str_split = (select qrd_pckqty from  QCRPTDTL where qrd_tmprptno=@TmpRPTNo )
SET @pckqty_str_split = LTRIM(RTRIM(@pckqty_str_split))
SET @pckqty_str_split = REPLACE(@pckqty_str_split,'，',',')

set @morepckqty_str = (select qrd_morepckqty from  QCRPTDTL where qrd_tmprptno=@TmpRPTNo )
SET @morepckqty_str = LTRIM(RTRIM(@morepckqty_str))
SET @morepckqty_str= REPLACE(@morepckqty_str,'，',',')


set @qrd_mtrpc  = (select isnull(qrd_mtrpc,1) from  QCRPTDTL where qrd_tmprptno=@TmpRPTNo )

set @morepo   = (select qrh_morepo from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
if rtrim(ltrim(@morepo  )) = ''
begin
set @morepo   = (select qrh_othpostr from  QCRPTHDR where qrh_tmprptno=@TmpRPTNo )
end

SET @morepo = LTRIM(RTRIM(@morepo))

SET @morepo = REPLACE(@morepo,'；',';')

IF SUBSTRING(@morepo,LEN(@morepo),LEN(@morepo)) = ';' 
BEGIN

SET @morepo =SUBSTRING(@morepo,1,LEN(@morepo)-1)
END

set @morepo_ori = @morepo  

set @morepo_shpqty = (select qrd_morepoqty from  QCRPTDTL where qrd_tmprptno=@TmpRPTNo )

SET @morepo_shpqty = LTRIM(RTRIM(@morepo_shpqty))

SET @morepo_shpqty = REPLACE(@morepo_shpqty,'；',';')

IF SUBSTRING(@morepo_shpqty,LEN(@morepo_shpqty),LEN(@morepo_shpqty)) = ';' 
BEGIN

SET @morepo_shpqty =SUBSTRING(@morepo_shpqty,1,LEN(@morepo_shpqty)-1)
END

-------------------------
-------------------------
create table #ponum
(
tmp_po nvarchar(30),
tmp_cuspo nvarchar(30),
tmp_cusitm nvarchar(30),
tmp_shpqty int,
tmp_pckqty int
)

DECLARE @CIndex smallint
DECLARE @CIndex2 smallint
DECLARE @CIndex3 smallint
DECLARE @CIndex4 smallint
DECLARE @CIndex5 smallint

WHILE (@po_str_split<>''  )

	BEGIN
	--select @po_str_split as '@po_str_split'
	SET @CIndex=CHARINDEX(',',@po_str_split)
	SET @CIndex2=CHARINDEX(',',@shpqty_str_split)
	SET @CIndex3=CHARINDEX(',',@cuspo_str_split)
	--SET @CIndex4=CHARINDEX(',',@cusitm_str_split)
	SET @CIndex5=CHARINDEX(',',@pckqty_str_split)


	IF @CIndex=0 SET @CIndex=LEN(@po_str_split)+1
	IF @CIndex2=0 SET @CIndex2=LEN(@shpqty_str_split)+1
	IF @CIndex3=0 SET @CIndex3=LEN(@cuspo_str_split)+1
	--IF @CIndex4=0 SET @CIndex4=LEN(@cusitm_str_split)+1
	IF @CIndex5=0 SET @CIndex5=LEN(@pckqty_str_split)+1

	--select @shpqty_str_split as '@shpqty_str_split'
	--select @CIndex2-1 as '@CIndex2-1'
	--select SUBSTRING('3996',1,4)

	INSERT INTO #ponum (tmp_po,tmp_cuspo,tmp_cusitm,tmp_shpqty,tmp_pckqty)
	values (
		SUBSTRING(@po_str_split,1,@CIndex-1), 
		SUBSTRING(@cuspo_str_split,1,@CIndex3-1), 
		@cusitm_str_split,
		SUBSTRING(@shpqty_str_split,1,@CIndex2-1),
		SUBSTRING(@pckqty_str_split,1,@CIndex5-1)
		)
   
	IF @CIndex=LEN(@po_str_split)+1			BREAK
	IF CHARINDEX(',',@po_str_split) = 0     BREAK

	SET @po_str_split=SUBSTRING(@po_str_split,@CIndex+1,LEN(@po_str_split)-@CIndex)
	SET @cuspo_str_split=SUBSTRING(@cuspo_str_split,@CIndex3+1,LEN(@cuspo_str_split)-@CIndex3)
	--SET @cusitm_str_split=SUBSTRING(@cusitm_str_split,@CIndex4+1,LEN(@cusitm_str_split)-@CIndex4)
	SET @shpqty_str_split=SUBSTRING(@shpqty_str_split,@CIndex2+1,LEN(@shpqty_str_split)-@CIndex2)
	SET @pckqty_str_split=SUBSTRING(@pckqty_str_split,@CIndex5+1,LEN(@pckqty_str_split)-@CIndex5)

END

 

--select * from #ponum


Declare @SQL VarChar(4500)
        


----------------------
------------------





----------------------------
-------------------------
create table #ponum2
(
tmp_po nvarchar(30),
tmp_shpqty int,
tmp_pckqty int
)

DECLARE @CIndexmore smallint
DECLARE @CIndexmore2 smallint
DECLARE @CIndexmore3 smallint


WHILE (@morepo <>''  )

	BEGIN

	SET @CIndexmore=CHARINDEX(';',@morepo )
	SET @CIndexmore2=CHARINDEX(';',@morepo_shpqty)
	SET @CIndexmore3=CHARINDEX(';',@morepckqty_str)


	IF @CIndexmore=0 SET @CIndexmore=LEN(@morepo )+1
	IF @CIndexmore2=0 SET @CIndexmore2=LEN(@morepo_shpqty)+1
	IF @CIndexmore3=0 SET @CIndexmore3=LEN(@morepckqty_str)+1
	--SELECT SUBSTRING(@morepo ,1,@CIndexmore-1), SUBSTRING(@morepo_shpqty,1,@CIndexmore2-1)
  
	  INSERT INTO #ponum2 (tmp_po,tmp_shpqty,tmp_pckqty)
	Values (SUBSTRING(@morepo ,1,@CIndexmore-1), SUBSTRING(@morepo_shpqty,1,@CIndexmore2-1), SUBSTRING(@morepckqty_str,1,@CIndexmore3-1))


	IF @CIndexmore=LEN(@morepo )+1 BREAK
	IF CHARINDEX(';',@morepo ) = 0   BREAK

	--SELECT SUBSTRING(@morepo ,@CIndexmore+1,LEN(@morepo )-@CIndexmore)
	--SELECT SUBSTRING(@morepo_shpqty,@CIndexmore2+1,LEN(@morepo_shpqty)-@CIndexmore2)
	SET @morepo =SUBSTRING(@morepo ,@CIndexmore+1,LEN(@morepo )-@CIndexmore)
	SET @morepo_shpqty=SUBSTRING(@morepo_shpqty,@CIndexmore2+1,LEN(@morepo_shpqty)-@CIndexmore2)
	SET @morepckqty_str=SUBSTRING(@morepckqty_str,@CIndexmore3+1,LEN(@morepckqty_str)-@CIndexmore3)

END


 
--  select * from #ponum2

--select  @morepo_ori
----------------------
-------------------------
------------------
--SELECT * FROM #ponum2
--SELECT   @itmno 

select  pod_purord pod_purord ,pod_cuspno pod_cuspno,pod_cusitm pod_cusitm , pod_ordqty pod_ordqty, tmp_shpqty tmp_shpqty , tmp_pckqty tmp_pckqty
from
(
	select  UPPER(tmp_po) as  'pod_purord',
		isnull(tmp_cuspo,'') as 'pod_cuspno',
		isnull(tmp_cusitm,'') as 'pod_cusitm' ,
		pod_ordqty*@qrd_mtrpc as  'pod_ordqty',
		tmp_shpqty as 'tmp_shpqty ',
		tmp_pckqty as 'tmp_pckqty'
	from POORDDTL  left join  #ponum
		on pod_purord =tmp_po
		AND pod_cusitm = CASE LEN(@cus_itmno) WHEN 0 
							THEN pod_cusitm
							ELSE @cus_itmno
						  END 
	WHERE pod_itmno = @itmno  
		and  @po_str   like '%' +   pod_purord + '%'         
		and tmp_shpqty is not null                           
		and pod_ttlctn <> 0

	union


	select UPPER(tmp_po) as  'pod_purord',
		isnull(poh_cuspno,'') as 'pod_cuspno',
		isnull(pod_cusitm,'') as 'pod_cusitm' ,
		isnull(pod_ordqty,0)*@qrd_mtrpc as  'pod_ordqty',
		tmp_shpqty as 'tmp_shpqty ',
		tmp_pckqty  as 'tmp_pckqty'
	from #ponum2
		left join   POORDDTL  
			on pod_purord =tmp_po 
				and  pod_itmno = @itmno
				AND pod_cusitm = CASE LEN(@cus_itmno) WHEN 0 
									THEN pod_cusitm
									ELSE @cus_itmno
								 END 
		left join poordhdr on pod_purord = poh_purord
				and  pod_itmno = @itmno

	WHERE pod_itmno = @itmno  
		and @morepo_ori      like '%' +   pod_purord + '%'    
		and tmp_shpqty  is not null             
		and pod_ordqty <> 0
		and pod_ttlctn <> 0
                                     
) t2

        
--select * from #ponum
--select * from  #ponum2

drop table #ponum
drop table #ponum2
END
                        


GO
GRANT EXECUTE ON [dbo].[sp_select_qcrpthdr_po] TO [ERPUSER] AS [dbo]
GO
