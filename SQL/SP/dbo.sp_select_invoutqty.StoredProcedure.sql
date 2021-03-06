/****** Object:  StoredProcedure [dbo].[sp_select_invoutqty]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_invoutqty]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_invoutqty]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 27/07/2003


CREATE procedure [dbo].[sp_select_invoutqty]                                                                                                                                                                                                                              
                                                                                                                                                                                                                                                                  
@cocde nvarchar(6),                                                                                                                                                                                                                                          
@invno nvarchar(20)
                                                                                                                                                                                                                                          
AS                                                                                                                                                                                                                                                                
begin 

SELECT 
hnd_ordno,
hnd_invlne,
SUM(CASE hnh_nottyp WHEN 'C' THEN -hnd_adjqty ELSE hnd_adjqty END) as 'outqty',
SUM(CASE hnh_nottyp WHEN 'C' THEN -hnd_adjqty ELSE 0 END) as 'creqty',
SUM(CASE hnh_nottyp WHEN 'D' THEN hnd_adjqty ELSE 0 END) as 'debqty'
FROM SHCBNHDR, SHCBNDTL
WHERE 
hnh_cocde = @cocde AND
hnh_refno = @invno AND
hnh_cocde = hnd_cocde AND
hnh_noteno = hnd_noteno AND
hnd_upd = 'Y' 
group by hnd_ordno , hnd_invlne


end



GO
GRANT EXECUTE ON [dbo].[sp_select_invoutqty] TO [ERPUSER] AS [dbo]
GO
