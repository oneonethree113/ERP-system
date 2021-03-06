/****** Object:  StoredProcedure [dbo].[sp_list_VNITMNAT]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_VNITMNAT]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_VNITMNAT]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







CREATE procedure [dbo].[sp_list_VNITMNAT]

@vin_cocde 	nvarchar(6) ,
@vin_venno  	nvarchar(6) ,
@typ		nvarchar(6)
                                              
AS

begin
	select 	
		'   '  as 'Status',
		vin_venno,
		--vin_natcde + ' - ' + vin_natdsc as 'Itmnat',
		vin_natcde + ' - ' + ltrim(rtrim(isnull(ysi_dsc,''))) as 'Itmnat',
		vin_creusr,
		vin_natseq
	from	
		VNITMNAT left join SYSETINF on vin_natcde = ysi_cde
	where                                  
	           	vin_venno = @vin_venno and
		ysi_typ = @typ	--ysi_typ = '25'	
			
end




GO
GRANT EXECUTE ON [dbo].[sp_list_VNITMNAT] TO [ERPUSER] AS [dbo]
GO
