/****** Object:  StoredProcedure [dbo].[sp_select_VNCNTINF_PG04]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_VNCNTINF_PG04]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_VNCNTINF_PG04]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





------------------------------------------------- 
CREATE PROCEDURE [dbo].[sp_select_VNCNTINF_PG04] 

@cocde  	nvarchar(6),
@venno		nvarchar(20)

AS


 select vci_adr as 'vci_adr' from VNCNTINF(nolock)
where vci_venno = @venno and vci_adr <> ''

union 

select vci_chnadr as 'vci_adr' from VNCNTINF(nolock)
where vci_venno = @venno and vci_chnadr<>''

 




GO
GRANT EXECUTE ON [dbo].[sp_select_VNCNTINF_PG04] TO [ERPUSER] AS [dbo]
GO
