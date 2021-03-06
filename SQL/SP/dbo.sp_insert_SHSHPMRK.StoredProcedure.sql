/****** Object:  StoredProcedure [dbo].[sp_insert_SHSHPMRK]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SHSHPMRK]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SHSHPMRK]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE procedure [dbo].[sp_insert_SHSHPMRK]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@hsm_cocde  	nvarchar  	(6),
@hsm_shpno 	nvarchar 	(20),
@hsm_invno	nvarchar  (20),
@hsm_ordno  	nvarchar  	(20),
@hsm_shptyp  	nvarchar  	(6),
@hsm_imgnam 	nvarchar  	(30),
@hsm_imgpth  	nvarchar 	(200),
@hsm_engdsc  	nvarchar  (1600),
@hsm_engrmk  	nvarchar  (1600),
@hsm_updusr  	nvarchar  (30)

---------------------------------------------- 
 
AS
begin

insert into SHSHPMRK
(
hsm_cocde,
hsm_shpno,
hsm_invno,
hsm_ordno,
hsm_shptyp,
hsm_imgnam,
hsm_imgpth,
hsm_engdsc,
hsm_engrmk,
hsm_creusr,
hsm_updusr,
hsm_credat,
hsm_upddat
)
values
(
@hsm_cocde,
@hsm_shpno,
@hsm_invno,
@hsm_ordno,
'M',
@hsm_imgnam,
@hsm_imgpth,
@hsm_engdsc,
@hsm_engrmk,
@hsm_updusr,
@hsm_updusr,
getdate(),
getdate()

)

end








GO
GRANT EXECUTE ON [dbo].[sp_insert_SHSHPMRK] TO [ERPUSER] AS [dbo]
GO
