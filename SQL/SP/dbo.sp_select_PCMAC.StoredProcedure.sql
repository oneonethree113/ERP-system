/****** Object:  StoredProcedure [dbo].[sp_select_PCMAC]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PCMAC]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PCMAC]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



create procedure [dbo].[sp_select_PCMAC]
@cocde varchar(6),
@pma_pcno varchar(20)
AS
begin

	select 	'' as 'pma_del',
		pma_pcno,
		pma_invacno_new as 'pma_invacno',
		pma_siacno_new as 'pma_siacno',
		pma_iaacno_new as 'pma_iaacno',
		pma_stacno_new as 'pma_stacno',
		pma_creusr,
		'' as 'pma_status'
	from	PCMAC
	where pma_pcno = @pma_pcno
	end


GO
GRANT EXECUTE ON [dbo].[sp_select_PCMAC] TO [ERPUSER] AS [dbo]
GO
