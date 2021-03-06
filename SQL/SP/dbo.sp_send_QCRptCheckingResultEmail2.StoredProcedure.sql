/****** Object:  StoredProcedure [dbo].[sp_send_QCRptCheckingResultEmail2]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_send_QCRptCheckingResultEmail2]
GO
/****** Object:  StoredProcedure [dbo].[sp_send_QCRptCheckingResultEmail2]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE  PROCEDURE [dbo].[sp_send_QCRptCheckingResultEmail2]
@tmprptno nvarchar(20),
@actcde	nvarchar(20),
@check_status nvarchar(20),
@check_message nvarchar(2000)


AS

SET NOCOUNT ON
--This stoed procedure will be called by sp_check_QCRpt, sp_update_QCRPTHDR for generating QC report
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
declare @mailid nvarchar(20)
declare @mailProcid nvarchar(20)
declare @subvalidstr nvarchar(20)
declare @apvstr nvarchar(20)

begin

set @qeh_fr = ''
set @qeh_cc = ''
SET @qeh_seq = (select  ISNULL(MAX(qeh_seq), 0 ) + 1  FROM QCEMLHDR WHERE qeh_tmprptno = @tmprptno)

if @check_message<>''
begin
	set @check_message=@check_message+'<br>'
end
set @qeh_content = @check_message
set @qeh_tmprptno = @tmprptno

set @qeh_mailflg = 'Y'
set @qeh_credat = GETDATE();
set @qeh_upddat = GETDATE();

select @qeh_to = yup_mailad , @qeh_creusr = qrh_creusr, @qeh_updusr = qrh_creusr 
from qcrptdtl left join qcrpthdr left join SYUSRPRF on qrh_creusr = yup_usrid
on qrd_tmprptno = qrh_tmprptno 
WHERE qrh_tmprptno =  @tmprptno 


if (select qrh_rpttyp from qcrpthdr where qrh_tmprptno=@tmprptno)='F' 
begin
	if (select qrh_finalstatus from qcrpthdr where qrh_tmprptno=@tmprptno)='' or ((select qrh_finalstatus from qcrpthdr where qrh_tmprptno=@tmprptno) is null)

--Onsite report will not be send to QC anymore
 	begin
		--set @qeh_to=''
		set @qeh_content=@qeh_content --+' This email is for testing only.  Onsite final report will not be send to QC anymore but can be found on web portal. '
	end
	else
	begin
	--in the future the @qeh_to will be QC,VENDOR,SALES,QC requirer if it is a approved report
		set @qeh_to=@qeh_to
		set @qeh_content=@qeh_content --+'In the future the email with final confirmed approved report will be send to QC,VENDOR,SALES,QC requirer if it is an approval report'
	end
end
else
begin
		set @qeh_to=@qeh_to
		set @qeh_content=@qeh_content+'it is a inline repport'
end
------------------------------------------------------------


--Title of email part start
--The format of title is 'UCP "(Inline/pp/final)" Inspection Report in "Vender"       for "Customer" with "Item no"      ["PASS/FAIL/Pending"] ("final/onsite") "Report ID"'
--Example :               UCP        Final        Inspection Report in SHUNJIE (??) for WEC        with S15HD01855MIC  [PASS]                (Final)           QCP981700046
--                              UCP Final Inspection Report in SHUNJIE (??) for WEC with S15HD01855MIC  [PASS] (Final)  QCP981700046
begin

	select top 1 qrh_rpttyp,qrh_inspresult,qrh_venno,qrh_cus1no,qrh_itmno,qrh_othitmno,qrh_finalstatus,qrh_cus2no into #temp from qcrpthdr where qrh_tmprptno=@tmprptno

	declare @onsiteOrFinal nvarchar(20)
	declare @inspresult nvarchar(50)
	declare @reportType nvarchar(50)
	declare @custName nvarchar(30)
	declare @itemno nvarchar(20)
	declare @vendor nvarchar(40)


	--If the result of report has been confirm by head of QC department, the value of qrh_finalstatus will not be Null or ''. 
	--The inspection result of report is the result chosen by the QC staff before the head of QC department confirm. After confirming, the result will be overrided by the confirming result from the department head
	if (select qrh_finalstatus from #temp)='' or ((select qrh_finalstatus from #temp) is null)
	begin
		set @inspresult=isnull((select qrh_inspresult from #temp),"N/A")
		set @onsiteOrFinal='On site'
	end
	else
	begin
		set @inspresult=(select qrh_finalstatus from #temp)
		set @onsiteOrFinal='Final'
	end

	if (select qrh_rpttyp from #temp)='F'
	begin
		set @reportType='Final Inspection Report'
	end
	if (select qrh_rpttyp from #temp)='M'
	begin
		set @reportType='In-line Inspection Report'
	end

	set @custName =(
	select 
	case  when secCust.cbi_cussna IS NULL OR secCust.cbi_cussna = '' 
		then priCust.cbi_cussna 
		else secCust.cbi_cussna 
	end
	from #temp     
		LEFT JOIN CUBASINF priCust on qrh_cus1no = priCust.cbi_cusno 
		LEFT JOIN CUBASINF secCust on qrh_cus2no = secCust.cbi_cusno 
	)
	
	set @itemno  = (select qrh_itmno from  #temp )
                
	if ltrim(rtrim(@itemno )) = '' 
	begin
	set @itemno  = (select qrh_othitmno from  #temp )
	end

	set @vendor=(select vbi_Vensna from #temp left join VNBASINF ON qrh_venno = vbi_venno )

	--set @qeh_sub = 'onsiteOrFinal: '+@onsiteOrFinal+'  reportType: '+@reportType+'  customer name : '+@custName+'  item name:  '+@itemno+'  vendor:   '+@vendor+'   '+@tmprptno + ' ' + LOWER(@actcde) + ' result xxxx(' +  ltrim(Str(@qeh_seq)) + ') (' + @subvalidstr + ', ' +  @apvstr + ')'
	
	if @reportType='Final Inspection Report'
		begin
		set @qeh_sub = 'UCP '+@reportType+' in '+@vendor+' for '+@custName+' with ' +@itemno+'  [' +@inspresult+'] ('+@onsiteOrFinal+')  '+@tmprptno
		end 
	else 
		begin
		set @qeh_sub = 'UCP '+@reportType+' in '+@vendor+' for '+@custName+' with ' +@itemno+' (In-line)'+@tmprptno

		end
	
	drop table #temp
end
--Title of email part end

begin
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
		set @subvalidstr = 'Valid'
	end
	else
	begin
		set @qeh_validflg = 'N'
		set @subvalidstr = 'Invalid'
	end
	
	if  (select qrh_finalstatus from qcrpthdr where qrh_tmprptno=@tmprptno)='' or ((select qrh_finalstatus from qcrpthdr where qrh_tmprptno=@tmprptno) is null)
	begin
		set @apvstr = @actcde
	end
	else
	begin
		set @apvstr = ' Approval'
	end



	set @qeh_content = " Remark: "+@tmprptno + ' ' + LOWER(@apvstr) + ' result (' +  ltrim(Str(@qeh_seq)) + ') (' + @subvalidstr  + ') <br> '+@qeh_content
end

--if the report is 'final' 'confirmed' 'on site' report, generate one more report without image for factory 
declare @rpttyp as nvarchar(15)
declare @rptstatus as nvarchar(20)
declare @finalstatus as nvarchar(50)
select @rpttyp=qrh_rpttyp,@rptstatus=qrh_rptstatus,@finalstatus=qrh_finalstatus from QCRPTHDR where qrh_tmprptno=@qeh_tmprptno
exec [sp_select_DOC_GEN_OUTPUT] 'UCP', 'EM', 'mis', @mailid output
if @rpttyp='F' and @rptstatus='CONFIRM' and @finalstatus is null 
	begin
		-- SET @qeh_to = @qeh_to+'henryli@ucp.com.hk'--It should be Factory address
		insert into QCEMLHDR (qeh_fr,qeh_to,qeh_cc,qeh_sub,qeh_content,qeh_tmprptno,qeh_seq,qeh_mailflg,
		qeh_validflg,qeh_mailtyp,qeh_creusr,qeh_updusr,qeh_credat,qeh_upddat) 
		select @qeh_fr, 
		@qeh_to, 
		@qeh_cc, 
		@qeh_sub, 
		@qeh_content+'. This is the report for factory. This is a final confirm report ', 
		@qeh_tmprptno, 
		@qeh_seq, 
		@qeh_mailflg, 
		@qeh_validflg, 
		@qeh_mailtyp, 
		@qeh_creusr, 
		@qeh_updusr, 
		@qeh_credat, 
		@qeh_upddat

		--exec [sp_select_DOC_GEN_OUTPUT] 'UCP', 'EM', 'mis', @mailid output

		--insert into EMSYSHDR VALUES(
		--@mailid,
		--1,
		--'QCAPP',
		--rtrim(@qeh_tmprptno),
		--1,
		--@actcde,
		--'erpsystem@ucp.com.hk',
		--@qeh_to,
		--@qeh_cc,
		--'chrisleung@ucp.com.hk;marco@ucp.com.hk;henryli@ucp.com.hk',
		--@qeh_sub,
		--@qeh_content+'. This is the report for factory. The report sould be no image ',
		--'I',
		--getdate(),
		--getdate(),
		--'mis',
		--'mis',null)

		exec [sp_select_DOC_GEN_OUTPUT] 'UCP', 'EP', 'mis', @mailprocid output

		insert into EMPROCESS values(
		@mailprocid,
		@mailid,
		'QCAPP01',
		'R',
		'',
		'QC Gen Report',
		'QCAPP',
		rtrim(@qeh_tmprptno),
		@qeh_seq,
		'QCRPT-no img',
		getdate(),
		getdate(),
		'mis',
		'mis',
		 null
		)
		
		 SET @qeh_seq = @qeh_seq+1
		update EMSYSHDR  set  esh_status = 'R'  where esh_mailid = @mailid
	end


insert into QCEMLHDR (qeh_fr,qeh_to,qeh_cc, qeh_sub, qeh_content, qeh_tmprptno,   qeh_seq, qeh_mailflg,
	qeh_validflg, qeh_mailtyp, qeh_creusr, qeh_updusr, qeh_credat, qeh_upddat) 
select				@qeh_fr,@qeh_to,@qeh_cc,@qeh_sub,@qeh_content,@qeh_tmprptno, @qeh_seq, @qeh_mailflg, 
	@qeh_validflg,@qeh_mailtyp,@qeh_creusr,@qeh_updusr,@qeh_credat,@qeh_upddat



insert into EMSYSHDR VALUES(
@mailid,
1,
'QCAPP',
rtrim(@qeh_tmprptno),
1,
@actcde,
'erpsystem@ucp.com.hk',
@qeh_to,
@qeh_cc,
'chrisleung@ucp.com.hk;marco@ucp.com.hk;henryli@ucp.com.hk',
@qeh_sub,
@qeh_content,
'I',
getdate(),
getdate(),
'mis',
'mis',null)

exec [sp_select_DOC_GEN_OUTPUT] 'UCP', 'EP', 'mis', @mailprocid output

insert into EMPROCESS values(
@mailprocid,
@mailid,
'QCAPP01',
'R',
'',
'QC Gen Report',
'QCAPP',
rtrim(@qeh_tmprptno),
@qeh_seq,
'QCRPT',
getdate(),
getdate(),
'mis',
'mis',
 null
)

update EMSYSHDR  set  esh_status = 'R'  where esh_mailid = @mailid



end




GO
GRANT EXECUTE ON [dbo].[sp_send_QCRptCheckingResultEmail2] TO [ERPUSER] AS [dbo]
GO
