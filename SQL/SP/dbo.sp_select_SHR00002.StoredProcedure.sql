/****** Object:  StoredProcedure [dbo].[sp_select_SHR00002]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SHR00002]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SHR00002]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



/*  
=========================================================  
Description    : sp_select_SHR00002  
Programmer   : PIC  
ALTER  Date    :   
Last Modified   : 2003-02-12  
Table Read(s)  :  
Table Write(s)  :  
=========================================================  
 Modification History                                      
=========================================================  
 Date        Initial    Description                            
=========================================================       
2003-10-13 Allan Yuen  Add Running No.  
2005-06-02 Allan Yuen  Add Custom Vendor  
*/  
  
-- Checked by Allan Yuen at 27/07/2003  
  
--  sp_select_SHR00002 'UCP','PR0601880','PR0601896','1'


CREATE PROCEDURE [dbo].[sp_select_SHR00002]   
  
@cocde nvarchar(6),  
@from nvarchar(20),  
@to nvarchar(20),  
@fntyp int  
  
AS  
BEGIN  
 IF @fntyp = 0   
 BEGIN  
  SELECT   
   distinct isnull(soh_cus1no,'')as 'soh_cus1no' ,  
   isnull(soh_cus2no,'') as 'soh_cus2no',  
   sod_ordno,  
   sod_purord,   
   isnull(bb.vbi_vensna,'') as 'CV',  
   isnull(aa.vbi_vensna,'') as 'vbi_vensna'  
  FROM   
   SCORDDTL (nolock)
   left join scordhdr (nolock) on soh_cocde = @cocde and soh_ordno = sod_ordno  
   --left join vnbasinf on vbi_cocde = @cocde and sod_venno = vbi_venno  
   left join vnbasinf aa (nolock) on sod_venno = aa.vbi_venno  
   left join vnbasinf bb (nolock) on sod_cusven = bb.vbi_venno  
  WHERE   
   sod_ordno >= @from AND  
   sod_ordno <= @to AND  
   sod_cocde = @cocde and rtrim(ltrim(sod_purord)) <> ''   
  order by    
   sod_ordno  
--  SELECT distinct sod_ordno,sod_purord  
--  FROM SCORDDTL  
--  WHERE sod_ordno >=@from AND  
--  sod_ordno <= @to AND  
--  sod_cocde = @cocde and rtrim(ltrim(sod_purord)) <> ''   
  
--  SELECT distinct sod_purord  
--  FROM SCORDDTL  
--  WHERE sod_ordno >= @from AND  
--  sod_ordno <= @to AND  
--  sod_cocde = @cocde  
 END  
 IF @fntyp = 1   
 BEGIN  
  
  
 SELECT cast(pod_purord as  nvarchar(20)) as 'pod_purord' ,   
  CASE sod_subcde when '' then isnull(left(a.vbi_vensna,20),'')  else isnull(left(a.vbi_vensna,20),'') + ' - '  + sod_subcde end  as 'a.vbi_vensna',   
  cast(pod_jobord as nvarchar(20)) as 'pod_jobord' ,   
  cast(pod_runno as nvarchar(20)) as 'pod_runno' ,   
  cast(isnull(pdb_bompno,'') as nvarchar(20)) as 'pbd_bompo',  
  case  cast(isnull(pdb_bompno,'') as nvarchar(20)) when '' then '' else isnull(left(b.vbi_vensna,20),'') end as 'b.vbi_vensna'  
 FROM  SCORDDTL (nolock), POORDDTL  (nolock)
--  Lester Wu 2006-05-17
--  left join  PODTLBOM on pdb_purord =  pod_purord   and pdb_cocde = @cocde  
 left join  PODTLBOM (nolock) on pdb_purord =  pod_purord  and pod_purseq  = pdb_seq  and pdb_cocde = @cocde 	--Lester Wu 2006-05-19
 -- left join  POBOMHDR on pbh_purord =  pod_purord   and pbh_cocde ='UCP'  
  left join poordhdr (nolock) on poh_cocde = @cocde and poh_purord = pod_purord  
--  left join vnbasinf a on poh_venno = a.vbi_venno and a.vbi_cocde =@cocde  
  left join vnbasinf a (nolock) on poh_venno = a.vbi_venno   
--  left join vnbasinf b on pdb_venno = b.vbi_venno and b.vbi_cocde =@cocde  
  left join vnbasinf b (nolock) on pdb_venno = b.vbi_venno   
 WHERE  pod_cocde = sod_cocde and pod_scno = sod_ordno and pod_scline = sod_ordseq   
 AND pod_purord >=  @from AND pod_purord <=@to  
 AND pod_cocde =@cocde

 group by  pod_purord,pod_jobord,  pod_runno,  pdb_bompno,a.vbi_vensna,b.vbi_vensna, sod_subcde  
 order by  pod_purord,pod_jobord, pod_runno,   pdb_bompno  
  
--  SELECT  cast(pod_purord as  nvarchar(20)) as 'pod_purord' , isnull(left(a.vbi_vensna,20),'') as 'a.vbi_vensna',  
--   cast(pod_jobord as nvarchar(20)) as 'pod_jobord' ,    
--   cast(isnull(pdb_bompno,'') as nvarchar(20)) as 'pbd_bompo', isnull(left(b.vbi_vensna,20),'') as 'b.vbi_vensna'  
--  FROM POORDDTL  
--  left join  PODTLBOM on pdb_purord =  pod_purord   and pdb_cocde = @cocde  
--  left join  POBOMHDR on pbh_purord =  pod_purord   and pbh_cocde ='UCP'  
--  left join poordhdr on poh_cocde = @cocde and poh_purord = pod_purord  
--  left join vnbasinf a on poh_venno = a.vbi_venno and a.vbi_cocde = @cocde  
--  left join vnbasinf b on pdb_venno = b.vbi_venno and b.vbi_cocde = @cocde  
--  WHERE pod_purord >=  @from AND  
--   pod_purord <= @to AND  
--   pod_cocde = @cocde  
--  group by pod_purord,pod_jobord ,  pdb_bompno,a.vbi_vensna,b.vbi_vensna  
--  order by pod_purord,pod_jobord ,  pdb_bompno  
  
--  SELECT  cast(pod_purord as  nvarchar(20)) as 'pod_purord' , isnull(a.vbi_vensna,'') as 'a.vbi_vensna',  
--   cast(pod_jobord as nvarchar(20)) as 'pod_jobord' ,    
--   cast(isnull(pbd_bompo,'') as nvarchar(20)) as 'pbd_bompo', isnull(b.vbi_vensna,'') as 'b.vbi_vensna'  
--  FROM POORDDTL  
--  left join  POBOMDTL on pbd_refpo =  pod_purord   and pbd_cocde = @cocde  
--  left join  POBOMHDR on pbh_purord =  pod_purord   and pbh_cocde = @cocde  
--  left join poordhdr on poh_cocde = @cocde and poh_purord = pod_purord  
--  left join vnbasinf a on poh_venno = a.vbi_venno and a.vbi_cocde = @cocde  
--  left join vnbasinf b on pbh_bvenno = b.vbi_venno and b.vbi_cocde = @cocde  
--  WHERE pod_purord >= @from AND  
--   pod_purord <=@to AND  
--   pod_cocde =@cocde  
--   group by pod_purord,pod_jobord ,  pbd_bompo,a.vbi_vensna,b.vbi_vensna  
--  order by pod_purord,pod_jobord ,  pbd_bompo  
  
--  SELECT  cast(pod_purord as  nvarchar(20)) as 'pod_purord' ,   
--   cast(pod_jobord as nvarchar(20)) as 'pod_jobord' ,    
--   cast(isnull(pbd_bompo,'') as nvarchar(20)) as 'pbd_bompo'  
--  FROM POORDDTL  
--  left join  POBOMDTL on pbd_refpo =  pod_purord   and pbd_cocde = @cocde  
--    
--  WHERE pod_purord >= @from AND  
--   pod_purord <=@to AND  
--   pod_cocde =@cocde  
--   group by pod_purord,pod_jobord ,  pbd_bompo  
--  order by pod_purord,pod_jobord ,  pbd_bompo  
  
--  SELECT distinct pod_jobord ,  pbd_bompo  
--  FROM POORDDTL  
--  WHERE pod_purord >= @from AND  
--  pod_purord <= @to AND  
--  pod_cocde = @cocde  
 END  
   
END


GO
GRANT EXECUTE ON [dbo].[sp_select_SHR00002] TO [ERPUSER] AS [dbo]
GO
