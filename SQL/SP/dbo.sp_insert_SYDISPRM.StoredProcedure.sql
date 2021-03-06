/****** Object:  StoredProcedure [dbo].[sp_insert_SYDISPRM]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYDISPRM]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYDISPRM]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

-- Checked by Allan Yuen at 28/07/2003

/************************************************************************
Author:		Samuel Chan   
Date:		15th September, 2001
Description:	Insert data into SYDISPRM
Parameter:
************************************************************************/

Create  PROCEDURE [dbo].[sp_insert_SYDISPRM] 
--------------------------------------------------------------------------------------------------------------------------------------

@ydp_cocde	nvarchar(6) = ' ',
@ydp_type	nvarchar(1),
@ydp_cde	nvarchar(6),
@ydp_dsc	nvarchar(200),
@ydp_account	nvarchar(15),
@ydp_sts	char(1),
@ydp_pca	varchar(15),
@ydp_pcb	varchar(15),
@ydp_updusr	nvarchar(30)

--------------------------------------------------------------------------------------------------------------------------------------
AS

INSERT INTO  SYDISPRM

(
ydp_cocde,
ydp_type,
ydp_cde,
ydp_dsc,
ydp_account_new,
ydp_sts,
ydp_pca,
ydp_pcb,
ydp_creusr,
ydp_updusr,
ydp_credat,	
ydp_upddat
)
--------------------------------------------------------------------------------------------------------------------------------------
values
(
--@ydp_cocde,
' ',
@ydp_type,
@ydp_cde,
@ydp_dsc,
@ydp_account,
@ydp_sts,
@ydp_pca,
@ydp_pcb,
@ydp_updusr,
@ydp_updusr,
getdate(),
getdate()
)







GO
GRANT EXECUTE ON [dbo].[sp_insert_SYDISPRM] TO [ERPUSER] AS [dbo]
GO
