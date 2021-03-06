/****** Object:  StoredProcedure [dbo].[sp_select_MSR00018]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MSR00018]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MSR00018]    Script Date: 09/29/2017 11:53:53 ******/
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

CREATE  PROCEDURE [dbo].[sp_select_MSR00018]

@Cocde 		nvarchar(10),
@hnh_nottyp	nvarchar(100),
@hnh_refno_Fm	nvarchar(20),
@hnh_refno_To	nvarchar(20),
@hnh_noteno_Fm	nvarchar(20),
@hnh_noteno_To	nvarchar(20),
@hnh_issdate_Fm	nvarchar(10),
@hnh_issdate_To	nvarchar(10),
@hnh_sortby	nvarchar(1),
@Usrid		nvarchar(30)

AS


Declare
@Opt1	nvarchar(1),
@Opt2	nvarchar(1),
@Opt3	nvarchar(1)

Set @Opt1= 'N'
If @hnh_refno_Fm <> '' or @hnh_refno_To <> ''
begin
	Set @Opt1 = 'Y'
end

Set @Opt2= 'N'
If @hnh_noteno_Fm <> '' or @hnh_noteno_To <> ''
begin
	Set @Opt2 = 'Y'
end

Set @Opt3= 'N'
If @hnh_issdate_Fm <> '' or @hnh_issdate_To <> ''
begin
	Set @Opt3 = 'Y'
end


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


select 
hnh_pricus, 
cbi_cussna,
hnh_noteno,
hnh_nottyp,
hnh_issdat,
hnh_refno,
hnd_itmno,


isnull(hnd_pckunt,'') + ' / ' +
cast(isnull(hnd_inrctn,0) as nvarchar(10)) + ' / ' +
cast(isnull(hnd_mtrctn,0) as nvarchar(10)) + ' / ' +
cast(isnull(hnd_cft,0) as nvarchar(10)) as 'hnd_pckunt',


hnd_colcde,
hnd_adjqty,
hnd_curcde,
hnd_adjprc,
hnd_adjqty * hnd_adjprc as 'AdjAmt',
hnd_upd,
hnd_ordno,

@cocde,
@hnh_nottyp,
@hnh_refno_Fm,
@hnh_refno_To,
@hnh_noteno_Fm,
@hnh_noteno_To,
@hnh_issdate_Fm,
@hnh_issdate_To,
@hnh_sortby,
@yco_conam as 'compName' --Retrieve company information from database

FROM SHCBNHDR


LEFT JOIN SHCBNDTL on hnh_cocde = hnd_cocde and hnh_noteno = hnd_noteno 
--LEFT JOIN CUBASINF on hnh_cocde = cbi_cocde and hnh_pricus = cbi_cusno
LEFT JOIN CUBASINF on hnh_pricus = cbi_cusno


Where	--2004/02/16 Lester Wu
	--hnh_cocde = (@cocde)
	--Lester Wu 2005-03-17 replace ALL with UC-G
	--(@cocde='ALL' or hnh_cocde=@cocde)
	((@cocde='UC-G' and hnh_cocde<>'MS') or hnh_cocde=@cocde) 

and 	(hnh_nottyp= left(@hnh_nottyp,1)  or left(@hnh_nottyp,1)='B')
and	((@Opt1 = 'Y' and hnh_refno between @hnh_refno_Fm and @hnh_refno_To) or @Opt1 = 'N')
and	((@Opt2 = 'Y' and hnh_noteno  between @hnh_noteno_Fm and @hnh_noteno_To) or @Opt2 = 'N')
and	((@Opt3 = 'Y' and hnh_issdat between  @hnh_issdate_Fm + ' 00:00:00'  and @hnh_issdate_To + ' 23:59:59.998') or @Opt3 ='N')







GO
GRANT EXECUTE ON [dbo].[sp_select_MSR00018] TO [ERPUSER] AS [dbo]
GO
