/****** Object:  StoredProcedure [dbo].[sp_list_VNPUCINF1]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_VNPUCINF1]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_VNPUCINF1]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





-- Checked by Allan Yuen at 28/07/2003


CREATE procedure [dbo].[sp_list_VNPUCINF1]
                                                                                                                                                                                                                                                               
@vpf_cocde 	nvarchar(6)

AS
Select distinct vpf_yymm

from VNPUCINF
--where                                                                                                                                                                                                                                                                 
--vpf_cocde = @vpf_cocde
order by vpf_yymm








GO
GRANT EXECUTE ON [dbo].[sp_list_VNPUCINF1] TO [ERPUSER] AS [dbo]
GO
