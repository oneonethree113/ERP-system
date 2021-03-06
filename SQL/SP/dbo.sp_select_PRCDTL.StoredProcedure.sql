/****** Object:  StoredProcedure [dbo].[sp_select_PRCDTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PRCDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PRCDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/*=========================================================
Program ID	: 	sp_select_PRCDTL
Description   	: 	Calculate factory prices from inputed factory costs
Programmer  	: 	Frankie Cheung
Create Date   	: 	9 Oct 2008
Last Modified  	: 
Table Read(s) 	:	
Table Write(s) 	:	
Parameter		
=========================================================
 Modification History                                    
=========================================================
=========================================================     
*/

CREATE PROCEDURE [dbo].[sp_select_PRCDTL] 

@fcA		numeric(13,4) ,
@fcB		numeric(13,4) ,
@fcC		numeric(13,4) ,
@fcD		numeric(13,4) ,
@fcTran	numeric(13,4) ,
@fcPck		numeric(13,4) ,
@fcTtl		numeric(13,4) ,

@cus1no	nvarchar(10),
@cus2no	nvarchar(10),
@catlvl4	nvarchar(20),

@icA	 	numeric(13,4) output ,  
@icB	 	numeric(13,4) output ,  
@icC	 	numeric(13,4) output ,
@icD		numeric(13,4) output ,
@icTran		numeric(13,4) output ,
@icPck	 	numeric(13,4) output ,  
@icTtl	 	numeric(13,4) output ,

@ftymuA 	nvarchar(20) output,   
@ftymuB 	nvarchar(20) output,  
@ftymuC 	nvarchar(20) output,   
@ftymuD 	nvarchar(20) output,   
@ftymuTran 	nvarchar(20) output,  
@ftymuPck 	nvarchar(20) output,

@hkmuA 	nvarchar(20) output,
@hkmuB 	nvarchar(20) output, 
@hkmuC 	nvarchar(20) output,  
@hkmuD 	nvarchar(20) output,  
@hkmuTran 	nvarchar(20) output,  
@hkmuPck 	nvarchar(20) output,

@ccA	 	numeric(13,4) output ,  
@ccB	 	numeric(13,4) output ,  
@ccC	 	numeric(13,4) output ,
@ccD		numeric(13,4) output ,
@ccTran	numeric(13,4) output ,
@ccPck	 	numeric(13,4) output ,  
@calftyprc	numeric(13,4) output


as


declare

@dfm1A 	nvarchar(4),
@dfm1B		nvarchar(4),
@dfm1C		nvarchar(4),
@dfm1D		nvarchar(4),
@dfm1tran	nvarchar(4),
@dfm1pck	nvarchar(4),

@dfm2A 	nvarchar(4),
@dfm2B 	nvarchar(4),
@dfm2C		nvarchar(4),
@dfm2D		nvarchar(4),
@dfm2tran	nvarchar(4),
@dfm2pck 	nvarchar(4),

@dfm1Aval	nvarchar(20),
@dfm1Bval 	nvarchar(20),
@dfm1Cval 	nvarchar(20),
@dfm1Dval	nvarchar(20),
@dfm1tranval	nvarchar(20),
@dfm1pckval	nvarchar(20),

@dfm2Aval	nvarchar(20), 
@dfm2Bval 	nvarchar(20), 
@dfm2Cval	nvarchar(20), 
@dfm2Dval 	nvarchar(20),
@dfm2tranval 	nvarchar(20),
@dfm2pckval	nvarchar(20),

@debug	int




/* End of formula section */


begin

exec sp_calc_mrkup @cus1no, @cus2no, @catlvl4, 'A', @fcA, @ftymuA output, @hkmuA output, @dfm1Aval output, @dfm2Aval output, @ccA output, @icA output

exec sp_calc_mrkup @cus1no, @cus2no, @catlvl4, 'B', @fcB, @ftymuB output, @hkmuB output, @dfm1Bval output, @dfm2Bval output, @ccB output, @icB output

exec sp_calc_mrkup @cus1no, @cus2no, @catlvl4, 'C', @fcC, @ftymuC output, @hkmuC output, @dfm1Cval output, @dfm2Cval output, @ccC output, @icC output

exec sp_calc_mrkup @cus1no, @cus2no, @catlvl4, 'D', @fcD, @ftymuD output, @hkmuD output, @dfm1Dval output, @dfm2Dval output, @ccD output, @icD output

exec sp_calc_mrkup @cus1no, @cus2no, @catlvl4, 'TRAN', @fcTran, @ftymuTran output, @hkmuTran output, @dfm1tranval output, @dfm2tranval output, @ccTran output, @icTran output

exec sp_calc_mrkup @cus1no, @cus2no, @catlvl4, 'PACK', @fcPck, @ftymuPck output, @hkmuPck output, @dfm1pckval output, @dfm2pckval output, @ccPck output, @icPck output

set @icTtl = @icA + @icB + @icC + @icD + @icTran + @icPck

set @calftyprc = @ccA + @ccB + @ccC + @ccD + @ccPck

/*
begin
	print '@icA=' +  CONVERT(VARCHAR(20), @fcA ) 
	print '@ftymuA=' +  CONVERT(VARCHAR(20), @ftymuA ) 
	print '@hkmuA=' +  CONVERT(VARCHAR(20), @hkmuA ) 
	print '@dfm1Aval=' +  CONVERT(VARCHAR(20), @dfm1Aval ) 
	print '@dfm2Aval=' +  CONVERT(VARCHAR(20), @dfm2Aval ) 
	print '@ccA=' +  CONVERT(VARCHAR(20), @ccA ) 
	print '@icA=' +  CONVERT(VARCHAR(20), @icA ) 
	print'--------------------------------------'
	print '@icB=' +  CONVERT(VARCHAR(20), @fcB ) 
	print '@ftymuB=' +  CONVERT(VARCHAR(20), @ftymuB ) 
	print '@hkmuB=' +  CONVERT(VARCHAR(20), @hkmuB ) 
	print '@dfm1Bval=' +  CONVERT(VARCHAR(20), @dfm1Bval ) 
	print '@dfm2Bval=' +  CONVERT(VARCHAR(20), @dfm2Bval ) 
	print '@ccB=' +  CONVERT(VARCHAR(20), @ccB ) 
	print '@icB=' +  CONVERT(VARCHAR(20), @icB ) 
	print'--------------------------------------'
	print '@icC=' +  CONVERT(VARCHAR(20), @fcC ) 
	print '@ftymuC=' +  CONVERT(VARCHAR(20), @ftymuC ) 
	print '@hkmuC=' +  CONVERT(VARCHAR(20), @hkmuC ) 
	print '@dfm1Cval=' +  CONVERT(VARCHAR(20), @dfm1Cval ) 
	print '@dfm2Cval=' +  CONVERT(VARCHAR(20), @dfm2Cval ) 
	print '@ccC=' +  CONVERT(VARCHAR(20), @ccC ) 
	print '@icC=' +  CONVERT(VARCHAR(20), @icC ) 
	print'--------------------------------------'
	print '@icD=' +  CONVERT(VARCHAR(20), @fcD ) 
	print '@ftymuD=' +  CONVERT(VARCHAR(20), @ftymuD ) 
	print '@hkmuD=' +  CONVERT(VARCHAR(20), @hkmuD ) 
	print '@dfm1Dval=' +  CONVERT(VARCHAR(20), @dfm1Dval ) 
	print '@dfm2Dval=' +  CONVERT(VARCHAR(20), @dfm2Dval ) 
	print '@ccD=' +  CONVERT(VARCHAR(20), @ccD ) 
	print '@icD=' +  CONVERT(VARCHAR(20), @icD ) 
	print'--------------------------------------'
	print '@icTran=' +  CONVERT(VARCHAR(20), @fcTran ) 
	print '@ftymuT=' +  CONVERT(VARCHAR(20), @ftymuTran ) 
	print '@hkmuT=' +  CONVERT(VARCHAR(20), @hkmuTran ) 
	print '@dfm1tranval=' +  CONVERT(VARCHAR(20), @dfm1tranval ) 
	print '@dfm2tranval=' +  CONVERT(VARCHAR(20), @dfm2tranval ) 
	print '@ccTran=' +  CONVERT(VARCHAR(20), @ccTran ) 
	print '@icTran=' +  CONVERT(VARCHAR(20), @icTran ) 
	print'--------------------------------------'
	print '@icPck=' +  CONVERT(VARCHAR(20), @fcPck ) 
	print '@ftymuP=' +  CONVERT(VARCHAR(20), @ftymuPck ) 
	print '@hkmuP=' +  CONVERT(VARCHAR(20), @hkmuPck ) 
	print '@dfm1pckval=' +  CONVERT(VARCHAR(20), @dfm1pckval ) 
	print '@dfm2pckval=' +  CONVERT(VARCHAR(20), @dfm2pckval ) 
	print '@ccPck=' +  CONVERT(VARCHAR(20), @ccPck ) 
	print '@icPck=' +  CONVERT(VARCHAR(20), @icPck ) 
	print'--------------------------------------'
	print '@icTtl=' +  CONVERT(VARCHAR(20), @icTtl ) 
	print '@calftyprc=' +  CONVERT(VARCHAR(20), @calftyprc ) 
end
*/




/*
set @icA = @fcA *@dfm1Aval * @dfm2Aval
set @icB = @fcB * @dfm1Bval * @dfm2Bval
set @icC = @fcC * @dfm1Cval * @dfm2Cval
set @icTran = @fctran * @dfm1tranval * @dfm2tranval
set @icPck = @fcpck * @dfm1pckval * @dfm2pckval
set @icTtl = @icA + @icB + @icC + @icTran + @icPck
*/

end






GO
GRANT EXECUTE ON [dbo].[sp_select_PRCDTL] TO [ERPUSER] AS [dbo]
GO
