/****** Object:  StoredProcedure [dbo].[sp_select_IMTMPREL_Q3]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMTMPREL_Q3]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMTMPREL_Q3]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE    PROCEDURE [dbo].[sp_select_IMTMPREL_Q3] 
                                                                                                                                                                                                                                                                 
@itr_itmno		nvarchar(20)
 
 
AS
begin

select * from IMBASINF (nolock)
left join IMTMPREL (nolock) on itr_itmno = ibi_itmno
where ibi_ftytmp <> 'Y'  and itr_itmno is null
	and ibi_itmno= @itr_itmno	



end






GO
GRANT EXECUTE ON [dbo].[sp_select_IMTMPREL_Q3] TO [ERPUSER] AS [dbo]
GO
