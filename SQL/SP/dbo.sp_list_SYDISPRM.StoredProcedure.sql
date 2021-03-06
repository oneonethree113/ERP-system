/****** Object:  StoredProcedure [dbo].[sp_list_SYDISPRM]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYDISPRM]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYDISPRM]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO




-- Checked by Allan Yuen at 28/07/2003

/*
Samuel
*/
------------------------------------------------- 
CREATE procedure [dbo].[sp_list_SYDISPRM]

                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ydp_cocde nvarchar(6) = ' '

---------------------------------------------- 
 
AS
declare @ydp_timstp int

Set  @ydp_timstp = (Select max(cast(ydp_timstp as int)) from sydisprm where ydp_cocde = @ydp_cocde)

begin
 Select 
ydp_cocde,
ydp_type,
ydp_cde,
ydp_sts,
ydp_dsc,
ydp_account,
ydp_pca,
ydp_pcb,
ydp_creusr,
ydp_updusr,
ydp_credat,
ydp_upddat,
@ydp_timstp as ydp_timstp 

/*
yci_creusr as 'yci_status'
*/
                                  
--------------------------------- 
 from SYDISPRM
-- where
--                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
-- ydp_cocde = @ydp_cocde

-------------------------- 

                                                           
---------------------------------------------------------- 
end





GO
GRANT EXECUTE ON [dbo].[sp_list_SYDISPRM] TO [ERPUSER] AS [dbo]
GO
