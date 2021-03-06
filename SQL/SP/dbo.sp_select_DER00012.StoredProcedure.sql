/****** Object:  StoredProcedure [dbo].[sp_select_DER00012]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_DER00012]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_DER00012]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO



-- Checked by Allan Yuen at 27/07/2003


CREATE PROCEDURE [dbo].[sp_select_DER00012] 

@Cocde as nvarchar(20)
AS

select 

cpi_cocde,
'Sale Confirmation' as 'DocTyp',
cpi_curcde,
cpi_cusno + case when cbi_cusnam = '' then '' else ' - ' + cbi_cusnam end as 'cbi_cusno', 
'Risk' as 'R/C',
cpi_rsklmt - cpi_rskuse  as 'AvaAmt',
soh_ordno as 'DocNo1',
'' as 'DocNo2',
soh_issdat as 'Issdat',
soh_ttlamt as 'TtlAmt'


from CUPRCINF 
--Left Join CUBASINF on cbi_cocde =@Cocde and cpi_cusno = cbi_cusno 
Left Join CUBASINF on cpi_cusno = cbi_cusno 
Inner Join SCORDHDR on soh_cocde = @Cocde  and soh_cus1no = cpi_cusno and soh_ordsts = 'HLD'

where cpi_rskuse > cpi_rsklmt

Union

select 
cpi_cocde,
'Shipping Invoice' as 'DocTyp',
cpi_curcde,
cpi_cusno + case when cbi_cusnam = '' then '' else ' - ' + cbi_cusnam end, 
'Credit',
cpi_cdtlmt - cpi_cdtuse,
hih_shpno,
hiv_invno,
hiv_invdat,
hiv_ttlamt


from CUPRCINF 
--Left Join CUBASINF on cbi_cocde =@Cocde and cpi_cusno = cbi_cusno 
Left Join CUBASINF on cpi_cusno = cbi_cusno 
Inner Join SHIPGHDR on hih_cocde = @Cocde  and hih_cus1no = cpi_cusno and hih_shpsts = 'HLD'
Inner Join SHINVHDR on hiv_cocde =@Cocde and hih_shpno = hiv_shpno 


where cpi_cdtuse > cpi_cdtlmt

Union

select 
cpi_cocde,
'Sample Invoice' as 'DocTyp',
cpi_curcde,
cpi_cusno + case when cbi_cusnam = '' then '' else ' - ' + cbi_cusnam end, 
'Credit',
cpi_cdtlmt - cpi_cdtuse,
sih_invno,
'',
sih_issdat,
sih_ttlamt


from CUPRCINF 
--Left Join CUBASINF on cbi_cocde =@Cocde and cpi_cusno = cbi_cusno 
Left Join CUBASINF on cpi_cusno = cbi_cusno 
Inner Join SAINVHDR on sih_cocde = @Cocde  and sih_cus1no = cpi_cusno and sih_invsts = 'HLD'

where cpi_cdtuse > cpi_cdtlmt

Order by Doctyp,  cbi_cusno, DocNo1, DocNo2



GO
GRANT EXECUTE ON [dbo].[sp_select_DER00012] TO [ERPUSER] AS [dbo]
GO
