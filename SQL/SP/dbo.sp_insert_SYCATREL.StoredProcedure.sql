/****** Object:  StoredProcedure [dbo].[sp_insert_SYCATREL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYCATREL]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYCATREL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 28/07/2003

/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
Create Date   	: 
Last Modified  	: 15 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
20030715	Allan Yuen		Modify For Merge Porject 
*/

/************************************************************************
Author:		Samuel Chan   
Date:		22-10-2001
Description:	Insert data into SYCATREL
************************************************************************/

CREATE PROCEDURE [dbo].[sp_insert_SYCATREL] 
--------------------------------------------------------------------------------------------------------------------------------------
@ycr_cocde	nvarchar(6) = ' ',
@ycr_catlvl0	nvarchar(20),
@ycr_catlvl1	nvarchar(20),
@ycr_catlvl2	nvarchar(20),
@ycr_catlvl3	nvarchar(20),
@ycr_catlvl4	nvarchar(20),
@ycr_updusr	nvarchar(30)

--------------------------------------------------------------------------------------------------------------------------------------
AS

declare @ycr_catseq int

--Set @ycr_catseq = (Select max(ycr_catseq) from sycatrel where ycr_cocde = @ycr_cocde) + 1
Set @ycr_catseq = ISNULL((Select max(ycr_catseq) from sycatrel),0) + 1


INSERT INTO  SYCATREL

(
ycr_cocde,
ycr_catseq,
ycr_catlvl0,
ycr_catlvl1,
ycr_catlvl2,
ycr_catlvl3,
ycr_catlvl4,
ycr_creusr,
ycr_updusr,
ycr_credat,	
ycr_upddat
)
--------------------------------------------------------------------------------------------------------------------------------------
values
(
-- @ycr_cocde,
' ',
@ycr_catseq,
@ycr_catlvl0,
@ycr_catlvl1,
@ycr_catlvl2,
@ycr_catlvl3,
@ycr_catlvl4,
@ycr_updusr,
@ycr_updusr,
getdate(),
getdate()
)










GO
GRANT EXECUTE ON [dbo].[sp_insert_SYCATREL] TO [ERPUSER] AS [dbo]
GO
