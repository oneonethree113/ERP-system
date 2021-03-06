/****** Object:  StoredProcedure [dbo].[sp_list_SHCBNDTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SHCBNDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SHCBNDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 27/07/2003


/************************************************************************
Author:		Wong Hong
Date:		4th Jan, 2002
Description:	Select data From SHCBNDTL
Parameter:	1. Company
		2. Note No
************************************************************************/

CREATE procedure [dbo].[sp_list_SHCBNDTL]
@hnd_cocde nvarchar(6) ,
@hnd_noteno nvarchar(20) 
AS
begin

Declare @max_seq  int

SET @max_seq = (Select isnull(max(hnd_seq),0)  from SHCBNDTL Where hnd_cocde = @hnd_cocde and hnd_noteno = @hnd_noteno) 



select 
distinct
@max_seq as 'max_seq',
d.*,
s.*,
c.sod_shpqty,
c.sod_ordqty
from SHCBNDTL d
left join  SHCBNHDR h on  d.hnd_noteno = h.hnh_noteno  and
 d.hnd_cocde = h.hnh_cocde 
left join SHIPGDTL s on d.hnd_cocde = s.hid_cocde  and
 d.hnd_invlne = s.hid_ordseq and
 d.hnd_itmno  = s.hid_itmno  and
 d.hnd_colcde = s.hid_colcde and
 d.hnd_pckunt = s.hid_untcde and
 d.hnd_inrctn = s.hid_inrctn and
 d.hnd_mtrctn = s.hid_mtrctn and
 d.hnd_cft    = s.hid_vol    and
  h.hnh_refno  = s.hid_invno 
 left join SCORDDTL c on s.hid_cocde = c.sod_cocde and
s.hid_ordno = c.sod_ordno and
s.hid_ordseq =  c.sod_ordseq
where                                                                                                                                                                                                                                                                 
d.hnd_noteno = @hnd_noteno and     
d.hnd_cocde = @hnd_cocde 

order by d.hnd_seq




end



GO
GRANT EXECUTE ON [dbo].[sp_list_SHCBNDTL] TO [ERPUSER] AS [dbo]
GO
