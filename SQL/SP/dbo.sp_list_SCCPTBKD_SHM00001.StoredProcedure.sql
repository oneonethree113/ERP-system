/****** Object:  StoredProcedure [dbo].[sp_list_SCCPTBKD_SHM00001]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SCCPTBKD_SHM00001]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SCCPTBKD_SHM00001]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_list_SCCPTBKD_SHM00001]

@cocde as nvarchar(6),
@ordno as nvarchar(20),
@ordseq as int

AS

SELECT count( * ) as 'cbd_count'
FROM SCCPTBKD (nolock)

WHERE  scb_cocde = @cocde and
	scb_ordno = @ordno and
	scb_ordseq = @ordseq










GO
GRANT EXECUTE ON [dbo].[sp_list_SCCPTBKD_SHM00001] TO [ERPUSER] AS [dbo]
GO
