/****** Object:  StoredProcedure [dbo].[sp_insert_POR00005_PDO_SAP]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_POR00005_PDO_SAP]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_POR00005_PDO_SAP]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--sp_insert_POR00005_PDO_SAP 'UCPP','UT0700001-0001'  
  
CREATE procedure [dbo].[sp_insert_POR00005_PDO_SAP]  
@cocde varchar(6) ,   
@batno  varchar(30)   
as  
begin  

	 declare   
	  @bat as varchar(30) ,   
	  @seq as varchar(4)  
	
	declare 
	  @jobord as varchar(30)
	
	
	  
	 if charindex('-',@batno ) > 0   
	 begin  
	  set @bat = left(@batno , charindex('-',@batno) - 1)  
	  set @seq = right(@batno , len(@batno) - charindex('-',@batno))  
	 end  
	   
	 --select @bat, @seq  
	
	set @jobord = ''
	-- Lester Wu 2007-11-29
	select top 1 @jobord = pjs_jobord from POJBBSAP where pjs_batno = @bat and pjs_batseq = @seq
	   
	if @jobord <> '' 
	begin
		 update POJBBSAP  
		 set pjs_gendoc = 'Y', pjs_gendat = getdate()   
		-- where pjs_batno = @bat and pjs_batseq = @seq
		where pjs_jobord = @jobord
		and pjs_credat = (select max(pjs_credat) from POJBBSAP
						where pjs_jobord = @jobord)
	
	end
  
end  
  
  



GO
GRANT EXECUTE ON [dbo].[sp_insert_POR00005_PDO_SAP] TO [ERPUSER] AS [dbo]
GO
