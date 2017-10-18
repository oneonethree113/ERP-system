/****** Object:  StoredProcedure [dbo].[sp_select_Shipmark_BMP]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_Shipmark_BMP]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_Shipmark_BMP]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_select_Shipmark_BMP] 
as

select 
--stm_ordno,
--stm_ordseq,
--stm_jobno,
distinct stm_smkno
--case stm_act when 'DEL' then 'DEL' else 'ADD' end as 'stm_act',
--sod_zorvbeln,
--sod_zorposnr,
--stm_credat,
--stm_upddat
from SCTPSMRK (nolock), SCORDDTL (nolock)
where stm_ordno = sod_ordno and stm_ordseq = sod_ordseq
--and stm_credat >'2015-4-29' and stm_credat <= getdate()
and stm_credat >'2015-10-07' and stm_credat <= getdate()
--order by stm_smkno  desc
--and stm_credat > getdate() - 1 and stm_credat <= getdate()







GO
GRANT EXECUTE ON [dbo].[sp_select_Shipmark_BMP] TO [ERPUSER] AS [dbo]
GO
