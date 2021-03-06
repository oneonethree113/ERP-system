/****** Object:  StoredProcedure [dbo].[sp_select_QCM00009_POULFILE]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QCM00009_POULFILE]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QCM00009_POULFILE]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO




Create     procedure [dbo].[sp_select_QCM00009_POULFILE] 
@cocde as nvarchar(6) , 
@poFm as nvarchar(20) , 
@poTo as nvarchar(20) , 
@usrid	nvarchar(30),
@doctyp nvarchar(2),
@dummy as char(1),
@type as char(1)

as

begin
select 
puf_ordno,
puf_ordseq,
puf_ordnoseq,
puf_jobno,
puf_filepath,
puf_file,
puf_creusr, 

puf_type
from POULFILE 
where
puf_ordno >= @poFm and puf_ordno <= @poTo 
and puf_act <> 'DEL'                
end










GO
GRANT EXECUTE ON [dbo].[sp_select_QCM00009_POULFILE] TO [ERPUSER] AS [dbo]
GO
