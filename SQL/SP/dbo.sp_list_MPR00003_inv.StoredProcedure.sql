/****** Object:  StoredProcedure [dbo].[sp_list_MPR00003_inv]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_MPR00003_inv]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_MPR00003_inv]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







/*  
=========================================================  
Program ID : sp_list_MPR00003_inv  
Description    : 6/F Costing Depart -- INVOICE  
Programmer   : Lester Wu  
ALTER  Date    :2005-08-24  
Last Modified   :   
Table Read(s)  :  
Table Write(s)  :  
=========================================================  
 Modification History                                      
=========================================================  
Date  		Author  			Description  
=========================================================       
2009-10-16  	Frankie Cheung		Add Print Group
=========================================================       
  
select   
grd_ctnfm,grd_ctnto,grd_custcat,isnull(ymc_catdsc,'其它')  
from GRNTRFDTL  
LEFT JOIN SYMCATCDE on Grd_CustCat = ymc_catcde and ymc_type = '1'  
where grd_grnno = 'GT0500001'  
order by grd_ctnfm  
  
sp_list_MPR00003_inv 'UCPP','GT0800026','GT0800026',2,1,'MIS'  
  
  
*/  
  
  
  
CREATE   Procedure [dbo].[sp_list_MPR00003_inv]  
@cocde varchar(6),  
@GRNFm varchar(20),  
@GRNTo varchar(20),  
@DP int,  
@Hidden int,  
@INVUM int,
@ynPRTGRP	varchar(1),
@UserID varchar(30)  
as  
BEGIN  
  
/*declare   
@cocde varchar(6),  
@GRNFm varchar(20),  
@GRNTo varchar(20),  
@UserID varchar(30)  
  
  
set @cocde = 'UCP'  
set @GRNFm = 'GT0800026'  
set @GRNTo = @GRNFm  
set @UserID = 'MIS'  
*/  
  
-- Lester Wu 2006-03-20  
declare @strAmt char(500)  
declare @strCurr varchar(100)  
  
set @strAmt = '';  
set @strCurr = '';  

select top 1 @strCurr = upper(grd_curr)  --replace(upper(grd_curr),'HKD','HONG KONG DOLLARS')  
from GRNTRFDTL where   
Grd_GrnNo between @GRNFm and @GRNTo and  
Grd_Type <> 'Misc'  
  
  
select   
  
 --isnull(_Bill_Chin,'') as '_Bill_Chin',  
 --isnull(_Bill_Eng,'') as '_Bill_Eng',  
 isnull(inv.Gvi_VenNam,'') as '_Bill_Chin' ,   
 isnull(inv.Gvi_EngNam,'') as '_Bill_Eng' ,  
 isnull(inv.Gvi_EngAddr,'') as '_Bill_Addr',  
 isnull(inv.Gvi_Tel1,'') as '_Bill_Tel1',  
 isnull(inv.Gvi_Tel2,'') as '_Bill_Tel2',   
 isnull(inv.Gvi_Fax,'') as '_Bill_Fax',  
 isnull(inv.Gvi_TLX,'') as '_Bill_TLX',  
 --isnull(_Name,'') as '_Name',  
 --isnull(_Addr,'') as '_Addr',  
 isnull(dest.Gvi_VenNam,'') as '_Name',  
 Grh_ShpAddr as '_Addr' ,   
 isnull(ymc_catdis,'其它') as 'CustType',  
 case isnull(Grd_Grp,'') when '' then sum(Grd_TtlCtn) else max(Grd_TtlCtn) end as 'Grd_TtlCtn',  
 Grd_CTNUM,  
 /*sum (case Grd_Type   
  when 'MPO' then Grd_TtlShpQty * Grd_UntPrc  
  when 'AdHoc' then Grd_TtlShpQty * Grd_UntPrc  
  when 'Misc' then 0 end   
  )  
 as 'TtlAmt',*/  
 round(case isnull(Grd_Grp,'') when '' then   
  sum (case Grd_Type   
   when 'MPO' then Grd_CustQty * Grd_UntPrc  
   when 'AdHoc' then Grd_CustQty * Grd_UntPrc  
   when 'Misc' then 0 end   
   )  
 else  
  max (case Grd_Type   
   when 'MPO' then Grd_CustQty * Grd_UntPrc  
   when 'AdHoc' then Grd_CustQty * Grd_UntPrc  
   when 'Misc' then 0 end   
   )  
-- end,0)  
 end,@DP)  
 as 'TtlAmt',  
   
 case isnull(grd_grp,'') when '' then sum(Grd_GW * Grd_TtlCtn) else max(Grd_GW*Grd_TtlCtn) end as 'TtlGW',  
 case isnull(grd_grp,'') when '' then sum(Grd_NW * Grd_TtlCtn) else max(Grd_NW*Grd_TtlCtn) end as 'TtlNW',  
 Grh_GrnNo,  
 --------------------------------------------------------  
 -- Lester Wu 2006-03-20  
 right(Grh_DlvDat,2) + ' 年 ' + left(Grh_DlvDat,2) + ' 月 ' + substring(Grh_DlvDat,4,2) + ' 日' as 'Grh_DlvDat',  
 Grh_CtrNo ,  
 Grh_car ,  
 @strAmt as 'strAmt' ,  
 @strCurr as 'strCurr' ,   
 --------------------------------------------------------  
 min(Grd_CtnFm) as 'CTNRange' ,   
 max(Grd_UntPrc) as 'UntPrc' ,   
 case isnull(Grd_Grp,'') when '' then   
  sum (case Grd_Type   
   when 'MPO' then Grd_CustQty  
   when 'AdHoc' then Grd_CustQty  
   when 'Misc' then 0 end   
   )  
 else  
  max (case Grd_Type   
   when 'MPO' then Grd_CustQty  
   when 'AdHoc' then Grd_CustQty  
   when 'Misc' then 0 end   
   )  
 end  
 as 'CustQty' ,   
 grd_custum,  
 isnull(ymc_catdsc,'其它') as 'CustDsc',  
 isnull(ymc_cloth,'') as 'iscloth' ,   
-- isnull(Grh_CusUM,'') as 'CustUM' ,   
 isnull(replace(grd_custum,'M','米'),'') as 'CustUM' ,   
 isnull(Grh_InvUM,'') as 'InvUM'   
 ,Grd_PrtGrp 	--Frankie Cheung 20091016
into #Tmp_Result  
  
from   
GRNTRFHDR  
LEFT JOIN GRNTRFDTL on Grh_GrnNo = Grd_GrnNo  
--LEFT JOIN  #_tmp_LST on Grd_GrnNo = Grl_GrnNo and Grd_Seq = Grl_GrnSeq  
LEFT JOIN SYMCATCDE (NOLOCK) on Grd_CustCat = ymc_catcde and ymc_type = '1'  
LEFT JOIN GRNVENINF cust (NOLOCK)  on Grh_ImpFty = cust.Gvi_VenSna and cust.Gvi_Type = 'CUST'  
LEFT JOIN GRNVENINF inv (NOLOCK)  on cust.Gvi_InvVen = inv.Gvi_VenSna and inv.Gvi_Type = 'INV'  
LEFT JOIN GRNVENINF dest (NOLOCK)  on Grh_ShpPlc = dest.Gvi_VenSna and dest.Gvi_Type = 'CUST'  
  
--LEFT JOIN #tmp_lh on Grh_ImpFty = _CustFty  
--LEFT JOIN #tmp_messrs on Grh_ImpFty = _Fty  
  
Where  
 Grh_GrnNo between @GRNFm and @GRNTo and  
 Grd_Type <> 'Misc'  
Group by   
 Grh_GrnNo,   
 ----------------------------------  
 --Lester Wu 2006-03-20  
 right(Grh_DlvDat,2) + ' 年 ' + left(Grh_DlvDat,2) + ' 月 ' + substring(Grh_DlvDat,4,2) + ' 日' ,  
 Grh_CtrNo ,  
 Grh_Car ,  
 ----------------------------------  
 isnull(inv.Gvi_VenNam,'') ,  
 isnull(inv.Gvi_EngNam,'') ,  
 isnull(inv.Gvi_EngAddr,'') ,  
 isnull(dest.Gvi_VenNam,'') ,  
 isnull(inv.Gvi_Tel1,'') ,  
 isnull(inv.Gvi_Tel2,'') ,  
 isnull(inv.Gvi_Fax,'') ,  
 isnull(inv.Gvi_TLX,'') ,  
 Grh_ShpAddr ,  
 isnull(ymc_catdsc,'其它'),  
 isnull(ymc_catdis,'其它'),  
 Grd_CTNUM,  
 grd_grp,  
 grd_custum,  
 isnull(ymc_cloth,'') ,   
 isnull(Grh_CusUM,'') ,  
 isnull(Grh_InvUM,'')   
 ,Grd_PrtGrp	-- Frankie Cheung 20091016
Order by  
 Grh_GrnNo,  
 min(Grd_CtnFm)   
  
-----------------------------------------------  
--Lester Wu   
set @strAmt = ''  
  
select @strAmt = isnull(sum(TtlAmt) ,0)  
from #Tmp_Result  
  
update #Tmp_Result  
set strAmt = @strAmt  
  
--select * from #Tmp_Result  
  
select   
 _Bill_Chin as 'Grh_InvHdr',  
 _Bill_Eng as '_Bill_Eng',  
 _Bill_Addr as '_Bill_Addr',  
 _Bill_Tel1 as '_Bill_Tel1',  
 _Bill_Tel2 as '_Bill_Tel2',  
 _Bill_Fax as '_Bill_Fax',  
 _Bill_TLX as '_Bill_TLX',  
 _Name as '_Name',  
 _Addr as '_Addr',  
 CustType as 'CustType',  
 sum(Grd_TtlCtn) as 'Grd_TtlCtn',  
 Grd_CTNUM as 'Grd_CTNUM',  
 sum(TtlAmt) as 'TtlAmt',  
 sum(TtlGW) as 'TtlGW',  
 sum(TtlNW) as 'TtlNW',  
 Grh_GrnNo as 'Grh_GrnNo',  
 Grh_DlvDat as 'Grh_DlvDat',  
 Grh_CtrNo as 'Grh_CtrNo',  
 Grh_car as 'Grh_CtrSiz',  
 strAmt as 'strAmt',  
 max(UntPrc) as 'UntPrc',  
 sum(case isnull(iscloth,'') when '' then 0 else CustQty end) as 'CustQty',  
 case grd_custum when 'M' then '米' when 'KG' then '千克' else grd_custum end as 'grd_custum' ,   
 iscloth as 'isCloth',  
 strCurr as 'strCurr',  
 CustUM  as 'CUSTUM',   
 InvUM  as 'INVUM',  
 @DP as 'DP',  
 @HIDDEN as 'HIDDEN',  
 @INVUM as 'INVUMSHOW',
 convert(numeric(13,4),strAmt)  as 'TtlAmt_DP',   
 --Grd_PrtGrp,	--Frankie Cheung 20091016	
 case @ynPRTGRP when 'Y' then convert(varchar(20),Grd_PrtGrp) else '***' end as 'Grd_PRTGRP', -- Frankie Cheung 20091028: Add print group
 min(CTNRange)  ,
 CustDsc  
    
from   
 #Tmp_Result  
group by   
 _Bill_Chin,  
 _Bill_Eng,  
 _Bill_Addr,  
 _Bill_Tel1,  
 _Bill_Tel2,  
 _Bill_Fax,  
 _Bill_TLX,  
 _Name,  
 _Addr,  
 CustType,  
 Grd_CTNUM,  
 Grh_GrnNo,  
 Grh_DlvDat,  
 Grh_CtrNo,  
 Grh_car,  
 strAmt,  
 strCurr,  
 case grd_custum when 'M' then '米' when 'KG' then '千克' else grd_custum end ,   
 iscloth,  
 CustDsc ,   
 CustUM ,   
 InvUM   
 ,Grd_PrtGrp	-- Frankie Cheung 20091016
Order by  
 Grh_GrnNo,  
 len(ltrim(rtrim(str(min(CTNRange))))) ,   
 min(CTNRange)   
  
-----------------------------------------------  
  
--drop table #_tmp_LST  
--drop table #tmp_lh  
--drop table #Tmp_Result  
  
END  
  
  
  
  
  
  










GO
GRANT EXECUTE ON [dbo].[sp_list_MPR00003_inv] TO [ERPUSER] AS [dbo]
GO
