/****** Object:  StoredProcedure [dbo].[sp_insert_PKREQDTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_PKREQDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_PKREQDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
















CREATE  procedure [dbo].[sp_insert_PKREQDTL]
                                                                                                                                                                                                                                                                 
@cocde nvarchar(6),
@reqno nvarchar(20),
@seq int,
@itemno nvarchar(20),
@assitm nvarchar(20),
@tmpitmno nvarchar(20),
@venno nvarchar(6),
@venitm nvarchar(20),
@pckunt nvarchar(10),
@inrqty int,
@mtrqty int,
@cft numeric(13,4),
@colcde nvarchar(20),
@conftr int,
@ftyprctrm nvarchar(10),
@hkprctrm nvarchar(10),
@trantrm nvarchar(10),
@pkgitm nvarchar(20),
@pkgven nvarchar(10),
@cate nvarchar(20),
@chndsc nvarchar(300),
@engdsc nvarchar(300),
@remark nvarchar(500),
@EInchL numeric(13,4),
@EInchW numeric(13,4),
@EInchH numeric(13,4),
@EcmL numeric(13,4),
@EcmW numeric(13,4),
@EcmH numeric(13,4),
@FinchL numeric(13,4),
@FinchW numeric(13,4),
@FinchH numeric(13,4),
@FcmL numeric(13,4),
@FcmW numeric(13,4),
@FcmH numeric(13,4),
@matral nvarchar(100),
@tiknes nvarchar(100),
@prtmtd nvarchar(100),
@clrfot nvarchar(100),
@clrbck nvarchar(100),
@finish nvarchar(500),
@matDsc nvarchar(300),
@tikDsc nvarchar(300),
@prtDsc nvarchar(300),
@rmtnce nvarchar(100),
@addres nvarchar(300),
@state nvarchar(50),
@cntry nvarchar(50),
@zip nvarchar(50),
@Tel nvarchar(20),
@cntper nvarchar(30),
@sctoqty int,
@qtyum nvarchar(10),
@curcde nvarchar(10),
@multip int,
@ordqty int,
@wasper numeric(13,4),
@wasqty int,
@ttlordqty int,
@untprc numeric(11,6),
@ttlamtqty numeric(13,4),
@receqty int,
@flag nvarchar(20),
@quoteprice numeric(13,4),
@ScToNo nvarchar(20),
@ScToSeq int ,
@sku nvarchar(20),
@cusitm nvarchar(20),
@bonqty int,
@user nvarchar(30)

---------------------------------------------- 

 
AS
 

begin

	 
insert into PKREQDTL

values 
(
@cocde ,
@reqno ,
@seq ,
@itemno ,
@assitm,
@tmpitmno ,
@venno ,
@venitm ,
@pckunt ,
@inrqty ,
@mtrqty ,
@cft,
@colcde,
@sku,
@cusitm,
@conftr,
@ftyprctrm ,
@hkprctrm ,
@trantrm ,
@pkgitm ,
@pkgven ,
@cate ,
@chndsc ,
@engdsc ,
@remark ,
@EInchL ,
@EInchW ,
@EInchH ,
@EcmL ,
@EcmW ,
@EcmH ,
@FinchL ,
@FinchW ,
@FinchH ,
@FcmL ,
@FcmW ,
@FcmH ,
@matral ,
@tiknes ,
@prtmtd ,
@clrfot ,
@clrbck ,
@finish ,
@matDsc ,
@tikDsc ,
@prtDsc  ,
@rmtnce ,
@addres ,
@state ,
@cntry ,
@zip ,
@Tel ,
@cntper ,
@sctoqty ,
@qtyum ,
@curcde ,
@multip ,
@ordqty ,
@wasper ,
@wasqty ,
@bonqty,
@ttlordqty ,
@untprc ,
@ttlamtqty ,
@receqty ,
'', --This is for Ordno  (null for insert)
0,--This is for Ord Seq   (0 for insert)
@flag, --02 Flag for Add  by PGM00002 
@quoteprice,
@ScToNo,
@ScToSeq,
@user ,
@user,
getdate(),
getdate(),
null)


end




 

















GO
GRANT EXECUTE ON [dbo].[sp_insert_PKREQDTL] TO [ERPUSER] AS [dbo]
GO
