/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_PKMTLSHP]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_Physical_Delete_PKMTLSHP]
GO
/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_PKMTLSHP]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







CREATE  procedure [dbo].[sp_Physical_Delete_PKMTLSHP]
                                                                                                                                                                                                                                                                 
@code nvarchar(10),
@ordno nvarchar(20),
@ordseq int , 
@shpseq int



---------------------------------------------- 

 
AS
 

begin

	 
delete from PKMTLSHP
where pms_ordno = @ordno
and pms_ordseq = @ordseq 
and pms_shpseq = @shpseq



end












GO
GRANT EXECUTE ON [dbo].[sp_Physical_Delete_PKMTLSHP] TO [ERPUSER] AS [dbo]
GO
