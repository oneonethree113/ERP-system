/****** Object:  StoredProcedure [dbo].[sp_select_QUR0000excel]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QUR0000excel]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QUR0000excel]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO





CREATE    PROCEDURE [dbo].[sp_select_QUR0000excel]   
  
@cocde	nvarchar(6),  
@from	nvarchar(20),  
@to	nvarchar(20),  
@sortBy	nvarchar(4),
@usrid	nvarchar(30),
@doctyp	nvarchar(2)  
  
AS  
  
BEGIN  
	--********************************Temp Table ************************************  
	DECLARE  
	@pre_qutno	nvarchar(20),  
	@pre_qutseq	int,
	@tmptive		nvarchar(2000),  
	@qutno		nvarchar(20),  
	@qutseq		int,  
	@destive		nvarchar(200),  
	@asstive		numeric(6,3),  
	@strflg		int  
   
	SET @tmptive = ''  
	SET @pre_qutno = ''  
	SET @pre_qutseq = 0  
   
	SET @strflg = 0  
   
	CREATE TABLE #tempTable  
		(temp_cocde	nvarchar(6)		NULL,      
		 temp_qutno	nvarchar(20)	NULL,  
		 temp_qutseq	int		NULL,  
		 temp_tive		nvarchar(2000)	NULL  
		) ON [PRIMARY]       
  
	DECLARE		cur_QUOTNHDR CURSOR  
	FOR SELECT	hdr.quh_qutno, dtl.qud_qutseq, com.qcb_cpt, com.qcb_pct  
	FROM		QUOTNHDR hdr, QUOTNDTL dtl, QUCPTBKD com
	WHERE		hdr.quh_cocde = @cocde	AND  
			hdr.quh_qutno >= @from	AND  
			hdr.quh_qutno <= @to		AND  
			dtl.qud_cocde = hdr.quh_cocde	AND  
			dtl.qud_qutno = hdr.quh_qutno	AND  
			dtl.qud_qutno = com.qcb_qutno	AND  
			dtl.qud_qutseq = com.qcb_qutseq  
	ORDER BY	hdr.quh_qutno, dtl.qud_qutseq  
    
	OPEN		cur_QUOTNHDR  
	FETCH NEXT FROM	cur_QUOTNHDR
	INTO		@qutno, @qutseq, @destive, @asstive   
   
	IF @strflg = 0   
	BEGIN  
		SET @pre_qutno = @qutno  
		SET @pre_qutseq = @qutseq    
	END  
   
	WHILE @@fetch_status = 0   
	BEGIN   
    		SET @strflg = 1  
    
		IF @pre_qutno = @qutno AND @pre_qutseq = @qutseq  
		BEGIN  
			SET @tmptive = @tmptive + @destive + ' ' + str(@asstive) + '%' + char(13)  
		END  
		ELSE  
		BEGIN  
			INSERT INTO #tempTable
				(temp_cocde,	temp_qutno,	temp_qutseq,	temp_tive)
			VALUES	(@cocde,		@qutno,		@qutseq,		@tmptive)   
  
			SET @tmptive = ''  
			SET @tmptive = @tmptive + @destive + ' ' + str(@asstive) + '%' + char(13)  
       
		END  
    
		SET @pre_qutno = @qutno  
		SET @pre_qutseq = @qutseq  
   
	FETCH NEXT FROM	cur_QUOTNHDR
	INTO		@qutno, @qutseq, @destive, @asstive   
	END  
   
CLOSE cur_QUOTNHDR
DEALLOCATE cur_QUOTNHDR     
--******************************************************************************  
  
Select	quh_cocde as 'Code',   
	quh_cus1no as 'Primary Customer',   
	isnull(cbi_cusnam,'') as 'Primary Cust Name',  
	quh_qutno as 'Quotation No',  
	qud_qutseq as 'Sequence No',  
	quh_rvsdat as 'Revised Date',  
	quh_valdat as 'Validity Date',  
	qud_itmno as 'Item #',  
	cals.ica_cusalsitm as 'Customer Alias No.',  
	qud_cusitm as 'Cust Item #',  
	qud_alsitmno as 'Old Item #',  
	qud_alscolcde as 'Old VD. Color Code',  
	qud_itmdsc as 'Item Desc',  
	qud_colcde as 'VD. Color Code',  
	qud_cuscol as 'Cust Color Code',   
	qud_coldsc as 'Color Desc',  
	case	when qud_contopc = 'Y' then qud_inrqty * qud_conftr
		else qud_inrqty
	end as 'Inner',  
	case	when qud_contopc = 'Y' then qud_mtrqty * qud_conftr
		else  qud_mtrqty
	end as 'Master',  
	case	when qud_contopc = 'Y' then 'PC'
		else qud_untcde
	end as 'UM',  
	qud_cft as 'CFT',  
	quh_curcde as 'Currency',  
	case	when qud_contopc = 'Y' then qud_pcprc
		else qud_cus1dp
	end as 'Primary Discounted Price',  
	case	when qud_prctrm = '' then isnull(prcH.ysi_dsc,'')
		else isnull(prc.ysi_dsc,'')
	end as 'PriceTerm',  
	case qud_moflag
		when 'Q' then qud_moq
		when '' then qud_moq
		else 0
	end as 'MOQ',  
	case qud_moflag
		when 'A' then qud_moa
		when '' then qud_moa
		else 0
	end as 'MOA',  
	qud_note as 'Note',  
	qud_hrmcde as 'HSTU #',  
	qud_dtyrat as 'Duty',  
	qud_cususd as 'Cust Retail: USD',  
	qud_cuscad as 'Cust Retail CAD',  
	convert(numeric(13,4),qud_inrdin) as 'Inner Dim - d (in)',  
	convert(numeric(13,4),qud_inrwin) as 'Inner Dim - w (in)',  
	convert(numeric(13,4),qud_inrhin) as 'Inner Dim - h (in)',  
	convert(numeric(13,4),qud_inrdcm) as  'Inner Dim - d (cm)',  
	convert(numeric(13,4),qud_inrwcm) as 'Inner Dim - w (cm)',  
	convert(numeric(13,4),qud_inrhcm) as  'Inner Dim - h (cm)',  
	convert(numeric(13,4),qud_mtrdin) as  'Master Dim - d (in)',  
	convert(numeric(13,4),qud_mtrwin) as  'Master Dim - w (in)',  
	convert(numeric(13,4),qud_mtrhin) as   'Master Dim - h (in)',  
	convert(numeric(13,4),qud_mtrdcm) as 'Master Dim - d (cm)',  
	convert(numeric(13,4),qud_mtrwcm) as 'Master Dim - w (cm)',  
	convert(numeric(13,4),qud_mtrhcm) as 'Master Dim - h (cm)',  
	qud_grswgt as 'GW',  
	qud_netwgt as 'NW',  
	mth.ysi_dsc as 'Const Method',  
	tmp.temp_tive as 'Comp BreakDown',  
	qud_cusven as 'Custom Vendor #',  
	isnull(cusven.vbi_vensna,'') as 'Custom Vendor Short Name',  
	qud_venno as 'Vendor #',  
	isnull(ven.vbi_vensna,'') as 'Vendor Short Name',  
	qud_venitm as 'Vendor Item #'
From	QUOTNHDR     
left join	CUBASINF on	cbi_cusno = quh_cus1no  
left join	SYSETINF prcH on	prcH.ysi_typ = '03'		and
			prcH.ysi_cde = quh_prctrm  
left join	QUOTNDTL on	qud_qutno = quh_qutno  
left join	imcusals cals on	cals.ica_itmno = qud_itmno	and
			cals.ica_cusno = quh_cus1no	and
			ica_apvsts = 'Y'  
left join	SYSETINF mth on	mth.ysi_typ = '07'		and
			mth.ysi_cde = qud_cosmth  
left join	VNBASINF ven on	ven.vbi_venno = qud_venno
left join	IMPRCINF on	imu_itmno = qud_itmno	and
			imu_status = 'ACT'		and
			imu_pckunt = qud_untcde	and
			imu_inrqty = qud_inrqty	and
			imu_mtrqty = qud_mtrqty	and
			imu_cus1no = ''		and
			imu_cus2no = ''		and
			imu_venno = qud_venno	and
			imu_ventyp = 'D'
left join	SYFMLINF on	yfi_fmlopt = imu_fmlopt   
left join	SYSETINF prc on	prc.ysi_typ = '03'		and
			prc.ysi_cde = qud_prctrm  
left join	#TempTable tmp on	tmp.temp_cocde = @cocde	and
			tmp.temp_qutno = qud_qutno	and
			tmp.temp_qutseq = qud_qutseq   
left join	VNBASINF cusven on cusven.vbi_venno = qud_cusven
left join	SYSALREP on	cbi_salrep = ysr_code1		and
			ysr_cocde = ' '
Where	quh_cocde = qud_cocde	and  
	quh_qutno = qud_qutno	and  
	quh_cocde = @cocde		and
	quh_qutno >= @From		and
	quh_qutno <= @to		and
	(	exists
		(	select	1
			from	syusrright
			where	yur_usrid = @usrid	and
				yur_doctyp = @doctyp	and
				yur_lvl = 0)
		or cbi_saltem in  -- ori > ysr_saltem
		(	select	yur_para
			from	syusrright
			where	yur_usrid = @usrid	and
				yur_doctyp = @doctyp	and
				yur_lvl = 1)
		or cbi_cusno in
		(	select	yur_para
			from	syusrright
			where	yur_usrid = @usrid	and
				yur_doctyp = @doctyp	and
				yur_lvl = 2)
	)
   
Drop Table #tempTable  
  
  
END



GO
GRANT EXECUTE ON [dbo].[sp_select_QUR0000excel] TO [ERPUSER] AS [dbo]
GO
