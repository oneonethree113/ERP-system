/****** Object:  StoredProcedure [dbo].[sp_insert_SYCOMINF_sys]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYCOMINF_sys]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYCOMINF_sys]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 28/07/2003


/************************************************************************
Author:		Samuel Chan   
Date:		15th September, 2001
Description:	Insert data into SYCOMINF

************************************************************************/

CREATE PROCEDURE [dbo].[sp_insert_SYCOMINF_sys] 
--------------------------------------------------------------------------------------------------------------------------------------
@yco_cocde	nvarchar(6), 
@yco_addr	nvarchar(200),
@yco_mfystr	int,
@yco_curyer	int,
@yco_systim	int,
@yco_IRday	int,
@yco_moq	int,
@yco_curcde	nvarchar(4),
@yco_moa	numeric(11,4),
@yco_bscrat	int,
@yco_datfmt	nvarchar(20),
@yco_ivmth	nvarchar(10),
@yco_commth	nvarchar(1),
@yco_prctle	numeric(6,3),
@yco_expday	int,
@yco_datrme1	nvarchar(5),
@yco_datrme2	nvarchar(5),
@yco_datrme3	nvarchar(5),
@yco_datrme4	nvarchar(5),
@yco_year	int,
@yco_updusr	nvarchar(30)


--------------------------------------------------------------------------------------------------------------------------------------
AS

INSERT INTO  SYCOMINF

(
yco_cocde,	
yco_addr,	
yco_mfystr,	
yco_curyer,
yco_systim,
yco_IRday,
yco_moq,	
yco_curcde,	
yco_moa,	
yco_bscrat,	
yco_datfmt,	
yco_ivmth,	
yco_commth,	
yco_prctle,	
yco_expday,	
yco_datrme1,	
yco_datrme2,	
yco_datrme3,	
yco_datrme4,	
yco_year,	
yco_updusr,
yco_creusr,
yco_upddat,
yco_credat	
)
--------------------------------------------------------------------------------------------------------------------------------------
values
(
@yco_cocde,	
@yco_addr,	
@yco_mfystr,	
@yco_curyer,
@yco_systim,
@yco_IRday,
@yco_moq,	
@yco_curcde,	
@yco_moa,	
@yco_bscrat,	
@yco_datfmt,	
@yco_ivmth,	
@yco_commth,	
@yco_prctle,	
@yco_expday,	
@yco_datrme1,	
@yco_datrme2,	
@yco_datrme3,	
@yco_datrme4,	
@yco_year,	
@yco_updusr,
@yco_updusr,
getdate(),
getdate()
)








GO
GRANT EXECUTE ON [dbo].[sp_insert_SYCOMINF_sys] TO [ERPUSER] AS [dbo]
GO
