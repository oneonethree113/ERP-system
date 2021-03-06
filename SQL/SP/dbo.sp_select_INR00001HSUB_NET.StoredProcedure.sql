/****** Object:  StoredProcedure [dbo].[sp_select_INR00001HSUB_NET]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_INR00001HSUB_NET]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_INR00001HSUB_NET]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create    procedure [dbo].[sp_select_INR00001HSUB_NET]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@cocde nvarchar(6) ,
@from nvarchar(20),
@to nvarchar(20)                                               
---------------------------------------------- 
 
AS
begin

create table #temp_fmto
(
	tmp_fm  int,
	tmp_to int,
	tmp_cusitm      nvarchar(40),
)

create table #temp_main
(
	 hdc_shpno     nvarchar(40),
	hdc_shpseq  nvarchar(20),
	hdc_ctnseq int,
	hdc_from int,
	hdc_to int,
	hdc_fromto   nvarchar(40),
	hid_ctnftr INT,
	hid_cusitm      nvarchar(40)
)

insert into #temp_main
Select	
	hdc_shpno as hdc_shpno,
	cast(hdc_shpseq as nvarchar(20)) as  hdc_shpseq,
	hdc_ctnseq as hdc_ctnseq,
	ltrim(str(hdc_from)) as hdc_from,
	ltrim(str(hdc_to)) as hdc_to,
	'C/NO.  '+ltrim(str(hdc_from))  +' - ' + ltrim(str(hdc_to))  as 'hdc_fromto',
	hid_ctnftr as 	hid_ctnftr,Case isnull(hid_cusitm, '') when '' then hid_itmno else hid_cusitm end as 'hid_cusitm' 
From 	SHDTLCTN  ctn 
	left join SHINVHDR hiv
	on ctn.hdc_cocde = hiv.hiv_cocde
	and  ctn.hdc_shpno = hiv.hiv_shpno
	left join SHIPGDTL  dtl 
	on ctn.hdc_shpno = dtl.hid_shpno
	and ctn.hdc_shpseq = dtl.hid_shpseq -- 20150317
WHERE 	
hiv.hiv_cocde = @cocde AND
hiv.hiv_invno >= @from AND
hiv.hiv_invno <= @to  

insert into #temp_main

Select	
	hid_shpno as hdc_shpno,
	cast(hid_shpseq as nvarchar(20)) as  hdc_shpseq,
	0 as hdc_ctnseq,
	hid_ctnstr as hdc_from,
	hid_ctnend as hdc_to,
	'C/NO.  '+ltrim(str(hid_ctnstr))  +' - ' + ltrim(str(hid_ctnend))  as 'hdc_fromto',

	hid_ctnftr as 	hid_ctnftr,
	Case isnull(hid_cusitm, '') when '' then hid_itmno else hid_cusitm end as 'hid_cusitm'
	 
From 	SHIPGDTL  dtl 
	left join SHINVHDR  hiv
	on dtl.hid_cocde = hiv.hiv_cocde AND
	dtl.hid_shpno = hiv.hiv_shpno 
WHERE 	
hiv.hiv_cocde = @cocde AND
hiv.hiv_invno >= @from AND
hiv.hiv_invno <= @to AND
dtl.hid_shpno + str(dtl.hid_shpseq,4) not in
(select hdc_shpno + str(hdc_shpseq,4)
From SHDTLCTN, SHINVHDR 
WHERE hiv_cocde = @cocde AND
hiv_invno >= @from AND
hiv_invno <= @to  AND
hdc_cocde = hiv_cocde AND
hdc_shpno = hiv_shpno)
ORDER BY hdc_from


INSERT INTO #temp_fmto
select MIN(HDC_FROM),MAX(HDC_TO),hid_cusitm
from #temp_main group by hid_cusitm

select 
hdc_shpno  AS 'hdc_shpno'   ,
	hdc_shpseq AS 'hdc_shpseq',
	hdc_ctnseq AS 'hdc_ctnseq',
	hdc_from AS 'hdc_from',
	hdc_to AS 'hdc_to',
	'C/NO.  '+ltrim(str(tmp_fm))  +' - ' + ltrim(str(tmp_to))  as 'hdc_fromto',
	hid_ctnftr AS 'hid_ctnftr',
	hid_cusitm      AS 'hid_cusitm' 

 from  #temp_main
							left join #temp_fmto
							on hid_cusitm = tmp_cusitm

drop table  #temp_fmto
drop table  #temp_main

end



GO
GRANT EXECUTE ON [dbo].[sp_select_INR00001HSUB_NET] TO [ERPUSER] AS [dbo]
GO
