/****** Object:  StoredProcedure [dbo].[sp_insert_PKGENQP]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_PKGENQP]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_PKGENQP]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[sp_insert_PKGENQP]

@pgq_cocde nvarchar(40),
@pgq_pkordno nvarchar(40),
@pgq_ordqty int,
@pgq_wasqty int,
@pgq_bonqty int,
@pgq_stkqty int,
@pgq_ttlordqty int,
@pgq_unitprc numeric(11,6),
@pgq_ttlamt numeric(13,4),
@pgq_genflag nvarchar(20),
@pgq_usrid nvarchar(40)


as 

begin

insert into
PKGENQP
(
pgq_cocde,
pgq_pkordno,
pgq_ordqty,
pgq_wasqty,
pgq_bonqty,
pgq_stkqty,
pgq_ttlordqty,
pgq_unitprc,
pgq_ttlamt,
pgq_genflag,
pgq_creusr,
pgq_updusr,
pgq_credat,
pgq_upddat
)
values
(
@pgq_cocde,
@pgq_pkordno,
@pgq_ordqty,
@pgq_wasqty,
@pgq_bonqty,
@pgq_stkqty,
@pgq_ttlordqty,
@pgq_unitprc,
@pgq_ttlamt,
@pgq_genflag,
@pgq_usrid,
@pgq_usrid,
getdate(),
getdate()
)






end




GO
GRANT EXECUTE ON [dbo].[sp_insert_PKGENQP] TO [ERPUSER] AS [dbo]
GO
