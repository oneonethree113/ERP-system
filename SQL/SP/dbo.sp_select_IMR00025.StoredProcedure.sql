/****** Object:  StoredProcedure [dbo].[sp_select_IMR00025]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMR00025]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMR00025]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- sp_select_IMR00025 'UCPP','US0701739','','','','I','Anita'    
--select soh_moqsc,* from SCORDHDR,SCORDDTL where soH_ordno = 'US0700111' and sod_ordno = soh_ordno    
    
    
CREATE  procedure [dbo].[sp_select_IMR00025]    
@cocde varchar(6),     
@MOQScFm varchar(20),     
--@MOQSCTo varchar(20),     
@SCFm varchar(20),     
--@SCTo varchar(20),     
@ItmFm varchar(20),     
@ItmTo varchar(20),     
@Act char(1),    
@gsUsrID varchar(30)    
as    
begin    
     
 declare  @moqsc char(20),     
   @salTeam char(3)    
 declare    
   @selrat numeric(13,9),    
   @buyrat numeric(13,9)    
    
 set @selrat = 1    
 set @buyrat = 1    

 set @moqsc = ''    
 set @salTeam = ''    
     
 select top 1 @salTeam = ysr_saltem from SYSALREP where ysr_code = @gsUsrID    
     
     
 if len(@MOQSCFm) <= 0 and len(@SCFm) > 0     
 begin    
  -- select top 1 @moqsc  = case soh_moqsc when '' then soh_ordno else soh_moqsc end from SCORDHDR where soh_ordno = @SCFm    
      
  select top 1 @moqsc  = case soh_moqsc when '' then soh_ordno else soh_moqsc end     
  from SCORDHDR (nolock)    
  left join CUBASINF (nolock) on soh_cus1no = cbi_cusno and cbi_custyp = 'P'    
  left join SCORDDTL (nolock) on soh_ordno = sod_ordno    
  left join SYSALREP (nolock) on cbi_salrep = ysr_code1    
  left join CUPRCINF (nolock) on soh_cus1no = cpi_cusno     
  where soh_ordno = @SCFm    
  and soh_ordno = sod_ordno    
  and (@ItmFm = '' or (@ItmFm <> '' and sod_itmno between @ItmFm and @ItmTo))    
  and (@ACT = 'B' or     
   (@ACT = 'I' and sod_venno between 'A' and 'Z') or    
   (@ACT = 'E' and sod_venno not between 'A' and 'Z')    
  )    
  and (@salTeam = '' or @salTeam = 'S' or @salTeam = isnull(ysr_saltem,''))    
 end    
 else    
 begin    
  set @moqsc = @MOQScFm    
 end    
     
    
/*     
 if len(@moqsc) <= 0     
 begin    
  set @moqsc  = @SCFm    
 end    
*/    
 if len(@moqsc) <= 0     
 begin
/*
  print 'No MOQ SC# Found!'
  return 99 
*/
  select 'No MOQ SC# Found!'
  return 99
 end    
     
 select @buyrat = ysi_buyrat, @selrat = ysi_selrat from SYSETINF where ysi_typ = '06' and ysi_cde = 'HKD'    
     
     
 select    
 soh_cus1no + case isnull(cbi_cussna,'') when '' then '' else ' - ' + isnull(cbi_cussna,'') end as 'Cust. Name',     
 case soh_moqsc when '' then soh_ordno else soh_moqsc end  as 'MOQ SC' ,     
 sod_itmno as 'Item No.',     
 sod_colcde as 'Color Code',     
 sod_pckunt + '/' + ltrim(str(sod_inrctn)) + '/' + ltrim(str(sod_mtrctn)) as 'Packing',    
 sod_ordno as 'SC No.' ,     
 soh_cpodat as 'Cust PO Date',     
 isnull(pod_jobord,'') as 'Job No.' ,     
     
 sod_moq as 'Comp MOQ (SC)',    
 sod_ordqty/sod_mtrctn as 'Order Qty (Ctn)',    
     
 sod_curcde as 'MOA Curr. (SC)',     
 sod_moa as 'Comp MOA (SC)',     
 sod_selprc as 'Order Amount' ,     
 isnull(cpi_curcde,'USD') as 'Curr'    ,
 sod_venno as 'Prd Ven'
 into #tmpSC    
 from     
 SCORDHDR(nolock)    
 left join CUBASINF (nolock) on soh_cus1no = cbi_cusno and cbi_custyp = 'P'    
 left join SCORDDTL (nolock) on soh_ordno = sod_ordno    
 left join POORDDTL (nolock) on sod_ordno = pod_scno and sod_ordseq = pod_scline    
 left join SYSALREP (nolock) on cbi_salrep = ysr_code1    
 left join CUPRCINF (nolock) on soh_cus1no = cpi_cusno     
 where     
  case soh_moqsc when '' then soh_ordno else soh_moqsc end  = @moqsc    
  and (@itmFm = '' or (@itmFm <> '' and sod_itmno between @itmFm and @itmTo))    
  and (@ACT = 'B' or     
   (@ACT = 'I' and sod_venno between 'A' and 'Z') or    
   (@ACT = 'E' and sod_venno not between 'A' and 'Z')    
  )    
  and (@salTeam = '' or @salTeam = 'S' or @salTeam = isnull(ysr_saltem,''))    
    
    
 select     
  [Cust. Name] ,    
  [MOQ SC] ,    
  [Item No.] ,    
  [Color Code],     
  [Packing],    
  sum(case when [Comp MOQ (SC)] > 0 then [Order Qty (Ctn)] else 0 end) as 'TtlCtn',     
  [Curr] ,     
  sum(case when [Comp MOQ (SC)] > 0 then 0 else     
    case when [Curr] = [MOA Curr. (SC)] then [Order Amount]     
    when [MOA Curr. (SC)] = 'HKD' then convert(numeric(13,4), [Order Amount] * @selrat)    
    else convert(numeric(13,4) , [Order Amount] / @selrat ) end end)     
  as 'TtlAmt'    
 into    
  #tmpSC_ttl    
 from     
  #tmpSC     
 group by     
  [Cust. Name] ,    
  [MOQ SC] ,    
  [Item No.] ,    
  [Color Code],     
  [Packing],    
  [Curr]    
      
    
 select     
  sc.[MOQ SC] ,    
  sc.[Cust. Name] ,    
  sc.[Item No.] ,    
  sc.[Color Code],     
  sc.[Packing],    
  sc.[SC No.] ,     
  sc.[Cust PO Date],     
  sc.[Job No.] ,     
  sc.[Comp MOQ (SC)],    
  sc.[Order Qty (Ctn)],    
  ttl.[ttlCtn] ,     
  sc.[MOA Curr. (SC)],     
  sc.[Comp MOA (SC)],     
  sc.[Order Amount] ,     
  sc.[Curr] ,     
  ttl.[ttlAmt], 
  sc.[Prd Ven] + case isnull(vbi_vensna,'') when '' then '' else ' - ' + vbi_vensna end as 'Prd Ven'
  from      
  #tmpSC as sc 
left join VNBASINF on sc.[Prd Ven] = vbi_venno
, #tmpSC_ttl as ttl    

 where     
  sc.[Cust. Name] = ttl.[Cust. Name] and    
  sc.[MOQ SC] = ttl.[MOQ SC] and    
  sc.[Item No.] = ttl.[Item No.] and    
  sc.[Color Code] = ttl.[Color Code] and    
  sc.[Packing] = ttl.[Packing]    
 order by     
  sc.[Cust. Name] ,    
  sc.[MOQ SC] ,    
  sc.[Item No.] ,    
  sc.[Color Code],     
  sc.[Packing],    
  sc.[SC No.] ,     
  sc.[Job No.]     
      
-- select @salTeam, @ACT, @itmFm, @itmTo,@moqsc    
-- group by soh_cus1no, cbi_cussna,  sod_itmno, sod_colcde, sod_pckunt,sod_inrctn, sod_mtrctn    
     
    
end    
    
    
  






GO
GRANT EXECUTE ON [dbo].[sp_select_IMR00025] TO [ERPUSER] AS [dbo]
GO
