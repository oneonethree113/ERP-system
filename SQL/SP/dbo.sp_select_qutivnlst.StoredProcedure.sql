/****** Object:  StoredProcedure [dbo].[sp_select_qutivnlst]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_qutivnlst]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_qutivnlst]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




CREATE procedure [dbo].[sp_select_qutivnlst]                                                                                                                                                                                                                            
@cocde nvarchar(6),                                                                                                                                                                                                                                         
@qutno nvarchar(20)                                                                                                                                                                                                                                          
                                                                                                                                                                                                                                                                 
                                                                                                                                                                                                                                                                 
AS                                                                                                                                                                                                                                                               
                                                                                                                                                                                                                                                                 
BEGIN                                                                                                                                                                                                                                                            
-----------------------------------------------------------------------------------------------------------------------                                                                                                                                          
SELECT	                                                                                                                                                                                                        
qud_itmno                                                                                                                                                                                                                                                                 
FROM QUOTNDTL, VNBASINF
WHERE 
qud_cocde = @cocde AND
qud_qutno = @qutno AND
--vbi_cocde = qud_cocde AND
vbi_venno = qud_venno AND
vbi_vensts = 'I'
order by qud_itmno                                                                                                                                                                                                                                            
-----------------------------------------------------------------------------------------------------------------------                                                                                                                                          
end



GO
GRANT EXECUTE ON [dbo].[sp_select_qutivnlst] TO [ERPUSER] AS [dbo]
GO
