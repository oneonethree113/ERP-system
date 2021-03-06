/****** Object:  StoredProcedure [dbo].[sp_select_qcrptimg2]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_qcrptimg2]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_qcrptimg2]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_select_qcrptimg2] 
@TmpRPTNo as nvarchar(30)

AS
begin

SELECT 
bb.qdt_dftseq,bb.qdt_imgseq,bb.qdt_file ,aa.qdt_dftdsc +' ('  + 
case 
when bb.qdt_dftcat like '%Crit%'
then  'Critical'
else  bb.qdt_dftcat
end
 + ')' as 'rmk' 
from qcdftimg  bb
			left join QCRPTDFT aa
				on bb.qdt_tmprptno = aa.qdt_tmprptno
				and  bb.qdt_dftseq  = aa.qdt_dftseq  
where  bb.qdt_tmprptno = @TmpRPTNo 
		order by bb.qdt_dftseq,bb.qdt_imgseq
		
END



---


GO
GRANT EXECUTE ON [dbo].[sp_select_qcrptimg2] TO [ERPUSER] AS [dbo]
GO
