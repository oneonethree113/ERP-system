/****** Object:  StoredProcedure [dbo].[sp_select_IMITMDAT_ItmSeq]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMITMDAT_ItmSeq]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMITMDAT_ItmSeq]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO











/*
=================================================================
Program ID	: sp_select_IMITMDAT_ItmSeq
Description	: Retrieve Next IMITMDAT Item Sequence
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2014-03-03 	David Yue		SP Created
=================================================================
*/

CREATE PROCEDURE [dbo].[sp_select_IMITMDAT_ItmSeq] 

AS

declare	@cur_itmseq int
declare	@his_itmseq int

select	@cur_itmseq = isnull(max(iid_itmseq), 0) + 1
from	IMITMDAT (nolock)

select	@his_itmseq = isnull(max(iid_itmseq), 0) + 1
from	IMITMDATH (nolock)

if @his_itmseq > @cur_itmseq
	select	@his_itmseq as 'iid_itmseq'
else
	select	@cur_itmseq as 'iid_itmseq'



GO
GRANT EXECUTE ON [dbo].[sp_select_IMITMDAT_ItmSeq] TO [ERPUSER] AS [dbo]
GO
