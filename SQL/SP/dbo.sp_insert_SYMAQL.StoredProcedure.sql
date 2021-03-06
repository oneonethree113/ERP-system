/****** Object:  StoredProcedure [dbo].[sp_insert_SYMAQL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYMAQL]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYMAQL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_insert_SYMAQL]

@yal_cocde	nvarchar(6),
@yal_lotfm int,
@yal_lotto int,
@yal_sample int,
@yal_aql15 int,
@yal_aql25 int,
@yal_updusr	nvarchar(30)


 
AS

BEGIN


insert into  SYMAQL
(
yal_cocde,
yal_lotfm,
yal_lotto,
yal_sample,
yal_aql15,
yal_aql25,
yal_creusr,
yal_updusr,
yal_credat,
yal_upddat
)
values
(
@yal_cocde,
@yal_lotfm,
@yal_lotto,
@yal_sample,
@yal_aql15,
@yal_aql25,
@yal_updusr,
@yal_updusr,
getdate(),
getdate()
)

END

----------------------------------------------------------




GO
GRANT EXECUTE ON [dbo].[sp_insert_SYMAQL] TO [ERPUSER] AS [dbo]
GO
