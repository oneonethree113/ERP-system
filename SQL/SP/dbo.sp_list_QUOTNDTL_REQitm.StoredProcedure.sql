/****** Object:  StoredProcedure [dbo].[sp_list_QUOTNDTL_REQitm]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_QUOTNDTL_REQitm]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_QUOTNDTL_REQitm]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


--update quh
--set quh.quh_qutsts = 'H'	-- HOLD

Create  procedure  [dbo].[sp_list_QUOTNDTL_REQitm]
@cocde	varchar(6),
@qutno	varchar(30)
as
Begin

	select 
		'N' AS 'UPD',
		qud_qutseq as 'Seq',
		qud_itmno as 'Item No',
		case qud_untcde 
			when '' then ''
			else qud_untcde + '/' + CAST(qud_inrqty AS varchar(10)) + '/' + CAST(qud_mtrqty AS varchar(10)) + '/' + qud_prctrm + '/' + qud_ftyprctrm + '/' + qud_trantrm
		end as 'P&T(apps)',	
		
		'' as 'Packing & Terms',
		'' as 'Color',
		'' as 'PriceKey (Pri)',
		'' as 'PriceKey (Sec)',
		'' as 'IM Found',
		'' as 'Message',
		
		
		
		--Not Shown Data
		qud_untcde,
		qud_inrqty,
		qud_mtrqty, 
		qud_prctrm,
		qud_ftyprctrm,
		qud_trantrm
	
		
	FROM QUOTNDTL
	Where 
		qud_cocde = @cocde and
		qud_qutno = @qutno and
		qud_qutitmsts = 'REQ'
		
End




GO
GRANT EXECUTE ON [dbo].[sp_list_QUOTNDTL_REQitm] TO [ERPUSER] AS [dbo]
GO
