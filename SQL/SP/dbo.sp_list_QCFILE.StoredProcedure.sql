/****** Object:  StoredProcedure [dbo].[sp_list_QCFILE]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_QCFILE]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_QCFILE]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[sp_list_QCFILE]
	@qcno nvarchar(220),
	@pono nvarchar(220)
AS 
BEGIN
	DECLARE @count_qcno int
	DECLARE @count_pono int
	DECLARE @count_poseq int 

	DECLARE @count_i_qcno int =0
	DECLARE @count_i_pono int =0
	DECLARE @count_i_poseq int =0
	
	DECLARE @key_QCNo nvarchar(20)
	
	
	DECLARE @count_file int
	DECLARE @count_i_file int = 0
	
	
	DECLARE @LIST table(
		res_qcno nvarchar(20), 
		res_qcseq int, 
		res_purord nvarchar(20), 
		res_purseq int
	)	
	
	DECLARE @VEN_List table(
		qcno nvarchar(20),
		qcvensna nvarchar(49)
	)
	
	DECLARE @QC_List table(
		qc_id int IDENTITY(1,1) NOT NULL, 
		qcno nvarchar(20)
	)
	
	DECLARE @POHDR_List table(		
		poh_purord nvarchar(20)	
	)
	
	-- DECLARE @PODTL_List table(
		-- qc_id int,
		-- poh_id int, 
		-- pod_id int IDENTITY(1,1) NOT NULL, 
		
		-- pod_purord nvarchar(20), 
		-- pod_purseq int
	-- )
	
	DECLARE @File_List table(
		tmp_file nvarchar(250), 
		tmp_athseq int
	)
	

	DECLARE @RESULT_FINAL table(
		res_qcno nvarchar(20), 
		res_qcvensna nvarchar(49),
		res_qcseq int, 
		res_purord nvarchar(20), 
		res_purseq int, 
		res_filepath nvarchar(300), 
		res_file nvarchar(250), 
		res_type nvarchar(1)
	)


	--Test
	-- INSERT INTO @LIST
	-- SELECT qch_qcno, qcd_qcseq,  qcd_purord, qcd_purseq from qcreqhdr
	-- left join qcreqdtl
	-- on qch_qcno = qcd_qcno
	-- where QCH_qcno = 'QCR1500145'

	INSERT INTO @LIST
	SELECT qch_qcno, qcd_qcseq,  qcd_purord, qcd_purseq from qcreqhdr
	left join qcreqdtl
	on qch_qcno = qcd_qcno
	--where QCH_qcno = @QCNo
	where (qch_qcno in (select Name from dbo.splitstring2(@QCNo, ';')) or @QCNo = '') AND 
	(qcd_purord in (select Name from dbo.splitstring2(@pono, ';')) or @pono = '')

	INSERT into @QC_List
	SELECT DISTINCT res_qcno from @LIST

	INSERT into @VEN_List
	SELECT qch_qcno, res_vensna = vbi_venno + ' - ' + vbi_Vensna 
    FROM QCREQHDR LEFT JOIN 
	VNBASINF on
	vbi_venno = qch_venno
	
	SELECT @count_qcno = count(qcno) from @QC_List
	WHILE( @count_i_qcno < @count_qcno)
	BEGIN
	
		--Insert QC Attachment Start
		select @key_QCNo = qcno FROM @QC_List where  qc_id = @count_i_qcno +1
		
		INSERT INTO @File_List
		select  puf_file, max(puf_athseq) from poulfile 
		where puf_ordno = @key_QCNo AND puf_act <> 'DEL' and puf_type = 'Q' 
		group by puf_file --having puf_act <> 'DEL'
		
		-- select @count_file = count(tmp_file) from @File_List
		-- WHILE( @count_i_file < @count_file)
		-- BEGIN
			INSERT INTO @RESULT_FINAL
			SELECT 
				@key_QCNo,(SELECT qcvensna from @VEN_List where qcno = @key_QCNo),  '', '', '',
				puf_filepath, puf_file, puf_type
			FROM POULFILE
			INNER JOIN @FILE_List
			ON 
				puf_ordno = @key_QCNo
			AND puf_file = tmp_file
			AND puf_athseq = tmp_athseq
			AND puf_act = 'ADD'	
			and puf_type = 'Q'
			-- select @count_i_file  = @count_i_file +1
		-- END
		
		DELETE FROM @File_List
		
		--Insert QC Attachment End
		
		--Insert PO Attachment Start
		INSERT INTO @POHDR_List
		SELECT DISTINCT res_purord from @LIST
		WHERE res_qcno = @key_QCNo
		
		INSERT INTO @File_List
		select  puf_file, max(puf_athseq) from poulfile 
		where puf_ordno in (select poh_purord from @POHDR_List) AND puf_act <> 'DEL' and (puf_type = 'H' or puf_type = 'P')
		group by puf_file --having puf_act <> 'DEL'
		
		INSERT INTO @RESULT_FINAL
		SELECT 
			@key_QCNo,(SELECT qcvensna from @VEN_List where qcno = @key_QCNo), '', puf_ordno, puf_ordseq,
			puf_filepath, puf_file, puf_type
		FROM POULFILE
		INNER JOIN @POHDR_List
		ON puf_ordno = poh_purord
		INNER JOIN @FILE_List
		ON 
			puf_ordno = poh_purord
		AND puf_file = tmp_file
		AND puf_athseq = tmp_athseq
		AND puf_act = 'ADD'	
		and (puf_type = 'H' or puf_type = 'P')

		
		
		DELETE FROM @POHDR_List
		DELETE FROM @FILE_List
		
		--Insert PO Attachment End
		
		
		
			
		select @count_i_qcno = @count_i_qcno +1
	END
	
	SELECT res_qcno, res_qcvensna, res_purord, res_purseq, res_filepath, res_file, res_type FROM @RESULT_FINAL
	
	
	

END


GO
GRANT EXECUTE ON [dbo].[sp_list_QCFILE] TO [ERPUSER] AS [dbo]
GO
