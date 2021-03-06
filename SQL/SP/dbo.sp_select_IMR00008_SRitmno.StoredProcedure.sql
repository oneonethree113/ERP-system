/****** Object:  StoredProcedure [dbo].[sp_select_IMR00008_SRitmno]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMR00008_SRitmno]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMR00008_SRitmno]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
Create Date   	: 
Last Modified  	: 17 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
17 July 2003	Allan Yuen		For Merge Porject, disable company code
15 July 2005	Allan Yuen		Change read color code from icf_colcde -> icf_vencol
18 Oct 2005	Lester Wu		Show Vendor Item No
01 Mar 2006	Lester Wu		Show first 2 characters of IM Color Information Line Code
03 Mar 2006	Lester Wu		Show Our Color Code instead of Vendor Color
*/

/********************************************************************************
Author:		Louis Siu
Date:		15th Jan, 2002
Description:	Bar Code Printing Report - Create TempTable for Show Report by Item No
*********************************************************************************/
--

	CREATE PROCEDURE [dbo].[sp_select_IMR00008_SRitmno] 

	@cocde 		nvarchar(6),
	@credat		datetime,
	@startNo 		int,
	@creusr		nvarchar(30)

AS
	
/*
	@sql  nvarchar(20)
	set @sql = cast(getdate() as nvarchar(20))
	set @sql = cast(@@DBTS as int)
*/

	-- * Create Temporary Table------------------------------------------------------------------------------------------------------------------------------------
	CREATE TABLE #tempTable
	(                 
 	temp_cocde	nvarchar(6)	NULL,                                                                                                                                                                                                                                     
	temp_itmno 	nvarchar(20) 	NULL,
	temp_engdsc 	nvarchar(800)	NULL,
	temp_venno 	nvarchar(6) 	NULL,
	temp_lnecde 	nvarchar(10)	NULL,
	temp_colcde 	nvarchar(30) 	NULL,
             temp_coldsc	nvarchar(200) 	NULL, 
	-------------- 
	temp_venitm	nvarchar(30)	NULL,	-- Lester Wu 2005-10-18, show vendor color code
	temp_imlnecde	varchar(2)		NULL	-- Lester Wu 2006-03-01
	) ON [PRIMARY]     

	
	------------------------------------------------------------------------------------------------------------------------------------------------------------------
	DECLARE
	@sql 	nvarchar(2000),
	@i 	int

	IF @startNo >= 2
	begin
		set @i = 1
		while @i < @startNo 
		begin
		                INSERT INTO #tempTable (temp_cocde,temp_itmno,temp_engdsc,temp_venno,temp_lnecde,temp_colcde,temp_coldsc, temp_venitm,temp_imlnecde) 
			--VALUES ('','','','','','','')
			VALUES ('','','','','','','','', '')

		set @i  = @i + 1
		end 		
	end



	--SET @sql = 'INSERT INTO #tempTable select ibi_cocde, ibi_itmno, ibi_engdsc, ibi_venno, ibi_lnecde, icf_colcde, icf_coldsc from IMBASINF , IMCOLINF, IMRTEMP where ibi_itmno = imr_itmno and ibi_itmno *= icf_itmno and ibi_cocde ='  + '''' +  @cocde +''' and imr_credat =' + '''' +  @credat + ''' and imr_creusr =' + '''' +  @creusr + '''' 
--	INSERT INTO #tempTable select ibi_cocde, ibi_itmno, ibi_engdsc, ibi_venno, ibi_lnecde, icf_colcde, icf_coldsc from IMBASINF , IMCOLINF, IMRTEMP where ibi_itmno = imr_itmno and ibi_itmno *= icf_itmno and ibi_cocde = @cocde and imr_credat = @credat and imr_creusr = @creusr 
---	INSERT INTO #tempTable select ' ', ibi_itmno, ibi_engdsc, ibi_venno, ibi_lnecde, icf_colcde, icf_coldsc from IMBASINF , IMCOLINF, IMRTEMP where ibi_itmno = imr_itmno and ibi_itmno *= icf_itmno and  imr_credat = @credat and imr_creusr = @creusr 
	INSERT INTO #tempTable 
	select ' ', ibi_itmno, ibi_engdsc, ibi_venno, ibi_lnecde, 
		--icf_vencol, 	Show Our Color Code instead of Vendor Color
		icf_colcde, 
		icf_coldsc , ivi_venitm
	-- Lester Wu 2006-03-01
	, isnull(left(icf_lnecde,2),'') as 'icf_lnecde'
	from IMBASINF 
	left join IMCOLINF(nolock) on icf_itmno = ibi_itmno
	, IMRTEMP , IMVENINF

	where ibi_itmno = imr_itmno  and  imr_credat = @credat and imr_creusr = @creusr 
	and ibi_itmno = ivi_itmno



--	select @sql
	--execute(@sql)

	-- * For test only
--	INSERT INTO #tempTable select ibi_cocde, ibi_itmno, ibi_engdsc, ibi_venno, ibi_lnecde, icf_colcde, icf_coldsc from IMBASINF , IMCOLINF where ibi_itmno in ('01060475','1233456') and icf_itmno in ('01060475','1233456') and ibi_itmno = icf_itmno order by ibi_itmno

DELETE  FROM IMRTEMP WHERE imr_credat = @credat and imr_creusr = @creusr

	-- * Select data from Temporary  Table
	SELECT temp_cocde, temp_itmno, convert(varchar(200),temp_engdsc) as 'temp_engdsc', temp_venno, temp_lnecde, temp_colcde, temp_coldsc, temp_venitm
	-- Lester Wu 2006-03-01
	,temp_imlnecde
	FROM #tempTable order by temp_itmno






GO
GRANT EXECUTE ON [dbo].[sp_select_IMR00008_SRitmno] TO [ERPUSER] AS [dbo]
GO
