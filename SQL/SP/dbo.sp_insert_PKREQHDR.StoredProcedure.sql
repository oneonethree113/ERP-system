/****** Object:  StoredProcedure [dbo].[sp_insert_PKREQHDR]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_PKREQHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_PKREQHDR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








CREATE  procedure [dbo].[sp_insert_PKREQHDR]
                                                                                                                                                                                                                                                                 
@cocde nvarchar(6),
@reqno nvarchar(20),
@ver int,
@issdat datetime,
@revdat  datetime,
@status nvarchar(20),
@cus1no nvarchar(20),
@cus2no nvarchar(20),
@saldiv nvarchar(20),
@saltem nvarchar(20),
@salrep nvarchar(30),
@ToNo nvarchar(20),
@ToVer nvarchar(20),
@ToSts nvarchar(20),
@ToIsdat datetime,
@ToRevdat datetime,
@ToRefqut nvarchar(20),
@potyp nvarchar(20),
@ScNo nvarchar(20),
@ScVer nvarchar(20),
@ScSts nvarchar(20),
@ScIsdat datetime,
@ScRevdat datetime,
@ScPodat datetime,
@ScCandat datetime,
@ScShpdatstr datetime,
@ScShpdatend  datetime,
@ScRemark nvarchar(300),
@Flag nvarchar(20),
@user nvarchar(30)


---------------------------------------------- 

 
AS
 

begin

	 
insert into PKREQHDR

values 
(@cocde , 
@reqno  ,
@ver  ,
@issdat,  
@revdat , 
@status , 
@cus1no ,
@cus2no ,
@saldiv ,
@saltem ,
@salrep ,
@ToNo ,
@ToVer ,
@ToSts ,
@ToIsdat ,
@ToRevdat ,
@ToRefqut ,
@potyp ,
@ScNo ,
@ScVer ,
@ScSts ,
@ScIsdat ,
@ScRevdat ,
@ScPodat ,
@ScCandat ,
@ScShpdatstr ,
@ScShpdatend ,
@ScRemark ,
@Flag , -- 02 Flag for insert by pgm0002 orther wise insert by pgm00009 + cate
@user,
@user,
getdate(),
getdate(),
null
 )

end














GO
GRANT EXECUTE ON [dbo].[sp_insert_PKREQHDR] TO [ERPUSER] AS [dbo]
GO
