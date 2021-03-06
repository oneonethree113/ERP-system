/****** Object:  StoredProcedure [dbo].[sp_update_SYCLMTYP]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SYCLMTYP]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SYCLMTYP]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



--sp_update_SYCLMTYP 'UCP', '2011C015', '1', 'APV1', 'mis'
CREATE  PROCEDURE [dbo].[sp_update_SYCLMTYP]
@cocde nvarchar(6),
@yct_cde nvarchar(2),
@yct_dsc char(300),
@yct_cus char(1),
@yct_ven nvarchar(1),
@yct_ucp nvarchar(1),
@yct_Salaccrgt nvarchar(1),
@yct_Shpaccrgt nvarchar(1),
@yct_Acctaccrgt nvarchar(1),
@yct_SMApprgt nvarchar(1),
@yct_SZApprgt nvarchar(1),
@yct_ShpApprgt nvarchar(1),
@yct_AppAmt	decimal(13,4),
@yct_updusr nvarchar(30)
AS
begin
			update SYCLMTYP
			set 
				yct_dsc=@yct_dsc,
				yct_cus=@yct_cus,
				yct_ven=@yct_ven,
				yct_ucp=@yct_ucp,
				yct_Salaccrgt=@yct_Salaccrgt,
				yct_Shpaccrgt=@yct_Shpaccrgt,
				yct_Acctaccrgt=@yct_Acctaccrgt,
				yct_SMApprgt=@yct_SMApprgt,
				yct_SZApprgt=@yct_SZApprgt,
				yct_ShpApprgt=@yct_ShpApprgt,
				yct_AppAmt=@yct_AppAmt,	
				yct_updusr=@yct_updusr
			where 
			--yct_cocde = @cocde
			--and 
			yct_cde = @yct_cde
end






GO
GRANT EXECUTE ON [dbo].[sp_update_SYCLMTYP] TO [ERPUSER] AS [dbo]
GO
