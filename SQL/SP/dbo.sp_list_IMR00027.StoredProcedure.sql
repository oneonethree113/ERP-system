/****** Object:  StoredProcedure [dbo].[sp_list_IMR00027]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_IMR00027]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_IMR00027]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





/*
=========================================================
Program ID	: sp_list_IMR00027
Description   	: 
Programmer  	: Marco Chan
ALTER  Date   	: 20/10/2005
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
30/07/2009	Frankie Cheung	New sp_list_IMR00027 for IMR00027 enhanced functions

*/


create procedure [dbo].[sp_list_IMR00027]
	@cocde	nvarchar(6),	

	@prdlneFm	nvarchar(10),
	@prdlneTo	nvarchar(10),
	@prdlneList	nvarchar(1000),
	@prdlneOpr	nvarchar(3),

	@itmnoFm	nvarchar(20),
	@itmnoTo	nvarchar(20),
	@itmnoList	nvarchar(1000),
	@itmnoOpr	nvarchar(3),

	@itmDscFm	nvarchar(200),
	@itmDscTo	nvarchar(200),
	@itmDscList	nvarchar(1000),
	@itmDscOpr	nvarchar(3),

	@colDscFm	nvarchar(200),
	@colDscTo	nvarchar(200),
	@colDscList	nvarchar(1000),
	@colDscOpr	nvarchar(3),

	@vdrFm		nvarchar(20),
	@vdrTo		nvarchar(20),
	@vdrList	nvarchar(1000),
	@vdrOpr	nvarchar(3),

	@itmNatList	nvarchar(1000),
	@itmNatOpr	nvarchar(3),

	@prdSzeList	nvarchar(1000),
	@prdSzeOpr	nvarchar(3),

	@prdGrpList	nvarchar(1000),
	@prdGrpOpr	nvarchar(3),

	@prdIcnList	nvarchar(1000),
	@prdIcnOpr	nvarchar(3),

	@prdMatList	nvarchar(1000),
	@prdMatOpr	nvarchar(3),
	
	@ventyp	nvarchar(10),
	@itmtyp		nvarchar(10),
	@prdtyp	nvarchar(10),
	@resol		nvarchar(1),

	@TEMP		nvarchar(10)

as

set nocount on 

declare @optItmStr		char(1),
	@optPrdLneStr		char(1),
	@optExCustStr		char(1),

	@ItmNoStrRemain	nvarchar(1000),
	@ItmDscStrRemain	nvarchar(1000),
	@ColDscStrRemain	nvarchar(1000),
	@PrdLneStrRemain	nvarchar(1000),
	@VenCdeStrRemain 	nvarchar(1000),
	@ItmNatStrRemain 	nvarchar(1000),
	@PrdSzeStrRemain 	nvarchar(1000),
	@PrdGrpStrRemain 	nvarchar(1000),
	@PrdIcnStrRemain	nvarchar(1000),
	@PrdMatStrRemain	nvarchar(1000),

	@ExCustStrRemain	nvarchar(1000),

	@ItmNoStrPart		nvarchar(20),
	@ItmDscStrPart		nvarchar(1000),
	@ColDscStrPart		nvarchar(1000),
	@PrdLneStrPart		nvarchar(15),
	@VenCdeStrPart 	nvarchar(15),
	@ItmNatStrPart 		nvarchar(15),
	@PrdSzeStrPart 		nvarchar(30),
	@PrdGrpStrPart 		nvarchar(15),
	@PrdIcnStrPart 		nvarchar(15),
	@PrdMatStrPart 		nvarchar(15),

	@sql 			nvarchar(4000),
	@tblname_and		nvarchar(1000),
	@wclause_and		nvarchar(1000),
	@tblname_or		nvarchar(1000),
	@wclause_or		nvarchar(1000),
	@fm			nvarchar(1000),
	@to			nvarchar(1000),
	@szeTyp		nvarchar(1),
	@szeVal			nvarchar(20),
	@szeUnt		nvarchar(10),
	@szeRemain		nvarchar(31),
	@szeTypfm		nvarchar(15),
	@szeValfm		nvarchar(15),
	@szeUntfm		nvarchar(15),
	@szeTypto		nvarchar(15),
	@szeValto		nvarchar(15),
	@szeUntto		nvarchar(15)

create table #TMP_ITM (tmp_ITMNO nvarchar(20)) on [PRIMARY]
create table #TMP_IDS (tmp_ITMDSC nvarchar(1600)) on [PRIMARY]
create table #TMP_CDS (tmp_COLDSC nvarchar(1000)) on [PRIMARY]
create table #TMP_LNE (tmp_PRDLNE nvarchar(10)) on [PRIMARY]
create table #TMP_VEN (tmp_VENCDE nvarchar(10)) on [PRIMARY]
create table #TMP_NAT (tmp_ITMNAT nvarchar(10)) on [PRIMARY]
create table #TMP_SZE (tmp_PRDSZE nvarchar(1000)) on [PRIMARY]
create table #TMP_PGP (tmp_PRDGRP nvarchar(10)) on [PRIMARY]
create table #TMP_ICN (tmp_PRDICN nvarchar(10)) on [PRIMARY]
create table #TMP_MAT (tmp_PRDMAT nvarchar(10)) on [PRIMARY]

create table #TMP_EXCUST (tmp_CUSNO nvarchar(10)) on [PRIMARY]

create table #TMP_VENTYP (tmp_VENTYP nvarchar(10)) on [PRIMARY]
create table #TMP_ITMTYP (tmp_ITMTYP nvarchar(10)) on [PRIMARY]
create table #TMP_PRDTYP (tmp_PRDTYP nvarchar(10)) on [PRIMARY]


if ltrim(rtrim(@ventyp)) <> '' 
begin 
	if substring(@ventyp,1,1) = 'Y'
		insert into #TMP_VENTYP values ('I')

	if substring(@ventyp,2,1) = 'Y'
		insert into #TMP_VENTYP values ('J')

	if substring(@ventyp,3,1) = 'Y'
		insert into #TMP_VENTYP values ('E')
end


if ltrim(rtrim(@itmtyp)) <> '' 
begin 
	if substring(@itmtyp,1,1) = 'Y'
		insert into #TMP_ITMTYP values ('REG')

	if substring(@itmtyp,2,1) = 'Y'
		insert into #TMP_ITMTYP values ('ASS')

	if substring(@itmtyp,3,1) = 'Y'
		insert into #TMP_ITMTYP values ('BOM')

	if substring(@itmtyp,4,1) = 'Y'
		insert into #TMP_ITMTYP values ('OTH')
end

if ltrim(rtrim(@prdtyp)) <> '' 
begin 
	if substring(@prdtyp,1,1) = 'Y'
		insert into #TMP_PRDTYP values ('SHOWROOM')

	if substring(@prdtyp,2,1) = 'Y'
		insert into #TMP_PRDTYP values ('OEM')

	if substring(@prdtyp,3,1) = 'Y'
		insert into #TMP_PRDTYP values ('MODIFY')

	if substring(@prdtyp,4,1) = 'Y'
		insert into #TMP_PRDTYP values ('ODM')

	if substring(@prdtyp,5,1) = 'Y'
		insert into #TMP_PRDTYP values (' ')
end



/*** Start: Generate Product Line List ***/

set @optPrdLneStr = 'N'
if ltrim(rtrim(@prdlneList)) <> ''
begin
	set @optPrdLneStr = 'Y'
	set @PrdLneStrRemain = @prdlneList

	while charindex(',', @PrdLneStrRemain) <> 0
	begin
		set @PrdLneStrPart = ltrim(left(@PrdLneStrRemain, charindex(',', @PrdLneStrRemain)-1))
		set @PrdLneStrRemain = right(@PrdLneStrRemain, len(@PrdLneStrRemain) - charindex(',', @PrdLneStrRemain))

		if charindex('~', 	@PrdLneStrPart) <> 0 
		begin
			set @fm = ltrim(left(@PrdLneStrPart, charindex('~', @PrdLneStrPart)-1))
			set @to = right(@PrdLneStrPart, len(@PrdLneStrPart) - charindex('~', @PrdLneStrPart))
					
			insert into #TMP_LNE 	
			select yli_lnecde from sylneinf where  yli_lnecde between @fm and @to	
		
		end
		else if charindex('%', @PrdLneStrPart) <> 0
		begin		
			insert into #TMP_LNE 	
			select yli_lnecde from sylneinf where  yli_lnecde like @PrdLneStrPart			
		end
		else
		begin			
			insert into #TMP_LNE values (@PrdLneStrPart)
		end
	end


	if charindex(',',@PrdLneStrRemain) = 0 
	begin
		set @PrdLneStrRemain = ltrim(@PrdLneStrRemain)
		if charindex('~', 	@PrdLneStrRemain) <> 0 
		begin
			set @fm = ltrim(left(@PrdLneStrRemain, charindex('~', @PrdLneStrRemain)-1))
			set @to = right(@PrdLneStrRemain, len(@PrdLneStrRemain) - charindex('~', @PrdLneStrRemain))
					
			insert into #TMP_LNE 	
			select yli_lnecde from sylneinf where  yli_lnecde between @fm and @to

		end
		else if charindex('%', @PrdLneStrRemain) <> 0
		begin		
			insert into #TMP_LNE 	
			select yli_lnecde from sylneinf where  yli_lnecde like @PrdLneStrRemain			
		end
		else
		begin			
			insert into #TMP_LNE values (ltrim(@PrdLneStrRemain))
		end
	end
end

/*** END: Generate Product Line List ***/


/*** Start: Generate Item Number List ***/

if ltrim(rtrim(@itmnoList)) <> ''
begin
	set @ItmNoStrRemain = @itmnoList

	while charindex(',', @ItmNoStrRemain) <> 0
	begin
		set @ItmNoStrPart = ltrim(left(@ItmNoStrRemain, charindex(',', @ItmNoStrRemain)-1))
		set @ItmNoStrRemain = right(@ItmNoStrRemain, len(@ItmNoStrRemain) - charindex(',', @ItmNoStrRemain))

		if charindex('~', 	@ItmNoStrPart) <> 0 
		begin
			set @fm = ltrim(left(@ItmNoStrPart, charindex('~', @ItmNoStrPart)-1))
			set @to = right(@ItmNoStrPart, len(@ItmNoStrPart) - charindex('~', @ItmNoStrPart))
					
			insert into #TMP_ITM 	
			select ibi_itmno from imbasinf where ibi_itmno between @fm and @to	

			insert into #TMP_ITM 	
			select ibi_itmno from imbasinfh where ibi_itmno between @fm and @to	
		
		end
		else if charindex('%', @ItmNoStrPart) <> 0
		begin		
			insert into #TMP_ITM 	
			select ibi_itmno from imbasinf where ibi_itmno like @ItmNoStrPart		

			insert into #TMP_ITM 	
			select ibi_itmno from imbasinfh where ibi_itmno like @ItmNoStrPart		
		end
		else
		begin			
			insert into #TMP_ITM values (@ItmNoStrPart)
		end
	end


	if charindex(',',@ItmNoStrRemain) = 0 
	begin
		set @PrdLneStrRemain = ltrim(@ItmNoStrRemain)
		if charindex('~', 	@ItmNoStrRemain) <> 0 
		begin
			set @fm = ltrim(left(@ItmNoStrRemain, charindex('~', @ItmNoStrRemain)-1))
			set @to = right(@ItmNoStrRemain, len(@ItmNoStrRemain) - charindex('~', @ItmNoStrRemain))
					
			insert into #TMP_ITM 	
			select ibi_itmno from imbasinf where ibi_itmno between @fm and @to

			insert into #TMP_ITM 	
			select ibi_itmno from imbasinfh where ibi_itmno between @fm and @to

		end
		else if charindex('%', @ItmNoStrRemain) <> 0
		begin		
			insert into #TMP_ITM 	
			select ibi_itmno from imbasinf where ibi_itmno like @ItmNoStrRemain	

			insert into #TMP_ITM 	
			select ibi_itmno from imbasinfh where ibi_itmno like @ItmNoStrRemain	
		
		end
		else
		begin			
			insert into #TMP_ITM values (ltrim(@ItmNoStrRemain))
		end
	end
end

/*** End: Generate Item Number List ***/



/*** Start: Generate Item Description List ***/

if ltrim(rtrim(@itmdscList)) <> ''
begin
	set @ItmDscStrRemain = @itmdscList

	while charindex(',', @ItmDscStrRemain) <> 0
	begin

		set @ItmDscStrPart = ltrim(left(@ItmDscStrRemain, charindex(',', @ItmDscStrRemain)-1))
		set @ItmDscStrRemain = right(@ItmDscStrRemain, len(@ItmDscStrRemain) - charindex(',', @ItmDscStrRemain))

		if charindex('~', 	@ItmDscStrPart) <> 0 
		begin
			set @fm = ltrim(left(@ItmDscStrPart, charindex('~', @ItmDscStrPart)-1))
			set @to = right(@ItmDscStrPart, len(@ItmDscStrPart) - charindex('~', @ItmDscStrPart))
					
			insert into #TMP_IDS 	
			select ibi_engdsc from imbasinf where ibi_engdsc between @fm and @to	

			insert into #TMP_IDS 	
			select ibi_engdsc from imbasinfh where ibi_engdsc between @fm and @to	
		
		end
		else if charindex('%', @ItmDscStrPart) <> 0
		begin		

			set @ItmDscStrPart = left(@ItmDscStrPart, len(@ItmDscStrPart) - 1)
			set @ItmDscStrPart = right(@ItmDscStrPart, len(@ItmDscStrPart) - 1)	
				

			set @ItmDscStrPart = '%' + replace(@ItmDscStrPart, '%', '\%') + '%'
			
			insert into #TMP_IDS 	
			select ibi_engdsc from imbasinf where ibi_engdsc like @ItmDscStrPart ESCAPE '\' 

			insert into #TMP_IDS 	
			select ibi_engdsc from imbasinfh where ibi_engdsc like @ItmDscStrPart ESCAPE '\' 			
		end
		else
		begin			
			insert into #TMP_IDS values (@ItmDscStrPart)
		end
	end
 
	if charindex(',',@ItmDscStrRemain) = 0 
	begin
		set @ItmDscStrRemain = ltrim(@ItmDscStrRemain)
		if charindex('~', 	@ItmDscStrRemain) <> 0 
		begin
			set @fm = ltrim(left(@ItmDscStrRemain, charindex('~', @ItmDscStrRemain)-1))
			set @to = right(@ItmDscStrRemain, len(@ItmDscStrRemain) - charindex('~', @ItmDscStrRemain))
					
			insert into #TMP_IDS 	
			select ibi_engdsc from imbasinf where ibi_engdsc between @fm and @to

			insert into #TMP_IDS 	
			select ibi_engdsc from imbasinfh where ibi_engdsc between @fm and @to

		end
		else if charindex('%', @ItmDscStrRemain) <> 0
		begin	

			set @ItmDscStrRemain = left(@ItmDscStrRemain, len(@ItmDscStrRemain) - 1)
			set @ItmDscStrRemain = right(@ItmDscStrRemain, len(@ItmDscStrRemain) - 1)	
				
			set @ItmDscStrRemain = '%' + replace(@ItmDscStrRemain, '%', '\%') + '%'
				
			insert into #TMP_IDS 	
			select ibi_engdsc from imbasinf where ibi_engdsc like @ItmDscStrRemain ESCAPE '\' 		

			insert into #TMP_IDS 	
			select ibi_engdsc from imbasinfh where ibi_engdsc like @ItmDscStrRemain ESCAPE '\' 		
					
		end
		else
		begin			
			insert into #TMP_IDS values (ltrim(@ItmDscStrRemain))
		end
	end
end

/*** End: Generate Item Description List ***/


/*** Start: Generate Color Description List ***/

if ltrim(rtrim(@coldscList)) <> ''
begin
	set @ColDscStrRemain = @coldscList

	while charindex(',', @ColDscStrRemain) <> 0
	begin

		set @ColDscStrPart = ltrim(left(@ColDscStrRemain, charindex(',', @ColDscStrRemain)-1))
		set @ColDscStrRemain = right(@ColDscStrRemain, len(@ColDscStrRemain) - charindex(',', @ColDscStrRemain))

		if charindex('~', 	@ColDscStrPart) <> 0 
		begin
			set @fm = ltrim(left(@ColDscStrPart, charindex('~', @ColDscStrPart)-1))
			set @to = right(@ColDscStrPart, len(@ColDscStrPart) - charindex('~', @ColDscStrPart))
					
			insert into #TMP_CDS
			select ibi_itmno from IMBASINF (nolock), IMCOLINF (nolock)
			where ibi_itmno = icf_itmno and icf_coldsc between @fm and @to
	
			insert into #TMP_CDS
			select ibi_itmno from IMBASINFH (nolock), IMCOLINFH (nolock)
			where ibi_itmno = icf_itmno and icf_coldsc between @fm and @to
		
		end
		else if charindex('%', @ColDscStrPart) <> 0
		begin		
			insert into #TMP_CDS
			select ibi_itmno from IMBASINF (nolock), IMCOLINF (nolock)
			where ibi_itmno = icf_itmno and icf_coldsc like @ColDscStrPart	

			insert into #TMP_CDS
			select ibi_itmno from IMBASINFH (nolock), IMCOLINFH (nolock)
			where ibi_itmno = icf_itmno and icf_coldsc like @ColDscStrPart			
		end
		else
		begin			
			insert into #TMP_CDS
			select ibi_itmno from IMBASINF (nolock), IMCOLINF (nolock)
			where ibi_itmno = icf_itmno and icf_coldsc = @ColDscStrPart	

			insert into #TMP_CDS
			select ibi_itmno from IMBASINFH (nolock), IMCOLINFH (nolock)
			where ibi_itmno = icf_itmno and icf_coldsc = @ColDscStrPart	
		end
	end
 
	if charindex(',',@ColDscStrRemain) = 0 
	begin
		set @ColDscStrRemain = ltrim(@ColDscStrRemain)
		if charindex('~', 	@ColDscStrRemain) <> 0 
		begin
			set @fm = ltrim(left(@ColDscStrRemain, charindex('~', @ColDscStrRemain)-1))
			set @to = right(@ColDscStrRemain, len(@ColDscStrRemain) - charindex('~', @ColDscStrRemain))
					
			insert into #TMP_CDS
			select ibi_itmno from IMBASINF (nolock), IMCOLINF (nolock)
			where ibi_itmno = icf_itmno and icf_coldsc between @fm and @to
	
			insert into #TMP_CDS
			select ibi_itmno from IMBASINFH (nolock), IMCOLINFH (nolock)
			where ibi_itmno = icf_itmno and icf_coldsc between @fm and @to

		end
		else if charindex('%', @ColDscStrRemain) <> 0
		begin		
			insert into #TMP_CDS
			select ibi_itmno from IMBASINF (nolock), IMCOLINF (nolock)
			where ibi_itmno = icf_itmno and icf_coldsc like @ColDscStrRemain	

			insert into #TMP_CDS
			select ibi_itmno from IMBASINFH (nolock), IMCOLINFH (nolock)
			where ibi_itmno = icf_itmno and icf_coldsc like @ColDscStrRemain							
		end
		else
		begin			
			insert into #TMP_CDS
			select ibi_itmno from IMBASINF (nolock), IMCOLINF (nolock)
			where ibi_itmno = icf_itmno and icf_coldsc = @ColDscStrRemain	

			insert into #TMP_CDS
			select ibi_itmno from IMBASINFH (nolock), IMCOLINFH (nolock)
			where ibi_itmno = icf_itmno and icf_coldsc = @ColDscStrRemain	
		end
	end
end

/*** End: Generate Color Description List ***/



/*** Start: Convert Vendor List to #TMP_VEN ***/

if ltrim(rtrim(@vdrList)) <> ''
begin
	set @VenCdeStrRemain = @vdrList

	while charindex(',', @VenCdeStrRemain) <> 0
	begin
		set @VenCdeStrPart = ltrim(left(@VenCdeStrRemain, charindex(',', @VenCdeStrRemain)-1))
		set @VenCdeStrRemain = right(@VenCdeStrRemain, len(@VenCdeStrRemain) - charindex(',', @VenCdeStrRemain))

		if charindex('~', 	@VenCdeStrPart) <> 0 
		begin
			set @fm = ltrim(left(@VenCdeStrPart, charindex('~', @VenCdeStrPart)-1))
			set @to = right(@VenCdeStrPart, len(@VenCdeStrPart) - charindex('~', @VenCdeStrPart))
					
			insert into #TMP_VEN 	
			Select vbi_venno from VNBASINF 
			where vbi_vensts <> 'D' and vbi_ventyp = 'E' 
				and vbi_venno between @fm and @to 
			order by vbi_venno
	
		end
		else if charindex('%', @VenCdeStrPart) <> 0
		begin		
			insert into #TMP_VEN 	
			Select vbi_venno from VNBASINF 
			where vbi_vensts <> 'D' and vbi_ventyp = 'E' 
				and vbi_venno like @VenCdeStrPart			
		end
		else
		begin			
			insert into #TMP_VEN values (@VenCdeStrPart)
		end
	end


	if charindex(',',@VenCdeStrRemain) = 0 
	begin
		set @VenCdeStrRemain = ltrim(@VenCdeStrRemain)
		if charindex('~', 	@VenCdeStrRemain) <> 0 
		begin
			set @fm = ltrim(left(@VenCdeStrRemain, charindex('~', @VenCdeStrRemain)-1))
			set @to = right(@VenCdeStrRemain, len(@VenCdeStrRemain) - charindex('~', @VenCdeStrRemain))
					
			insert into #TMP_VEN 	
			Select vbi_venno from VNBASINF 
			where vbi_vensts <> 'D' and vbi_ventyp = 'E' 
				and vbi_venno between @fm and @to 
			order by vbi_venno
		end
		else if charindex('%', @VenCdeStrRemain) <> 0
		begin		
			insert into #TMP_VEN 	
			Select vbi_venno from VNBASINF 
			where vbi_vensts <> 'D' and vbi_ventyp = 'E' 
				and vbi_venno like @VenCdeStrRemain	
		end
		else
		begin			
			insert into #TMP_VEN values (ltrim(@VenCdeStrRemain))
		end
	end
end

/*** End: Convert Vendor List to #TMP_VEN ***/


/*** Start: Convert Item Nature List to #TMP_NAT ***/

if ltrim(rtrim(@itmNatList)) <> ''
begin
	set @ItmNatStrRemain = @itmNatList

	while charindex(',', @ItmNatStrRemain) <> 0
	begin
		set @ItmNatStrPart = ltrim(left(@ItmNatStrRemain, charindex(',', @ItmNatStrRemain)-1))
		set @ItmNatStrRemain = right(@ItmNatStrRemain, len(@ItmNatStrRemain) - charindex(',', @ItmNatStrRemain))

		if charindex('~', 	@ItmNatStrPart) <> 0 
		begin
			set @fm = ltrim(left(@ItmNatStrPart, charindex('~', @ItmNatStrPart)-1))
			set @to = right(@ItmNatStrPart, len(@ItmNatStrPart) - charindex('~', @ItmNatStrPart))
					
			insert into #TMP_NAT 	
			select ysi_cde from sysetinf where ysi_typ = '20' and ysi_cde between @fm and @to			
		end
		else if charindex('%', @ItmNatStrPart) <> 0
		begin		
			insert into #TMP_NAT 	
			select ysi_cde from sysetinf where ysi_typ = '20' and ysi_dsc like @ItmNatStrPart			
		end
		else
		begin			
			insert into #TMP_NAT values (@ItmNatStrPart)
		end
	end


	if charindex(',',@ItmNatStrRemain) = 0 
	begin
		set @ItmNatStrRemain = ltrim(@ItmNatStrRemain)
		if charindex('~', 	@ItmNatStrRemain) <> 0 
		begin
			set @fm = ltrim(left(@ItmNatStrRemain, charindex('~', @ItmNatStrRemain)-1))
			set @to = right(@ItmNatStrRemain, len(@ItmNatStrRemain) - charindex('~', @ItmNatStrRemain))
					
			insert into #TMP_NAT 	
			select ysi_cde from sysetinf where ysi_typ = '20' and ysi_cde between @fm and @to	

		end
		else if charindex('%', @ItmNatStrRemain) <> 0
		begin		
			insert into #TMP_NAT 	
			select ysi_cde from sysetinf where ysi_typ = '20' and ysi_dsc like @ItmNatStrRemain			
		end
		else
		begin			
			insert into #TMP_NAT values (ltrim(@ItmNatStrRemain))
		end
	end
end


/*** END: Convert Item Nature List to #TMP_NAT ***/


/*** Start: Generate Product Size List ***/

if ltrim(rtrim(@prdSzeList)) <> ''
begin
	set @PrdSzeStrRemain = @prdSzeList

	while charindex(',', @PrdSzeStrRemain) <> 0
	begin

		set @PrdSzeStrPart = ltrim(left(@PrdSzeStrRemain, charindex(',', @PrdSzeStrRemain)-1))
		set @PrdSzeStrRemain = right(@PrdSzeStrRemain, len(@PrdSzeStrRemain) - charindex(',', @PrdSzeStrRemain))

		if charindex('~', 	@PrdSzeStrPart) <> 0 
		begin
			set @fm = ltrim(left(@PrdSzeStrPart, charindex('~', @PrdSzeStrPart)-1))
			set @to = right(@PrdSzeStrPart, len(@PrdSzeStrPart) - charindex('~', @PrdSzeStrPart))
					
			set @szeTypfm = ltrim(left(@fm, charindex(' ', @fm)-1))
			set @szeRemain = right(@fm, len(@fm) - charindex(' ', @fm))
			set @szeValfm = ltrim(left(@szeRemain, charindex(' ', @szeRemain)-1))
			set @szeUntfm = right(@szeRemain, len(@szeRemain) - charindex(' ', @szeRemain))

			set @szeTypto = ltrim(left(@to, charindex(' ', @to)-1))
			set @szeRemain = right(@to, len(@to) - charindex(' ', @to))
			set @szeValto = ltrim(left(@szeRemain, charindex(' ', @szeRemain)-1))
			set @szeUntto = right(@szeRemain, len(@szeRemain) - charindex(' ', @szeRemain))
								
			insert into #TMP_SZE 	
			select ibi_itmno from imbasinf(nolock) left join sysetinf on ibi_prdsizeunt = ysi_cde
			where	ysi_typ = '27' 
				and (ibi_prdsizetyp = ltrim(rtrim(upper(@szeTypfm))) and ibi_prdsizeval >= ltrim(rtrim(@szeValfm)) and ysi_dsc = ltrim(rtrim(upper(@szeUntfm))))
				and (ibi_prdsizetyp = ltrim(rtrim(upper(@szeTypto))) and ibi_prdsizeval <= ltrim(rtrim(@szeValto)) and ysi_dsc = rtrim(rtrim(upper(@szeUntto))))

			insert into #TMP_SZE 	
			select ibi_itmno from imbasinfh(nolock) left join sysetinf on ibi_prdsizeunt = ysi_cde
			where	ysi_typ = '27' 
				and (ibi_prdsizetyp = ltrim(rtrim(upper(@szeTypfm))) and ibi_prdsizeval >= ltrim(rtrim(@szeValfm)) and ysi_dsc = ltrim(rtrim(upper(@szeUntfm))))
				and (ibi_prdsizetyp = ltrim(rtrim(upper(@szeTypto))) and ibi_prdsizeval <= ltrim(rtrim(@szeValto)) and ysi_dsc = rtrim(rtrim(upper(@szeUntto))))
		
		end
		else
		begin			
			set @szeTyp = ltrim(left(@PrdSzeStrPart, charindex(' ', @PrdSzeStrPart)-1))
			set @szeRemain = right(@PrdSzeStrPart, len(@PrdSzeStrPart) - charindex(' ', @PrdSzeStrPart))
			set @szeVal = ltrim(left(@szeRemain, charindex(' ', @szeRemain)-1))
			set @szeUnt = right(@szeRemain, len(@szeRemain) - charindex(' ', @szeRemain))

			insert into #TMP_SZE 	
			select ibi_itmno from imbasinf(nolock) left join sysetinf on ibi_prdsizeunt = ysi_cde
			where ysi_typ = '27' and ibi_prdsizetyp = ltrim(rtrim(upper(@szeTyp))) and ibi_prdsizeval =  ltrim(rtrim(@szeVal)) and ysi_dsc = ltrim(rtrim(upper(@szeUnt)))

			insert into #TMP_SZE 	
			select ibi_itmno from imbasinfh(nolock) left join sysetinf on ibi_prdsizeunt = ysi_cde
			where ysi_typ = '27' and ibi_prdsizetyp = ltrim(rtrim(upper(@szeTyp))) and ibi_prdsizeval =  ltrim(rtrim(@szeVal)) and ysi_dsc = ltrim(rtrim(upper(@szeUnt)))
		end
	end
 
	if charindex(',',@PrdSzeStrRemain) = 0 
	begin
		set @PrdSzeStrRemain = ltrim(@PrdSzeStrRemain)
		if charindex('~', 	@PrdSzeStrRemain) <> 0 
		begin
			set @fm = ltrim(left(@PrdSzeStrRemain, charindex('~', @PrdSzeStrRemain)-1))
			set @to = right(@PrdSzeStrRemain, len(@PrdSzeStrRemain) - charindex('~', @PrdSzeStrRemain))

			set @szeTypfm = ltrim(left(@fm, charindex(' ', @fm)-1))
			set @szeRemain = right(@fm, len(@fm) - charindex(' ', @fm))
			set @szeValfm = ltrim(left(@szeRemain, charindex(' ', @szeRemain)-1))
			set @szeUntfm = right(@szeRemain, len(@szeRemain) - charindex(' ', @szeRemain))

			set @szeTypto = ltrim(left(@to, charindex(' ', @to)-1))
			set @szeRemain = right(@to, len(@to) - charindex(' ', @to))
			set @szeValto = ltrim(left(@szeRemain, charindex(' ', @szeRemain)-1))
			set @szeUntto = right(@szeRemain, len(@szeRemain) - charindex(' ', @szeRemain))
								
			insert into #TMP_SZE 	
			select ibi_itmno from imbasinf(nolock) left join sysetinf on ibi_prdsizeunt = ysi_cde
			where 	ysi_typ = '27' 
				and (ibi_prdsizetyp = ltrim(rtrim(upper(@szeTypfm))) and ibi_prdsizeval >= ltrim(rtrim(@szeValfm)) and ysi_dsc = ltrim(rtrim(upper(@szeUntfm))))
				and (ibi_prdsizetyp = ltrim(rtrim(upper(@szeTypto))) and ibi_prdsizeval <= ltrim(rtrim(@szeValto)) and ysi_dsc = rtrim(rtrim(upper(@szeUntto))))

			insert into #TMP_SZE 	
			select ibi_itmno from imbasinfh(nolock) left join sysetinf on ibi_prdsizeunt = ysi_cde
			where 	ysi_typ = '27' 
				and (ibi_prdsizetyp = ltrim(rtrim(upper(@szeTypfm))) and ibi_prdsizeval >= ltrim(rtrim(@szeValfm)) and ysi_dsc = ltrim(rtrim(upper(@szeUntfm))))
				and (ibi_prdsizetyp = ltrim(rtrim(upper(@szeTypto))) and ibi_prdsizeval <= ltrim(rtrim(@szeValto)) and ysi_dsc = rtrim(rtrim(upper(@szeUntto))))
		end
/*
		else if charindex('%', @PrdSzeStrRemain) <> 0
		begin		

			insert into #TMP_SZE 	
			select ibi_engdsc from imbasinf where ibi_engdsc like @PrdSzeStrRemain		

			insert into #TMP_SZE 	
			select ibi_engdsc from imbasinfh where ibi_engdsc like @PrdSzeStrRemain	
					
		end
*/
		else
		begin	

			set @szeTyp = ltrim(left(@PrdSzeStrRemain, charindex(' ', @PrdSzeStrRemain)-1))
			set @szeRemain = right(@PrdSzeStrRemain, len(@PrdSzeStrRemain) - charindex(' ', @PrdSzeStrRemain))
			set @szeVal = ltrim(left(@szeRemain, charindex(' ', @szeRemain)-1))
			set @szeUnt = right(@szeRemain, len(@szeRemain) - charindex(' ', @szeRemain))

			insert into #TMP_SZE 	
			select ibi_itmno from imbasinf(nolock) left join sysetinf on ibi_prdsizeunt = ysi_cde
			where	ysi_typ = '27' 
				and ibi_prdsizetyp = ltrim(rtrim(upper(@szeTyp))) and ibi_prdsizeval= ltrim(rtrim(@szeVal)) and ysi_dsc = ltrim(rtrim(upper(@szeUnt)))

			insert into #TMP_SZE 	
			select ibi_itmno from imbasinfh(nolock) left join sysetinf on ibi_prdsizeunt = ysi_cde
			where	ysi_typ = '27' 
				and ibi_prdsizetyp = ltrim(rtrim(upper(@szeTyp))) and ibi_prdsizeval= ltrim(rtrim(@szeVal)) and ysi_dsc = ltrim(rtrim(upper(@szeUnt)))

/*		
			set @szeTypfm = ltrim(left(@fm, charindex(' ', @fm)-1))
			set @szeRemain = right(@fm, len(@fm) - charindex(' ', @fm))
			set @szeValfm = ltrim(left(@szeRemain, charindex(' ', @szeRemain)-1))
			set @szeUntfm = right(@szeRemain, len(@szeRemain) - charindex(' ', @szeRemain))

			set @szeTypto = ltrim(left(@to, charindex(' ', @to)-1))
			set @szeRemain = right(@to, len(@to) - charindex(' ', @to))
			set @szeValto = ltrim(left(@szeRemain, charindex(' ', @szeRemain)-1))
			set @szeUntto = right(@szeRemain, len(@szeRemain) - charindex(' ', @szeRemain))
								
			insert into #TMP_SZE 	
			select ibi_itmno from imbasinf(nolock) left join sysetinf on ibi_prdsizeunt = ysi_cde
			where 
				ysi_typ = '27' 
				and (ibi_prdsizetyp = ltrim(rtrim(@szeTypfm)) and ibi_prdsizeval >= ltrim(rtrim(@szeValfm)) and ysi_dsc = ltrim(rtrim(upper(@szeUntfm))))
				and (ibi_prdsizetyp = ltrim(rtrim(@szeTypto)) and ibi_prdsizeval <= ltrim(rtrim(@szeValto)) and ysi_dsc = rtrim(rtrim(upper(@szeUntto))))

			insert into #TMP_SZE 	
			select ibi_itmno from imbasinfh(nolock) left join sysetinf on ibi_prdsizeunt = ysi_cde
			where 
				ysi_typ = '27' 
				and (ibi_prdsizetyp = ltrim(rtrim(@szeTypfm)) and ibi_prdsizeval >= ltrim(rtrim(@szeValfm)) and ysi_dsc = ltrim(rtrim(upper(@szeUntfm))))
				and (ibi_prdsizetyp = ltrim(rtrim(@szeTypto)) and ibi_prdsizeval <= ltrim(rtrim(@szeValto)) and ysi_dsc = rtrim(rtrim(upper(@szeUntto))))	--insert into #TMP_SZE values (ltrim(@PrdSzeStrRemain))
*/
		end
	end
end


/*** End: Generate Product Size List ***/



/*** Start: Convert Product Group List to #TMP_PGP ***/

if ltrim(rtrim(@prdGrpList)) <> ''
begin
	set @PrdGrpStrRemain = @prdGrpList

	while charindex(',', @PrdGrpStrRemain) <> 0
	begin
		set @PrdGrpStrPart = ltrim(left(@PrdGrpStrRemain, charindex(',', @PrdGrpStrRemain)-1))
		set @PrdGrpStrRemain = right(@PrdGrpStrRemain, len(@PrdGrpStrRemain) - charindex(',', @PrdGrpStrRemain))

		if charindex('~', 	@PrdGrpStrPart) <> 0 
		begin
			set @fm = ltrim(left(@PrdGrpStrPart, charindex('~', @PrdGrpStrPart)-1))
			set @to = right(@PrdGrpStrPart, len(@PrdGrpStrPart) - charindex('~', @PrdGrpStrPart))
					
			insert into #TMP_PGP
			select ysi_cde from sysetinf where ysi_typ = '24' and ysi_cde between @fm and @to			
		end
		else if charindex('%', @PrdGrpStrPart) <> 0
		begin		
			insert into #TMP_PGP
			select ysi_cde from sysetinf where ysi_typ = '24' and ysi_dsc like @PrdGrpStrPart			
		end
		else
		begin			
			insert into #TMP_PGP values (@PrdGrpStrPart)
		end
	end


	if charindex(',',@PrdGrpStrRemain) = 0 
	begin
		set @PrdGrpStrRemain = ltrim(@PrdGrpStrRemain)
		if charindex('~', 	@PrdGrpStrRemain) <> 0 
		begin
			set @fm = ltrim(left(@PrdGrpStrRemain, charindex('~', @PrdGrpStrRemain)-1))
			set @to = right(@PrdGrpStrRemain, len(@PrdGrpStrRemain) - charindex('~', @PrdGrpStrRemain))
					
			insert into #TMP_PGP
			select ysi_cde from sysetinf where ysi_typ = '24' and ysi_cde between @fm and @to	

		end
		else if charindex('%', @PrdGrpStrRemain) <> 0
		begin		
			insert into #TMP_PGP	
			select ysi_cde from sysetinf where ysi_typ = '24' and ysi_dsc like @PrdGrpStrRemain			
		end
		else
		begin			
			insert into #TMP_PGP values (ltrim(@PrdGrpStrRemain))
		end
	end
end

/*** End: Convert Product Group List to #TMP_PGP ***/


/*** Start: Convert Product Icon List to #TMP_ICN ***/

if ltrim(rtrim(@prdIcnList)) <> ''
begin
	set @PrdIcnStrRemain = @prdIcnList

	while charindex(',', @PrdIcnStrRemain) <> 0
	begin
		set @PrdIcnStrPart = ltrim(left(@PrdIcnStrRemain, charindex(',', @PrdIcnStrRemain)-1))
		set @PrdIcnStrRemain = right(@PrdIcnStrRemain, len(@PrdIcnStrRemain) - charindex(',', @PrdIcnStrRemain))

		if charindex('~', 	@PrdIcnStrPart) <> 0 
		begin
			set @fm = ltrim(left(@PrdIcnStrPart, charindex('~', @PrdIcnStrPart)-1))
			set @to = right(@PrdIcnStrPart, len(@PrdIcnStrPart) - charindex('~', @PrdIcnStrPart))
					
			insert into #TMP_ICN
			select ysi_cde from sysetinf where ysi_typ = '28' and ysi_cde between @fm and @to			
		end
		else if charindex('%', @PrdIcnStrPart) <> 0
		begin		
			insert into #TMP_ICN
			select ysi_cde from sysetinf where ysi_typ = '28' and ysi_dsc like @PrdIcnStrPart			
		end
		else
		begin			
			insert into #TMP_ICN values (@PrdIcnStrPart)
		end
	end


	if charindex(',',@PrdIcnStrRemain) = 0 
	begin
		set @PrdIcnStrRemain = ltrim(@PrdIcnStrRemain)
		if charindex('~', 	@PrdIcnStrRemain) <> 0 
		begin
			set @fm = ltrim(left(@PrdIcnStrRemain, charindex('~', @PrdIcnStrRemain)-1))
			set @to = right(@PrdIcnStrRemain, len(@PrdIcnStrRemain) - charindex('~', @PrdIcnStrRemain))
					
			insert into #TMP_ICN
			select ysi_cde from sysetinf where ysi_typ = '28' and ysi_cde between @fm and @to	

		end
		else if charindex('%', @PrdIcnStrRemain) <> 0
		begin		
			insert into #TMP_ICN	
			select ysi_cde from sysetinf where ysi_typ = '28' and ysi_dsc like @PrdIcnStrRemain			
		end
		else
		begin			
			insert into #TMP_ICN values (ltrim(@PrdIcnStrRemain))
		end
	end
end

/*** End: Convert Product Icon List to #TMP_ICN ***/



/*** Start: Convert Product Material List to #TMP_MAT ***/

if ltrim(rtrim(@prdMatList)) <> ''
begin
	set @PrdMatStrRemain = @prdMatList

	while charindex(',', @PrdMatStrRemain) <> 0
	begin
		set @PrdMatStrPart = ltrim(left(@PrdMatStrRemain, charindex(',', @PrdMatStrRemain)-1))
		set @PrdMatStrRemain = right(@PrdMatStrRemain, len(@PrdMatStrRemain) - charindex(',', @PrdMatStrRemain))

		if charindex('~', 	@PrdMatStrPart) <> 0 
		begin
			set @fm = ltrim(left(@PrdMatStrPart, charindex('~', @PrdMatStrPart)-1))
			set @to = right(@PrdMatStrPart, len(@PrdMatStrPart) - charindex('~', @PrdMatStrPart))
					
			insert into #TMP_MAT
			select ysi_cde from sysetinf where ysi_typ = '25' and ysi_cde between @fm and @to			
		end
		else if charindex('%', @PrdMatStrPart) <> 0
		begin		
			insert into #TMP_MAT
			select ysi_cde from sysetinf where ysi_typ = '25' and ysi_dsc like @PrdMatStrPart			
		end
		else
		begin			
			insert into #TMP_MAT values (@PrdMatStrPart)
		end
	end


	if charindex(',',@PrdMatStrRemain) = 0 
	begin
		set @PrdMatStrRemain = ltrim(@PrdMatStrRemain)
		if charindex('~', 	@PrdMatStrRemain) <> 0 
		begin
			set @fm = ltrim(left(@PrdMatStrRemain, charindex('~', @PrdMatStrRemain)-1))
			set @to = right(@PrdMatStrRemain, len(@PrdMatStrRemain) - charindex('~', @PrdMatStrRemain))
					
			insert into #TMP_MAT
			select ysi_cde from sysetinf where ysi_typ = '25' and ysi_cde between @fm and @to	

		end
		else if charindex('%', @PrdMatStrRemain) <> 0
		begin		
			insert into #TMP_MAT	
			select ysi_cde from sysetinf where ysi_typ = '25' and ysi_dsc like @PrdMatStrRemain			
		end
		else
		begin			
			insert into #TMP_MAT values (ltrim(@PrdMatStrRemain))
		end
	end
end

/*** END: Convert Product Material List to #TMP_MAT ***/



CREATE TABLE #TMP_RESULT(
	tmp_venno	nvarchar(20),
	tmp_vensna	nvarchar(20),
	tmp_itmno	nvarchar(20),
	tmp_itmdsc	nvarchar(800),
	tmp_imgpth	nvarchar(200),
	tmp_prdlne	nvarchar(20),
	tmp_itmnat	nvarchar(20),
	tmp_prdgrp	nvarchar(20),
	tmp_prdicn	nvarchar(20),
	tmp_prdmat	nvarchar(20),
)


CREATE TABLE #RESULT(
	res_reccnt	int identity(1,1) ,
	res_venno	nvarchar(20),
	res_vensna	nvarchar(20),
	res_itmno	nvarchar(20),
	res_itmdsc	nvarchar(800),
	res_imgpth	nvarchar(200),
	res_ttlcnt_vdr	int,
	res_qutcnt_vdr	int
)

declare @optVdr char(1), @optItmno char(1), @optPrdlne char(1)


if @vdrFm = ''
	set @optVdr = 'N'
else
	set @optVdr = 'Y'


if @itmnoFm = ''
	set @optItmno = 'N'
else
	set @optItmno = 'Y'

if @prdlneFm = ''
	set @optPrdlne = 'N'
else
	set @optPrdlne = 'Y'

set @tblname_and = ''
set @wclause_and = ''

if (select count(*) from #TMP_LNE) > 0 and @prdlneOpr = 'AND'
begin
	set @tblname_and = @tblname_and + ', #TMP_LNE '
	set @wclause_and = @wclause_and + ' and ibi_lnecde = tmp_PRDLNE '
end

if (select count(*) from #TMP_ITM) > 0 and @itmnoOpr = 'AND'
begin
	set @tblname_and = @tblname_and + ', #TMP_ITM '
	set @wclause_and = @wclause_and + ' and ibi_itmno = tmp_ITMNO '
end

if (select count(*) from #TMP_IDS) > 0 and @itmdscOpr = 'AND'
begin
	set @tblname_and = @tblname_and + ', #TMP_IDS '
	set @wclause_and = @wclause_and + ' and ibi_engdsc = tmp_ITMDSC '
end

if (select count(*) from #TMP_CDS) > 0 and @coldscOpr = 'AND'
begin
	set @tblname_and = @tblname_and + ', #TMP_CDS '
	set @wclause_and = @wclause_and + ' and ibi_itmno = tmp_COLDSC '
end

if (select count(*) from #TMP_VEN) > 0 and @vdrOpr = 'AND'
begin
	set @tblname_and = @tblname_and + ', #TMP_VEN '
	set @wclause_and = @wclause_and + ' and vbi_venno = tmp_VENCDE '
end

if (select count(*) from #TMP_NAT) > 0 and @itmnatOpr = 'AND'
begin
	set @tblname_and = @tblname_and + ', #TMP_NAT '
	set @wclause_and = @wclause_and + ' and ibi_itmnat = tmp_ITMNAT '
end

if (select count(*) from #TMP_SZE) > 0 and @prdSzeOpr = 'AND'
begin
	set @tblname_and = @tblname_and + ', #TMP_SZE '
	set @wclause_and = @wclause_and + ' and ibi_itmno = tmp_PRDSZE '
end

if (select count(*) from #TMP_PGP) > 0 and @prdGrpOpr = 'AND'
begin
	set @tblname_and = @tblname_and + ', #TMP_PGP '
	set @wclause_and = @wclause_and + ' and ibi_prdgrp = tmp_PRDGRP '
end

if (select count(*) from #TMP_ICN) > 0 and @prdIcnOpr = 'AND'
begin
	set @tblname_and = @tblname_and + ', #TMP_ICN '
	set @wclause_and = @wclause_and + ' and ibi_prdicon = tmp_PRDICN '
end

if (select count(*) from #TMP_MAT) > 0 and @prdMatOpr = 'AND'
begin
	set @tblname_and = @tblname_and + ', #TMP_MAT '
	set @wclause_and = @wclause_and + ' and ibi_material = tmp_PRDMAT '
end


if ltrim(rtrim(@tblname_and)) <> ''
begin
	if @resol = 'L' 
	begin
		SELECT @sql = 	' INSERT into #TMP_RESULT ' +
				' SELECT ' + 
					' vbi_venno, vbi_vensna, ibi_itmno, ibi_engdsc, ibi_imgpth, ibi_lnecde, ibi_itmnat, ibi_prdgrp, ibi_prdicon, ibi_material ' +
				' FROM ' + 
					' IMBASINF (nolock) left join IMVENINF (nolock) on ibi_itmno = ivi_itmno and ivi_def = ''Y''' +
					' left join VNBASINF (nolock) on vbi_venno = ivi_venno,#TMP_VENTYP, #TMP_ITMTYP, #TMP_PRDTYP ' + @tblname_and +
			           ' WHERE ' + 
					' vbi_ventyp = tmp_VENTYP and ibi_typ = tmp_ITMTYP and ibi_prdtyp = tmp_PRDTYP ' + @wclause_and
		EXEC sp_executesql @sql
	
		SELECT @sql = 	' INSERT into #TMP_RESULT ' +
				' SELECT ' + 
					' vbi_venno, vbi_vensna, ibi_itmno, ibi_engdsc, ibi_imgpth, ibi_lnecde, ibi_itmnat, ibi_prdgrp, ibi_prdicon, ibi_material ' +
				' FROM ' + 
					' IMBASINFH (nolock) left join IMVENINFH (nolock) on ibi_itmno = ivi_itmno and ivi_def = ''Y''' +
					' left join VNBASINF (nolock) on vbi_venno = ivi_venno,#TMP_VENTYP, #TMP_ITMTYP, #TMP_PRDTYP ' + @tblname_and +
			           ' WHERE ' + 
					' vbi_ventyp = tmp_VENTYP and ibi_typ = tmp_ITMTYP and ibi_prdtyp = tmp_PRDTYP ' + @wclause_and
		EXEC sp_executesql @sql
	end
	else -- High Resolution at below code
	begin
		SELECT @sql = 	' INSERT into #TMP_RESULT ' +
				' SELECT ' + 
					' vbi_venno, vbi_vensna, ibi_itmno, ibi_engdsc, ibi_imgpthhr, ibi_lnecde, ibi_itmnat, ibi_prdgrp, ibi_prdicon, ibi_material ' +
				' FROM ' + 
					' IMBASINF (nolock) left join IMVENINF (nolock) on ibi_itmno = ivi_itmno and ivi_def = ''Y''' +
					' left join VNBASINF (nolock) on vbi_venno = ivi_venno,#TMP_VENTYP, #TMP_ITMTYP, #TMP_PRDTYP ' + @tblname_and +
			           ' WHERE ' + 
					' vbi_ventyp = tmp_VENTYP and ibi_typ = tmp_ITMTYP and ibi_prdtyp = tmp_PRDTYP ' + @wclause_and
		EXEC sp_executesql @sql
	
		SELECT @sql = 	' INSERT into #TMP_RESULT ' +
				' SELECT ' + 
					' vbi_venno, vbi_vensna, ibi_itmno, ibi_engdsc, ibi_imgpthhr, ibi_lnecde, ibi_itmnat, ibi_prdgrp, ibi_prdicon, ibi_material ' +
				' FROM ' + 
					' IMBASINFH (nolock) left join IMVENINFH (nolock) on ibi_itmno = ivi_itmno and ivi_def = ''Y''' +
					' left join VNBASINF (nolock) on vbi_venno = ivi_venno,#TMP_VENTYP, #TMP_ITMTYP, #TMP_PRDTYP ' + @tblname_and +
			           ' WHERE ' + 
					' vbi_ventyp = tmp_VENTYP and ibi_typ = tmp_ITMTYP and ibi_prdtyp = tmp_PRDTYP ' + @wclause_and
		EXEC sp_executesql @sql		
	end

--	select count(*) from #TMP_RESULT
--	print 'AND ' + convert(nvarchar(100),@tblname_and + ' ' + @wclause_and)
--	print convert(nvarchar(1000), @sql)

end

set @tblname_or = ''
set @wclause_or = ''

if (select count(*) from #TMP_LNE) > 0 and @prdlneOpr = 'OR'
begin
	set @tblname_or = @tblname_or + ', #TMP_LNE '
	if ltrim(rtrim(@wclause_or)) = ''
		set @wclause_or = @wclause_or + ' ibi_lnecde = tmp_PRDLNE '
	else
		set @wclause_or = @wclause_or + ' or ibi_lnecde = tmp_PRDLNE '	
end

if (select count(*) from #TMP_ITM) > 0 and @itmnoOpr = 'OR'
begin
	set @tblname_or = @tblname_or + ', #TMP_ITM '
	if ltrim(rtrim(@wclause_or)) = ''
		set @wclause_or = @wclause_or + ' ibi_itmno = tmp_ITMNO '
	else
		set @wclause_or = @wclause_or + ' or ibi_itmno = tmp_ITMNO '	
end

if (select count(*) from #TMP_IDS) > 0 and @itmdscOpr = 'OR'
begin
	set @tblname_or = @tblname_or + ', #TMP_IDS '
	if ltrim(rtrim(@wclause_or)) = ''
		set @wclause_or = @wclause_or + ' ibi_engdsc = tmp_ITMDSC '
	else
		set @wclause_or = @wclause_or + ' or ibi_engdsc = tmp_ITMDSC '	
end

if (select count(*) from #TMP_CDS) > 0 and @coldscOpr = 'OR'
begin
	set @tblname_or = @tblname_or + ', #TMP_CDS '
	if ltrim(rtrim(@wclause_or)) = ''
		set @wclause_or = @wclause_or + ' ibi_itmno = tmp_COLDSC '
	else
		set @wclause_or = @wclause_or + ' or ibi_itmno = tmp_COLDSC '	
end


if (select count(*) from #TMP_VEN) > 0 and @vdrOpr = 'OR'
begin
	set @tblname_or = @tblname_or + ', #TMP_VEN '
	if ltrim(rtrim(@wclause_or)) = ''
		set @wclause_or = @wclause_or + ' vbi_venno = tmp_VENCDE '
	else
		set @wclause_or = @wclause_or + ' or vbi_venno = tmp_VENCDE '
end

if (select count(*) from #TMP_NAT) > 0 and @itmnatOpr = 'OR'
begin
	set @tblname_or = @tblname_or + ', #TMP_NAT '
	if ltrim(rtrim(@wclause_or)) = ''
		set @wclause_or = @wclause_or + ' ibi_itmnat = tmp_ITMNAT '
	else
		set @wclause_or = @wclause_or + ' or ibi_itmnat = tmp_ITMNAT '
end

if (select count(*) from #TMP_SZE) > 0 and @prdSzeOpr = 'OR'
begin
	set @tblname_or = @tblname_or + ', #TMP_SZE '
	if ltrim(rtrim(@wclause_or)) = ''
		set @wclause_or = @wclause_or + ' ibi_itmno = tmp_PRDSZE '
	else
		set @wclause_or = @wclause_or + ' or ibi_itmno = tmp_PRDSZE '
end

if (select count(*) from #TMP_PGP) > 0 and @prdGrpOpr = 'OR'
begin
	set @tblname_or = @tblname_or + ', #TMP_PGP '
	if ltrim(rtrim(@wclause_or)) = ''
		set @wclause_or = @wclause_or + ' ibi_prdgrp = tmp_PRDGRP '
	else
		set @wclause_or = @wclause_or + ' or ibi_prdgrp = tmp_PRDGRP '
end

if (select count(*) from #TMP_ICN) > 0 and @prdIcnOpr = 'OR'
begin
	set @tblname_or = @tblname_or + ', #TMP_ICN '
	if ltrim(rtrim(@wclause_or)) = ''
		set @wclause_or = @wclause_or + ' ibi_prdicon = tmp_PRDICN '
	else
		set @wclause_or = @wclause_or + ' or ibi_prdicon = tmp_PRDICN '
end


if (select count(*) from #TMP_MAT) > 0 and @prdMatOpr = 'OR'
begin
	set @tblname_or = @tblname_or + ', #TMP_MAT '
	if ltrim(rtrim(@wclause_or)) = ''
		set @wclause_or = @wclause_or + ' ibi_material = tmp_PRDMAT '
	else
		set @wclause_or = @wclause_or + ' or ibi_material = tmp_PRDMAT '
end

if ltrim(rtrim(@tblname_or)) <> ''
begin
	if @resol = 'L' 
	begin
		SELECT @sql = 	' INSERT into #TMP_RESULT ' +
				' SELECT ' + 
					' vbi_venno, vbi_vensna, ibi_itmno, ibi_engdsc, ibi_imgpth, ibi_lnecde, ibi_itmnat, ibi_prdgrp, ibi_prdicon, ibi_material ' +
				' FROM ' + 
					' IMBASINF (nolock) left join IMVENINF (nolock) on ibi_itmno = ivi_itmno and ivi_def = ''Y''' +
					' left join VNBASINF (nolock) on vbi_venno = ivi_venno,#TMP_VENTYP, #TMP_ITMTYP, #TMP_PRDTYP ' + @tblname_or +
			           ' WHERE ' + 
					' (vbi_ventyp = tmp_VENTYP and ibi_typ = tmp_ITMTYP and ibi_prdtyp = tmp_PRDTYP) and ( ' + @wclause_or + ' ) '
		EXEC sp_executesql @sql
	
		SELECT @sql = 	' INSERT into #TMP_RESULT ' +
				' SELECT ' + 
					' vbi_venno, vbi_vensna, ibi_itmno, ibi_engdsc, ibi_imgpth, ibi_lnecde, ibi_itmnat, ibi_prdgrp, ibi_prdicon, ibi_material ' +
				' FROM ' + 
					' IMBASINFH (nolock) left join IMVENINFH (nolock) on ibi_itmno = ivi_itmno and ivi_def = ''Y''' +
					' left join VNBASINF (nolock) on vbi_venno = ivi_venno,#TMP_VENTYP, #TMP_ITMTYP, #TMP_PRDTYP ' + @tblname_or +
			           ' WHERE ' + 
					' (vbi_ventyp = tmp_VENTYP and ibi_typ = tmp_ITMTYP and ibi_prdtyp = tmp_PRDTYP) and ( ' + @wclause_or + ' ) '
		EXEC sp_executesql @sql
	end
	else -- High Resolution
	begin
		SELECT @sql = 	' INSERT into #TMP_RESULT ' +
				' SELECT ' + 
					' vbi_venno, vbi_vensna, ibi_itmno, ibi_engdsc, ibi_imgpthhr, ibi_lnecde, ibi_itmnat, ibi_prdgrp, ibi_prdicon, ibi_material ' +
				' FROM ' + 
					' IMBASINF (nolock) left join IMVENINF (nolock) on ibi_itmno = ivi_itmno and ivi_def = ''Y''' +
					' left join VNBASINF (nolock) on vbi_venno = ivi_venno,#TMP_VENTYP, #TMP_ITMTYP, #TMP_PRDTYP ' + @tblname_or +
			           ' WHERE ' + 
					' (vbi_ventyp = tmp_VENTYP and ibi_typ = tmp_ITMTYP and ibi_prdtyp = tmp_PRDTYP) and ( ' + @wclause_or + ' ) '
		EXEC sp_executesql @sql
	
		SELECT @sql = 	' INSERT into #TMP_RESULT ' +
				' SELECT ' + 
					' vbi_venno, vbi_vensna, ibi_itmno, ibi_engdsc, ibi_imgpthhr, ibi_lnecde, ibi_itmnat, ibi_prdgrp, ibi_prdicon, ibi_material ' +
				' FROM ' + 
					' IMBASINFH (nolock) left join IMVENINFH (nolock) on ibi_itmno = ivi_itmno and ivi_def = ''Y''' +
					' left join VNBASINF (nolock) on vbi_venno = ivi_venno,#TMP_VENTYP, #TMP_ITMTYP, #TMP_PRDTYP ' + @tblname_or +
			           ' WHERE ' + 
					' (vbi_ventyp = tmp_VENTYP and ibi_typ = tmp_ITMTYP and ibi_prdtyp = tmp_PRDTYP) and ( ' + @wclause_or + ' ) '
		EXEC sp_executesql @sql		
	end

--	select count(*) from #TMP_RESULT
--	print 'OR ' +  convert(nvarchar(100),@tblname_or + ' ' + @wclause_or)
--	print convert(nvarchar(1000), @sql)

end



--Select distinct * from #TMP_RESULT

--select distinct * from #TMP_LNE

--Select distinct * from #TMP_CDS


--select distinct tmp_itmno, icf_coldsc from #tmp_result, imcolinf where tmp_itmno = icf_itmno order by tmp_itmno



	insert into #RESULT
	(	res_venno,
		res_vensna,
		res_itmno,
		res_itmdsc,
		res_imgpth,
		res_ttlcnt_vdr,
		res_qutcnt_vdr
	)
	select distinct
		tmp_venno,
		tmp_vensna,
		tmp_itmno,
		tmp_itmdsc,
		tmp_imgpth, 
		0,
		0
	from 
		#TMP_RESULT
	order by 
		tmp_itmno


if @@LANGUAGE <> 'us_english' 
	set LANGUAGE 'us_english'


select 
isnull(a.res_reccnt, 0) 'res_reccnt1',
isnull(a.res_venno, '') 'res_venno1',
isnull(a.res_vensna, '') 'res_vensna1',
isnull(a.res_itmno, '') 'res_itmno1',
isnull(a.res_itmdsc, '') 'res_itmdsc1',
isnull(a.res_imgpth, '') 'res_imgpth1',
isnull(a.res_ttlcnt_vdr, 0) 'res_ttlcnt_vdr1',
isnull(a.res_qutcnt_vdr, 0) 'res_qutcnt_vdr1',

isnull(b.res_reccnt, 0) 'res_reccnt2',
isnull(b.res_venno, '') 'res_venno2',
isnull(b.res_vensna, '') 'res_vensna2',
isnull(b.res_itmno, '') 'res_itmno2',
isnull(b.res_itmdsc, '') 'res_itmdsc2',
isnull(b.res_imgpth, '') 'res_imgpth2',
isnull(b.res_ttlcnt_vdr, 0) 'res_ttlcnt_vdr2',
isnull(b.res_qutcnt_vdr, 0) 'res_qutcnt_vdr2',

isnull(c.res_reccnt, 0) 'res_reccnt3',
isnull(c.res_venno, '') 'res_venno3',
isnull(c.res_vensna, '') 'res_vensna3',
isnull(c.res_itmno, '') 'res_itmno3',
isnull(c.res_itmdsc, '') 'res_itmdsc3',
isnull(c.res_imgpth, '') 'res_imgpth3',
isnull(c.res_ttlcnt_vdr, 0) 'res_ttlcnt_vdr3',
isnull(c.res_qutcnt_vdr, 0) 'res_qutcnt_vdr3'

from #RESULT a
left join #RESULT b on 
a.res_reccnt = b.res_reccnt - 1
left join #RESULT c on 
b.res_reccnt = c.res_reccnt - 1
where  a.res_reccnt % 3 = 1
order by a.res_reccnt












GO
GRANT EXECUTE ON [dbo].[sp_list_IMR00027] TO [ERPUSER] AS [dbo]
GO
