/****** Object:  StoredProcedure [dbo].[sp_list_POJBBDTL_SMK_2]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_POJBBDTL_SMK_2]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_POJBBDTL_SMK_2]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





/*
=================================================================
Program ID	: sp_list_POJBBDTL_SMK_2
Description	: Select data From POORDDTL and PORODHDR
Programmer	: Johnson
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2002-01-04 	Johnson		SP Created
2003-10-27	Allan Yuen	Add Running No.
2005-03-14	Allan Yuen	Add Company Info
2010-06-15	Frankie Cheung	Add Shipmark attachment list for Excel
2013-10-23	David Yue	Fix Company Name Field name
=================================================================
*/

CREATE procedure [dbo].[sp_list_POJBBDTL_SMK_2]
                                                                                                                                                                                                                                                               
@pjd_cocde nvarchar(6) ,
@pjd_batno nvarchar(20) ,
@export nvarchar(3)

AS
begin

CREATE TABLE #ResList
(
	tmp_jobord nvarchar(20),
	tmp_smklist nvarchar(3000)
)


-- Read Company Information --
declare 
	@yco_conam varchar(50),	@yco_addr nvarchar(200),	@yco_logoimgpth varchar(100),	@yco_phoneno varchar(50),	@yco_faxno varchar(50)

SELECT 
	@yco_conam = yco_conam,	
	@yco_addr = yco_addr,
	@yco_logoimgpth = yco_logoimgpth, 
	@yco_phoneno = yco_phoneno,
	@yco_faxno = yco_faxno 
FROM
	SYCOMINF
WHERE
	YCO_COCDE = @pjd_cocde

---------------------------------------------

if @export = 'PDF' 
begin
	select 
	pjd_cocde,
	@yco_conam as 'conam',
	pjd_batno,
	pjd_batseq,
	pod_purord,
	pod_scno,
	pod_runno,
	pod_jobord,
	pod_venitm,
	vv.vbi_vensna,
	sod_subcde,
	v.vbi_vensna as 'cusven',
	cbi_cussna
	
	from 
		POJBBDTL
		inner join POORDDTL on pjd_cocde = pod_cocde and pjd_jobord = pod_jobord
		inner join POORDHDR on pjd_cocde = poh_cocde and pod_purord = poh_purord
		inner join VNBASINF v on v.vbi_venno = poh_venno
		inner join SCORDDTL on pjd_cocde = sod_cocde and pod_scno = sod_ordno and pod_scline = sod_ordseq
		inner join VNBASINF vv on vv.vbi_venno = pod_prdven 
		inner join SCORDHDR on soh_cocde = sod_cocde and soh_ordno = sod_ordno
		inner join cubasinf on cbi_cusno = soh_cus1no 
	
	where                                                                                                                                                                                                                                                                 
		pjd_cocde = @pjd_cocde and
		pjd_batno = @pjd_batno and
		pjd_confrm = 'Y'
	
	
	order by pjd_batseq
end
else if @export = 'XLS' 
begin

/*
	select 
		pjd_batseq as 'B. Seq',
		cbi_cussna as 'Cust Short Name.',
		pod_jobord as 'Job No.',
		pod_runno as 'Running No.',
		pod_venitm as 'Item No.',
		v.vbi_vensna as '清關工廠',
		vv.vbi_vensna as '生產工廠',
		sod_subcde as 'Sub Code',
		@yco_conam as 'conam'
	from 
		POJBBDTL
		inner join POORDDTL on pjd_cocde = pod_cocde and pjd_jobord = pod_jobord
		inner join POORDHDR on pjd_cocde = poh_cocde and pod_purord = poh_purord
		inner join VNBASINF v on v.vbi_venno = poh_venno
		inner join SCORDDTL on pjd_cocde = sod_cocde and pod_scno = sod_ordno and pod_scline = sod_ordseq
		inner join VNBASINF vv on vv.vbi_venno = pod_prdven 
		inner join SCORDHDR on soh_cocde = sod_cocde and soh_ordno = sod_ordno
		inner join cubasinf on cbi_cusno = soh_cus1no 
	
	where                                                                                                                                                                                                                                                                 
		pjd_cocde = @pjd_cocde and
		pjd_batno = @pjd_batno and
		pjd_confrm = 'Y'
	
	
	order by pjd_batseq
*/

	select 
		pjd_batseq,
		cbi_cussna,
		pod_jobord,
		pod_runno ,
		pod_venitm,
		v.vbi_vensna as 'cusven',
		vv.vbi_vensna as 'prdven',
--		sod_subcde,
		poh_signappflg as 'sod_subcde',
		@yco_conam as 'conam',
		sod_ordno,
		sod_ordseq
	into	#Result1
	from 	POJBBDTL
		inner join POORDDTL on pjd_cocde = pod_cocde and pjd_jobord = pod_jobord
		inner join POORDHDR on pjd_cocde = poh_cocde and pod_purord = poh_purord
		inner join VNBASINF v on v.vbi_venno = poh_venno
		inner join SCORDDTL on pjd_cocde = sod_cocde and pod_scno = sod_ordno and pod_scline = sod_ordseq
		inner join VNBASINF vv on vv.vbi_venno = pod_prdven 
		inner join SCORDHDR on soh_cocde = sod_cocde and soh_ordno = sod_ordno
		inner join cubasinf on cbi_cusno = soh_cus1no 	
	where                                                                                                                                                                                                                                                                 
		pjd_cocde = @pjd_cocde and
		pjd_batno = @pjd_batno and
		pjd_confrm = 'Y'		
	order by pjd_batseq

	select distinct pod_jobord, sod_ordno, sod_ordseq into #Result2 from #Result1

	select	distinct	
		pod_jobord,
		stm_cocde,
		stm_ordno,
		stm_ordseq,
		stm_ordnoseq,
		stm_jobno,
		stm_smkno,
		left(stm_smkno, len(stm_smkno) - 9) as 'stm_smkno_P5',
		left(right(stm_smkno, 9),5) as 'stm_smkno_L5',	
		stm_creusr
	into 	#Result3
	from 	#Result2 left join SCTPSMRK on (sod_ordno = stm_ordno and sod_ordseq = stm_ordseq)
	where	
		stm_cocde = @pjd_cocde
		and stm_act <> 'DEL' and stm_act <> 'NEW'	


	declare @jobord as nvarchar(20)
	declare @smkno_P5 as nvarchar(45)	
	declare @smkno_L5 as nvarchar(5)
	declare @prv_jobord as nvarchar(20)
	declare @prv_smkno_P5 as nvarchar(45)	
	declare @smknolist as nvarchar(3000)
	
	set @prv_jobord = ''
	
	DECLARE cur_Result3 CURSOR
	FOR 	SELECT 		pod_jobord ,		stm_smkno_P5 ,		stm_smkno_L5 
		FROM 		#Result3	
		ORDER BY 	pod_jobord ,		stm_smkno_P5 ,		stm_smkno_L5 
	
	OPEN cur_Result3
	FETCH NEXT FROM cur_Result3 INTO 
	@jobord ,		@smkno_P5 ,		@smkno_L5 
	
	WHILE @@fetch_status = 0
	BEGIN
	
	if @prv_jobord = ''
	begin
		set @prv_jobord = @jobord	
		set @prv_smkno_P5 = @smkno_P5
	end
	
	if @prv_jobord = @jobord
	begin
		if @prv_smkno_P5 = @smkno_P5
		begin
			if ltrim(rtrim(@smknolist)) <> '' 
			begin
				if isnumeric(@smkno_L5) = 1
					set @smknolist = @smknolist + ', ' + @smkno_L5
				else
					set @smknolist = @smknolist + ' / ' + @smkno_P5 + @smkno_L5	
			end
			else
			begin
				set @smknolist = @smkno_P5 + @smkno_L5
			end
		end	
		else
		begin
			set @smknolist = @smknolist + ' / ' + @smkno_P5 + @smkno_L5		
		end
	end
	else
	begin
		insert into #ResList values (@prv_jobord, @smknolist)	
		set @smknolist = ''	
		set @smknolist = @smkno_P5 + @smkno_L5
	end
	
	set @prv_jobord = @jobord
	set @prv_smkno_P5 = @smkno_P5
	
	--print @jobord + '     ' + @smknolist
	
	FETCH NEXT FROM cur_Result3 INTO 
	@jobord ,		@smkno_P5 ,		@smkno_L5 
	
	END
	CLOSE cur_Result3
	DEALLOCATE cur_Result3
	
	insert into #ResList values (@prv_jobord, @smknolist)	



	select
		pjd_batseq as 'B. Seq',
		cbi_cussna as 'Cust Short Name.',
		pod_jobord as 'Job No.',
		pod_runno as 'Running No.',
		pod_venitm as 'Item No.',
		cusven as '清關工廠',
		prdven as '生產工廠',
		sod_subcde as 'PO Apv',
		conam,
		isnull(tmp_smklist,'') as 'Attachment'
	from  #Result1 left join #ResList on (pod_jobord = tmp_jobord)	


	drop table #Result1
	drop table #Result2
	drop table #Result3
	drop table #ResList

end


end

















GO
GRANT EXECUTE ON [dbo].[sp_list_POJBBDTL_SMK_2] TO [ERPUSER] AS [dbo]
GO
