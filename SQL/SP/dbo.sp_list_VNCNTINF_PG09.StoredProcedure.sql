/****** Object:  StoredProcedure [dbo].[sp_list_VNCNTINF_PG09]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_VNCNTINF_PG09]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_VNCNTINF_PG09]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







------------------------------------------------- 
CREATE PROCEDURE [dbo].[sp_list_VNCNTINF_PG09] 

@cocde  	nvarchar(6)

AS


 select  vci_venno,  vci_adr as 'vci_adr' from VNCNTINF(nolock)
left join vnbasinf on vci_venno = vbi_venno
where  vci_adr <> '' and vbi_venflag = 'P' and vbi_vensts = 'A' and vci_cnttyp ='M'

union 

select vci_venno, vci_chnadr as 'vci_adr' from VNCNTINF(nolock)
left join vnbasinf on vci_venno = vbi_venno
where  vci_chnadr<>'' and vbi_venflag = 'P' and vbi_vensts = 'A' and vci_cnttyp ='M'

 

 




GO
GRANT EXECUTE ON [dbo].[sp_list_VNCNTINF_PG09] TO [ERPUSER] AS [dbo]
GO
