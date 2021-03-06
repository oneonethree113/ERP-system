/****** Object:  StoredProcedure [dbo].[temp_sp_select_MSR00020]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[temp_sp_select_MSR00020]
GO
/****** Object:  StoredProcedure [dbo].[temp_sp_select_MSR00020]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









-- Checked by Allan Yuen at 27/07/2003

--------------------------------------------------------------------
-- Add Searching cryteria by Lester Wu at 05 Feb 2004
--"Customer Number", "PO Status" , "Sort By"
--------------------------------------------------------------------
/*
-----------------------------------------------------------------------------------------------------------------------------------------------
Modification History
-----------------------------------------------------------------------------------------------------------------------------------------------
Modified On	Modified By	Description
-----------------------------------------------------------------------------------------------------------------------------------------------
2004/12/20		Lester Wu		Rearrange of the order of where condition's range option checking
						Remark : @optCust = 'Y' should be checked before range checking
-----------------------------------------------------------------------------------------------------------------------------------------------

*/


CREATE       PROCEDURE [dbo].[temp_sp_select_MSR00020]


	@cocde 		nvarchar(6),
	@VenFm		nvarchar(6),
	@VenTo		nvarchar(6),
	@POfm		nvarchar(10),
	@POto		nvarchar(10),
	@IssDateFm	nvarchar(30),
	@IssDateTo	nvarchar(30),
	@ShipDateFm	nvarchar(30),
	@ShipDateTo	nvarchar(30),
--------------------------------
-- Lester Wu -2004/02/05--
	@CustNoFm	nvarchar(20),
	@CustNoTo	nvarchar(20),
	@Status		nvarchar(3),
	@Sortby		nvarchar(1),
--------------------------------
	@user		nvarchar(30)
AS

Declare 
	@optVen		nvarchar(1),
	@optPO		nvarchar(1),
	@optID		nvarchar(1),
	@optSD		nvarchar(1)
------------------------------
-- Lester -- 2004/02/05 --
	,
	@optCust		nvarchar(1)

set @optCust = 'N'
	If @CustNoFm='' and @CustNoTo=''
	begin
		set @optCust='Y'
	end
-----------------------------

set @optVen = 'N'
	If @VenFm = '' and @VenTo = ''
	begin
		set @optVen = 'Y'
	end

set @optPO = 'N'
	If @POfm = '' and @POto = ''
	begin
		set @optPO = 'Y'
	end

set @optID = 'N'
	If @IssDateFm = '' and @IssDateTo = ''
	begin
		set @optID = 'Y'
	end

set @optSD = 'N'
	If @ShipDateFm = '' and @ShipDateTo = ''
	begin
		set @optSD = 'Y'
	end
------------------------------------------------------------

--Lester Wu 2005-04-02, retrieve company name from database----------------------------------------
declare @compName varchar(100)
set @compName = 'UNITED CHINESE GROUP'
if @cocde<>'UC-G'
begin
	select @compName = yco_conam from sycominf where yco_cocde = @cocde
end
---------------------------------------------------------------------------------------------------------------------


while 0 < ( 22 -len(@compName)/2 )
begin 
set @compName = ' ' +  @compName
end


SELECT 
	-- Parameter
	@cocde as 'cocde',
	@VenFm as 'VenFm',		@VenTo as 'VenTo',
	@POfm as 'POfm',		@POto as 'POto',
	convert( varchar(10), @IssDateFm, 101)  as 'IssDateFm',	
	convert( varchar(10), @IssDateTo, 101)  as 'IssDateTo',	
	convert( varchar(10), @ShipDateFm, 101)  as 'ShipDateFm',	
	convert( varchar(10), @ShipDateTo, 101)  as 'ShipDateTo',	
	------------------------------------------------
	-- Lester Wu 2004/02/05 -----------------
	@CustNoFm as 'CustNoFm',
	@CustNoTo as 'CustNoTo',
	@Status as 'Status',
	@Sortby as 'Sortby',
	-----------------------------------------------
	@user as 'user',

	--  POORDHDR
	poh_purord,	poh_ordno,
	convert( varchar(10), poh_issdat, 101)  as 'poh_issdat',	
	convert( varchar(10), poh_credat, 101)  as 'poh_credat',	
	convert( varchar(10), poh_shpstr, 101)  as 'poh_shpstr',	
	convert( varchar(10), poh_shpend, 101)  as 'poh_shpend',	
	poh_curcde,	
	poh_ttlamt,	poh_netamt,
	
	-- VNBASINF
	vbi_venno,		vbi_vensna,	

	-- CUBASINF
	p.cbi_cusno as 'PriCustShort',	p.cbi_cussna as 'pri_name',		
	s.cbi_cusno as 'SecCustShort',	s.cbi_cussna as 'sec_name',
----
	poh_pursts
	,@compName as 'compName'

FROM POORDHDR
left join SCORDHDR on poh_cocde = soh_cocde and poh_ordno = soh_ordno
left join CUBASINF p on soh_cus1no = p.cbi_cusno 
left join CUBASINF s on soh_cus2no = s.cbi_cusno 
left join VNBASINF on poh_venno = vbi_venno 
WHERE	
((@cocde='UC-G' and poh_cocde<>'MS') or poh_cocde=@cocde)
AND	( @optVen = 'Y' or (@optVen = 'N' and poh_venno between @VenFm and @VenTo))
AND	( @optPO = 'Y' or (@optPO = 'N' and poh_purord between @POfm and @POto))
AND	( @optID = 'Y' or (@optID = 'N' and poh_credat between @IssDateFm and @IssDateTo))
AND 	( @optSD = 'Y' or (@optSD = 'N' and poh_shpstr >= @ShipDateFm and poh_shpend <= @ShipDateTo))
AND	(@optCust = 'Y' or (@optCust = 'N' and soh_cus1no between @CustNoFm and @CustNoTo))
AND	(@Status='' or (@Status=poh_pursts))
ORDER BY case @Sortby when 'C' then p.cbi_cussna else poh_purord end 
-----------------------------------------




















GO
GRANT EXECUTE ON [dbo].[temp_sp_select_MSR00020] TO [ERPUSER] AS [dbo]
GO
