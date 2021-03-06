/****** Object:  StoredProcedure [dbo].[sp_select_IMType]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMType]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMType]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO













------------------------------------------------- 
CREATE procedure [dbo].[sp_select_IMType]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ibi_cocde nvarchar(6) ,
@ibi_itmno nvarchar(20) 
                                               
---------------------------------------------- 
 
AS
begin

declare @IM char(1),@IMH char(1),@PCIM char(1),@PCIMH char(1)

set @IM = 'N'
set @IMH = 'N'
set @PCIM = 'N'
set @PCIMH = 'N'

if (select count(*) from IMBASINF (nolock) where ibi_itmno = @ibi_itmno) = 1
	set @IM = 'Y'
else if (select count(*) from IMBASINFH (nolock) where ibi_itmno = @ibi_itmno) = 1
	set @IMH = 'Y'

--if (select count(*) from IMPCBASINF (nolock) where ibi_itmno = @ibi_itmno) = 1
--	set @PCIM = 'Y'
--else if (select count(*) from IMPCBASINFH (nolock) where ibi_itmno = @ibi_itmno) = 1
--	set @PCIMH = 'Y'

select @ibi_itmno 'ItemNo', @IM 'IM', @IMH 'IMH', @PCIM 'PCIM', @PCIMH 'PCIMH'



end



GO
GRANT EXECUTE ON [dbo].[sp_select_IMType] TO [ERPUSER] AS [dbo]
GO
