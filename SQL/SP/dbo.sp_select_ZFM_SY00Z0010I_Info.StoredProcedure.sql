/****** Object:  StoredProcedure [dbo].[sp_select_ZFM_SY00Z0010I_Info]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_ZFM_SY00Z0010I_Info]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_ZFM_SY00Z0010I_Info]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO





--sp_select_ZFM_SY00Z0010I_Info '','1010'
CREATE procedure [dbo].[sp_select_ZFM_SY00Z0010I_Info]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

@cocde nvarchar(6) ,
@SalOrg Nvarchar(4)      

---------------------------------------------- 
 
AS


begin

select

--GOODS RECIPIENT FOR PRIMARY CUSTOMER
'50000000' as 'KUNNR',
'' as 'BUKRS',
@SalOrg as 'VKORG',
'10' as 'VTWEG',
 '00' as 'SPART',
 '0002' as 'KTOKD',
'' as 'TITLE',
'DUMMY' as 'NAME1', 
''   as 'NAME2', 
'' AS 'NAME3',
'' AS 'NAME4',
'50000000'  as 'SORT1',
'DUMMY'  AS 'SORT2',
'BLOCK C, 6/F., ELDEX INDUSTRIAL BUILDING, 21 MA TAU WAI ROAD' as 'STREET', 
'HUNG HOM' AS 'STR_SUPPL3',
'KOWLOON' AS 'LOCATION',
'' AS 'CITY2',
''  as 'POST_CODE1',
'HONG KONG' as 'CITY1',
'HK' as 'COUNTRY', 
 '' as 'REGION',
 '' AS 'TAXJURCODE',
 'E' as 'LANGU', 
'' as 'TEL_NUMBER', '' AS 'TEL_EXTENS',
'' AS 'MOB_NUMBER',
'' as 'FAX_NUMBER', '' as 'FAX_EXTENS',
'' as 'SMTP_ADDR',
'1131010000' AS 'AKONT',
'' AS 'ZTERM',
 '001' AS 'BZIRK',
 '001'  as 'VKBUR', 
 '015'  as 'VKGRP' ,
 '01'    as 'KDGRP',
'USD'  as 'WAERS',
'01' AS 'VSBED',
'' as 'INCO1',
'' as 'INCO2',
'' as 'ZTERM_S',
'Z1' AS 'KTGRD',
'1' AS 'ORDER'
 from cubasinf where cbi_cusno = '50001'

union

select
--GOODS RECIPIENT FOR PRIMARY CUSTOMER
cci_sapshcusno as 'KUNNR',
'' as 'BUKRS',
@SalOrg as 'VKORG',
'10' as 'VTWEG',
 '00' as 'SPART',
 '0002' as 'KTOKD',
'' AS 'TITLE',
left(cbi_cusnam,35) as 'NAME1', 
case when len(cbi_cusnam) > 35 then right (cbi_cusnam,  len(cbi_cusnam)-35) else '' end  as 'NAME2', 
'' AS 'NAME3',
'' AS 'NAME4',
cbi_cusno as 'SORT1',
cbi_cussna AS 'SORT2',
'BLOCK C, 6/F., ELDEX INDUSTRIAL BUILDING, 21 MA TAU WAI ROAD' as 'STREET', 
'HUNG HOM' AS 'STR_SUPPL3',
'KOWLOON' AS 'LOCATION',
'' AS 'CITY2',
''  as 'POST_CODE1',
'HONG KONG' as 'CITY1',
cci_cntcty as 'COUNTRY', 
'' as 'REGION',
'' AS 'TAXJURCODE',
 'E' as 'LANGU', 
'' as 'TEL_NUMBER', '' AS 'TEL_EXTENS',
'' AS 'MOB_NUMBER',
'' as 'FAX_NUMBER', '' as 'FAX_EXTENS',
'' as 'SMTP_ADDR',
'1131010000' AS 'AKONT',
'' AS 'ZTERM',
case cbi_mrkreg
    when 'ASIA PACIFIC' then '001'
    when ' CENTRAL AMERIC' then '002'
     when 'CENTRAL EUROPE' then '003'
     when 'EASTERN EUROPE' then '004'
    when 'NORTH AMERICA' then '005'
      when 'NORTHERN EUROP' then '006'
     when 'OTHER REGIONS' then '007'
     when ' SOUTH AMERICA' then '008'
     when 'WESTERN EUROPE' then '009'
     else '010'
end AS 'BZIRK',

case  ysr_saltem	 when   'A' then '001'   
	  	when 'B' then '001'   
 	 	when 'C' then '001'   	
		when 'D' then '002' 
		when 'E' then '002' 
		when 'F' then '002' 
		when 'G' then '002' 
		when 'H' then '003' 
		when 'I' then '003'
		when 'J' then '003' 
		when 'K' then '001' 
		when 'L' then '001' 
		when 'M' then '001' 
		when 'N' then '003' 
		when 'S' then '001' 
		else '*'
end as 'VKBUR', 

case  ysr_saltem	 when   'A' then '001'   
	  	when 'B' then '002'   
 	 	when 'C' then '003'   	
		when 'D' then '004' 
		when 'E' then '005' 
		when 'F' then '006' 
		when 'G' then '007' 
		when 'H' then '008' 
		when 'I' then '009'
		when 'J' then '010' 
		when 'K' then '011' 
		when 'L' then '012' 
		when 'M' then '013' 
		when 'N' then '014' 
		when 'S' then '015' 
		else '*'
end as 'VKGRP' ,

case upper(t.ysi_cde) 	when  'CCH' then '01'   
	  	when 'CGR' then '02'   
 	 	when 'DIS' then '03'   	
		when 'DPT' then '04' 
		when 'IMP' then '05' 
		when 'MAL' then '06' 
		when 'MMD' then '07' 
		when 'OTH' then '08' 
		when 'RET' then '09'
		when 'TRD' then '10' 
		when 'WHL' then '11' 
		else ''
 end  as 'KDGRP',
case  when cpi_curcde = '' then '' else cpi_curcde end  as 'WAERS',
'01' AS 'VSBED',
case when cpi_prctrm = '' then '' else substring(cpi_prctrm,1,3) end as 'INCO1',
case when cpi_prctrm = '' then '' else 
 case substring(cpi_prctrm,5,2) 
when  'HK' then 'HONG KONG'  
when  'YT' then 'YANTIAN'  
when  'ZS' then 'ZHONGSHAN'  
when  'JX' then ' JIANG XI'
else substring(cpi_prctrm,5,2) 
end
end as 'INCO2',
isnull(ypm_sappayterm,'') as 'ZTERM_S',
'Z1' AS 'KTGRD'
,'1' AS 'ORDER'
 from cubasinf 
left join cuprcinf on cpi_cusno = cbi_cusno
left join sysalrep on cbi_salrep = ysr_code1
left join sysetinf t on cbi_mrktyp = t.ysi_cde and t.ysi_typ = '08'
left join sysetinf p on cpi_paytrm = p.ysi_cde and p.ysi_typ = '04'
left join sypaytermmap on ypm_erppayterm = p.ysi_cde 
left join cucntinf on cci_cusno = cbi_cusno
where cbi_cusno like '5%'   and CCI_CNTTYP in ('M','S','B') 

union 

select
--GOODS RECIPIENT FOR SECONDARY CUSTOMER
cci_sapshcusno as 'KUNNR',
'' as 'BUKRS',
@SalOrg as 'VKORG',
'10' as 'VTWEG',
 '00' as 'SPART',
 '0002' as 'KTOKD',
'' AS 'TITLE',
left(cbi_cusnam,35) as 'NAME1', 
case when len(cbi_cusnam) > 35 then right (cbi_cusnam,  len(cbi_cusnam)-35) else '' end  as 'NAME2', 
'' AS 'NAME3',
'' AS 'NAME4',
cbi_cusno as 'SORT1', 
cbi_cussna AS 'SORT2',
'BLOCK C, 6/F., ELDEX INDUSTRIAL BUILDING, 21 MA TAU WAI ROAD' as 'STREET', 
'HUNG HOM' AS 'STR_SUPPL3',
'KOWLOON' AS 'LOCATION',
'' AS 'CITY2',
'' as 'POST_CODE1',
'HONG KONG' as 'CITY1',
cci_cntcty as 'COUNTRY', 
''  as 'REGION',
''  AS 'TAXJURCODE',
 'E' as 'LANGU', 
'' as 'TEL_NUMBER', '' AS 'TEL_EXTENS',
'' AS 'MOB_NUMBER',
'' as 'FAX_NUMBER', '' as 'FAX_EXTENS',
'' as 'SMTP_ADDR',
'1131010000' AS 'AKONT',
'' AS 'ZTERM',

case cbi_mrkreg
    when 'ASIA PACIFIC' then '001'
    when ' CENTRAL AMERIC' then '002'
     when 'CENTRAL EUROPE' then '003'
     when 'EASTERN EUROPE' then '004'
    when 'NORTH AMERICA' then '005'
      when 'NORTHERN EUROP' then '006'
     when 'OTHER REGIONS' then '007'
     when ' SOUTH AMERICA' then '008'
     when 'WESTERN EUROPE' then '009'
     else '010'
end AS 'BZIRK',

case  ysr_saltem	 when   'A' then '001'   
	  	when 'B' then '001'   
 	 	when 'C' then '001'   	
		when 'D' then '002' 
		when 'E' then '002' 
		when 'F' then '002' 
		when 'G' then '002' 
		when 'H' then '003' 
		when 'I' then '003'
		when 'J' then '003' 
		when 'K' then '001' 
		when 'L' then '001' 
		when 'M' then '001' 
		when 'N' then '003' 
		when 'S' then '001' 
		else '*'
end as 'VKBUR', 

case  ysr_saltem	 when   'A' then '001'   
	  	when 'B' then '002'   
 	 	when 'C' then '003'   	
		when 'D' then '004' 
		when 'E' then '005' 
		when 'F' then '006' 
		when 'G' then '007' 
		when 'H' then '008' 
		when 'I' then '009'
		when 'J' then '010' 
		when 'K' then '011' 
		when 'L' then '012' 
		when 'M' then '013' 
		when 'N' then '014' 
		when 'S' then '015' 
		else '*'
end as 'VKGRP' ,

case upper(t.ysi_cde) 	when  'CCH' then '01'   
	  	when 'CGR' then '02'   
 	 	when 'DIS' then '03'   	
		when 'DPT' then '04' 
		when 'IMP' then '05' 
		when 'MAL' then '06' 
		when 'MMD' then '07' 
		when 'OTH' then '08' 
		when 'RET' then '09'
		when 'TRD' then '10' 
		when 'WHL' then '11' 
		else ''
 end  as 'KDGRP',
case  when cpi_curcde = '' then '' else cpi_curcde end  as 'WAERS',
'01' AS 'VSBED',
case when cpi_prctrm = '' then '' else substring(cpi_prctrm,1,3) end as 'INCO1',
case when cpi_prctrm = '' then '' else 
 case substring(cpi_prctrm,5,2) 
when  'HK' then 'HONG KONG'  
when  'YT' then 'YANTIAN'  
when  'ZS' then 'ZHONGSHAN'  
when  'JX' then ' JIANG XI'
else substring(cpi_prctrm,5,2) 
end
end as 'INCO2',
isnull(ypm_sappayterm,'') as 'ZTERM_S',
'Z1' AS 'KTGRD'
,'2' AS 'ORDER'
 from cubasinf 
left join cuprcinf on cpi_cusno = cbi_cusno

left join sysalrep on cbi_salrep = ysr_code1
left join sysetinf t on cbi_mrktyp = t.ysi_cde and t.ysi_typ = '08'
left join sysetinf p on cpi_paytrm = p.ysi_cde and p.ysi_typ = '04'
left join sypaytermmap on ypm_erppayterm = p.ysi_cde 
left join cucntinf on cci_cusno = cbi_cusno


where cbi_cusno like '6%'   and CCI_CNTTYP in ('M','S','B') 

union 



--SECONDARY CUSTOMERS
select
cbi_cusno as 'KUNNR',
'' as 'BUKRS',
@SalOrg as 'VKORG',
'10' as 'VTWEG',
 '00' as 'SPART',
 'Z1' as 'KTOKD',
'' AS 'TITLE',
left(cbi_cusnam,35) as 'NAME1', 
case when len(cbi_cusnam) > 35 then right (cbi_cusnam,  len(cbi_cusnam)-35) else '' end  as 'NAME2', 
'' AS 'NAME3',
'' AS 'NAME4',
cbi_cusno as 'SORT1',
cbi_cussna AS 'SORT2',
'BLOCK C, 6/F., ELDEX INDUSTRIAL BUILDING, 21 MA TAU WAI ROAD' as 'STREET', 
'HUNG HOM' AS 'STR_SUPPL3',
'KOWLOON' AS 'LOCATION',
'' AS 'CITY2', 
'' as 'POST_CODE1',
'HONG KONG' as 'CITY1',
cci_cntcty as 'COUNTRY', 
'' as 'REGION',
'' AS 'TAXJURCODE',
 'E' as 'LANGU', 
'' as 'TEL_NUMBER', '' AS 'TEL_EXTENS',
'' AS 'MOB_NUMBER',
'' as 'FAX_NUMBER', '' as 'FAX_EXTENS',
'' as 'SMTP_ADDR',
'1131010000' AS 'AKONT',
'' AS 'ZTERM',
case cbi_mrkreg
    when 'ASIA PACIFIC' then '001'
    when ' CENTRAL AMERIC' then '002'
     when 'CENTRAL EUROPE' then '003'
     when 'EASTERN EUROPE' then '004'
    when 'NORTH AMERICA' then '005'
      when 'NORTHERN EUROP' then '006'
     when 'OTHER REGIONS' then '007'
     when ' SOUTH AMERICA' then '008'
     when 'WESTERN EUROPE' then '009'
     else '010'
end AS 'BZIRK',

case  ysr_saltem	 when   'A' then '001'   
	  	when 'B' then '001'   
 	 	when 'C' then '001'   	
		when 'D' then '002' 
		when 'E' then '002' 
		when 'F' then '002' 
		when 'G' then '002' 
		when 'H' then '003' 
		when 'I' then '003'
		when 'J' then '003' 
		when 'K' then '001' 
		when 'L' then '001' 
		when 'M' then '001' 
		when 'N' then '003' 
		when 'S' then '001'
		else '*'
end as 'VKBUR', 

case  ysr_saltem	 when   'A' then '001'   
	  	when 'B' then '002'   
 	 	when 'C' then '003'   	
		when 'D' then '004' 
		when 'E' then '005' 
		when 'F' then '006' 
		when 'G' then '007' 
		when 'H' then '008' 
		when 'I' then '009'
		when 'J' then '010' 
		when 'K' then '011' 
		when 'L' then '012' 
		when 'M' then '013' 
		when 'N' then '014' 
		when 'S' then '015' 
		else '*'
end as 'VKGRP' ,

case upper(t.ysi_cde) 	when  'CCH' then '01'   
	  	when 'CGR' then '02'   
 	 	when 'DIS' then '03'   	
		when 'DPT' then '04' 
		when 'IMP' then '05' 
		when 'MAL' then '06' 
		when 'MMD' then '07' 
		when 'OTH' then '08' 
		when 'RET' then '09'
		when 'TRD' then '10' 
		when 'WHL' then '11' 
		else ''
 end  as 'KDGRP',
case  when cpi_curcde = '' then '' else cpi_curcde end  as 'WAERS',
'01' AS 'VSBED',
case when cpi_prctrm = '' then '' else substring(cpi_prctrm,1,3) end as 'INCO1',
case when cpi_prctrm = '' then '' else 
 case substring(cpi_prctrm,5,2) 
when  'HK' then 'HONG KONG'  
when  'YT' then 'YANTIAN'  
when  'ZS' then 'ZHONGSHAN'  
when  'JX' then ' JIANG XI'
else substring(cpi_prctrm,5,2) 
end
end as 'INCO2',
isnull(ypm_sappayterm,'') as 'ZTERM_S',
'Z1' AS 'KTGRD'
,'3' AS 'ORDER'
 from cubasinf 
left join cuprcinf on cpi_cusno = cbi_cusno
left join sysalrep on cbi_salrep = ysr_code1
left join sysetinf t on cbi_mrktyp =t.ysi_cde and t.ysi_typ = '08'
left join sysetinf p on cpi_paytrm = p.ysi_cde and p.ysi_typ = '04'
left join sypaytermmap on ypm_erppayterm = p.ysi_cde
left join cucntinf on cci_cusno = cbi_cusno and cci_cnttyp = 'M' and cci_cntseq = '1'
where cbi_cusno like '6%' 

UNION

select
--PRIMARY CUSTOMER
 cbi_cusno as 'KUNNR', --MANDATORY
'' as 'BUKRS', --MANDATORY
@SalOrg as 'VKORG', --MANDATORY
'10' as 'VTWEG', --MANDATORY
 '00' as 'SPART', --MANDATORY
 '0001' as 'KTOKD', --MANDATORY
'' AS 'TITLE',
left(cbi_cusnam,35) as 'NAME1', --MANDATORY
case when len(cbi_cusnam) > 35 then right (cbi_cusnam,  len(cbi_cusnam)-35) else '' end  as 'NAME2', 
'' as 'NAME3',
'' as 'NAME4',
cbi_cusno as 'SORT1', --MANDATORY
cbi_cussna as 'SORT2',
'BLOCK C, 6/F., ELDEX INDUSTRIAL BUILDING, 21 MA TAU WAI ROAD' as 'STREET', 
'HUNG HOM' AS 'STR_SUPPL3',
'KOWLOON' AS 'LOCATION',
'' AS 'CITY2',
'' as 'POST_CODE1',  --Max. 10 length
'HONG KONG' as 'CITY1',
cci_cntcty as 'COUNTRY', 
'' as 'REGION',
'' AS 'TAXJURCODE',
 'E' as 'LANGU', 
'' as 'TEL_NUMBER', '' AS 'TEL_EXTENS',
'' AS 'MOB_NUMBER',
'' as 'FAX_NUMBER', '' as 'FAX_EXTENS',
'' as 'SMTP_ADDR',
'1131010000' AS 'AKONT',
'' AS 'ZTERM',
case cbi_mrkreg
    when 'ASIA PACIFIC' then '001'
    when ' CENTRAL AMERIC' then '002'
     when 'CENTRAL EUROPE' then '003'
     when 'EASTERN EUROPE' then '004'
    when 'NORTH AMERICA' then '005'
      when 'NORTHERN EUROP' then '006'
     when 'OTHER REGIONS' then '007'
     when ' SOUTH AMERICA' then '008'
     when 'WESTERN EUROPE' then '009'
     else '010'
end AS 'BZIRK',

case  ysr_saltem	 when   'A' then '001'   
	  	when 'B' then '001'   
 	 	when 'C' then '001'   	
		when 'D' then '002' 
		when 'E' then '002' 
		when 'F' then '002' 
		when 'G' then '002' 
		when 'H' then '002' 
		when 'I' then '003'
		when 'J' then '003' 
		when 'K' then '003' 
		when 'L' then '001' 
		when 'M' then '001' 
		when 'N' then '003' 
		when 'S' then '001'  -- Which Code should be assigned for Team S
		else '*'
end as 'VKBUR', 

case  ysr_saltem	 when   'A' then '001'   
	  	when 'B' then '002'   
 	 	when 'C' then '003'   	
		when 'D' then '004' 
		when 'E' then '005' 
		when 'F' then '006' 
		when 'G' then '007' 
		when 'H' then '008' 
		when 'I' then '009'
		when 'J' then '010' 
		when 'K' then '011' 
		when 'L' then '012' 
		when 'M' then '013' 
		when 'N' then '014' 
		when 'S' then '015' 
		else '*'
end as 'VKGRP' ,

case upper(t.ysi_cde) 	when  'CCH' then '01'   
	  	when 'CGR' then '02'   
 	 	when 'DIS' then '03'   	
		when 'DPT' then '04' 
		when 'IMP' then '05' 
		when 'MAL' then '06' 
		when 'MMD' then '07' 
		when 'OTH' then '08' 
		when 'RET' then '09'
		when 'TRD' then '10' 
		when 'WHL' then '11' 
		else ''
 end  as 'KDGRP',
case  when cpi_curcde = '' then '' else cpi_curcde end  as 'WAERS',
'01' AS 'VSBED',
case when cpi_prctrm = '' then '' else substring(cpi_prctrm,1,3) end as 'INCO1',
case when cpi_prctrm = '' then '' else 
 case substring(cpi_prctrm,5,2) 
when  'HK' then 'HONG KONG'  
when  'YT' then 'YANTIAN'  
when  'ZS' then 'ZHONGSHAN'  
when  'JX' then ' JIANG XI'
else substring(cpi_prctrm,5,2) 
end
end as 'INCO2',
isnull(ypm_sappayterm,'') as 'ZTERM_S',
'Z1' AS 'KTGRD'
,'4' AS 'ORDER'
from cubasinf 
left join cuprcinf on cpi_cusno = cbi_cusno
left join sysalrep on cbi_salrep = ysr_code1
left join sysetinf t on cbi_mrktyp = t.ysi_cde and t.ysi_typ = '08'
left join sysetinf p on cpi_paytrm = p.ysi_cde and p.ysi_typ = '04'
left join sypaytermmap on ypm_erppayterm = p.ysi_cde
left join cucntinf on cci_cusno = cbi_cusno and cci_cnttyp = 'M' and cci_cntseq = '1'
where cbi_cusno like '5%'  and isnull(ypm_sappayterm,'') <> '' --order by cbi_cusno asc



 order by [ORDER] , kunnr asc


end



GO
GRANT EXECUTE ON [dbo].[sp_select_ZFM_SY00Z0010I_Info] TO [ERPUSER] AS [dbo]
GO
