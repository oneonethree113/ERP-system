/****** Object:  StoredProcedure [dbo].[sp_list_CUCNTINF_SHM00001]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_CUCNTINF_SHM00001]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_CUCNTINF_SHM00001]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO











/************************************************************************
Author:		Johnson Lai
Date:		24 Jan, 2002
Description:	Select data From CUCNTINF
Parameter:	1. Company
		2. Customer No.	
		3. Contact type
***********************************************************************
20 Aug 2003	Allan Yuen	Fix Dead Lock Program.
*/


CREATE procedure [dbo].[sp_list_CUCNTINF_SHM00001]

@cci_cocde 	nvarchar(6) ,
@cci_cusno  	nvarchar(6) ,
@cci_cnttyp	nvarchar(6)
                                              
AS

-- Billing ----------------------------------------------------------------------------------------------------------------
begin

SELECT	
	isnull(cci_cusno,'') as 'cci_cusno', 
	isnull(cci_cnttyp,'') as 'cci_cnttyp', 
	isnull(cci_cntadr,'') as 'cci_cntadr', 
	isnull(cci_cntstt,'') as 'cci_cntstt', 
	isnull(cci_cntcty,'') as 'cci_cntcty', 
	isnull(cci_cntpst,'') as 'cci_cntpst'
FROM 
	CUCNTINF (nolock)
WHERE	
	--cci_cocde	= @cci_cocde and                                                                                                                                                                                                                         
	cci_cusno	= @cci_cusno and
	cci_cnttyp= @cci_cnttyp and
	cci_cntadr <> '' 
ORDER BY 
	cci_cntseq


END
------------------------------------------------------------------------------------------------------------------------------









GO
GRANT EXECUTE ON [dbo].[sp_list_CUCNTINF_SHM00001] TO [ERPUSER] AS [dbo]
GO
