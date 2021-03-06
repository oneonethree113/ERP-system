/****** Object:  StoredProcedure [dbo].[sp_list_IMR00004]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_IMR00004]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_IMR00004]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO










/*
=========================================================
Program ID	: 	sp_list_IMR00004
Description   	: 	list Item Validation Entries
Programmer  	: 	Lester Wu
=========================================================
 Modification History                                    
=========================================================

=========================================================
*/

CREATE PROCEDURE [dbo].[sp_list_IMR00004]

@cocde as nvarchar(6),
@stage as nvarchar(30),

@fromvenno as nvarchar(6),
@tovenno as nvarchar(6),
@fromcredat as nvarchar(10),
@tocredat as nvarchar(10),
@bomflg as nvarchar(1),
@usrid as nvarchar(30)
-------------------------------


as

declare @string as nvarchar(4000)


declare 	@VenTypFm	as	char(1),
	@VenTypTo	as	char(1)
	

SET @VenTypFm=''
SET @VenTypTo=''

select distinct @VenTypFm = 
		case when isnull(yuc_flgcstext,'')='1' then 'E'
		 	when isnull(yuc_flgcstext,'')='0' then case when isnull(yuc_flgcst,'') = '1' then 'I' else '' end 
			else '' end,
	 @VenTypTo = 
		case when isnull(yuc_flgcst,'')='1' then 'J'
		 	when isnull(yuc_flgcst,'')='0' then case when isnull(yuc_flgcstext,'') = '1' then 'E' else '' end 
			else '' end

from SYMUSRCO
where yuc_usrid=@usrid

/*
set @string = 
'select 
a.iid_stage, a.iid_venno, a.iid_prdven, convert(varchar,a.iid_credat,101) as iid_credat , a.iid_venitm, a.iid_lnecde, a.iid_engdsc, 
a.iid_untcde, a.iid_conftr,  a.iid_inrqty, a.iid_mtrqty, a.iid_ftyprc, 
a.iid_sysmsg + '' ('' +a.iid_xlsfil  + '')'' as iid_sysmsg
,''' + 
replace(@stage,'@',' ') + ''',''' + @fromvenno + ''','''  + @tovenno + ''',''' + @fromcredat + ''',''' + @tocredat +  '''
,vbi_ventyp
 from  (select * from imitmdat union select * from imitmdath) a
 left join VNBASINF on a.iid_venno = vbi_venno
 where
--a.iid_cocde = ''' +@cocde + ''' and 
 a.iid_stage in (' + replace(@stage,'@','''') + ') and 
 a.iid_venno  between ''' + @fromvenno + ''' and ''' + @tovenno + ''' and
 a.iid_credat  between ''' + @fromcredat + ' 00:00:00' + ''' and ''' + @tocredat + ' 23:59:59' + ''' 
-- and ''' + @VenTypFm + '''<>'''' 
and  isnull(vbi_ventyp,'''') between ''' + @VenTypFm + ''' and ''' + @VenTypTo + '''
 order by a.iid_stage, a.iid_venno,  cast(a.iid_credat as smalldatetime), a.iid_venitm'
*/
set @string = 
'select iid_stage, iid_venno, iid_prdven, convert(varchar,iid_credat,101) as iid_credat, 
iid_venitm, iid_lnecde, iid_engdsc, iid_untcde, iid_conftr, iid_inrqty, iid_mtrqty, iid_ftyprc, 
iid_sysmsg + '' ('' +iid_xlsfil  + '')'' as iid_sysmsg,''' + replace(@stage,'@',' ') + ''',''' + 
@fromvenno + ''','''  + @tovenno + ''',''' + @fromcredat + ''',''' + @tocredat + ''', vbi_ventyp
from	(select * from IMITMDAT (nolock) union select * from IMITMDATH (nolock)) im
left join VNBASINF (nolock) on iid_venno = vbi_venno
where iid_stage in (' + replace(@stage,'@','''') + ') and
((iid_venno between ''' + @fromvenno + ''' and ''' + @tovenno + ''') or (''' + @bomflg + ''' = ''Y'' and iid_itmtyp = ''BOM'')) and
iid_credat  between ''' + @fromcredat + ' 00:00:00' + ''' and ''' + @tocredat + ' 23:59:59' + ''' and
isnull(vbi_ventyp,'''') between ''' + @VenTypFm + ''' and ''' + @VenTypTo + '''
order by iid_stage, iid_venno,  cast(iid_credat as smalldatetime), iid_venitm'

exec( @string)
--print @string









GO
GRANT EXECUTE ON [dbo].[sp_list_IMR00004] TO [ERPUSER] AS [dbo]
GO
