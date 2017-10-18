/****** Object:  StoredProcedure [dbo].[sp_physical_delete_QUDTLSHP]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_QUDTLSHP]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_QUDTLSHP]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





create PROCEDURE [dbo].[sp_physical_delete_QUDTLSHP] 

@qds_cocde 	nvarchar(6),
@qds_qutno 	nvarchar(20),
@qds_qutseq 	int,
@qds_shpseq 	int


AS

delete from QUDTLSHP
where 	qds_cocde = @qds_cocde
and 	qds_qutno = @qds_qutno
and 	qds_qutseq = @qds_qutseq
and 	qds_shpseq = @qds_shpseq






GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_QUDTLSHP] TO [ERPUSER] AS [dbo]
GO
