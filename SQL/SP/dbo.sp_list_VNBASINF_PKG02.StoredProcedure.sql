/****** Object:  StoredProcedure [dbo].[sp_list_VNBASINF_PKG02]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_VNBASINF_PKG02]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_VNBASINF_PKG02]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








-- Checked by Allan Yuen at 28/07/2003


CREATE  procedure [dbo].[sp_list_VNBASINF_PKG02]
	@vbi_cocde nvarchar(6) 
AS

Select 
vbi_cocde,
vbi_venno,
vbi_vensts,
vbi_vensna,
vbi_vennam,
vbi_venrat,
vbi_prctrm,
vbi_paytrm,
vbi_curcde,
vbi_discnt,
vbi_orgven,
vbi_rmk,
vbi_ledtim,
vbi_tsttim,
vbi_bufday,
vbi_venweb,
vbi_ventyp,
vbi_moqchg,
vbi_creusr,
vbi_updusr,
vbi_credat,
vbi_upddat,
cast(vbi_timstp as int) as vbi_timstp,
vbi_ventyp,
vbi_venfty,
case vnc1.vci_adr when '' then case vnc1.vci_chnadr when '' then '' else vnc1.vci_chnadr end else vnc1.vci_adr end as 'vci_address',
vnc1.vci_cty,
vnc1.vci_stt,
vnc1.vci_zip,
vnc2.vci_cntctp,
vnc2.vci_cntphn

from 
	VNBASINF
left join vncntinf vnc1 on vnc1.vci_venno = vbi_venno and vnc1.vci_cnttyp = 'M'
left join vncntinf vnc2 on vnc2.vci_venno = vbi_venno and vnc2.vci_cnttyp <> 'M' and vnc2.vci_cntdef  ='Y'
where
 vbi_cocde = ' ' 
order by vbi_venno




GO
GRANT EXECUTE ON [dbo].[sp_list_VNBASINF_PKG02] TO [ERPUSER] AS [dbo]
GO
