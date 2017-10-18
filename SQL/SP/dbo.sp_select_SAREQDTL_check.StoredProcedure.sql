/****** Object:  StoredProcedure [dbo].[sp_select_SAREQDTL_check]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SAREQDTL_check]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SAREQDTL_check]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO



-- Checked by Allan Yuen at 30/07/2003

CREATE PROCEDURE [dbo].[sp_select_SAREQDTL_check]

@srd_cocde	nvarchar(6),
@srd_reqno	nvarchar(20),
@srd_reqseq	int,
@srd_creusr	nvarchar(30)

AS


select 	sad_orgitm, sad_itmno, sad_colcde
from 	SAORDDTL
where	sad_cocde = @srd_cocde and sad_reqno = @srd_reqno and 
	sad_reqseq = @srd_reqseq --and sad_delflg = 'N'




GO
GRANT EXECUTE ON [dbo].[sp_select_SAREQDTL_check] TO [ERPUSER] AS [dbo]
GO
