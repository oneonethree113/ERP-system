/****** Object:  StoredProcedure [dbo].[sp_insert_CUSHPFML]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_CUSHPFML]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_CUSHPFML]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





CREATE procedure [dbo].[sp_insert_CUSHPFML]
@csf_cocde nvarchar(6),
@csf_cus1no nvarchar(10),
@csf_cus2no nvarchar(10),
@csf_venno nvarchar(10),
@csf_shpstrbuf	int,
@csf_shpendbuf	int,
@csf_cancelbuf	int,
@csf_creusr	nvarchar(30)
AS

begin

insert into CUSHPFML
(csf_cocde, csf_cus1no, csf_cus2no, csf_venno, 
csf_shpstrbuf, csf_shpendbuf, csf_cancelbuf, csf_creusr, csf_updusr,
csf_credat, csf_upddat)
values 
( @csf_cocde ,@csf_cus1no  ,@csf_cus2no ,@csf_venno ,
@csf_shpstrbuf, @csf_shpendbuf, @csf_cancelbuf, @csf_creusr, @csf_creusr,
getdate(),getdate())

end









GO
GRANT EXECUTE ON [dbo].[sp_insert_CUSHPFML] TO [ERPUSER] AS [dbo]
GO
