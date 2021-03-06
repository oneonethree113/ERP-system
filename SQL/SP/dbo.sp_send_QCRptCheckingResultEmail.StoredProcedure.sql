/****** Object:  StoredProcedure [dbo].[sp_send_QCRptCheckingResultEmail]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_send_QCRptCheckingResultEmail]
GO
/****** Object:  StoredProcedure [dbo].[sp_send_QCRptCheckingResultEmail]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[sp_send_QCRptCheckingResultEmail]
@tmprptno nvarchar(20),
@actcde	nvarchar(20),
@check_status nvarchar(20),
@check_message nvarchar(2000)


AS

SET NOCOUNT ON

declare @qeh_fr nvarchar(50)
declare @qeh_to nvarchar(1000)
declare @qeh_cc nvarchar(500)
declare @qeh_sub nvarchar(300)
declare @qeh_content nvarchar(3000)
declare @qeh_tmprptno char(30)
declare @qeh_seq int
declare @qeh_mailflg char(1)
declare @qeh_validflg char(1)
declare @qeh_mailtyp char(1)
declare @qeh_creusr nvarchar(30)
declare @qeh_updusr nvarchar(30)
declare @qeh_credat datetime
declare @qeh_upddat datetime

begin

set @qeh_fr = ''
set @qeh_cc = ''
set @qeh_sub = @tmprptno + ' ' + LOWER(@actcde) + ' result'
set @qeh_content = @check_message
set @qeh_tmprptno = @tmprptno
SET @qeh_seq = (select  ISNULL(MAX(qeh_seq), 0 ) + 1  FROM QCEMLHDR WHERE qeh_tmprptno = @tmprptno)
set @qeh_mailflg = 'Y'
set @qeh_credat = GETDATE();
set @qeh_upddat = GETDATE();
select @qeh_to = yup_mailad , @qeh_creusr = qrh_creusr, @qeh_updusr = qrh_creusr 
from qcrptdtl left join qcrpthdr left join SYUSRPRF on qrh_creusr = yup_usrid
on qrd_tmprptno = qrh_tmprptno 
WHERE qrh_tmprptno =  @tmprptno

if @actcde = 'CONFIRM'
begin
	set @qeh_mailtyp = 'C'
end
else
begin
	set @qeh_mailtyp = 'S'
end

if @check_status = 'CONFIRM' OR @check_status = 'VALID'
begin
	set @qeh_validflg = 'Y'
end
else
begin
	set @qeh_validflg = 'N'
end

insert into QCEMLHDR (qeh_fr,qeh_to,qeh_cc,qeh_sub,qeh_content,qeh_tmprptno,qeh_seq,qeh_mailflg,
qeh_validflg,qeh_mailtyp,qeh_creusr,qeh_updusr,qeh_credat,qeh_upddat) 
select @qeh_fr, 
@qeh_to, 
@qeh_cc, 
@qeh_sub, 
@qeh_content, 
@qeh_tmprptno, 
@qeh_seq, 
@qeh_mailflg, 
@qeh_validflg, 
@qeh_mailtyp, 
@qeh_creusr, 
@qeh_updusr, 
@qeh_credat, 
@qeh_upddat

end




GO
GRANT EXECUTE ON [dbo].[sp_send_QCRptCheckingResultEmail] TO [ERPUSER] AS [dbo]
GO
