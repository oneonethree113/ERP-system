/****** Object:  StoredProcedure [dbo].[sp_update_QUM00005_HDR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_QUM00005_HDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_QUM00005_HDR]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



/*  
=========================================================  
Description    : sp_update_QUM00005_HDR
=========================================================  
 Modification History                                      
=========================================================  
 Date      Initial   Description                            
=========================================================       
*/  
  
CREATE     PROCEDURE [dbo].[sp_update_QUM00005_HDR]   
  
@quh_qutno  nvarchar(20)
AS  
  
  
update	QUOTNHDR   
set	quh_qutsts = 'A'
where	
	quh_qutno = @quh_qutno	





GO
GRANT EXECUTE ON [dbo].[sp_update_QUM00005_HDR] TO [ERPUSER] AS [dbo]
GO
