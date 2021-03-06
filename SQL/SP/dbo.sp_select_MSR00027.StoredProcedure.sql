/****** Object:  StoredProcedure [dbo].[sp_select_MSR00027]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MSR00027]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MSR00027]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







-- Checked by Allan Yuen at 27/07/2003

/*****************************************************************************************************************************************
Modification History
******************************************************************************************************************************************
Modified on		Modified by		Description
******************************************************************************************************************************************
17 Mar 2005		Lester Wu			Replace "ALL" with "UC-G"
						Retrieve company info from database
******************************************************************************************************************************************
*/
CREATE  PROCEDURE [dbo].[sp_select_MSR00027]

	@cocde 		nvarchar	(6),
	@containFm	nvarchar	(20),
	@containTo	nvarchar	(20),
	@scFm		nvarchar	(20),
	@scTo		nvarchar 	(20),
	@jobFm		nvarchar 	(20),
	@jobTo		nvarchar 	(20),
	@itmFm	 	nvarchar 	(20),
	@itmTo 		nvarchar 	(20),
	@custFm		nvarchar 	(20),
	@custTo		nvarchar 	(20),
	@ST		nvarchar 	(1),
	@user		nvarchar 	(30)
AS
-----------------------------------------------------------
Declare		
	@containOpt	nvarchar	(1),
	@scOpt	nvarchar	(1),
	@itmOpt	nvarchar 	(1),
	@jobOpt	nvarchar 	(1),
	@custOpt	nvarchar 	(1)

SET @containOpt = 'N'
	If @containFm <> '' or @containTo <> ''
	begin
		SET @containOpt = 'Y'
	end
	
SET @scOpt = 'N'
	If @scFm <> '' or @scTo <> ''
	begin
		SET @scOpt = 'Y'
	end

SET @itmOpt = 'N'
	If @itmFm <> '' or @itmTo <> ''
	begin
		SET @itmOpt = 'Y'
	end

SET @jobOpt = 'N'
	If @jobFm <> '' or @jobTo <> ''
	begin
		SET @jobOpt = 'Y'
	end

SET @custOpt = 'N'
	If @custFm <> '' or @custTo <> ''
	begin
		SET @custOpt = 'Y'
	end
--------------------------------------------------------

------------------------------------------------------------------------------------------------------------------------------------------------------
--Lester Wu 2005/03/17 -- Retrieve Company Name from database
------------------------------------------------------------------------------------------------------------------------------------------------------
DECLARE
@yco_conam	varchar(100)

set @yco_conam = 'UNITED CHINESE GROUP'

if @cocde <> 'UC-G' 
BEGIN
	select @yco_conam=yco_conam from SYCOMINF(NOLOCK) where yco_cocde = @cocde
END

------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------


Select 
	-- Parameter 
	@cocde,
	@containFm,	@containTo,
	@scFm,		@scTo,
	@itmFm,		@itmTo,
	@jobFm,		@jobTo,
	@custFm,		@custTo,
	@ST,

	groupKey = ltrim(hid_itmno) +  ltrim(hid_untcde) + ltrim(str(hid_inrctn)) + ltrim(str(hid_mtrctn)),

	-- SHIPGDTL
	hid_jobno, 
	hid_ctrcfs,
	hid_invno, 
	hid_itmno,
	hid_cusitm,
	hid_shpqty, 
	hid_colcde,
	hid_itmdsc,
	hid_inrctn,
	hid_mtrctn,
	hid_shpno,


	-- SCORDDTL
	sod_ordno,
	sod_ordqty, 
	
	-- SHINVHDR
	hiv_invdat,

	-- SYSETINF
	pckunt = ysi_dsc,
	@yco_conam as 'compName' --Retrieve company information from database


From SHIPGDTL, 
SHINVHDR, 
SCORDDTL
left join SYSETINF on sod_pckunt = ysi_cde and  ysi_typ = '05'
 --, SYSETINF
Where 	
((@cocde<>'UC-G' and hid_cocde=@cocde) or (@cocde='UC-G' and hid_cocde<>'MS') ) 
and	hid_cocde = hiv_cocde
And 	hid_shpno = hiv_shpno
And 	hid_invno = hiv_invno
And 	hid_cocde = sod_cocde
And 	hid_ordno = sod_ordno
And 	hid_ordseq = sod_ordseq

--And	sod_pckunt *= ysi_cde and  ysi_typ = '05'

And 	((@containOpt = 'Y' and hid_ctrcfs between @containFm and @containTo) or @containOpt = 'N')
And 	((@scOpt = 'Y' and sod_ordno between @scFm and @scTo) or @scOpt = 'N')
And 	((@itmOpt = 'Y' and hid_itmno between @itmFm and @itmTo) or @itmOpt = 'N')
And 	((@jobOpt = 'Y' and hid_jobno between @jobFm and @jobTo) or @jobOpt = 'N')
And 	((@custOpt = 'Y' and hid_cusitm between @custFm and @custTo) or @custOpt = 'N')

Order by 
	hid_itmno,
	Case @ST when 'S' then sod_ordno when 'J' then hid_jobno when 'C' then hid_ctrcfs when 'I' then hid_invno else '' end,
	hid_ordno, hid_jobno, hid_ctrcfs, hiv_invno








GO
GRANT EXECUTE ON [dbo].[sp_select_MSR00027] TO [ERPUSER] AS [dbo]
GO
