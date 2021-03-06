/****** Object:  StoredProcedure [dbo].[sp_select_INR00001B_ASSORT_NET]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_INR00001B_ASSORT_NET]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_INR00001B_ASSORT_NET]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO













/*
=================================================================
Program ID	: sp_select_INR00001B_ASSORT_NET
Description	: Retrieve Customer Invoice Data (Walmart) - 
		  Assorted Items
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2015-05-16 	David Yue		SP Created
=================================================================
*/

CREATE       procedure [dbo].[sp_select_INR00001B_ASSORT_NET] 
@cocde		nvarchar(6) ,    
@from		nvarchar(20),
@to		nvarchar(20)

AS    
BEGIN    

select	@cocde as 'cocde',
	hid_invno,
	hid_shpno,
	hid_shpseq,
	(select count(*) from SHASSINF (nolock)
		 where /*hai_cocde = hid_cocde and*/ 
		hai_shpno = hid_shpno and hai_shpseq = hid_shpseq)
		 as 'hid_asscnt',
	hai_assdsc as 'sai_assdsc',
	hai_cusstyno as 'sai_cusstyno',
	cast(hai_mtrqty as nvarchar(9))  as 'sai_mtrqty',
	hai_upcean as 'sai_upcean',
	rtrim(ltrim(hid_cusitm)) as 'sai_cusitm' 
from	SHINVHDR (nolock)
	join SHIPGDTL (nolock) on
		hid_cocde = hiv_cocde and
		hid_shpno = hiv_shpno and
		hid_invno = hiv_invno
	join SHASSINF (nolock) on
		--hai_cocde = hid_cocde and
--		hai_ordno = hid_ordno and
	--	hai_ordseq = hid_ordseq
hai_shpno = hid_shpno and hai_shpseq = hid_shpseq
where	hiv_cocde = @cocde and
	hiv_invno between @from and @to

END











GO
GRANT EXECUTE ON [dbo].[sp_select_INR00001B_ASSORT_NET] TO [ERPUSER] AS [dbo]
GO
