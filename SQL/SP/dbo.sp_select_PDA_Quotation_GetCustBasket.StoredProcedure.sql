/****** Object:  StoredProcedure [dbo].[sp_select_PDA_Quotation_GetCustBasket]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PDA_Quotation_GetCustBasket]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PDA_Quotation_GetCustBasket]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/*
=========================================================
Description   	: sp_select_PDA_Quotation_GetQuot
Programmer  	: PIC
Create Date   	: 2008-06-18
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      Initial  	Description                          
=========================================================    */ 
CREATE procedure [dbo].[sp_select_PDA_Quotation_GetCustBasket]
@usrid		nvarchar(30)


as

select distinct   qud_cus1no + '-' +  p.cbi_cussna as 'qud_cus1no',  
case when isnull(qud_cus2no,'') = '' then '' else  qud_cus2no + '-' + s.cbi_cussna end as 'qud_cus2no'
/*
,
convert(datetime,substring (qud_sessid, 1 , charindex('_',qud_sessid) -1 - 6),111 )as 'qud_credat',
substring (qud_sessid, charindex('_',qud_sessid) +1 , len(qud_sessid ) -  charindex('_',qud_sessid)) as 'qud_creusr'
*/


from pda_quot
left join SYSALREP as q (nolock) on  q.ysr_code = qud_creusr 
left join SYSALREP as u (nolock) on  u.ysr_code = @usrid 
left join SYMUSRCO  (nolock)  on yuc_usrid  = @usrid
left join cubasinf as p (nolock) on qud_cus1no = p.cbi_cusno
left join cubasinf as s (nolock) on qud_cus2no = s.cbi_cusno
where  isnull(qud_aprsts,'') = '' and
(  ( qud_creusr = @usrid or q.ysr_saltem = u.ysr_saltem  or u.ysr_saltem = 'S'  or yuc_supid = @usrid or yuc_usrgrp like '%MGT%' or isnull(u.ysr_saltem,'') = '') and @usrid <> '')
--or isnull(u.ysr_saltem,'') = ''
and isnull(qud_aprsts,'') ='' and isnull(qud_qutno,'') = ''  and isnull(qud_tmpqutno,'') <> ''
and qud_credat >=  convert(nvarchar(10),getdate(),121)
order by   qud_cus1no asc, qud_cus2no asc



GO
GRANT EXECUTE ON [dbo].[sp_select_PDA_Quotation_GetCustBasket] TO [ERPUSER] AS [dbo]
GO
