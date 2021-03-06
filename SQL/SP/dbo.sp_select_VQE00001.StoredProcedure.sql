/****** Object:  StoredProcedure [dbo].[sp_select_VQE00001]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_VQE00001]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_VQE00001]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO



-- Checked by Allan Yuen 27/07/2003


CREATE procedure [dbo].[sp_select_VQE00001]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@cocde nvarchar(6)
                                           
---------------------------------------------- 
 
AS
BEGIN

-- QUOTATION UPDATE TO EXPIRE
/*
UPDATE QUOTNHDR SET quh_qutsts = 'E'
WHERE quh_valdat < GETDATE() and
quh_qutsts = 'A' and
quh_cocde = @cocde
*/

update QUOTNHDR set quh_qutsts = 'E' from QUOTNHDR 
left join QUOTNDTL on qud_qutno = quh_qutno 
where quh_qutsts = 'A' and
qud_expdat < getdate() and quh_cocde = @cocde







/*
-- SHIPPING OR INVOICE UPDATE

UPDATE SHIPGHDR SET hih_shpsts = 'HLD',
hih_updusr = 'SYSTEM',
hih_upddat = getdate()
WHERE GETDATE() - hih_slnonb > 30 and
hih_shpsts = 'OPE' and
hih_cocde = @cocde
*/
-- CREDIT /DEBIT NOTE UPDATE

UPDATE SHCBNHDR SET hnh_notsts = 'HLD',
hnh_updusr = 'SYSTEM',
hnh_upddat = getdate()
WHERE GETDATE() - hnh_issdat > 30 and
hnh_notsts = 'OPE' and
hnh_cocde = @cocde

-- SAMPLE INVOICE UPDATE

UPDATE SAINVHDR set sih_invsts = 'REL',
sih_updusr = 'SYSTEM',
sih_upddat = getdate()
WHERE GETDATE() - sih_issdat > 30 and
sih_invsts = 'OPE' and
sih_cocde = @cocde

END



GO
GRANT EXECUTE ON [dbo].[sp_select_VQE00001] TO [ERPUSER] AS [dbo]
GO
