/****** Object:  StoredProcedure [dbo].[sp_update_QCREQACT]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_QCREQACT]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_QCREQACT]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









/*
=============================================================================


=============================================================================
*/

--sp_select_POR00003 'UCP','PR0202457-B001','PR03000090-B001','Y'

CREATE PROCEDURE [dbo].[sp_update_QCREQACT]
@qcno	nvarchar(20),	
@verno	nvarchar(20),
@actyp		nvarchar(1), 
@usr nvarchar(30),	
@alert nvarchar(1)

AS




update QCREQACT
set qca_alert=@alert
where qca_qcno=@qcno and qca_verno=@verno and qca_actyp=@actyp and qca_usr=@usr





GO
GRANT EXECUTE ON [dbo].[sp_update_QCREQACT] TO [ERPUSER] AS [dbo]
GO
