/****** Object:  StoredProcedure [dbo].[sp_select_SYM00004_Check]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYM00004_Check]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYM00004_Check]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--Lester Wu 
--2004/06/09


CREATE procedure [dbo].[sp_select_SYM00004_Check]
@cocde	nvarchar(6),
@id	nvarchar(6)
as
begin 
select count(*) as 'intCount' from
--select * from  
 SYLNEINF 
where yli_dsgcde = @id
and yli_dsgcde<>''
end




GO
GRANT EXECUTE ON [dbo].[sp_select_SYM00004_Check] TO [ERPUSER] AS [dbo]
GO
