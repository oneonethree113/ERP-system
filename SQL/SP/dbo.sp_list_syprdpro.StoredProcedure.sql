/****** Object:  StoredProcedure [dbo].[sp_list_syprdpro]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_syprdpro]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_syprdpro]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sp_list_syprdpro] AS
select * from syprdpro order by ypp_display




GO
GRANT EXECUTE ON [dbo].[sp_list_syprdpro] TO [ERPUSER] AS [dbo]
GO
