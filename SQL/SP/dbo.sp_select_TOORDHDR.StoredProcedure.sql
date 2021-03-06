/****** Object:  StoredProcedure [dbo].[sp_select_TOORDHDR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_TOORDHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_TOORDHDR]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




CREATE   PROCEDURE [dbo].[sp_select_TOORDHDR]
@toh_cocde		nvarchar(6),
@toh_toordno		nvarchar(20)

AS

select 
toh_cocde,
toh_toordno,
toh_ordsts,
toh_issdat,
toh_rvsdat,
toh_verno,
toh_saldiv,
toh_saltem,
toh_salrep,
toh_custcde,
toh_buyer,
toh_year,
toh_cus1no,
toh_cus2no,
toh_refqut,
toh_to,
toh_cc,
toh_fm,
toh_rmk,
toh_season,
toh_creusr,
toh_updusr,
toh_credat,
toh_upddat,
cast(toh_timstp as int) as 'toh_timstp'
from 
TOORDHDR (nolock)
where toh_cocde = @toh_cocde and toh_toordno = @toh_toordno



GO
GRANT EXECUTE ON [dbo].[sp_select_TOORDHDR] TO [ERPUSER] AS [dbo]
GO
