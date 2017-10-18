/****** Object:  StoredProcedure [dbo].[sp_select_SYSDESC]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYSDESC]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYSDESC]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/************************************************************************
Author:		Louis Siu   
Date:		19th Dec, 2001
Description:	Select data From SYUSRGRP
************************************************************************/

CREATE procedure [dbo].[sp_select_SYSDESC]
                                                                                                                                                                                                                                                                 

@cocde nvarchar(6),
@usrgrp nvarchar(6),
@usrfun nvarchar(10)

AS

begin

Select	yug_grpdsc

from SYUSRGRP
where

yug_usrgrp = @usrgrp 

GROUP BY yug_grpdsc

end




GO
GRANT EXECUTE ON [dbo].[sp_select_SYSDESC] TO [ERPUSER] AS [dbo]
GO
