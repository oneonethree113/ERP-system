/****** Object:  StoredProcedure [dbo].[sp_select_sainvhdr_cus1no]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_sainvhdr_cus1no]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_sainvhdr_cus1no]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO








/**********************************************************************************************************************************
Modification History
**********************************************************************************************************************************
Modifiy by		Modified on		Description
**********************************************************************************************************************************
***********************************************************************************************************************************/

CREATE    procedure [dbo].[sp_select_sainvhdr_cus1no]
@tmp_sminvno  nvarchar(30) , 
@tmp_cus1no  nvarchar(6)   

as


select 
*
 from SAINVHDR
where
sih_cus1no =   	@tmp_cus1no and   
sih_invno =   	@tmp_sminvno  


---------------------------------------------------------------------------------------------------------------------------------------------------------------------














GO
GRANT EXECUTE ON [dbo].[sp_select_sainvhdr_cus1no] TO [ERPUSER] AS [dbo]
GO
