/****** Object:  StoredProcedure [dbo].[sp_select_SCM00001_SM]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SCM00001_SM]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SCM00001_SM]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO




-- sp_select_SCM00001_SM 'UCPP','','US0403171-J001','US0403171-J999','X'

CREATE  procedure [dbo].[sp_select_SCM00001_SM] 
@cocde as varchar(6) , 
@batNo as varchar(30) , 
@jobFm as varchar(20) , 
@jobTo as varchar(20) , 
@usrid	nvarchar(30),
@doctyp	nvarchar(2),
@dummy as char(1)
as
begin
	
	declare 
		@batno_y as char(1),
		@jobfm_y as char(1)

	
	set @batno_y = ''
	if @batno <> '' 
	begin
		set @batno_y = 'X'
	end
	
	set @jobfm_y = ''
	if @jobfm <> ''
	begin
		set @jobfm_y = 'X'
	end
	

	select distinct pjd_jobord as 'jobno' from POJBBDTL
	left join SCORDHDR on left(pjd_jobord,9) = soh_ordno and pjd_cocde = soh_cocde
	left join CUBASINF on soh_cus1no = cbi_cusno
	left join SYSALREP on cbi_salrep = ysr_code1 and ysr_cocde = ' '
	where 
		pjd_cocde = @cocde and 
		(@batno_y = '' or (@batno_y = 'X' and isnull(soh_ordno,'') = @batno )) and 
		(@jobfm_y = '' or (@jobfm_y = 'X' and pjd_jobord between @jobfm and @jobto))
--		 and isnull(soh_ordsts,'') = 'ACT'

and 	(	
		exists
		(	
			select 1 from syusrright
			where yur_usrid = @usrid  and yur_doctyp = @doctyp and yur_lvl = 0
--			and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
		)
		or cbi_saltem in 
		(	
			select yur_para from syusrright
			where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 1
--			and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
		)
		or soh_cus1no in 
		(
			select yur_para from syusrright
			where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 2
--			and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
		)
	)

		
end

GO
GRANT EXECUTE ON [dbo].[sp_select_SCM00001_SM] TO [ERPUSER] AS [dbo]
GO
