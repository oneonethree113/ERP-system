/****** Object:  StoredProcedure [dbo].[sp_insert_CombineInvoice]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_CombineInvoice]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_CombineInvoice]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









/************************************************************************
Author:		Marco Chan
Date:		15th February, 2011
***********************************************************************
sp_insert_CombineInvoice 'UCP','50155', '01/01/2010', '05/01/2010','S', '','mis'
*/


CREATE procedure [dbo].[sp_insert_CombineInvoice]
@cocde nvarchar(6),
@cinvno nvarchar(20),
@cshpno nvarchar(20),
@usrid nvarchar(30)
 
AS

BEGIN


declare @hsh_cocde nvarchar(10)
declare @hsh_cinvno nvarchar(20)
declare @hsh_cshpno nvarchar(20)
declare @hsh_invno nvarchar(20)
declare @hsh_shpno nvarchar(20)
declare @hsh_cusno nvarchar(10)

declare @ttl_hiv_ttlamt numeric(13,4)
declare @ttl_hiv_ttlvol numeric(13,4)
declare @ttl_hiv_ttlctn numeric(13,4) 
declare @ttl_hiv_invamt numeric(13,4)
declare @ttl_hiv_afamt numeric(13,4)


declare @ttl_hih_ttlctn numeric(13,4)
declare @ttl_hih_ttlnwg numeric(13,4)
declare @ttl_hih_ttlgwg numeric(13,4)
declare @ttl_hih_ttlamt numeric(13,4)


/**********************/
/* 0. Get Document No */
/**********************/
select 
top 1
@hsh_cocde = hsh_cocde, 
@hsh_cinvno = hsh_cinvno, -- 1 combine invno (SHCI) assigned in program
@hsh_cshpno = hsh_cshpno, -- 1 combine shipping no (SHCI) assigned in program
@hsh_invno = hsh_invno, -- 1 combine invno (SHCI) = n shpping no (SHINVHDR)
@hsh_shpno = hsh_shpno, -- 1 combine invno (SHCI) = n shipping no (SHIPGHDR)
@hsh_cusno = hsh_cusno
from SHSUBSH where hsh_cocde = @cocde and hsh_cinvno = @cinvno
order by hsh_cocde,hsh_cinvno,hsh_invno


/***************/
/* 1. SHINVHDR */
/***************/
insert into SHCI_SHINVHDR
select top 1 
@hsh_cocde,
@hsh_cshpno,
@hsh_cinvno,
hiv_invdat,
hiv_prctrm,
hiv_paytrm,
hiv_doctyp,
hiv_doc,
hiv_cover,
hiv_ftrrmk,
hiv_untamt,
0,0,0,
hiv_bank,
hiv_aformat,
0,0,
hiv_invsts,
hiv_lcstmt,
hiv_creusr,
hiv_updusr,
hiv_credat,
hiv_upddat,
null from SHSUBSH,SHINVHDR
where hsh_cocde = @hsh_cocde and hsh_cinvno = @hsh_cinvno and hsh_cocde = hiv_cocde and hsh_invno = hiv_invno


set @ttl_hiv_ttlamt = 0.0
set @ttl_hiv_ttlvol = 0.0
set @ttl_hiv_ttlctn = 0.0
set @ttl_hiv_invamt = 0.0
set @ttl_hiv_afamt = 0.0


select 
@ttl_hiv_ttlamt = sum(hiv_ttlamt), 
@ttl_hiv_ttlvol = sum(hiv_ttlvol), 
@ttl_hiv_ttlctn = sum(hiv_ttlctn),
@ttl_hiv_invamt = sum(hiv_invamt),
@ttl_hiv_afamt = sum(hiv_afamt)
from SHSUBSH,SHINVHDR
where hsh_cocde = @hsh_cocde and hsh_cinvno = @hsh_cinvno and hsh_cocde = hiv_cocde and hsh_invno = hiv_invno


update SHCI_SHINVHDR set 
hiv_ttlamt = @ttl_hiv_ttlamt,
hiv_ttlvol = @ttl_hiv_ttlvol,
hiv_ttlctn = @ttl_hiv_ttlctn,
hiv_invamt = @ttl_hiv_invamt,
hiv_afamt = @ttl_hiv_afamt
where hiv_cocde = @hsh_cocde and hiv_invno = @hsh_cinvno



/***************/
/* 2. SHIPGHDR */
/***************/
insert into SHCI_SHIPGHDR
select top 1
@hsh_cocde,
@hsh_cshpno,
hih_issdat,
hih_rvsdat,
hih_cus1no,
'',
hih_smpshp,
hih_shpsts,
hih_ves,
hih_voy,
hih_slnonb,
hih_arrdat,
hih_potloa,
hih_dst,
hih_crr,
hih_crrso,
hih_goddsc,
hih_bilent,
hih_biladr,
hih_bilstt,
hih_bilcty,
hih_bilzip,
hih_bilrmk,
0,0,0,
hih_untamt,
0,
hih_lcno,
hih_lcbank,
hih_cntyorgn,
hih_creusr,
hih_updusr,
hih_credat,
hih_upddat,
null
from SHSUBSH, SHIPGHDR
where hsh_cocde = @hsh_cocde and hsh_cshpno = @hsh_cshpno
and hih_cocde = hsh_cocde and hih_shpno = hsh_shpno


set @ttl_hih_ttlctn = 0.0
set @ttl_hih_ttlnwg = 0.0
set @ttl_hih_ttlgwg = 0.0
set @ttl_hih_ttlamt = 0.0


select 
@ttl_hih_ttlctn = sum(hih_ttlctn), 
@ttl_hih_ttlnwg = sum(hih_ttlnwg), 
@ttl_hih_ttlgwg = sum(hih_ttlgwg),
@ttl_hih_ttlamt = sum(hih_ttlamt)
from SHSUBSH, SHIPGHDR
where hsh_cocde = @hsh_cocde and hsh_cshpno = @hsh_cshpno
and hih_cocde = hsh_cocde and hih_shpno = hsh_shpno

update SHCI_SHIPGHDR set
hih_ttlctn = @ttl_hih_ttlctn, 
hih_ttlnwg = @ttl_hih_ttlnwg, 
hih_ttlgwg = @ttl_hih_ttlgwg,
hih_ttlamt = @ttl_hih_ttlamt
where hih_cocde = @hsh_cocde and hih_shpno = @hsh_cshpno


/***************/
/* 3. SHSHPMRK */
/***************/
insert into SHCI_SHSHPMRK
select top 1
@hsh_cocde,
@hsh_cshpno,
@hsh_cinvno,
hsm_ordno,
hsm_shptyp,
hsm_imgnam,
hsm_imgpth,
hsm_engdsc,
hsm_engrmk,
hsm_creusr,
hsm_updusr,
hsm_credat,
hsm_upddat,
null
from SHSHPMRK where hsm_cocde = @hsh_cocde and hsm_shpno = @hsh_shpno


/**************/
/* 4.SHDISPRM */
/**************/
declare @hdp_type nvarchar(15)
declare @hdp_seqno int
declare @hdp_cde nvarchar(20)
declare @hdp_dsc nvarchar(200)
declare @hdp_pctamt nvarchar(10)
declare @hdp_amt numeric(11,4)

set @hdp_seqno = 0


declare cur_DiscountPremium cursor for
select hdp_type, hdp_cde, hdp_dsc, hdp_pctamt, sum(hdp_amt)
from SHSUBSH, SHDISPRM
where hsh_cocde = @hsh_cocde and hsh_cshpno = @hsh_cshpno
and hdp_cocde = hsh_cocde and hdp_shpno = hsh_shpno
group by hdp_type, hdp_cde, hdp_dsc, hdp_pctamt


Open cur_DiscountPremium
Fetch next from cur_DiscountPremium into
@hdp_type,@hdp_cde,@hdp_dsc,@hdp_pctamt,@hdp_amt

while @@fetch_status = 0
begin

	set @hdp_seqno = @hdp_seqno + 1
	
	if @hdp_pctamt = 'Amount'
	begin
		-- Amount part
		insert into SHCI_SHDISPRM
		select
		@hsh_cocde,
		@hsh_cshpno,
		@hsh_cinvno,
		@hdp_type,
		@hdp_seqno,
		@hdp_cde,
		@hdp_dsc,
		@hdp_pctamt,
		0.00,
		@hdp_amt,
		@usrid,
		@usrid,
		getdate(),
		getdate(),
		null
		
	end
	else
	begin
		-- Percentage Part
		-- Amount part
		insert into SHCI_SHDISPRM
		select
		@hsh_cocde,
		@hsh_cshpno,
		@hsh_cinvno,
		@hdp_type,
		@hdp_seqno,
		@hdp_cde,
		@hdp_dsc,
		@hdp_pctamt,
		(@hdp_amt/@ttl_hih_ttlamt) * 100,
		@hdp_amt,
		@usrid,
		@usrid,
		getdate(),
		getdate(),
		null
		
	end
	Fetch next from cur_DiscountPremium into @hdp_type,@hdp_cde,@hdp_dsc,@hdp_pctamt,@hdp_amt
end
close cur_DiscountPremium
deallocate cur_DiscountPremium





/***************/
/* 5. SHIPGDTL */
/***************/
declare @shpseqint integer
set @shpseqint = 0


declare cur_CombineInvoice cursor for
select hsh_cocde, hsh_cinvno, hsh_cshpno, hsh_invno, hsh_shpno, hsh_cusno
from SHSUBSH where hsh_cocde = @cocde and hsh_cinvno = @cinvno
order by hsh_cocde,hsh_cinvno,hsh_invno



Open cur_CombineInvoice
Fetch next from cur_CombineInvoice into
@hsh_cocde,@hsh_cinvno,@hsh_cshpno,@hsh_invno,@hsh_shpno,@hsh_cusno

while @@fetch_status = 0
begin

	set @shpseqint = @shpseqint + 100

	insert into SHCI_SHIPGDTL
	select 
	hid_cocde,
	@hsh_cshpno,
	@shpseqint + hid_shpseq,
	hid_ctrcfs,
	hid_sealno,
	hid_ctrsiz,
	hid_pckrmk,
	hid_jobno,
	hid_ordno,
	hid_ordseq,
	hid_cuspo,
	hid_cusitm,
	hid_cussku,
	hid_itmno,
	hid_itmtyp,
	hid_itmdsc,
	hid_colcde,
	hid_cuscol,
	hid_coldsc,
	hid_alsitmno,
	hid_alscolcde,
	hid_shpqty,
	hid_untcde,
	hid_ctnstr,
	hid_ctnend,
	hid_inrctn,
	hid_mtrctn,
	hid_vol,
	hid_mtrdcm,
	hid_mtrwcm,
	hid_mtrhcm,
	hid_actvol,
	hid_grswgt,
	hid_netwgt,
	hid_itmshm,
	hid_cmprmk,
	hid_mannam,
	hid_manadr,
	hid_ttlvol,
	hid_ttlnet,
	hid_ttlgrs,
	hid_ttlctn,
	hid_untsel,
	hid_selprc,
	hid_untamt,
	hid_ttlamt,
	@hsh_cinvno,
	hid_prctrm,
	hid_paytrm,
	hid_purord,
	hid_purseq,
	hid_venno,
	hid_cusven,
	hid_conftr,
	hid_contopc,
	hid_pcprc,
	hid_custum,
	hid_cusstyno,
	hid_creusr,
	hid_updusr,
	hid_credat,
	hid_upddat,
	null
	from SHIPGDTL where hid_cocde = @hsh_cocde and hid_shpno = @hsh_shpno


	insert into SHCI_SHDTLCTN
	select 
	hdc_cocde,
	@hsh_cshpno,
	@shpseqint + hdc_shpseq,
	hdc_ctnseq,
	hdc_ordno,
	hdc_seq,
	hdc_from,
	hdc_to,
	hdc_ttlctn,
	hdc_creusr,
	hdc_updusr,
	hdc_credat,
	hdc_upddat,
	null
	from SHDTLCTN where hdc_cocde = @hsh_cocde and hdc_shpno = @hsh_shpno






	Fetch next from cur_CombineInvoice into
	@hsh_cocde,@hsh_cinvno,@hsh_cshpno,@hsh_invno,@hsh_shpno,@hsh_cusno
end
close cur_CombineInvoice
deallocate cur_CombineInvoice




END








GO
GRANT EXECUTE ON [dbo].[sp_insert_CombineInvoice] TO [ERPUSER] AS [dbo]
GO
