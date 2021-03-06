/****** Object:  StoredProcedure [dbo].[sp_select_MPO00003_Dtl_update]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MPO00003_Dtl_update]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MPO00003_Dtl_update]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO




/*  
=========================================================  
Program ID : sp_select_MPO00003_Dtl_update  
Description    : Approve/ Reject MPO Exceptional record(s) - Detail  
Programmer   : Lester Wu  
Create Date    :  
Last Modified   :   
Table Read(s)  :  
Table Write(s)  :  
=========================================================  
 Modification History                                      
=========================================================  
Date  Author  Description  
=========================================================       
2005/10/05  Lester Wu  Update MPO Flag to "O" while the flag is "G"  
      O -- Old , G -- Generated  
  
*/  
  
--sp_help MPOEXPHDR  
  
--sp_select_MPO00003_Dtl_update 'UCPP','A','DingDtl200508130001_1','998','mis'  
  
CREATE  procedure [dbo].[sp_select_MPO00003_Dtl_update]  
@cocde  as varchar(6),  
@gen  as char(1),  
@Mxd_FilNam as varchar(50),  
@Mxd_seq as int,  
@UsrID  as varchar(30)  
as  
Begin  
 declare   
  @UntPrc  numeric(9,4)   
  
 declare   
  @Mxd_Expt varchar(255)  
  
 declare  
  @MPO#  varchar(20),  
  @MPOLst  varchar(500)  
  
 --sp_help MPOEXPDTL  
 declare  
  @Mxd_PONo varchar(20),  
  @Mxd_POSeq int,  
  @Mxd_ReqNo varchar(10),  
  @Mxd_ShpDat datetime,  
  @Mxd_ItmNo varchar(20),  
  @Mxd_ItmNam nvarchar(60),  
  @Mxd_ItmDsc nvarchar(30),  
  @Mxd_ColCde nvarchar(14),  
  @Mxd_UM varchar(5),  
  @Mxd_Qty numeric(9,2),  
  @Mxd_UntPrc numeric(9,4),  
  @Mxd_PckMth nvarchar(8),  
  @Mxd_Dept nvarchar(10),  
  @Mxd_PrdNo varchar(100),  
  @Mxd_Rmk nvarchar(400),  
  @MPO  varchar(20),  
  @Mxd_MPOFlg char(3),  
  @Mxd_UpdFlg char(3)  
  
   
 declare   
  @errMsg  varchar(300)  
  
  
 Declare   
  @Row_Idx  int,  
  @Err_Idx   int  
  
 set @Row_Idx = 0  
 set @Err_Idx = 0  
   
 declare  
  @Flag  varchar(6) ,   
  @ShpQty  numeric(9,2),  
  @OrdQty  numeric(9,2)  
  
-- Lester Wu 2005-10-10  
 declare   
  @PODAYS int ,  
  @DlvQty  numeric(9,2)  
    
  --Lester Wu 2007-06-11
-- declare   
--  @ttl_Amt   numeric(9,2)  
 declare   
  @ttl_Amt   numeric(13,4)  
   
 set @ttl_Amt = 0  
  
  
 select  @Mxd_PONo = Mxd_PONo,  
  @Mxd_POSeq = Mxd_POSeq,  
  @Mxd_ReqNo = Mxd_ReqNo,  
  @Mxd_ShpDat = Mxd_ShpDat,  
  @Mxd_ItmNo = Mxd_ItmNo,  
  @Mxd_ItmNam = Mxd_ItmNam,  
  @Mxd_ItmDsc = Mxd_ItmDsc,  
  @Mxd_ColCde = Mxd_ColCde,  
  @Mxd_UM = Mxd_UM,  
  @Mxd_Qty = isnull(Mxd_Qty, 0),  
  @Mxd_UntPrc = isnull(Mxd_UntPrc,0),  
  @Mxd_PckMth = Mxd_PckMth,  
  @Mxd_Dept = Mxd_Dept,  
  @Mxd_PrdNo = Mxd_PrdNo,  
  @Mxd_Rmk = Mxd_Rmk,  
  @Mxd_Expt = Mxd_Expt,  
  @Mxd_UpdFlg = Mxd_UpdFlg  
 from    
  MPOEXPDTL  
 where    
  Mxd_FilNam = @Mxd_FilNam and   
  Mxd_seq = @Mxd_seq   
  
 set @UntPrc = @Mxd_UntPrc  
  
 set @MPO = ''  
 set @errMsg = ''  
  
   
 if @gen = 'R'   
 begin  
 --Mark Record Reject  
  update MPOEXPDTL set Mxd_MpoFlg = @gen , Mxd_UpdDat = getdate(), Mxd_UpdUsr = @UsrID + '_AR'  
  where Mxd_FilNam = @Mxd_FilNam  and @Mxd_seq = Mxd_seq   
    
  select @Err_Idx = @@error, @Row_Idx = @@RowCount  
  select 'Reject of ' + @Mxd_FilNam + ' Seq : ' + ltrim(rtrim(str(@Mxd_seq))) + ' ( PO : ' + @Mxd_PONo + '   Seq : ' + ltrim(rtrim(str(@Mxd_POSeq))) + ' ). Success!'  
    
  return (99)  
 end  
 else  
 begin  
     
--xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  
--xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  
  
  set @Flag = ''  
  set @ShpQty = 0  
  set @OrdQty = 0  
  set @PODAYS = 0  
  set @DlvQty = 0  
  
  -- Action  --> @Mxd_UpdFlg  
  if Upper(@Mxd_UpdFlg) <> 'DEL'  and @Mxd_Qty = 0   
  begin  
   set @Mxd_UpdFlg = 'DEL'  
  end  
  
  -- MPO #  --> @MPO  
  select @MPO = max(isnull(Mxd_MPONo,'')) from MPOXLSDTL where Mxd_PONo = @Mxd_PONo and Mxd_POSeq = @Mxd_POSeq  
    
  -- Ship Qty  --> @ShpQty  
  -- Delivery Qty --> @DlvQty  
  -- Order Qty --> @OrdQty   
  -- Unit Price --> @UntPrc   
  -- PO Days  --> @PODAYS  
  if isnull(@MPO,'')  <> ''    
  begin  
   select   
    @ShpQty = sum(Mpd_ShpQty) ,   
    @DlvQty = sum(Mpd_DQty) ,   
    @OrdQty = sum(Mpd_Qty) ,   
    @UntPrc = max(Mpd_UntPrc),   
    @PODAYS = max(datediff(Day,Mpd_PODat,getdate()))  
   from   
    MPORDDTL   
   where   
    Mpd_PONo = @Mxd_PONo and   
    Mpd_POSeq = @Mxd_POSeq  
  end  
  
  -- ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++  
  -- ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++  
  
  -- Treat it as cancel record if Order Qty Set to ZERO  
  
  
  if Upper(@Mxd_UpdFlg) <> 'DEL'   
  begin  
  
   if   ltrim(rtrim(isnull(@Mxd_ItmNo,'')))= ''  
   begin  
    set @errMsg = @errMsg +  case len(@errMsg) when 0 then '' else ' | ' end + 'Item # Empty'  
    set @Flag = 'R'  
   end  
    
   if  isnull(@Mxd_UntPrc,0) <= 0   
   begin  
    set @errMsg = @errMsg +   case len(@errMsg) when 0 then '' else ' | ' end + 'Unit Price Invalid'  
    set @Flag = 'R'  
   end  
    
   if isnull(@Mxd_ShpDat,'') = '' or @Mxd_ShpDat = '1900/01/01'  
   begin  
    set @errMsg = @errMsg +   case len(@errMsg) when 0 then '' else ' | ' end + 'Ship Date Invalid'  
    set @Flag = 'R'  
   end  
     
   if isnull(@Mxd_Qty,0) = 0  
   begin  
    set @errMsg = @errMsg +   case len(@errMsg) when 0 then '' else ' | ' end + 'Zero Ord Qty'  
    set @Flag = 'R'  
   end  
     
   if isnull(@Mxd_UM,'') = ''  
   begin  
    set @errMsg = @errMsg +   case len(@errMsg) when 0 then '' else ' | ' end + 'UM Empty'  
    set @Flag = 'R'  
   end  
  end   
  -- ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++  
    
  if @Flag <> 'R'   
  begin  
  
   if Upper(@Mxd_UpdFlg) = 'DEL'   
   begin  
    -- CANCELATION  
    if isnull(@MPO,'') <> '' and  @ShpQty  > 0   
    begin  
     set @Flag = 'R'  
     set @errMsg = @errMsg +   case len(@errMsg) when 0 then '' else ' | ' end + 'MPO Gen (' + @MPO + ') & Ship Qty > 0'  
    end  
   end  
   else  
   begin  
    -- AMENDMENT  
    if isnull(@MPO,'') <> ''   
    begin  
       
     if @PODAYS > 9999  -- 21  
     begin  
      set @Flag = 'R'  
      set @errMsg = @errMsg +   case len(@errMsg) when 0 then '' else ' | ' end + 'MPO Gen (' + @MPO + ') & PO over 21 Days'  
     end  
     else  
     begin  
      if @ShpQty  > 0 and @DlvQty > @Mxd_Qty  
      begin  
       set @Flag = 'R'  
       set @errMsg = @errMsg +   case len(@errMsg) when 0 then '' else ' | ' end + 'MPO Gen (' + @MPO + ') & Modify Qty < Delivery Qty'  
      end  
     end       
    end  
   end  
  end  
  -- ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++    
  -- ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++    
    
    
--xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  
--xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  
  
  set @MPOLst = ''  
  set @MPO# = ''  
  
  if @Flag = 'R'   
  begin  
   select @Mxd_FilNam + ' Seq : ' + ltrim(rtrim(str(@Mxd_seq))) + ' ( PO : ' + @Mxd_PONo + '   Seq : ' +  ltrim(rtrim(str(@Mxd_POSeq))) + ' ) '  + @errMsg  
     
   return (99)  
  end  
  else  
  begin  
   begin tran  
   --xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  
   --xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  
    set @Mxd_Expt = 'Update from Exception Record'   
      
    if @MPO <> ''   
    begin  
     if @Err_Idx = 0  
     begin  
  
      --XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX  
      if upper(@Mxd_UpdFlg) = 'DEL'   
      begin  
       --========DELETE=========================================  
         
       update  
         MPORDDTL  
       set    
        Mpd_ReqNo = '',   
        Mpd_OrgShpDat = '1900/01/01' ,   
        Mpd_ItmNam = '',   
        Mpd_ItmDsc = 'Detail Record Deleted!' ,   
        Mpd_ColCde = '' ,   
        Mpd_UM = '' ,   
        Mpd_Qty = 0 ,   
        Mpd_UntPrc = 0 ,   
        Mpd_PckMth = '' ,   
        Mpd_Dept = '' ,   
        Mpd_Rmk = '' ,   
        Mpd_UpdDat = getdate(),  
        Mpd_UpdUsr = @UsrID + '_AR'   
          
       where   
        Mpd_PONo = @Mxd_PONo and   
        Mpd_POSeq = @Mxd_POSeq and   
        Mpd_POSeq > 0   
       --=======================================================  
      end  
      else  
      begin  
       --========UPDATE=========================================         
       update  
         MPORDDTL  
       set    
        Mpd_ReqNo = @Mxd_ReqNo,  
        Mpd_OrgShpDat = isnull(@Mxd_ShpDat,'1900/01/01') ,   
        --Mpd_ItmNo = @Mxd_ItmNo,  
        Mpd_ItmNam = @Mxd_ItmNam,  
        Mpd_ItmDsc = @Mxd_ItmDsc,  
        Mpd_ColCde = @Mxd_ColCde,  
        Mpd_UM = @Mxd_UM,  
        Mpd_Qty = isnull(@Mxd_Qty, 0) ,   
        Mpd_UntPrc = isnull(@Mxd_UntPrc,0) ,   
        Mpd_PckMth = @Mxd_PckMth,  
        Mpd_Dept = @Mxd_Dept,  
        Mpd_Rmk = @Mxd_Rmk,  
        Mpd_UpdDat = getdate(),  
        Mpd_UpdUsr = @UsrID + '_AR'   
          
       where   
        Mpd_PONo = @Mxd_PONo and   
        Mpd_POSeq = @Mxd_POSeq and   
        Mpd_POSeq > 0   
       --========================================================  
      end  
  
      --XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX  
      select @Err_Idx = @@error, @Row_Idx = @@RowCount  
        
/* Lester Wu 2006-04-18 Start */  
      set @ttl_Amt = 0  
      
      select   
       @ttl_Amt = min(Mpd_UntPrc)  
      from  
       MPORDDTL  
      where   
       Mpd_MPONo =@MPO and  
       Mpd_ItmNo = @Mxd_ItmNo and  
       Mpd_POSeq > 0  and   
       Mpd_UntPrc > 0  
      group by   
       Mpd_MpoNo  
  
      if isnull(@ttl_Amt,0) > 0   
      begin  
       Update   
        MPORDDTL set Mpd_MinPrc = @ttl_Amt  
       where   
        Mpd_MPONo =@MPO and  
        Mpd_ItmNo = @Mxd_ItmNo and   
        Mpd_POSeq > 0  
          
      end  
      /* Lester Wu 2006-04-18 End */  
      
      -- Update Total Amout  
      set @ttl_Amt = 0  
      
      select   
       @ttl_Amt = round(sum(Mpd_Qty * Mpd_MinPrc),2)  
      from  
       MPORDDTL  
      where   
       Mpd_MPONo =@MPO  
      group by   
       Mpd_MpoNo  
      
      update   
       MPORDHDR  
      set   
       Mph_ttlAmt =  @ttl_Amt,  
       Mph_NetAmt = round(@ttl_Amt * (1 - Mph_discnt),2) ,   
       Mph_UpdDat = getdate(),  
       Mph_UpdUsr = @UsrID + '_AR'  
      where   
       Mph_MPONo =@MPO and  
       Mph_TtlAmt <> @ttl_Amt  
  
  
     end  
  
     if upper(@Mxd_UpdFlg) = 'DEL'   
     begin  
      set @Mxd_MPOFlg = 'D'  
     end  
     else  
     begin  
      set @Mxd_MPOFlg = 'G'  
     end  
    end  
    else  
    begin  
     if upper(@Mxd_UpdFlg) = 'DEL'   
     begin  
      set @Mxd_MPOFlg = 'D'  
     end  
     else  
     begin  
      set @Mxd_MPOFlg = 'N'  
     end  
    end  
    --Error Handle  
  
    if @Err_Idx = 0  
    begin  
     update MPOEXPDTL set Mxd_MpoFlg = @gen , Mxd_UpdUsr = @UsrID + '_AR', Mxd_UpdDat = getdate()  
     where Mxd_FilNam = @Mxd_FilNam  and @Mxd_seq = Mxd_seq  
   
     select @Err_Idx = @@error, @Row_Idx = @@RowCount  
    end  
  
    --Error Handle  
  
    if @Err_Idx = 0   
    begin  
     update   
      MPOXLSDTL   
     set   
      Mxd_MpoFlg = 'O',  
      Mxd_UpdUsr = @UsrID + '_AR',   
      Mxd_UpdDat = getdate()   
     where   
      Mxd_PONo = @Mxd_Pono and   
      --Mxd_ItmNo = @Mxd_ItmNo and   
      Mxd_POSeq = @Mxd_POSeq  
      --Mxd_PrdNo = @Mxd_PrdNo    
      -- Lester Wu 2005/10/05  
      --and Mxd_MpoFlg = 'N'  
      and Mxd_MpoFlg in( 'N' , 'G' )  
       
     select @Err_Idx = @@error, @Row_Idx = @@RowCount       
      
     if @Err_Idx = 0   
     begin  
      update   
       MPOXLSDTL   
      set   
       Mxd_MpoFlg = @Mxd_MPOFlg ,   
       Mxd_UpdUsr = @UsrID + '_AR',   
       Mxd_UpdDat = getdate()   
      where   
       Mxd_PONo = @Mxd_Pono and   
       --Mxd_ItmNo = @Mxd_ItmNo and   
       Mxd_POSeq = @Mxd_POSeq  
       and Mxd_MpoFlg in( 'E' )  
        
      select @Err_Idx = @@error, @Row_Idx = @@RowCount  
     end  
    end  
    --Error Handle  
  
      
    /*if @Err_Idx = 0   
    begin  
     insert into MPOXLSDTL (Mxd_FilNam,Mxd_seq,Mxd_PONo,Mxd_POSeq,Mxd_ReqNo,Mxd_ShpDat,Mxd_ItmNo,Mxd_ItmNam,  
        Mxd_ItmDsc,Mxd_ColCde,Mxd_UM,Mxd_Qty,Mxd_UntPrc,Mxd_PckMth,Mxd_Dept,Mxd_PrdNo,  
        Mxd_Rmk,Mxd_UpdFlg,Mxd_Expt,Mxd_MPOFLG,Mxd_MPONO,Mxd_CreDat,Mxd_CreUsr,  
        Mxd_UpdDat,Mxd_UpdUsr)  
     select  @Mxd_FilNam,isnull(max(Mxd_seq),0) + 1,@Mxd_PONo, @Mxd_POSeq,@Mxd_ReqNo,isnull(@Mxd_ShpDat,'1900/01/01'),@Mxd_ItmNo,@Mxd_ItmNam,  
       @Mxd_ItmDsc,@Mxd_ColCde,@Mxd_UM, @Mxd_Qty,@Mxd_UntPrc,@Mxd_PckMth,@Mxd_Dept,@Mxd_PrdNo,@Mxd_Rmk,@Mxd_UpdFlg,  
       @Mxd_Expt, @Mxd_MPOFlg,@MPO, getdate(),@UsrID + '_AR',  getdate(),@UsrID + '_AR'  
     from  MPOXLSDTL  
     where  Mxd_FilNam = @Mxd_FilNam    
    end*/  
    --Error Handle  
    select @Err_Idx = @@error, @Row_Idx = @@RowCount  
   --xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  
   --xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx     
   if @Err_Idx = 0  
   begin  
    commit tran  
    select 'Approve of ' + @Mxd_FilNam + ' Seq : ' +  ltrim(rtrim(str(@Mxd_seq))) + ' ( PO : ' + @Mxd_PONo + '   Seq : ' +  ltrim(rtrim(str(@Mxd_POSeq))) + ' ). Success!'  
   end  
   else  
   begin  
    rollback tran  
    return (@Err_Idx)  
   end  
  end  
 end  
End


GO
GRANT EXECUTE ON [dbo].[sp_select_MPO00003_Dtl_update] TO [ERPUSER] AS [dbo]
GO
