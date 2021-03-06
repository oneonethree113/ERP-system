/****** Object:  StoredProcedure [dbo].[sp_insert_PKWASGE]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_PKWASGE]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_PKWASGE]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO











/************************************************************************
Author:		Kath Ng     
Date:		25th September, 2001
Description:	Insert data into PKWASGE
************************************************************************/

CREATE PROCEDURE [dbo].[sp_insert_PKWASGE] 
--------------------------------------------------------------------------------------------------------------------------------------

@pwa_cocde nvarchar(6),
@pwa_code nvarchar(6),
@pwa_qtyfrm  integer ,
@pwa_qtyto integer,
@pwa_wasage numeric(13,4),
@pwa_um nvarchar(12),
@user nvarchar(30)
--------------------------------------------------------------------------------------------------------------------------------------
AS

begin

declare @seq as int

select   @seq = isnull(max(pwa_seq),0) + 1   from pkwasge where pwa_code = @pwa_code

 
 

insert into  PKWASGE values 
(@pwa_cocde,
@pwa_code,
@seq,
@pwa_qtyfrm,
@pwa_qtyto,
@pwa_wasage,
@pwa_um,
@user,
@user,
getdate(),
getdate(),
null)

end






GO
GRANT EXECUTE ON [dbo].[sp_insert_PKWASGE] TO [ERPUSER] AS [dbo]
GO
