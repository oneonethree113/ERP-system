/****** Object:  StoredProcedure [dbo].[sp_insert_Image_Upload_aud]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_Image_Upload_aud]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_Image_Upload_aud]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_insert_Image_Upload_aud]
@cocde as nvarchar(6),
@ima_ttlimg  as int,
@ima_cpyimg  as int,
@ima_expimg  as int, 
@ima_dupimg  as int,
@ima_othimg  as int, 
@ima_lstimg  as int, 
@ima_elptime  as numeric(13,2),
@ima_rmk as nvarchar(100),
@ima_creusr  nvarchar(30) 
as
insert into IMGAUD (
ima_ttlimg,
ima_cpyimg,
ima_expimg,
ima_dupimg,
ima_othimg,
ima_lstimg,
ima_elptime,
ima_rmk,
ima_creusr,
ima_credat)
values (
@ima_ttlimg,
@ima_cpyimg,
@ima_expimg,
@ima_dupimg,
@ima_othimg,
@ima_lstimg,
@ima_elptime,
@ima_rmk,
@ima_creusr,
getdate()
)





GO
GRANT EXECUTE ON [dbo].[sp_insert_Image_Upload_aud] TO [ERPUSER] AS [dbo]
GO
