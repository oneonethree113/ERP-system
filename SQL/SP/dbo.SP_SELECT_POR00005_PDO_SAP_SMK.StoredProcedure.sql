/****** Object:  StoredProcedure [dbo].[SP_SELECT_POR00005_PDO_SAP_SMK]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[SP_SELECT_POR00005_PDO_SAP_SMK]
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_POR00005_PDO_SAP_SMK]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- sp_select_POR00005_PDO_SAP_SMK 'UCP','TJ0700125-0003'

--SP_SELECT_POR00005_PDO_SAP_SMK 'UCPP','UB0700076-0043'


CREATE PROCEDURE [dbo].[SP_SELECT_POR00005_PDO_SAP_SMK]
@cocde varchar(6),
@batno varchar(30)
as
BEGIN

	declare @docno varchar(30)

--	declare @batno varchar(30)	
--	set @batno = 'UB0700076-0043'

	declare	@t_batno as varchar(20),
		@t_batseq as varchar(6)

	if charindex('-',@batno 	) > 0 
	begin
		set @t_batno = left(@batno, charindex('-',@batno) - 1)
		set @t_batseq = ltrim(rtrim(right(@batno, len(@batno) - charindex('-', @batno) )))
	end

	
	-- Assume the no of records in FYJOBSMKH is unique
	declare @jobord as varchar(20)
	set @jobord = ''
	select @jobord = isnull(pjd_jobord,'') from POJBBDTL where pjd_batno = @t_batno and pjd_batseq = @t_batseq


/*	
	set @docno = ''
	select @docno = isnull(max(fsm_jobno) ,'')
	from 
		POJBBDTL , 
		FYJOBSMKH 


	where
		pjd_batno + '-' + pjd_batseq + '.doc' = fsm_jobno and
		pjd_jobord = @jobord

*/


--	select @t_batno, @t_batseq, @jobord, @docno
	

	/*
	select * from POJBBDTL
	select * from FYJOBSMKH where fsm_jobno = 'UB0700076-0043.doc'
	select * from FYJOBINF
	*/

/*	SELECT distinct fsm_smkno, fsm_jobno
	FROM FYJOBSMKH
	WHERE fsm_cocde = @cocde 
	and fsm_jobno = @docno
	and @docno <> ''
	ORDER BY fsm_smkno 
*/

--	Frankie Cheung 20100514
/*
	SELECT distinct fsa_smkno as 'fsm_smkno', fsa_jobno as 'fsm_jobno'
	FROM FYJOBATH
	WHERE --fsa_cocde = @cocde and 
	fsa_jobno = @jobord
	and fsa_act <> 'DEL'
	and @jobord <> ''
	ORDER BY fsa_smkno 
*/

	SELECT distinct stm_smkno as 'fsm_smkno', stm_jobno as 'fsm_jobno'
	FROM SCTPSMRK
	WHERE --fsa_cocde = @cocde and 
	stm_jobno = @jobord
	and stm_act <> 'DEL'
	and @jobord <> ''
	ORDER BY stm_smkno 


END













GO
GRANT EXECUTE ON [dbo].[SP_SELECT_POR00005_PDO_SAP_SMK] TO [ERPUSER] AS [dbo]
GO
