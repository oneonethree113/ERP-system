/****** Object:  StoredProcedure [dbo].[sp_insert_PCMDV]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_PCMDV]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_PCMDV]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

/*
=========================================================
Program ID	: sp_insert_PCMDV
Description   	: Insert Data for Profit Center Associated Design Vendor
Programmer  	: Marco Chan
Create Date   	: 19 Sept 2003
Last Modified  	: 
Table Read(s) 	: PCMDV
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
               
=========================================================     
*/
create procedure [dbo].[sp_insert_PCMDV]
@cocde 		varchar(6),
@pdv_pcno 	varchar(20),
@pdv_vencde 	varchar(10),
@pdv_creusr varchar(30)
AS
begin

insert into PCMDV(
	pdv_pcno,
	pdv_vencde,
	pdv_creusr,
	pdv_updusr,
	pdv_credat,
	pdv_upddat)
values (
	@pdv_pcno,
	@pdv_vencde,
	@pdv_creusr,
	@pdv_creusr,
	getdate(),
	getdate())
end




GO
GRANT EXECUTE ON [dbo].[sp_insert_PCMDV] TO [ERPUSER] AS [dbo]
GO
