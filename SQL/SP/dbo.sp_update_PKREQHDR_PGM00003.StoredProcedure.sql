/****** Object:  StoredProcedure [dbo].[sp_update_PKREQHDR_PGM00003]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_PKREQHDR_PGM00003]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_PKREQHDR_PGM00003]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





CREATE PROCEDURE [dbo].[sp_update_PKREQHDR_PGM00003] 


@prh_cocde		nvarchar(6),
@prh_From	nvarchar(20),
@prh_To		nvarchar(20),
@status		nvarchar(20),
@user			nvarchar(30)
AS



declare @prh_reqno nvarchar(30),
	 @count int,
	@prd_cocde nvarchar(6),
	@prd_reqno nvarchar(20) ,
	@prd_seq              int ,
	@prd_itemno      nvarchar(20),
	@prd_tmpitmno nvarchar(20),
	@prd_venno nvarchar(6),
	@prd_venitm nvarchar(20),
	@prd_pckunt nvarchar(10),
	@prd_inrqty int,
	@prd_mtrqty   int,
	@prd_cft numeric(13,4),
	@prd_ftyprctrm nvarchar(10),
	@prd_hkprctrm nvarchar(10),
	@prd_trantrm nvarchar(10),
	@prd_pkgitm nvarchar(20),
	@prd_pkgven nvarchar(10),
	@prd_cate nvarchar(20),
	@prd_chndsc nvarchar(300),
	@prd_engdsc nvarchar(300),
	@prd_remark nvarchar(500),
	@prd_EInchL numeric(13,4),
	@prd_EInchW numeric(13,4),
	@prd_EInchH numeric(13,4),
	@prd_EcmL numeric(13,4),
	@prd_EcmW numeric(13,4),
	@prd_EcmH numeric(13,4),
	@prd_FInchL numeric(13,4),
	@prd_FinchW numeric(13,4),
	@prd_FinchH numeric(13,4),
	@prd_FcmL numeric(13,4),
	@prd_FcmW numeric(13,4),
	@prd_FcmH numeric(13,4),
	@prd_matral nvarchar(100),
	@prd_tiknes nvarchar(100),
	@prd_prtmtd nvarchar(100),
	@prd_clrfot nvarchar(100),
	@prd_clrbck nvarchar(100),
	@prd_finish nvarchar(100),
	@prd_rmtnce nvarchar(100),
	@prd_addres nvarchar(300),
	@prd_state nvarchar(50),
	@prd_cntry nvarchar(50),
	@prd_zip nvarchar(50),
	@prd_Tel nvarchar(20),
	@prd_cntper nvarchar(30),
	@prd_sctoqty int , 
	@prd_qtyum nvarchar(10),
	@prd_curcde nvarchar(10),
	@prd_multip int , 
	@prd_ordqty int ,
	@prd_wasper numeric(13,4),
	@prd_wasqty int ,
	@prd_ttlordqty int , 
	@prd_untprc numeric(13,4),
	@prd_ttlamtqty numeric(13,4),
	@prd_receqty int , 
	@current_qty int,
	@msg nvarchar(1000),	
	@tmp_ordno nvarchar(20)

set @msg =''
if @status = 'REL'
begin 

Declare cur_check_prcingkey cursor
for
select 
prh_reqno from PKREQHDR (nolock) 
where prh_cocde = @prh_cocde and 
prh_reqno >= @prh_From and
prh_reqno <= @prh_To and 
len(rtrim(prh_reqno)) = len(rtrim(@prh_From)) and 
 prh_status = 'OPE'

Open cur_check_prcingkey
Fetch next from cur_check_prcingkey into
@prh_reqno

While @@fetch_status = 0
Begin
           if @prh_reqno <> ''
           begin
		UPDATE	PKREQHDR
		SET	prh_status = @status,
			prh_upddat = getdate(),
			prh_updusr = @user
			
		where prh_reqno = @prh_reqno

		set @msg = isnull(@msg,'') + ' - ' + @prh_reqno + ' successfully release'
           end
		/*
		Declare cur_pkreqdtl cursor
		for 
		select prd_cocde, prd_reqno, prd_seq, prd_itemno, prd_tmpitmno, prd_venno, prd_venitm, 
		prd_pckunt, prd_inrqty, prd_mtrqty, prd_cft, prd_ftyprctrm, prd_hkprctrm, prd_trantrm, prd_pkgitm, 
		prd_pkgven, prd_cate, prd_chndsc, prd_engdsc, prd_remark, prd_EInchL, prd_EInchW, 
		prd_EInchH, prd_EcmL, prd_EcmW, prd_EcmH, prd_FInchL, prd_FinchW, prd_FinchH, 
		prd_FcmL, prd_FcmW, prd_FcmH, prd_matral, prd_tiknes, prd_prtmtd, prd_clrfot, prd_clrbck, 
		prd_finish, prd_rmtnce, prd_addres, prd_state, prd_cntry, prd_zip, prd_Tel, prd_cntper, prd_sctoqty, 
		prd_qtyum, prd_curcde, prd_multip, prd_ordqty, prd_wasper, prd_wasqty, prd_ttlordqty, prd_untprc, 
		prd_ttlamtqty, prd_receqty from PKREQDTL (nolock)
		where prd_cocde = @prh_cocde and prd_reqno = @prh_reqno 
	
		Open cur_pkreqdtl 
		fetch next from cur_pkreqdtl into
		@prd_cocde, @prd_reqno, @prd_seq, @prd_itemno, @prd_tmpitmno, @prd_venno, @prd_venitm, 
		@prd_pckunt, @prd_inrqty, @prd_mtrqty, @prd_cft, @prd_ftyprctrm, @prd_hkprctrm, @prd_trantrm, @prd_pkgitm, 
		@prd_pkgven, @prd_cate, @prd_chndsc, @prd_engdsc, @prd_remark, @prd_EInchL, @prd_EInchW, 
		@prd_EInchH, @prd_EcmL, @prd_EcmW, @prd_EcmH, @prd_FInchL, @prd_FinchW, @prd_FinchH, 
		@prd_FcmL, @prd_FcmW, @prd_FcmH, @prd_matral, @prd_tiknes, @prd_prtmtd, @prd_clrfot, @prd_clrbck, 
		@prd_finish, @prd_rmtnce, @prd_addres, @prd_state, @prd_cntry, @prd_zip, @prd_Tel, @prd_cntper, @prd_sctoqty, 
		@prd_qtyum, @prd_curcde, @prd_multip, @prd_ordqty, @prd_wasper, @prd_wasqty, @prd_ttlordqty, @prd_untprc, 
		@prd_ttlamtqty, @prd_receqty
	
		While @@fetch_status = 0
		Begin
			select @count = count(*) from dbo.PKORDHDR (nolock)
			where poh_Reqno = @prh_reqno and poh_cocde = @prh_cocde and poh_Pkgven = @prd_pkgven

				if @count = 0
				begin	

				create table #temp (tmpno varchar(20))					
				insert into #temp
				exec sp_select_DOC_GEN @prh_cocde,'KO',@user
				select @tmp_ordno = tmpno from #temp
				drop table #temp
					

					insert into dbo.PKORDHDR
					(poh_cocde, poh_ordno, poh_ver, poh_issdat, poh_revdat, poh_status, 
					poh_cus1no, poh_cus2no, poh_saldiv, poh_saltem, poh_salrep, poh_ToNo, 
					poh_ToVer, poh_ToSts, poh_ToIsdat, poh_ToRevdat, poh_ToRefqut, poh_potyp, 
					poh_ScNo, poh_ScVer, poh_ScSts, poh_ScIsdat, poh_ScRevdat, poh_ScPodat, 
					poh_ScCandat, poh_ScShpdatstr, poh_ScShpdatend, poh_ScRemark, poh_Reqno, 
					poh_Pkgven,poh_creusr, poh_updusr, poh_credat, poh_upddat)
					 select prh_cocde, @tmp_ordno, prh_ver, prh_issdat, prh_revdat, prh_status, 
					prh_cus1no, prh_cus2no, prh_saldiv, prh_saltem, prh_salrep, prh_ToNo, 
					prh_ToVer, prh_ToSts, prh_ToIsdat, prh_ToRevdat, prh_ToRefqut, prh_potyp, 
					prh_ScNo, prh_ScVer, prh_ScSts, prh_ScIsdat, prh_ScRevdat, prh_ScPodat,
					 prh_ScCandat, prh_ScShpdatstr, prh_ScShpdatend, prh_ScRemark, prh_reqno,
					@prd_pkgven,@user,@user,getdate(),getdate() from PKREQHDR (nolock)
					where prh_cocde = @prh_cocde and prh_reqno = @prh_reqno 
				
				set @msg = isnull(@msg,'') + ' - ' + @tmp_ordno + ' for vendor ' + @prd_pkgven
				

				end 
				else
				begin 
				select  @tmp_ordno = poh_ordno from PKORDHDR (nolock) 
				 where poh_Reqno = @prh_reqno and poh_cocde = @prh_cocde and poh_Pkgven = @prd_pkgven
				end
				*/
				/*else (TO Useless)
				begin
					select @current_qty = tid_toqty from dbo.TOITMDTL
					where 
					tid_cus1no = @tod_cus1no and
					tid_cus2no = @tod_cus2no and
					tid_itmno = @tod_ftyitmno and
					tid_tmpitmno = @tod_ftytmpitmno and
					tid_venno = @tod_venno and
					tid_venitmno = @tod_venitm
					
					
					Update TOITMSUM SET
					tis_toqty = tis_toqty + @tod_projqty - @current_qty 
					
					Where
					tis_cus1no = @tod_cus1no and
					tis_cus2no = @tod_cus2no and
					tis_itmno = @tod_ftyitmno and
					tis_tmpitmno = @tod_ftytmpitmno and
					tis_venno = @tod_venno and
					tis_ventimno = @tod_venitm 
				end*/
			
			/*
			select @count = count(*) from PKORDDTL (nolock)
			where 
			pod_reqno = @prd_reqno and
			pod_reqseq = @prd_seq and 
			pod_cocde = @prh_cocde and 
			pod_pkgven = @prd_pkgven
			
				if @count = 0
				begin	
				
				declare @ordseq int
				select @ordseq = count(*) + 1 from PKORDDTL (nolock)
				where 
				pod_reqno = @prd_reqno and
				--pod_reqseq = @prd_seq and 
				pod_cocde = @prh_cocde and 
				pod_pkgven = @prd_pkgven

					insert into PKORDDTL
					(pod_cocde, pod_ordno, pod_seq,pod_status, pod_itemno, pod_tmpitmno, pod_venno, 
					pod_venitm, pod_pckunt, pod_inrqty, pod_mtrqty, pod_cft , pod_ftyprctrm, pod_hkprctrm, 
					pod_trantrm, pod_pkgitm, pod_pkgven, pod_cate, pod_chndsc, pod_engdsc, pod_remark,
					pod_EInchL, pod_EInchW, pod_EInchH, pod_EcmL, pod_EcmW, pod_EcmH, pod_FInchL, 
					pod_FinchW, pod_FinchH, pod_FcmL, pod_FcmW, pod_FcmH, pod_matral, pod_tiknes, pod_prtmtd, 
					pod_clrfot, pod_clrbck, pod_finish, pod_rmtnce, pod_addres, pod_state, pod_cntry, pod_zip, pod_Tel, 
					pod_cntper, pod_sctoqty, pod_qtyum, pod_curcde, pod_multip, pod_ordqty, pod_wasper, pod_wasqty, 
					pod_ttlordqty, pod_untprc, pod_ttlamtqty, pod_receqty, pod_Reqno, pod_Reqseq, pod_creusr, pod_updusr, pod_credat, pod_upddat)
					 values
					 (@prd_cocde, @tmp_ordno, @ordseq, 'REL' , @prd_itemno, @prd_tmpitmno, @prd_venno, 
					  @prd_venitm,  @prd_pckunt, @prd_inrqty, @prd_mtrqty, @prd_cft , @prd_ftyprctrm, @prd_hkprctrm ,
					  @prd_trantrm, @prd_pkgitm,@prd_pkgven, @prd_cate, @prd_chndsc, @prd_engdsc, @prd_remark, 
					  @prd_EInchL, @prd_EInchW, @prd_EInchH, @prd_EcmL, @prd_EcmW, @prd_EcmH, @prd_FInchL,  
					  @prd_FinchW, @prd_FinchH,@prd_FcmL, @prd_FcmW, @prd_FcmH, @prd_matral, @prd_tiknes, @prd_prtmtd,  
					  @prd_clrfot, @prd_clrbck,@prd_finish, @prd_rmtnce, @prd_addres, @prd_state, @prd_cntry, @prd_zip, @prd_Tel, 
					 @prd_cntper, @prd_sctoqty, @prd_qtyum, @prd_curcde, @prd_multip, @prd_ordqty, @prd_wasper, @prd_wasqty,  
					 @prd_ttlordqty, @prd_untprc, @prd_ttlamtqty, @prd_receqty,@prd_reqno,@prd_seq,@user,@user,getdate(),getdate())

				
				end
				else
				begin

					 
				
					Update PKORDDTL SET
					pod_itemno = @prd_itemno , 
					pod_tmpitmno = @prd_tmpitmno ,
					pod_venno = @prd_venno , 
					pod_venitm = @prd_venitm,  
					 pod_pckunt = @prd_pckunt,
					 pod_inrqty = @prd_inrqty,
					 pod_mtrqty = @prd_mtrqty, 
					pod_cft = @prd_cft,
					pod_ftyprctrm = @prd_ftyprctrm, 
					pod_hkprctrm = @prd_hkprctrm, 
					pod_trantrm = @prd_trantrm, 
					pod_pkgitm = @prd_pkgitm, 
					pod_pkgven = @prd_pkgven,
					 pod_cate = @prd_cate, 
					pod_chndsc = @prd_chndsc, 
					pod_engdsc = @prd_engdsc, 
					pod_remark = @prd_remark,
					pod_EInchL = @prd_EInchL,
					 pod_EInchW = @prd_EInchW, 
					pod_EInchH = @prd_EInchH, 
					pod_EcmL = @prd_EcmL, 
					pod_EcmW = @prd_EcmW, 
					pod_EcmH = @prd_EcmH, 
					pod_FInchL = @prd_FInchL, 
					pod_FinchW = @prd_FinchW, 
					pod_FinchH = @prd_FinchH, 
					pod_FcmL = @prd_FcmL, 
					pod_FcmW = @prd_FcmW, 
					pod_FcmH = @prd_FcmH , 
					pod_matral = @prd_matral, 
					pod_tiknes = @prd_tiknes,
					 pod_prtmtd = @prd_prtmtd, 
					pod_clrfot = @prd_clrfot, 
					pod_clrbck = @prd_clrbck , 
					pod_finish = @prd_finish, 
					pod_rmtnce = @prd_rmtnce, 
					pod_addres = @prd_addres, 
					pod_state = @prd_state, 
					pod_cntry = @prd_cntry, 
					pod_zip = @prd_zip, 
					pod_Tel = @prd_Tel , 
					pod_cntper = @prd_cntper , 
					pod_sctoqty = @prd_sctoqty , 
					pod_qtyum = @prd_qtyum , 
					pod_curcde = @prd_curcde, 
					pod_multip = @prd_multip, 
					pod_ordqty =  @prd_ordqty, 
					pod_wasper = @prd_wasper, 
					pod_wasqty = @prd_wasqty, 
					pod_ttlordqty = @prd_ttlordqty , 
					pod_untprc = @prd_untprc, 
					pod_ttlamtqty = @prd_ttlamtqty, 
					pod_receqty = @prd_receqty,
		
					
					pod_updusr = @user, 
					
					pod_upddat = getdate()
					where 
				pod_reqno = @prd_reqno and
				pod_reqseq = @prd_seq and 
				pod_cocde = @prh_cocde and 
				pod_pkgven = @prd_pkgven
				
				end
			
			
			

			 Fetch next from cur_pkreqdtl into
          			 @prd_cocde, @prd_reqno, @prd_seq, @prd_itemno, @prd_tmpitmno, @prd_venno, @prd_venitm, 
			@prd_pckunt, @prd_inrqty, @prd_mtrqty, @prd_cft , @prd_ftyprctrm, @prd_hkprctrm, @prd_trantrm, @prd_pkgitm, 
			@prd_pkgven, @prd_cate, @prd_chndsc, @prd_engdsc, @prd_remark, @prd_EInchL, @prd_EInchW, 
			@prd_EInchH, @prd_EcmL, @prd_EcmW, @prd_EcmH, @prd_FInchL, @prd_FinchW, @prd_FinchH, 
			@prd_FcmL, @prd_FcmW, @prd_FcmH, @prd_matral, @prd_tiknes, @prd_prtmtd, @prd_clrfot, @prd_clrbck, 
			@prd_finish, @prd_rmtnce, @prd_addres, @prd_state, @prd_cntry, @prd_zip, @prd_Tel, @prd_cntper, @prd_sctoqty, 
			@prd_qtyum, @prd_curcde, @prd_multip, @prd_ordqty, @prd_wasper, @prd_wasqty, @prd_ttlordqty, @prd_untprc, 
			@prd_ttlamtqty, @prd_receqty
		End
		Close cur_pkreqdtl
		Deallocate cur_pkreqdtl
		*/
           Fetch next from cur_check_prcingkey into
           @prh_reqno
End
Close cur_check_prcingkey
Deallocate cur_check_prcingkey


/**UPDATE	PKREQHDR
SET		toh_ordsts = @status,
		toh_upddat = getdate(),
		toh_updusr = @user,
		toh_verno = toh_verno + 1
		where
		toh_cocde = @toh_cocde and
		toh_toordno >= @toh_toordnoFrom and
		toh_toordno <= @toh_toordnoTo and
		len(rtrim(toh_toordno)) = len(rtrim(@toh_toordnoFrom))
		and toh_ordsts = 'REL' */
		 
end
else
begin
--update to ope
Declare cur_check_prcingkey cursor
for
select 
prh_reqno from PKREQHDR (nolock) 
where prh_cocde = @prh_cocde and 
prh_reqno >= @prh_From and
prh_reqno <= @prh_To and 
len(rtrim(prh_reqno)) = len(rtrim(@prh_From)) and 
 prh_status = 'REL'

Open cur_check_prcingkey
Fetch next from cur_check_prcingkey into
@prh_reqno

While @@fetch_status = 0
Begin
           if @prh_reqno <> ''
           begin
		UPDATE	PKREQHDR
		SET	prh_status = @status,
			prh_upddat = getdate(),
			prh_updusr = @user,
			prh_ver = prh_ver + 1
		where prh_reqno = @prh_reqno and prh_cocde = @prh_cocde

		set @msg = isnull(@msg,'') + ' - ' + @prh_reqno + ' successfully unrelease'
           end
 Fetch next from cur_check_prcingkey into
           @prh_reqno
End
Close cur_check_prcingkey
Deallocate cur_check_prcingkey
end


/*
Declare @pkgven nvarchar(20)
Declare @ordno nvarchar(20)
Declare @reqno nvarchar(20)
Declare cur_poven cursor
for
select distinct (pod_pkgven) , pod_ordno , pod_reqno from pkorddtl(nolock)
where pod_cocde = @prh_cocde and 
pod_reqno >= @prh_From and
pod_reqno <= @prh_To and 
len(rtrim(pod_reqno)) = len(rtrim(@prh_From))

Open cur_poven
Fetch next from cur_poven into
@pkgven,@ordno,@reqno

While @@fetch_status = 0
Begin
         set @msg = isnull(@msg,'') + ' - ' + 'Req#: ' + @reqno+ ' > Ord#: ' + @ordno + ' for vendor ' + @pkgven
 Fetch next from cur_poven into
           @pkgven,@ordno,@reqno
End
Close cur_poven
Deallocate cur_poven
*/



select @msg




GO
GRANT EXECUTE ON [dbo].[sp_update_PKREQHDR_PGM00003] TO [ERPUSER] AS [dbo]
GO
