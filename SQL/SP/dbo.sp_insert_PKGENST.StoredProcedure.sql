/****** Object:  StoredProcedure [dbo].[sp_insert_PKGENST]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_PKGENST]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_PKGENST]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[sp_insert_PKGENST]

@pgs_cocde nvarchar(40),
@pgs_pkordno nvarchar(40),
@pgs_Count int,
@pgs_Gen nvarchar(20),
@pgs_ordno nvarchar(40),
@pgs_seq int,
@pgs_item nvarchar(40),
@pgs_assitm nvarchar(40),
@pgs_custitm nvarchar(40),
@pgs_sku nvarchar(40),
@pgs_tmpitm nvarchar(40),
@pgs_venitm nvarchar(40),
@pgs_venno nvarchar(40),
@pgs_colcde nvarchar(40),
@pgs_ordqty int,
@pgs_wasqty int,
@pgs_sctoqty int,
@pgs_Terms nvarchar(120),
@pgs_usrid nvarchar(40)


as
begin


insert into PKGENST
(
pgs_cocde,
pgs_pkordno,
pgs_Count,
pgs_Gen,
pgs_ordno,
pgs_seq,
pgs_item,
pgs_assitm,
pgs_custitm,
pgs_sku,
pgs_tmpitm,
pgs_venitm,
pgs_venno,
pgs_colcde,
pgs_ordqty,
pgs_wasqty,
pgs_sctoqty,
pgs_Terms,
pgs_creusr,
pgs_updusr,
pgs_credat,
pgs_upddat
)
values
(
@pgs_cocde,
@pgs_pkordno,
@pgs_Count,
@pgs_Gen,
@pgs_ordno,
@pgs_seq,
@pgs_item,
@pgs_assitm,
@pgs_custitm,
@pgs_sku,
@pgs_tmpitm,
@pgs_venitm,
@pgs_venno,
@pgs_colcde,
@pgs_ordqty,
@pgs_wasqty,
@pgs_sctoqty,
@pgs_Terms,
@pgs_usrid,
@pgs_usrid,
getdate(),
getdate()
)





end





GO
GRANT EXECUTE ON [dbo].[sp_insert_PKGENST] TO [ERPUSER] AS [dbo]
GO
