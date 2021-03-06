/****** Object:  StoredProcedure [dbo].[sp_update_CODYNSQL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_CODYNSQL]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_CODYNSQL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO




/*	Author : Tommy Ho	*/

CREATE procedure [dbo].[sp_update_CODYNSQL]
                                                                                                                                                                                                                                                                 
@cds_cocde 	nvarchar(6),
@cds_sqlseq  	int,
@cds_usrid	nvarchar(30),
@cds_sqldsc	nvarchar(200),
@cds_sqlsta	nvarchar(3500)
                                   
AS
 
update CODYNSQL

SET

cds_sqldsc 	= 	@cds_sqldsc,
cds_sqlsta 	= 	@cds_sqlsta,
cds_updusr	=	@cds_usrid,
cds_upddat 	= 	getdate()

where 

cds_cocde 	= 	@cds_cocde 	and
cds_usrid 	= 	@cds_usrid  	and 
cds_sqlseq 	= 	@cds_sqlseq

---------------------------------------------------------------------------------------------------------------------------------------------------------------------





GO
GRANT EXECUTE ON [dbo].[sp_update_CODYNSQL] TO [ERPUSER] AS [dbo]
GO
