/****** Object:  StoredProcedure [dbo].[sp_list_SYLNEFML]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYLNEFML]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYLNEFML]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 28/07/2003



CREATE PROCEDURE [dbo].[sp_list_SYLNEFML] 

@ylf_cocde	nvarchar(6)

AS

Select * from SYLNEFML

--where 
--
--ylf_cocde= @ylf_cocde

Order By ylf_cocde







GO
GRANT EXECUTE ON [dbo].[sp_list_SYLNEFML] TO [ERPUSER] AS [dbo]
GO
