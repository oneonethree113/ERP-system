/****** Object:  StoredProcedure [dbo].[sp_update_QCRPTHDR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_QCRPTHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_QCRPTHDR]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_update_QCRPTHDR]
	@shipapprv nvarchar(50),
	@fsts nvarchar(50),
	@rptno nvarchar(50)

AS 
BEGIN
--select @rptno as 'test'
-------------------------
--if head of QC department confirm a report/ change the final status to  non-'REJECT' status, 
--the system will call the stored procedure [sp_send_QCRptCheckingResultEmail] 
--so the DB contains a record 
--which means the report will be generated again
declare @finalstatus as nvarchar(50)
declare @sendNewReportFlag as nvarchar(10)
set @sendNewReportFlag ='false'
set @finalstatus=(select qrh_finalstatus from QCRPTHDR where Rtrim(Ltrim(qrh_tmprptno)) = Rtrim(Ltrim(@rptno)))
if (@finalstatus<>@fsts or @finalstatus is null) and @fsts<>'REJECT'--before confirming, the final status of the report (qrh_finalstatus column in QCRPTHDR ) will be Null/''
begin
	set @sendNewReportFlag ='true'
end
-----------------------
update	QCRPTHDR
	set qrh_finalstatus = @fsts,	
		qrh_shipapprv =@shipapprv ,
		qrh_upddat = getdate()
		where Rtrim(Ltrim(qrh_tmprptno)) = Rtrim(Ltrim(@rptno))
--The record to regenerate the report contains information about finalstaus, so the stored procedure is run after the update.
if @sendNewReportFlag ='true'
begin
	exec [sp_send_QCRptCheckingResultEmail2]  @rptno,'CONFIRM','CONFIRM',''
end
--at this moment(09-02-2017), the following code is meaningless. The condition will never be fulfilled
update qcrpthdr 
set qrh_shipapprv = 'Accept'
where qrh_shipapprv  = 'P1'

update qcrpthdr 
set qrh_shipapprv = 'Agreed to ship W/LG'
where qrh_shipapprv  = 'P2'

update qcrpthdr 
set qrh_shipapprv = 'Ship Under AOD'
where qrh_shipapprv  = 'P3'

update qcrpthdr 
set qrh_shipapprv = 'Re-inspection'
where qrh_shipapprv  = 'P4'


update qcrpthdr 
set qrh_shipapprv = 'Reject'
where qrh_shipapprv  = 'P5'


update qcrpthdr 
set qrh_finalstatus = 'PASS'
where qrh_finalstatus  = 'P1'

update qcrpthdr 
set qrh_finalstatus = 'FAIL'
where qrh_finalstatus  = 'P2'

update qcrpthdr 
set qrh_finalstatus = 'PENDING'
where qrh_finalstatus  = 'P3'



END






GO
GRANT EXECUTE ON [dbo].[sp_update_QCRPTHDR] TO [ERPUSER] AS [dbo]
GO
