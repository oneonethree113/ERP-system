/****** Object:  StoredProcedure [dbo].[sp_select_PDA_Item_GetItem]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PDA_Item_GetItem]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PDA_Item_GetItem]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO













/*
=========================================================
Description   	: sp_select_PDA_Item_GetItem
Programmer  	: Mark Lau
ALTER  Date   	: 2008-06-04
Last Modified  	: 2008-06-04
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      		Initial  		Description                          
=========================================================     
2008-06-04 		Mark Lau	All Current Items can be selected

*/

CREATE   procedure [dbo].[sp_select_PDA_Item_GetItem]
@itmno NVARCHAR(20),
@isnewitmfmt	nvarchar(1)

as

set @isnewitmfmt = 'N'

Select 

isnull(case when @isnewitmfmt = 'N' then
case when ibi_itmno = @itmno then '' else
case when ibi_alsitmno = @itmno then 'A' end  
end 
end ,'') as 'typ',

ibi_credat,
' ' as 'ibi_cocde',
ibi_itmno,
ivi_venitm,
ibi_engdsc,
ibi_venno,
case rtrim(ltrim(ibi_imgpth)) when '' then 'N' else 'Y' end as ibi_img,
Isnull(pck.ipi_pckseq,1)as  'ipi_pckseq', 
isnull(pck.ipi_inrqty,0) as 'ipi_inrqty', 
isnull(pck.ipi_mtrqty,0) as 'ipi_mtrqty',
isnull(pck.ipi_cft,0) as 'ipi_cft', 
isnull(pck.ipi_pckunt,'N/A') as 'ipi_pckunt', 
isnull(pck.ipi_conftr,1) as 'ipi_conftr',
ibi_tirtyp, 
isnull(yts_moq,0) as 'ibi_moqctn',
isnull(yts_moa,0) as 'ibi_moa',
isnull(imu_bcurcde,'') as'imu_bcurcde', 
isnull(imu_basprc,0) as 'imu_basprc', 
isnull(case ycf_oper when'*'  then 'PC'  when '/' then 'PC' else ipi_pckunt end,'N/A') as 'ipi_smpunt',
--added by Mark Lau 20060919
isnull(ibi_alsitmno,' ') as  'ibi_alsitmno',			
isnull(ibi_alscolcde,' ') as  'ibi_alscolcde',	
--imu_alsbasprc,
vbi_ventyp,			--Add By Lewis For merge
ibi_catlvl3,				--Add By Lewis For merge
col.icf_colcde as 'icf_colcde',
ipi_qutdat 				-- Add by Joe on 20100416
From IMBASINF (NOLOCK)
left join IMCOLINF col (NOLOCK) on ibi_itmno = icf_itmno and icf_colseq = 1
left join  IMPCKINF  pck (NOLOCK) on --pck.ipi_cocde = ibi_cocde and 
		        pck.ipi_itmno = ibi_itmno and 
			pck.ipi_pckseq = (select min(spk.ipi_pckseq) from 
						impckinf spk (NOLOCK) where --spk.ipi_cocde = ibi_cocde and 
								spk.ipi_itmno = ibi_itmno)
left join VNBASINF (NOLOCK) on vbi_venno = ibi_venno
left join  IMMRKUP (NOLOCK) on --imu_cocde = ibi_cocde and 
			imu_ventyp = case vbi_ventyp when 'E' then 'D' else 'P' end and 
			imu_venno = ibi_venno and 
			imu_itmno = ibi_itmno and 
			pck.ipi_pckunt = imu_pckunt and
			pck.ipi_inrqty = imu_inrqty and
			pck.ipi_mtrqty = imu_mtrqty 
left join SYCONFTR (NOLOCK) on  --ycf_cocde=ibi_cocde and 
		pck.ipi_pckunt = ycf_code1 and ycf_code2 = 'PC' 
left join SYTIESTR (NOLOCK) on ibi_tirtyp = '1' 	and 
			pck.ipi_mtrqty >= yts_qtyfr and 
			pck.ipi_mtrqty <= yts_qtyto and 
			--ibi_cocde = yts_cocde and 
			ibi_venno = yts_venno and 
			yts_tirtyp = 'M' and 
			yts_itmtyp = 'R'
 and
			yts_effdat = (select top 1 yts_effdat from SYTIESTR where yts_venno = ibi_venno order by yts_effdat desc)

,IMVENINF (NOLOCK)
where 
ibi_itmno = ivi_itmno and 
ibi_venno = ivi_venno and 
ibi_venno  not in ('0005','0006','0007','0008','0009') and 
--ivi_cocde = ibi_cocde and
 ibi_tirtyp = '1'  and
--ibi_cocde = 'UCP' and 
ibi_typ = 'reg' and 
(ibi_itmsts = 'CMP' or ibi_itmsts = 'INC') and 
ivi_venitm <> '' and 

(
( (ibi_itmno = @itmno or ibi_alsitmno = @itmno ) and  @isnewitmfmt = 'N' )
or
( ibi_itmno = @itmno  and  @isnewitmfmt = '' )
)

-- Added by Mark Lau 20090318
and imu_std = 'Y'

UNION

Select 
isnull(case when @isnewitmfmt = 'N' then
case when ibi_itmno = @itmno then '' else
case when ibi_alsitmno = @itmno then 'A' end  
end 
end ,'') as 'typ',
ibi_credat,
' ' as 'ibi_cocde',
ibi_itmno,
ivi_venitm,
ibi_engdsc,
ibi_venno,
case rtrim(ltrim(ibi_imgpth)) when '' then 'N' else 'Y' end as ibi_img,
Isnull(pck.ipi_pckseq,1)as  'ipi_pckseq', 
isnull(pck.ipi_inrqty,0) as 'ipi_inrqty', 
isnull(pck.ipi_mtrqty,0) as 'ipi_mtrqty',
isnull(pck.ipi_cft,0) as 'ipi_cft', 
isnull(pck.ipi_pckunt,'N/A') as 'ipi_pckunt', 
isnull(pck.ipi_conftr,1) as 'ipi_conftr',
ibi_tirtyp, 
ibi_moqctn,
ibi_moa,
isnull(imu_bcurcde,'') as'imu_bcurcde', 
isnull(imu_basprc,0) as 'imu_basprc', 
isnull(case ycf_oper when'*'  then 'PC'  when '/' then 'PC' else ipi_pckunt end,'N/A') as 'ipi_smpunt',
--added by Mark Lau 20060919
isnull(ibi_alsitmno,' ') as  'ibi_alsitmno',			
isnull(ibi_alscolcde,' ') as  'ibi_alscolcde',	
--imu_alsbasprc,
vbi_ventyp,
ibi_catlvl3,
col.icf_colcde as 'icf_colcde',
ipi_qutdat 				-- Add by Joe on 20100416
From IMBASINF (NOLOCK)
left join IMCOLINF col (NOLOCK) on ibi_itmno = icf_itmno and icf_colseq = 1
left join  IMPCKINF pck (NOLOCK) on --pck.ipi_cocde = ibi_cocde and 
		            pck.ipi_itmno = ibi_itmno and 
			pck.ipi_pckseq = (select min(spk.ipi_pckseq) from 
						impckinf  spk (NOLOCK) where --spk.ipi_cocde = ibi_cocde and 
								spk.ipi_itmno = ibi_itmno)
left join VNBASINF (NOLOCK) on vbi_venno = ibi_venno
left join  IMMRKUP (NOLOCK) on -- imu_cocde = ibi_cocde and 
			imu_ventyp = case vbi_ventyp when 'E' then 'D' else 'P' end and 
			imu_venno = ibi_venno and 
			imu_itmno = ibi_itmno and 
			pck.ipi_pckunt = imu_pckunt and
			pck.ipi_inrqty = imu_inrqty and
			pck.ipi_mtrqty = imu_mtrqty 
left join SYCONFTR (NOLOCK)  on  --ycf_cocde=ibi_cocde and 
		pck.ipi_pckunt = ycf_code1 and ycf_code2 = 'PC' 

,IMVENINF (NOLOCK)
where 
ibi_itmno= ivi_itmno and
ibi_venno = ivi_venno and 
ibi_venno  not in ('0005','0006','0007','0008','0009') and 
--ibi_cocde = ivi_cocde and
--ibi_cocde = 'UCP' and 
ibi_typ = 'reg' and 
ibi_tirtyp = '2' and 
(ibi_itmsts = 'CMP' or ibi_itmsts = 'INC') and 
ivi_venitm <> '' and 
(
( (ibi_itmno = @itmno or ibi_alsitmno = @itmno ) and  @isnewitmfmt = 'N' )
or
( ibi_itmno = @itmno  and  @isnewitmfmt = '' )
)
-- Added by Mark Lau 20090318
and imu_std = 'Y'
/***************************Lester Wu 2006-03-21*******************************************/
UNION

Select 
isnull(case when @isnewitmfmt = 'N' then
case when ibi_itmno = @itmno then '' else
case when ibi_alsitmno = @itmno then 'A' end  
end 
end ,'') as 'typ',
ibi_credat,
' ' as 'ibi_cocde',
ibi_itmno,
ivi_venitm,
ibi_engdsc,
ibi_venno,
case rtrim(ltrim(ibi_imgpth)) when '' then 'N' else 'Y' end as ibi_img,
Isnull(pck.ipi_pckseq,1)as  'ipi_pckseq', 
isnull(pck.ipi_inrqty,0) as 'ipi_inrqty', 
isnull(pck.ipi_mtrqty,0) as 'ipi_mtrqty',
isnull(pck.ipi_cft,0) as 'ipi_cft', 
isnull(pck.ipi_pckunt,'N/A') as 'ipi_pckunt', 
isnull(pck.ipi_conftr,1) as 'ipi_conftr',
ibi_tirtyp, 
isnull(yts_moq,0) as 'ibi_moqctn',
isnull(yts_moa,0) as 'ibi_moa',
isnull(imu_bcurcde,'') as'imu_bcurcde', 
isnull(imu_basprc,0) as 'imu_basprc', 
isnull(case ycf_oper when'*'  then 'PC'  when '/' then 'PC' else ipi_pckunt end,'N/A') as 'ipi_smpunt',
--added by Mark Lau 20060919
isnull(ibi_alsitmno,' ') as  'ibi_alsitmno',			
isnull(ibi_alscolcde,' ') as  'ibi_alscolcde',	
--imu_alsbasprc,
vbi_ventyp,			--Add By Lewis For merge
ibi_catlvl3		,		--Add By Lewis For merge
col.icf_colcde as 'icf_colcde',
ipi_qutdat 				-- Add by Joe on 20100416
From 
IMPDAINF(NOLOCK)
left join IMCOLINF col (NOLOCK) on pda_itmno = icf_itmno and icf_colseq = 1
left join IMBASINF (NOLOCK) on pda_itmno = ibi_itmno
left join  IMPCKINF  pck (NOLOCK) on --pck.ipi_cocde = ibi_cocde and 
		        pck.ipi_itmno = ibi_itmno and 
			pck.ipi_pckseq = (select min(spk.ipi_pckseq) from 
						impckinf spk (NOLOCK) where --spk.ipi_cocde = ibi_cocde and 
								spk.ipi_itmno = ibi_itmno)
left join VNBASINF (NOLOCK) on vbi_venno = ibi_venno
left join  IMMRKUP (NOLOCK) on --imu_cocde = ibi_cocde and 
			imu_ventyp = case vbi_ventyp when 'E' then 'D' else 'P' end and 
			imu_venno = ibi_venno and 
			imu_itmno = ibi_itmno and 
			pck.ipi_pckunt = imu_pckunt and
			pck.ipi_inrqty = imu_inrqty and
			pck.ipi_mtrqty = imu_mtrqty 
left join SYCONFTR (NOLOCK) on  --ycf_cocde=ibi_cocde and 
		pck.ipi_pckunt = ycf_code1 and ycf_code2 = 'PC' 
left join SYTIESTR (NOLOCK) on ibi_tirtyp = '1' 	and 
			pck.ipi_mtrqty >= yts_qtyfr and 
			pck.ipi_mtrqty <= yts_qtyto and 
			--ibi_cocde = yts_cocde and 
			ibi_venno = yts_venno and 
			yts_tirtyp = 'M' and 
			yts_itmtyp = 'R'
 and
			yts_effdat = (select top 1 yts_effdat from SYTIESTR where yts_venno = ibi_venno order by yts_effdat desc)

,IMVENINF (NOLOCK)
where 

ibi_itmno = ivi_itmno and 
ibi_venno = ivi_venno and 
ibi_venno  not in ('0005','0006','0007','0008','0009') and 
--ivi_cocde = ibi_cocde and
 ibi_tirtyp = '1'  and
--ibi_cocde = 'UCP' and 
ibi_typ = 'reg' and 
(ibi_itmsts = 'CMP' or ibi_itmsts = 'INC') and 
ivi_venitm <> '' and 
--ibi_credat between @START  and @END
--pda_credat between @START  and @END and
ibi_itmno is not null 
and
(
( (pda_itmno = @itmno or ibi_alsitmno = @itmno ) and  @isnewitmfmt = 'N' )
or
( pda_itmno = @itmno  and  @isnewitmfmt = '' )
)
-- Added by Mark Lau 20090318
and imu_std = 'Y'

UNION

Select 
isnull(case when @isnewitmfmt = 'N' then
case when ibi_itmno = @itmno then '' else
case when ibi_alsitmno = @itmno then 'A' end  
end 
end ,'') as 'typ',
ibi_credat,
' ' as 'ibi_cocde',
ibi_itmno,
ivi_venitm,
ibi_engdsc,
ibi_venno,
case rtrim(ltrim(ibi_imgpth)) when '' then 'N' else 'Y' end as ibi_img,
Isnull(pck.ipi_pckseq,1)as  'ipi_pckseq', 
isnull(pck.ipi_inrqty,0) as 'ipi_inrqty', 
isnull(pck.ipi_mtrqty,0) as 'ipi_mtrqty',
isnull(pck.ipi_cft,0) as 'ipi_cft', 
isnull(pck.ipi_pckunt,'N/A') as 'ipi_pckunt', 
isnull(pck.ipi_conftr,1) as 'ipi_conftr',
ibi_tirtyp, 
ibi_moqctn,
ibi_moa,
isnull(imu_bcurcde,'') as'imu_bcurcde', 
isnull(imu_basprc,0) as 'imu_basprc', 
isnull(case ycf_oper when'*'  then 'PC'  when '/' then 'PC' else ipi_pckunt end,'N/A') as 'ipi_smpunt',
--added by Mark Lau 20060919
isnull(ibi_alsitmno,' ') as  'ibi_alsitmno',			
isnull(ibi_alscolcde,' ') as  'ibi_alscolcde',	
--imu_alsbasprc,
vbi_ventyp,
ibi_catlvl3,
col.icf_colcde as 'icf_colcde',
ipi_qutdat 				-- Add by Joe on 20100416
From 
IMPDAINF (NOLOCK)
left join IMCOLINF col (NOLOCK) on pda_itmno = icf_itmno and icf_colseq = 1
left join  IMBASINF (NOLOCK) on pda_itmno = ibi_itmno
left join  IMPCKINF pck (NOLOCK) on --pck.ipi_cocde = ibi_cocde and 
		            pck.ipi_itmno = ibi_itmno and 
			pck.ipi_pckseq = (select min(spk.ipi_pckseq) from 
						impckinf  spk (NOLOCK) where --spk.ipi_cocde = ibi_cocde and 
								spk.ipi_itmno = ibi_itmno)
left join VNBASINF (NOLOCK) on vbi_venno = ibi_venno
left join  IMMRKUP (NOLOCK) on -- imu_cocde = ibi_cocde and 
			imu_ventyp = case vbi_ventyp when 'E' then 'D' else 'P' end and 
			imu_venno = ibi_venno and 
			imu_itmno = ibi_itmno and 
			pck.ipi_pckunt = imu_pckunt and
			pck.ipi_inrqty = imu_inrqty and
			pck.ipi_mtrqty = imu_mtrqty 
left join SYCONFTR (NOLOCK)  on  --ycf_cocde=ibi_cocde and 
		pck.ipi_pckunt = ycf_code1 and ycf_code2 = 'PC' 

,IMVENINF (NOLOCK)
where 
ibi_itmno= ivi_itmno and
ibi_venno = ivi_venno and 
ibi_venno  not in ('0005','0006','0007','0008','0009') and 
--ibi_cocde = ivi_cocde and
--ibi_cocde = 'UCP' and 
ibi_typ = 'reg' and 
ibi_tirtyp = '2' and 
(ibi_itmsts = 'CMP' or ibi_itmsts = 'INC') and 
ivi_venitm <> '' and 
--ibi_credat between @START  and @END
--pda_credat between @START  and @END and
ibi_itmno is not null 
and 
(
( (pda_itmno = @itmno or ibi_alsitmno = @itmno ) and  @isnewitmfmt = 'N' )
or
( pda_itmno = @itmno  and  @isnewitmfmt = '' )
)
-- Added by Mark Lau 20090318
and imu_std = 'Y'

/***************************Lester Wu 2006-03-21*******************************************/
--Mark Lau 20060919, change sorting from 1, 3 to ibi_itmno
order by ibi_itmno










GO
GRANT EXECUTE ON [dbo].[sp_select_PDA_Item_GetItem] TO [ERPUSER] AS [dbo]
GO
