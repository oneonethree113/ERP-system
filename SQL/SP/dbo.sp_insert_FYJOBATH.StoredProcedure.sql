/****** Object:  StoredProcedure [dbo].[sp_insert_FYJOBATH]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_FYJOBATH]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_FYJOBATH]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_insert_FYJOBATH]  
@fsa_cocde  nvarchar(6),  
@fsa_jobno  nvarchar(20),  
@fsa_smkno nvarchar(20),  
@fsa_updusr  nvarchar(30),  
@act  char(3)   
AS  

declare @seq as int
set @seq = 0
select @seq = max(fsa_athseq) from FYJOBATH where 
fsa_cocde  = @fsa_cocde and
fsa_jobno  = @fsa_jobno  and
fsa_smkno = @fsa_smkno 

if @seq is null
begin
	set @seq = 1
end

if @act = 'ADD'  
begin  
	update FYJOBATH
	set fsa_act = 'DEL' , fsa_upddat = getdate(), fsa_updusr = @fsa_updusr
	where fsa_cocde  = @fsa_cocde and
	fsa_jobno  = @fsa_jobno  and
	fsa_smkno = @fsa_smkno and
	fsa_act  in ('ADD','UPD')

	 insert into FYJOBATH (fsa_athseq,fsa_cocde, fsa_jobno, fsa_smkno, fsa_act, fsa_creusr, fsa_updusr, fsa_credat, fsa_upddat )  
	 values (@seq + 1,@fsa_cocde, @fsa_jobno, @fsa_smkno, 'ADD', @fsa_updusr, @fsa_updusr, getdate(), getdate() )  
end  
else if @act = 'DEL'  
begin  
	 update FYJOBATH   
	 set fsa_act = 'DEL', fsa_updusr = @fsa_updusr , fsa_upddat = getdate()  
	 where fsa_jobno = @fsa_jobno  
	 and fsa_smkno = @fsa_smkno  
	and fsa_athseq = @seq
end  
else if @act = 'UPD'  
begin  
	 update FYJOBATH   
	 set fsa_act = 'UPD', fsa_updusr = @fsa_updusr , fsa_upddat = getdate()  
	 where fsa_jobno = @fsa_jobno  
	 and fsa_smkno = @fsa_smkno  
	and fsa_athseq = @seq
end  
/*  
if @act = 'ADD'  
begin  
 --select * from FYJOBSMKH  
 insert into FYJOBSMKH  
 (  
 fsm_cocde,  
 fsm_jobno,  
 fsm_smkno,  
 fsm_creusr,  
 fsm_updusr,  
 fsm_credat,  
 fsm_upddat  
 )  
 values(  
 @fsa_cocde,  
 @fsa_jobno,  
 @fsa_smkno,  
 'FYJOBATH',  
 @fsa_updusr,  
 getdate(),  
 getdate()  
 )       
end  
*/  
  
  
  




GO
GRANT EXECUTE ON [dbo].[sp_insert_FYJOBATH] TO [ERPUSER] AS [dbo]
GO
