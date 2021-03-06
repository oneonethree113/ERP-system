/****** Object:  StoredProcedure [dbo].[sp_insert_CUMCAMRK]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_CUMCAMRK]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_CUMCAMRK]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/*
=========================================================
Program ID	: sp_insert_CUMCAMRK
Description   	: Insert Data to  Customer Item Category Markup Table 
Programmer  	: Lewis To
Create Date   	: 18 Jun 2003
Last Modified  	: 
Table Read(s) 	:CUMCAMRK
Table Write(s) 	:CUMCAMRK
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
               
=========================================================     
*/

Create Procedure [dbo].[sp_insert_CUMCAMRK]

@ccm_cocde	varchar(6),
@ccm_cusno	varchar(6),
@ccm_cat		varchar(20),
@ccm_ventyp	char(1),
@ccm_markup	varchar(5),
@ccm_effdat	datetime,
@ccm_creusr 	varchar(30),
@ccm_updprg	varchar(20)

as

begin



insert into CUMCAMRK (
	ccm_cocde,
	ccm_cusno,
	ccm_cat,
	ccm_ventyp,
	ccm_markup,
	ccm_effdat,
	ccm_creusr,
	ccm_updusr,
	ccm_credat,
	ccm_upddat,
	ccm_updprg
) values (
	@ccm_cocde,
	@ccm_cusno,
	@ccm_cat,
	@ccm_ventyp,
	@ccm_markup,
	@ccm_effdat,
	@ccm_creusr,
	@ccm_creusr,
	getdate(),
	getdate(),
	@ccm_updprg
)

end





GO
GRANT EXECUTE ON [dbo].[sp_insert_CUMCAMRK] TO [ERPUSER] AS [dbo]
GO
