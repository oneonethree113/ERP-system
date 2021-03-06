/****** Object:  StoredProcedure [dbo].[sp_list_IMR00011]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_IMR00011]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_IMR00011]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



CREATE     PROCEDURE [dbo].[sp_list_IMR00011]

@cocde as nvarchar(6),
@stage as nvarchar(30),
@fromvenno as nvarchar(6),
@tovenno as nvarchar(6),
@fromcredat as nvarchar(10),
@tocredat as nvarchar(10)
-- 2004/03/08 Lester Wu
,@usrid as nvarchar(30)
-------------------------------


as

declare @string as nvarchar(4000)


declare 	@VenTypFm	as	char(1),
	@VenTypTo	as	char(1)
	

SET @VenTypFm=''
SET @VenTypTo=''

--select distinct @VenTypFm = 
--		case when isnull(yuc_flgcstext,'')='1' then 'E'
--		 	when isnull(yuc_flgcstext,'')='0' then case when isnull(yuc_flgcst,'') = '1' then 'I' else '' end 
--			else '' end,
--	 @VenTypTo = 
--		case when isnull(yuc_flgcst,'')='1' then 'J'
--		 	when isnull(yuc_flgcst,'')='0' then case when isnull(yuc_flgcstext,'') = '1' then 'E' else '' end 
--			else '' end
		--,yuc_usrid,yuc_flgcst,yuc_flgcstext
--from SYMUSRCO
--where yuc_usrid=@usrid

--select @VenTypFm,@VenTypTo

---	 EXT	INT	Ven Fm	Ven To
---------------------------------------------------------------------
--	   1	  1	     E	     J
--	   1	  0	     E	     E
--	   0	  1	     I	     J
--	   0	  0	   N/A	   N/A
----------------------------------------------------------------------

set @string = 
'select 
a.imd_stage, a.imd_itmno, a.imd_venno, a.imd_prdven, a.imd_credat ,  a.imd_lnecde, a.imd_engdsc, 
a.imd_untcde, a.imd_conftr,  a.imd_inrqty, a.imd_mtrqty, a.imd_fcttl, 
a.imd_sysmsg + '' ('' +a.imd_xlsfil  + '')'' as imd_sysmsg
,''' + 
replace(@stage,'@',' ') + ''',''' + @fromvenno + ''','''  + @tovenno + ''',''' + @fromcredat + ''',''' + @tocredat +  '''
,vbi_ventyp
 from  (select * from immmitmdat union select * from immmitmdath) a
 left join VNBASINF on a.imd_venno = vbi_venno
 where
--a.iid_cocde = ''' +@cocde + ''' and 
 a.imd_stage in (' + replace(@stage,'@','''') + ') and 
 a.imd_venno  between ''' + @fromvenno + ''' and ''' + @tovenno + ''' and
 a.imd_credat  between ''' + @fromcredat + ' 00:00:00' + ''' and ''' + @tocredat + ' 23:59:59' + ''' 
-- and ''' + @VenTypFm + '''<>'''' 
--and  isnull(vbi_ventyp,'''') between ''' + @VenTypFm + ''' and ''' + @VenTypTo + '''
 order by a.imd_stage, a.imd_venno,  cast(a.imd_credat as smalldatetime)'

--select @string,len(@string)

exec( @string)

--exec( @string)



GO
GRANT EXECUTE ON [dbo].[sp_list_IMR00011] TO [ERPUSER] AS [dbo]
GO
