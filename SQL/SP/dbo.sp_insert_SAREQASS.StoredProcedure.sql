/****** Object:  StoredProcedure [dbo].[sp_insert_SAREQASS]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SAREQASS]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SAREQASS]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 28/07/2003

/*	Author : Tommy Ho	*/

CREATE PROCEDURE [dbo].[sp_insert_SAREQASS] 

@sra_cocde 	nvarchar(6),	@sra_reqno 	nvarchar(20),	
@sra_reqseq 	int,		@sra_itmno 	nvarchar(20),
@sra_assitm 	nvarchar(20),	@sra_assdsc 	nvarchar(800),	
@sra_cusitm	nvarchar(20),	@sra_colcde	nvarchar(30),

--Added by Mark Lau 20060923
@sra_alsitmno	nvarchar(20),	@sra_alscolcde	nvarchar(30),

@sra_cussku           	nvarchar(20),	@sra_upcean      	nvarchar(15),
@sra_cusrtl	nvarchar(20),	@sra_pckunt 	nvarchar(6),	
@sra_inrqty	int,		@sra_mtrqty	int,		
@sra_creusr	nvarchar(30)


AS

insert into [SAREQASS](
	sra_cocde ,		sra_reqno ,		sra_reqseq ,
	sra_itmno ,	sra_assitm ,	sra_assdsc ,
	sra_cusitm ,	sra_colcde ,	

	--Added by Mark Lau 20060923
	sra_alsitmno,	sra_alscolcde,

	sra_cussku ,
	sra_upcean ,	sra_cusrtl ,		sra_pckunt ,
	sra_inrqty ,	sra_mtrqty ,	sra_creusr ,
	sra_updusr ,	sra_credat ,	sra_upddat 	
)
values
(
	@sra_cocde ,	@sra_reqno ,	@sra_reqseq ,
	@sra_itmno ,	@sra_assitm ,	@sra_assdsc ,
	@sra_cusitm ,	@sra_colcde ,	

	--Added by Mark Lau 20060923
	@sra_alsitmno,	@sra_alscolcde,

	@sra_cussku ,
	@sra_upcean ,	@sra_cusrtl ,	@sra_pckunt ,
	@sra_inrqty ,	@sra_mtrqty ,	@sra_creusr ,
	@sra_creusr ,	getdate() ,		getdate()
)



GO
GRANT EXECUTE ON [dbo].[sp_insert_SAREQASS] TO [ERPUSER] AS [dbo]
GO
