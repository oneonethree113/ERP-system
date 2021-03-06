/****** Object:  StoredProcedure [dbo].[sp_insert_PKMAPDTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_PKMAPDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_PKMAPDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_insert_PKMAPDTL]
@pmd_cocde nvarchar(6),
@pmd_type nvarchar(5),
@pmd_ordno nvarchar(20),
@pmd_ordseq int,
@pmd_reqno nvarchar(20),
@pmd_reqseq int,
@pmd_creusr nvarchar(30)
as

Begin
insert into PKMAPDTL
(
pmd_cocde,
pmd_type,
pmd_ordno,
pmd_ordseq,
pmd_reqno,
pmd_reqseq,
pmd_creusr,
pmd_updusr,
pmd_credat,
pmd_upddat
)
values
(
@pmd_cocde,
@pmd_type,
@pmd_ordno,
@pmd_ordseq,
@pmd_reqno,
@pmd_reqseq,
@pmd_creusr,
@pmd_creusr,
getdate(),
getdate()
)
END

GO
GRANT EXECUTE ON [dbo].[sp_insert_PKMAPDTL] TO [ERPUSER] AS [dbo]
GO
