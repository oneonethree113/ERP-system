/****** Object:  StoredProcedure [dbo].[sp_select_PKESTDTL_maxseq]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PKESTDTL_maxseq]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PKESTDTL_maxseq]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_select_PKESTDTL_maxseq]
                                                                                                                                                                                                                                                                 
@Req_no nvarchar(20),
@itmno nvarchar(20),
@assitm nvarchar(20),
@colcde nvarchar(30)

---------------------------------------------- 
 
AS


begin
	select isnull(max(isnull(ped_seq,0)),0)  from PKESDTL (nolock) 
	where ped_reqno = @Req_no
	and ped_itemno = @itmno
	and ped_assitm = @assitm
	and ped_colcde = @colcde
end
















GO
GRANT EXECUTE ON [dbo].[sp_select_PKESTDTL_maxseq] TO [ERPUSER] AS [dbo]
GO
