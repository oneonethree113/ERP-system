/****** Object:  StoredProcedure [dbo].[sp_insert_POULFILE]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_POULFILE]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_POULFILE]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO












CREATE   procedure [dbo].[sp_insert_POULFILE]  
@puf_cocde  nvarchar(6),  
@puf_ordno  nvarchar(20),  
@puf_ordseq  int,  
@puf_jobno nvarchar(20),
@puf_filepath nvarchar(300),  
@puf_file nvarchar(250),  
@puf_type nvarchar(1),  
@puf_updusr  nvarchar(30),  
@act  char(3)   
AS  


declare @seq as int
--set @seq = 0
select 
--	@seq = max(isnull(puf_athseq,0)) from POULFILE 
	@seq = max(puf_athseq) from POULFILE 
where 
--	puf_cocde  = @puf_cocde and
	puf_ordno  = @puf_ordno  and
	puf_ordseq  = @puf_ordseq  and
	puf_filepath = @puf_filepath 

if @seq is null
begin
	set @seq = 1
end

--PRINT 'DEBUG FLAG : ' + CONVERT(nvarchar(2), isnull(@seq,99))

if @act = 'ADD'  
begin  

	update 
		POULFILE
	set 
		puf_act = 'DEL' , puf_upddat = getdate(), puf_updusr = @puf_updusr
	where 
		puf_ordno  = @puf_ordno  and
		puf_ordseq  = @puf_ordseq  and
		puf_file =@puf_file



	 insert into POULFILE 
	(
		puf_athseq, 
		puf_cocde, 
		puf_ordno, 
		puf_ordseq,
		puf_ordnoseq, 
		puf_jobno,
		puf_filepath, 
		puf_file, 
		puf_type, 
		puf_act, 
		puf_creusr, 
		puf_updusr, 
		puf_credat, 
		puf_upddat 
	)  
	 values 
	(	@seq + 1, 
		@puf_cocde, 
		@puf_ordno, 
		@puf_ordseq, 
		@puf_ordno + ' - ' + ltrim(rtrim(convert(nvarchar(10), @puf_ordseq))), 
		@puf_jobno,
		@puf_filepath, 
		@puf_file, 
		@puf_type, 
		'ADD', 
		@puf_updusr, 
		@puf_updusr, 
		getdate(), 
		getdate() 
	)  

end
else if @act = 'DEL'  
begin    
	update 
		POULFILE
	set 
		puf_act = 'DEL' , puf_upddat = getdate(), puf_updusr = @puf_updusr
	where 
		puf_ordno  = @puf_ordno  and
		puf_ordseq  = @puf_ordseq  and
		puf_file =@puf_file
end












GO
GRANT EXECUTE ON [dbo].[sp_insert_POULFILE] TO [ERPUSER] AS [dbo]
GO
