/****** Object:  StoredProcedure [dbo].[sp_insert_SHINVELL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SHINVELL]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SHINVELL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





-- Checked by Allan Yuen at 28/07/2003

--*************************************************************
--*Description	: Elliwell Invoice
--*		: Extract Information from Invoice
--*Input File 	: SHINVHDR, SHIPGDTL, SYCOMINF, SYDISPRM
--*Output File	: SHINVELL
--*Create Date	: 2002-07-31
--*Create By	: Solo So
--*************************************************************
CREATE PROCEDURE [dbo].[sp_insert_SHINVELL] 
AS

Begin

Declare
@dateFm		datetime,
@dateTo		datetime,

@hie_cocde	nvarchar(6),
@hie_invno	nvarchar(20),
@hie_invtyp	nvarchar(2),
@hie_cus1no	nvarchar(6),
@hie_invdat	datetime,
@hie_invsts	nvarchar(3),
@hie_curcde	nvarchar(6),
@hie_ttlamt	numeric(13,2),
@hie_disamt	numeric(13,2),
@hie_netamt	numeric(13,2),
@hie_postdat	datetime,
@hie_oriinv	nvarchar(20)

--Set @dateFm = Convert(char(10), getdate(),111) + ' 00:00:00.000'
--Set @dateTo = getdate()

Set @dateFm = Convert(char(10), getdate()-1,111) + ' 00:00:00.000'
Set @dateTo = Convert(char(10), getdate()-1,111) + ' 23:59:59.998'

Declare	cur_SHINVELL cursor
for
Select	inv.hiv_cocde,
	'EL',
	hih_cus1no,
	inv.hiv_invdat,
	hih_shpsts,
	inv.hiv_untamt,
	vw.sumpmt,
	round(vw.sumpmt * 0.03, 2),
	vw.sumpmt - round(vw.sumpmt * 0.03, 2),
	hiv_invno
From	SHIPGHDR, SHINVHDR inv, 
	(select hid_cocde, hid_invno, sumpmt = sum(sumpmt) 
	from v_select_inr00002 
	where vw_venno = '0005' and hid_cocde = 'UCP' 
	group by hid_cocde, hid_invno) vw
where	hih_cocde = inv.hiv_cocde and hih_shpno = inv.hiv_shpno
and	inv.hiv_cocde = vw.hid_cocde and inv.hiv_invno = vw.hid_invno 
and	inv.hiv_upddat between @dateFm and @dateTo
and	inv.hiv_cocde = 'UCP' 
and 	inv.hiv_credat >= '2002-03-08' 
and	(inv.hiv_invno >= 'I0200876' or inv.hiv_invno in ('I0200789', 'I0200798', 'I0200807', 'I0200819', 'I0200821', 'I0200837', 'I0200841', 'I0200851', 'I0200853', 'I0200861', 'I0200862', 'I0200865'))

Union

Select	sid_cocde,
	'EA',
	max(sih_cus1no),
	max(sih_rvsdat),
	max(sih_invsts),
	max(sid_fcurcde),
	sum(round(sid_shpqty * sid_ftyprc, 2)),
	0,
	sum(round(sid_shpqty * sid_ftyprc, 2)),
	sih_invno
From	SAINVHDR, SAINVDTL
Where	sih_cocde = sid_cocde and sih_invno =	sid_invno
and	sih_cocde = 'UCP' --and sih_invsts = 'OPE'
and	sid_venno = '0005'
and	sih_upddat between @dateFm and @dateTo
and	sih_credat >= '2002-07-01'
group by	sid_cocde, sih_invno

order by	2 desc, 10

Open cur_SHINVELL
Fetch next from cur_SHINVELL into
@hie_cocde,
@hie_invtyp,
@hie_cus1no,
@hie_invdat,
@hie_invsts,
@hie_curcde,
@hie_ttlamt,
@hie_disamt,
@hie_netamt,
@hie_oriinv

While @@fetch_status = 0
Begin
	Update	SHINVELL
	Set	hie_invsts = @hie_invsts,
		hie_cus1no = @hie_cus1no,
		hie_ttlamt = @hie_ttlamt,
		hie_disamt = @hie_disamt,
		hie_netamt = @hie_netamt,
		hie_updusr = 'PostUsr',
		hie_upddat = getdate()
	Where	hie_oriinv = @hie_oriinv and hie_invtyp = @hie_invtyp

	If @@rowcount = 0
	begin
		If @hie_invtyp = 'EL'
		begin
			Execute sp_select_doc_gen_po "UCP", "EL", "PostUsr", @purord = @hie_invno OUTPUT
		End
		If @hie_invtyp = 'EA'
		begin
			Set @hie_invno = @hie_oriinv
		End

		Insert into SHINVELL (
		hie_cocde,
		hie_invno,
		hie_invtyp,
		hie_cus1no,
		hie_invdat,
		hie_invsts,
		hie_curcde,
		hie_ttlamt,
		hie_disamt,
		hie_netamt,
		hie_postdat,
		hie_oriinv,
		hie_upddat,
		hie_updusr,
		hie_credat,
		hie_creusr )
		Values (
		@hie_cocde,
		@hie_invno,
		@hie_invtyp,
		@hie_cus1no,
		@hie_invdat,
		@hie_invsts,
		@hie_curcde,
		@hie_ttlamt,
		@hie_disamt,
		@hie_netamt,
		'1900-01-01',
		@hie_oriinv,
		getdate(),
		'PostUsr',
		getdate(),
		'PostUsr' )
	End

	Fetch next from cur_SHINVELL into
	@hie_cocde,
	@hie_invtyp,
	@hie_cus1no,
	@hie_invdat,
	@hie_invsts,
	@hie_curcde,
	@hie_ttlamt,
	@hie_disamt,
	@hie_netamt,
	@hie_oriinv

End
Close cur_SHINVELL
Deallocate cur_SHINVELL

End





GO
GRANT EXECUTE ON [dbo].[sp_insert_SHINVELL] TO [ERPUSER] AS [dbo]
GO
