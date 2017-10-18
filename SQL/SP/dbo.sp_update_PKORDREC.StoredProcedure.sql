/****** Object:  StoredProcedure [dbo].[sp_update_PKORDREC]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_PKORDREC]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_PKORDREC]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







CREATE  procedure [dbo].[sp_update_PKORDREC]
                                                                                                                                                                                                                                                                 

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
@por_updusr nvarchar(30)

---------------------------------------------- 

 
AS
 

begin

	 
update PKORDREC set 
por_recdate = @por_recdate,
por_recqty = @por_recqty,
por_type = @por_type,
por_fty = @por_fty,
por_extqty = @por_extqty,
por_updusr = @por_updusr,
por_upddat = getdate()
where
por_ordno = @por_ordno and 
por_ordseq = @por_ordseq  and 
por_recseq = @por_recseq 

end













GO
GRANT EXECUTE ON [dbo].[sp_update_PKORDREC] TO [ERPUSER] AS [dbo]
GO
