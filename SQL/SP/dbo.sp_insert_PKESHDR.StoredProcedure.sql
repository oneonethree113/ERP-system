/****** Object:  StoredProcedure [dbo].[sp_insert_PKESHDR]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_PKESHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_PKESHDR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO













CREATE  procedure [dbo].[sp_insert_PKESHDR]
                                                                                                                                                                                                                                                                 
@peh_cocde nvarchar(20),
@peh_reqno nvarchar(20),
        @peh_itemno  nvarchar(20),
        @peh_assitm  nvarchar(20),
        @peh_tmpitmno  nvarchar(20),
        @peh_venno  nvarchar(20),
        @peh_venitm  nvarchar(20),
        @peh_colcde nvarchar(20),
        @peh_price numeric(13,4),
        @peh_curcde nvarchar(20),
        @peh_creusr  nvarchar(30)

---------------------------------------------- 

 
AS
 

begin

	 
insert into PKESHDR

values 
(@peh_cocde,
@peh_reqno,
@peh_itemno,
@peh_assitm,
@peh_tmpitmno,
@peh_venno,
@peh_venitm,
@peh_colcde,
@peh_price,
@peh_curcde,
@peh_creusr,
@peh_creusr,
getdate(),
getdate(),
null
 )

end



















GO
GRANT EXECUTE ON [dbo].[sp_insert_PKESHDR] TO [ERPUSER] AS [dbo]
GO
