/****** Object:  StoredProcedure [dbo].[sp_update_QCRPTHDR_ship]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_QCRPTHDR_ship]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_QCRPTHDR_ship]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_update_QCRPTHDR_ship]
	@shipapprv nvarchar(50),
	@rptno nvarchar(50)

AS 
BEGIN
--select @rptno as 'test'
update	QCRPTHDR
	set qrh_shipapprv = @shipapprv
		where Rtrim(Ltrim(qrh_tmprptno)) = Rtrim(Ltrim(@rptno))

END

GO
GRANT EXECUTE ON [dbo].[sp_update_QCRPTHDR_ship] TO [ERPUSER] AS [dbo]
GO
