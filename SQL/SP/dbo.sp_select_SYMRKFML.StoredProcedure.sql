/****** Object:  StoredProcedure [dbo].[sp_select_SYMRKFML]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYMRKFML]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYMRKFML]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






-- Checked by Allan Yuen at 28/07/2003



CREATE PROCEDURE [dbo].[sp_select_SYMRKFML] 

@ymf_cocde 	nvarchar(6) = ' ',
@ymf_degvenno	nvarchar(6),
@ymf_prdvenno	nvarchar(6)
AS

Select 
ymf_creusr as 'ymf_status',
ymf_cocde,
ymf_degvenno,
ymf_prdvenno,
ymf_seq,
ymf_mkpopt,
a.yfi_prcfml,	-- 
a.yfi_fml,		--
ymf_fmlopt,
b.yfi_prcfml,	--
b.yfi_fml		--
ymf_def,
ymf_effdat,
ymf_creusr,
ymf_updusr,
ymf_credat,
ymf_upddat,
cast(ymf_timstp as int) as ymf_timstp


from SYMRKFML
--left join SYFMLINF a on a.yfi_cocde = @ymf_cocde and a.yfi_fmlopt = ymf_mkpopt
--left join SYFMLINF b on b.yfi_cocde = @ymf_cocde and b.yfi_fmlopt = ymf_fmlopt
left join SYFMLINF a on a.yfi_fmlopt = ymf_mkpopt
left join SYFMLINF b on b.yfi_fmlopt = ymf_fmlopt
--where ymf_cocde = @ymf_cocde and
where ymf_cocde = ' ' and
ymf_degvenno = @ymf_degvenno and
ymf_prdvenno = @ymf_prdvenno
order by ymf_mkpopt, ymf_fmlopt










GO
GRANT EXECUTE ON [dbo].[sp_select_SYMRKFML] TO [ERPUSER] AS [dbo]
GO
