/****** Object:  StoredProcedure [dbo].[sp_insert_qcrptpho]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_qcrptpho]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_qcrptpho]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   PROCEDURE [dbo].[sp_insert_qcrptpho] 
	@QCRptNo nvarchar(20)

AS BEGIN
	
	INSERT INTO 
		qcrptpho (
		qrp_tmprptno, 
		qrp_flg,
		qrp_creusr, qrp_updusr, qrp_credat, qrp_upddat
	) SELECT
		@QCRptNo, 
		'N',
		'mis','mis', getdate(), getdate()


IF ( Select count(*) from qcrpthdr where qrh_tmprptno = 
@QCRptNo ) > 0 
begin
	select @QCRptNo  as rtn_value
end
else
begin
    delete from qcrptpho where qrp_tmprptno = @QCRptNo
	 
	select 'fail' as rtn_value
end


END


GO
GRANT EXECUTE ON [dbo].[sp_insert_qcrptpho] TO [ERPUSER] AS [dbo]
GO
