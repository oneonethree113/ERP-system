/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUCSTAMT]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_CUCSTAMT]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUCSTAMT]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








/************************************************************************
Author:		Lester Wu
Date:		12th September, 2008
Description:	delete data From CUCSTAMT
***********************************************************************
*/

CREATE procedure [dbo].[sp_physical_delete_CUCSTAMT]


@cca_cocde	nvarchar(6),
@cca_cusno	nvarchar(6),
@cca_cecde	nvarchar(6),
@cca_seq	int

 
AS

BEGIN

--------------------------------------------------------------------------------------------------

if @cca_cecde = 'ALL' 
begin

delete FROM	CUCSTAMT
WHERE	
cca_cusno = @cca_cusno

end
else if @cca_cecde = 'GRP'
begin

delete FROM	CUCSTAMT
WHERE	
cca_cusno = @cca_cusno and
cca_cecde = @cca_cecde

end
else
begin

delete FROM	CUCSTAMT
WHERE	
cca_cusno = @cca_cusno and
cca_cecde = @cca_cecde and
cca_seq = @cca_seq

end

END






GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_CUCSTAMT] TO [ERPUSER] AS [dbo]
GO
