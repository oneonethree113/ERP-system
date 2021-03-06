/****** Object:  StoredProcedure [dbo].[sp_insert_QUXERPDA]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_QUXERPDA]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_QUXERPDA]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO





/*=========================================================
Program ID	: 	sp_insert_QUXERPDA
Description   	: 	Insert Record to PDA upload Log File
Programmer  	: 	Lewis To	
Create Date   	: 	19 AAug 2003
Last Modified  	: 
Table Read(s) 	:	
Table Write(s) 	:	QUXERPDA
Parameter		:	
		:	
		:	
=========================================================
 Modification History                                    
=========================================================
=========================================================     
*/
CREATE PROCEDURE [dbo].[sp_insert_QUXERPDA] 



 @qxp_cocde    	varchar   (6)   ,
 @qxp_cus1no    	varchar   (6)    ,
 @qxp_cus2no    	varchar   (6)    ,
 @qxp_cus2na    	varchar   (20)    ,
 @qxp_seq    	numeric   (4)    ,
 @qxp_itmno    	varchar   (20)    ,
 @qxp_img    	char   (1)   ,
 @qxp_del    	char   (1)    ,
 @qxp_currel    	char   (1)  ,
 @qxp_colcde    	varchar   (6)   ,
 @qxp_pckseq    	numeric   (4)  ,
 @qxp_inrqty    	numeric   (4)   ,
 @qxp_mtrqty    	numeric   (4)   ,
 @qxp_cft    	numeric   (11,4)   ,
 @qxp_moq    	numeric   (9)   ,
 @qxp_moa    	numeric   (11,4)  ,
 @qxp_untcde    	varchar   (4)  ,
 @qxp_smpqty    	numeric   (9)   ,
 @qxp_disc    	numeric   (8,4)    ,
 @qxp_curcde    	varchar   (4)    ,
 @qxp_cu1pri    	numeric   (13,4)    ,
 @qxp_cu2pri    	numeric   (13,4)   ,
 @qxp_note    	varchar   (200)   ,
 @qxp_modify    	char   (1)   ,
 @qxp_prcsec    	char   (2)   ,
 @qxp_grsmgn    	numeric   (8,4)   ,
 @qxp_basprc    	numeric   (13,4)   ,
 @qxp_smpunt    	varchar   (4)  ,
 @qxp_venitm    	varchar   (20)   ,
 @qxp_aliitm    	varchar   (20)   ,

--Added by Mark Lau 20060918
 @qxp_alsitmno	nvarchar(20),
 @qxp_alscolcde	nvarchar(30),

 @qxp_ventyp    	char   (1)    ,
 @qxp_cat    		varchar   (20)    ,
 @qxp_errmsg    	varchar   (200)  ,
 @qxp_creusr    	varchar   (30)    ,
 @qxp_credat    	Datetime      ,
 @qxp_updprg    	varchar  (20)  

as

begin

insert into QUXERPDA (
			qxp_cocde,
			qxp_cus1no,
			qxp_cus2no,
			qxp_cus2na,
			qxp_seq,
			qxp_itmno,
			qxp_img,
			qxp_del,
			qxp_currel,
			qxp_colcde,
			qxp_pckseq,
			qxp_inrqty,
			qxp_mtrqty,
			qxp_cft,
			qxp_moq,
			qxp_moa,
			qxp_untcde,
			qxp_smpqty,
			qxp_disc,
			qxp_curcde,
			qxp_cu1pri,
			qxp_cu2pri,
			qxp_note,
			qxp_modify,
			qxp_prcsec,
			qxp_grsmgn,
			qxp_basprc,
			qxp_smpunt,
			qxp_venitm,
			qxp_aliitm,
			
			--Added  by Mark Lau 20060918
			qxp_alsitmno,
			qxp_alscolcde,

			qxp_ventyp,
			qxp_cat,
			qxp_errmsg,
			qxp_creusr,
			qxp_updusr,
			qxp_credat,
			qxp_upddat,
			qxp_updprg 
		)
		values
		(
			@qxp_cocde,
			@qxp_cus1no,
			@qxp_cus2no,
			@qxp_cus2na,
			@qxp_seq,
			@qxp_itmno,
			@qxp_img,
			@qxp_del,
			@qxp_currel,
			@qxp_colcde,
			@qxp_pckseq,
			@qxp_inrqty,
			@qxp_mtrqty,
			@qxp_cft,
			@qxp_moq,
			@qxp_moa,
			@qxp_untcde,
			@qxp_smpqty,
			@qxp_disc,
			@qxp_curcde,
			@qxp_cu1pri,
			@qxp_cu2pri,
			@qxp_note,
			@qxp_modify,
			@qxp_prcsec,
			@qxp_grsmgn,
			@qxp_basprc,
			@qxp_smpunt,
			@qxp_venitm,
			@qxp_aliitm,

			--Added  by Mark Lau 20060918
			@qxp_alsitmno,
			@qxp_alscolcde,

			@qxp_ventyp,
			@qxp_cat,
			@qxp_errmsg,
			@qxp_creusr,
			@qxp_creusr,
			@qxp_credat,
			getdate(),
			@qxp_updprg
		)

end



GO
GRANT EXECUTE ON [dbo].[sp_insert_QUXERPDA] TO [ERPUSER] AS [dbo]
GO
