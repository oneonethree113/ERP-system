/****** Object:  StoredProcedure [dbo].[sp_select_IMITMCUSSTY]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMITMCUSSTY]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMITMCUSSTY]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





/*  
=========================================================  
Program ID : sp_select_IMITMCUSSTY
Description    :   
Programmer   : Frankie Cheung  
Create Date    :   
Last Modified   :   
Table Read(s)  :  
Table Write(s)  :  
=========================================================  
 Modification History                                      
=========================================================  
 Date        Initial    Description                            
=========================================================      
*/  
  
CREATE PROCEDURE [dbo].[sp_select_IMITMCUSSTY]   

@cocde		varchar(6), 
@upload	datetime,
@gsusrid	varchar(30) 
  
AS  

BEGIN

	select  
		'999' as no,
		iic_sts,
		iic_itmno,
		iic_cusno,
		iic_cusstyno,
		iic_mode,
		isnull(iic_sysmsg,'') as 'iic_sysmsg',
		iic_filnam,
		iic_upload,
		iic_seq,
		iic_creusr,
		iic_updusr,
		iic_credat,
		iic_upddat
	from	
		IMITMCUSSTY
	where 
		iic_upload = @upload and
		iic_sts <> 'I' and iic_sts <> 'O'
		--iic_creusr = @gsusrid
 	order by iic_credat
		

END



GO
GRANT EXECUTE ON [dbo].[sp_select_IMITMCUSSTY] TO [ERPUSER] AS [dbo]
GO
