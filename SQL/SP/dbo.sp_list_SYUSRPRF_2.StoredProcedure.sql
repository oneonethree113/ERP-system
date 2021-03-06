/****** Object:  StoredProcedure [dbo].[sp_list_SYUSRPRF_2]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYUSRPRF_2]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYUSRPRF_2]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO















CREATE PROCEDURE [dbo].[sp_list_SYUSRPRF_2] 

 

@cocde nvarchar(6),

@saltem char(1)

 

AS

 

select  ssr_saldiv  , a.ssr_salmgr ,a.ssr_salrep , c.yup_usrnam as 'yup_repnam'  

, b.yup_usrnam as 'yup_mgrnam'

from sysalrel a  

left join syusrprf c on c.yup_usrid = a.ssr_salrep

left join syusrprf b on a.ssr_salmgr = b.yup_usrid

where ssr_saltem = @saltem  and c.yup_accexp >= getdate()

order by ssr_default desc

 

 

 

 

 


GO
GRANT EXECUTE ON [dbo].[sp_list_SYUSRPRF_2] TO [ERPUSER] AS [dbo]
GO
