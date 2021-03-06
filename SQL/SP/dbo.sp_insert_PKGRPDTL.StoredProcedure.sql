/****** Object:  StoredProcedure [dbo].[sp_insert_PKGRPDTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_PKGRPDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_PKGRPDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










CREATE procedure [dbo].[sp_insert_PKGRPDTL]
@pgd_cocde nvarchar(6),
@pgd_grpno nvarchar(20),
@pgd_ordno nvarchar(20),
@pgd_ordseq int,
@pgd_reqno nvarchar(20),
@pgd_reqseq int,
@pgd_creusr nvarchar(30)

as



declare @seq as int

select @seq = count(*) + 1 from PKGRPDTL (nolock)
where pgd_cocde = @pgd_cocde and pgd_grpno = @pgd_grpno

insert into PKGRPDTL
(
pgd_cocde,
pgd_grpno,
pgd_grpseq,
pgd_ordno,
pgd_ordseq,
pgd_reqno,
pgd_reqseq,
pgd_creusr,
pgd_updusr,
pgd_credat,
pgd_upddat
)
values
(
@pgd_cocde,
@pgd_grpno,
@seq,
@pgd_ordno,
@pgd_ordseq,
@pgd_reqno,
@pgd_reqseq,
@pgd_creusr,
@pgd_creusr,
getdate(),
getdate()
)






GO
GRANT EXECUTE ON [dbo].[sp_insert_PKGRPDTL] TO [ERPUSER] AS [dbo]
GO
