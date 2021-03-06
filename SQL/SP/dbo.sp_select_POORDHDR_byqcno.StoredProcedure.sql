/****** Object:  StoredProcedure [dbo].[sp_select_POORDHDR_byqcno]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_POORDHDR_byqcno]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_POORDHDR_byqcno]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE   procedure [dbo].[sp_select_POORDHDR_byqcno]


@qch_cocde nvarchar(6)                                                


AS

BEGIN

select       distinct
        qpd_cocde,
		qpd_qcno, 
        isnull(qpd_purord,'') as 'qpd_purord'
from        QCREQHDR (nolock)
        left join QCPORDTL (nolock)
        on qpd_qcno=qch_qcno
where      qch_qcsts = 'REL'
		AND qpd_verdoc < qch_verno
        --AND DATEDIFF(DAY,qch_upddat ,GETDATE()) =0
        and qpd_purord <> 'NULL'
		and qpd_qcno not in (select qca_qcno from QCREQACT where qca_qcno = qpd_qcno and qca_actyp = 'R')
        order by qpd_purord

END











GO
GRANT EXECUTE ON [dbo].[sp_select_POORDHDR_byqcno] TO [ERPUSER] AS [dbo]
GO
