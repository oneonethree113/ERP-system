/****** Object:  StoredProcedure [dbo].[sp_list_SYMRKFML]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYMRKFML]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYMRKFML]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





-- Checked by Allan Yuen at 28/07/2003



/************************************************************************
Author:		Kenny Chan
Date:		24-102001
Description:	List data From SYMRKFML
Parameter:	1. Company Code range    
************************************************************************/
CREATE procedure [dbo].[sp_list_SYMRKFML]
                                                                                                                                                                                                                                                               
@ymf_cocde nvarchar(6) = ' '
AS
Select 

ymf_cocde,
ymf_degvenno,
ymf_prdvenno,
ymf_seq,
cast(ymf_mkpopt as Nvarchar(5))+ ' - ' +ISNULL(cast(a.yfi_fml as Nvarchar(300)),'***') as 'ymf_mkpopt',
cast(ymf_fmlopt as Nvarchar(5)) + ' - ' + ISNULL(cast(b.yfi_fml as Nvarchar(300)), '***') as 'ymf_fmlopt',
ymf_def,
ymf_effdat
ymf_creusr,
ymf_updusr,
ymf_credat,
ymf_upddat,
cast(ymf_timstp as int) as 'ymf_timstp'

 from SYMRKFML
--left join SYFMLINF a on ymf_mkpopt= a.yfi_fmlopt  and a.yfi_cocde = @ymf_cocde
--left join SYFMLINF b on ymf_fmlopt  = b.yfi_fmlopt and b.yfi_cocde = @ymf_cocde
left join SYFMLINF a on ymf_mkpopt= a.yfi_fmlopt  and a.yfi_cocde = ' '
left join SYFMLINF b on ymf_fmlopt  = b.yfi_fmlopt and b.yfi_cocde = ' '
Where                                                                                                                                                                                                                                                                  
-- ymf_cocde = @ymf_cocde 

ymf_cocde = ' '

order by ymf_degvenno,ymf_prdvenno









GO
GRANT EXECUTE ON [dbo].[sp_list_SYMRKFML] TO [ERPUSER] AS [dbo]
GO
