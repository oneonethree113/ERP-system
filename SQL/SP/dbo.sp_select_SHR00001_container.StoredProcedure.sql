/****** Object:  StoredProcedure [dbo].[sp_select_SHR00001_container]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SHR00001_container]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SHR00001_container]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




/***************************************************************************************************************************
Modification History
***************************************************************************************************************************
Modified on		Modified by		Description
***************************************************************************************************************************
17-Mar-2005		Lester Wu			Add Company name, address, phone, fax
29-Apr-2005		Lester Wu			Rem code to join table by customer company code (cbi_cocde)
****************************************************************************************************************************/



CREATE PROCEDURE [dbo].[sp_select_SHR00001_container]
@cocde		nvarchar(6),
@from		nvarchar(20),
@to		nvarchar(20)

AS
Begin

------------------------------------------------------------------------------------------------------------------------------------------------------
--Lester Wu 2005/03/03 -- Retrieve Company Name, Short Name, Address, Phone No, Fax No, Email Address, Logo Path
------------------------------------------------------------------------------------------------------------------------------------------------------
DECLARE
@yco_conam	varchar(100),
@yco_shtnam	varchar(25),
@yco_addr		varchar(200),

@yco_phoneno	varchar(50),
@yco_faxno	varchar(50)


set @yco_conam = ''
set @yco_shtnam = ''
set @yco_addr = ''

set @yco_phoneno = ''
set @yco_faxno = ''

select
@yco_conam=yco_conam,
@yco_shtnam=yco_shtnam,
@yco_addr=yco_addr,

@yco_phoneno= yco_phoneno,
@yco_faxno = yco_faxno

from 

SYCOMINF(NOLOCK)

where
yco_cocde = @cocde
------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------


Select
	@cocde,	
                'P',
                cus.cbi_cusnam,
               	dtl.hid_ctrcfs,
	ltrim(rtrim(dtl.hid_ctrsiz)),
	dtl.hid_sealno,
	hdr.hih_crr,
	hdr.hih_crrso,
	hdr.hih_ves,
	hdr.hih_voy,
	hdr.hih_potloa,
	hdr.hih_dst,
	hdr.hih_slnonb,
	hdr.hih_arrdat,
	dtl.hid_cuspo,
	sod.sod_resppo,

---	Respective PO#
	dtl.hid_cusitm,
	dtl.hid_itmdsc,
	dtl.hid_ttlctn,
	dtl.hid_ttlvol,
---	dtl.hid_ttlnet,
	dtl.hid_ttlgrs,

---	For format 2
	dtl.hid_shpqty,
---	dtl.hid_actvol,

	hdr.hih_rvsdat,
--2005/03/17 Lester Wu -- Retrieve Company Name , Short Name , Address, Phone, Fax, Email
	@yco_conam,
	@yco_shtnam,
	@yco_addr,
	
	@yco_phoneno,
	@yco_faxno
	--

From 	SHIPGHDR hdr, SHIPGDTL dtl, CUBASINF cus, SCORDDTL sod
WHERE 	hdr.hih_cocde = dtl.hid_cocde and hdr.hih_shpno = dtl.hid_shpno
--Lester Wu 2005-04-29, rem code to join table with company code
--and	hdr.hih_cocde = cus.cbi_cocde 
-----------------------------------------
and hdr.hih_cus1no = cus.cbi_cusno
and	dtl.hid_cocde = sod.sod_cocde and dtl.hid_ordno = sod.sod_ordno and dtl.hid_ordseq = sod.sod_ordseq
and     hdr.hih_cocde = @cocde and dtl.hid_ctrcfs >= @from and dtl.hid_ctrcfs <= @to
order by   dtl.hid_sealno, dtl.hid_cuspo, sod.sod_resppo, dtl.hid_cusitm


End






GO
GRANT EXECUTE ON [dbo].[sp_select_SHR00001_container] TO [ERPUSER] AS [dbo]
GO
