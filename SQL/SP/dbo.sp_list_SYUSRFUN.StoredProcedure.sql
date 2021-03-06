/****** Object:  StoredProcedure [dbo].[sp_list_SYUSRFUN]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYUSRFUN]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYUSRFUN]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







--Modification History
--Modified By	Modified On	Description
--Lester Wu	2004/07/06		change the character length of @usrid from 6 to 12
--Lester Wu	2004/09/30 	Add Sorting by User Function
--Lester Wu	2005-04-15	retrieve user function base on user's login company group
--				Remark : no data will be selected if user is not in UCP/UCPP/MS company by default
--Henry Li 2017/06/29 		change the character length of @usrid of the whole SP from 12 to 30, want to die
CREATE   PROCEDURE [dbo].[sp_list_SYUSRFUN] 
@cocde nvarchar(6),
--@usrid nvarchar(30)
@usrid nvarchar(30),
@coGrp nvarchar(6)
AS


--declare @cocde nvarchar(6)
set @cocde=''

select @cocde = yuc_cocde 
from SYMUSRCO(NOLOCK)
where yuc_usrid=@usrid
and yuc_flgdef='Y'

select *,SUBSTRING(yuf_usrfun,1,3 )+SUBSTRING(yuf_usrfun,7,2 ) as "yuf_usrfun2"
from syusrfun
--where yuf_cocde = @cocde
where 
yuf_cocde = case @coGrp when 'UCG' then @cocde else 'MS' end and 
yuf_cogrp = @coGrp
order by yuf_usrfun -- Lester Wu 2004/09/30 Add Sorting by User Function










GO
GRANT EXECUTE ON [dbo].[sp_list_SYUSRFUN] TO [ERPUSER] AS [dbo]
GO
