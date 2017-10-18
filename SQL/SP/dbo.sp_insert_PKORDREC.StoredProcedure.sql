/****** Object:  StoredProcedure [dbo].[sp_insert_PKORDREC]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_PKORDREC]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_PKORDREC]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







CREATE  procedure [dbo].[sp_insert_PKORDREC]
                                                                                                                                                                                                                                                                 

@por_cocde nvarchar(6),
@por_ordno nvarchar(20), 
@por_ordseq int,
@por_recseq int, 
@por_recdate datetime, 
@por_recqty int, 
@por_um nvarchar(20), 
@por_remark nvarchar(500), 
@por_invno nvarchar(20), 
@por_type nvarchar(20),
@por_fty nvarchar(20),
@por_extqty int , 
@por_creusr nvarchar(30)
---------------------------------------------- 

 
AS
 

begin

	 
insert into PKORDREC
values
(@por_cocde, @por_ordno, @por_ordseq, 
@por_recseq, @por_recdate, @por_recqty, @por_type , @por_fty , @por_extqty,
@por_um, @por_remark, @por_invno, 
@por_creusr, @por_creusr, getdate(),
 getdate(),null)

end



 









GO
GRANT EXECUTE ON [dbo].[sp_insert_PKORDREC] TO [ERPUSER] AS [dbo]
GO
