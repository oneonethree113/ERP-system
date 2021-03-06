/****** Object:  StoredProcedure [dbo].[sp_select_IMR00010]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMR00010]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMR00010]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/*
=========================================================
Program ID	: sp_select_IMR00010
Description   	: Missing Image Item Report
Programmer  	: Lewis To
Create Date   	: 15 Apr 2003
Last Modified  	: 
Table Read(s) 	:IMR00010
Table Write(s) 	:#tmp_IMR00010
=========================================================
 Modification History                                    
=========================================================
 Date      	Initial  	Description          
               
=========================================================     
*/
CREATE PROCEDURE [dbo].[sp_select_IMR00010] 
@cocde	nvarchar(6),
@txntype	char(1)
AS

declare
@cre	int,
@cre1	int,
@cre2	int,
@cre3	int,
@cre4	int,
@cre5	int,
@ttlcre	int,
@miss	int,
@miss1	int,
@miss2	int,
@miss3	int,
@miss4	int,
@miss5	int,
@ttlmiss	int,

@current	char(6),
@current1	char(6),
@current2	char(6),
@current3	char(6),
@current4	char(6),
@current5	char(6),
@currentmth	varchar(6),
@current1mth	varchar(6),
@current2mth	varchar(6),
@current3mth	varchar(6),
@current4mth	varchar(6),
@current5mth	varchar(6),


@mth1	char(4),
@mth2	char(4),
@mth3	char(4),
@mth4	char(4),
@mth5	char(4),
@mth6	char(4),
@mth7	char(4),
@mth8	char(4),
@mth9	char(4),
@mth10	char(4),
@mth11	char(4),
@mth12	char(4),
@rundat	datetime,
@runname varchar(20)



set @mth1 		= 'JAN '
set @mth2 		= 'FEB '
set @mth3 		= 'MAR'
set @mth4 		= 'APR'
set @mth5 		= 'MAY'
set @mth6		= 'JUN'
set @mth7 		= 'JUL'
set @mth8 		= 'AUG'
set @mth9		= 'SEP'
set @mth10 	= 'OCT'
set @mth11 	= 'NOV'
set @mth12 	= 'DEC'



set  @current = convert(varchar(6),getdate(),112) 


set  @current1 = case when right(convert(varchar(6),getdate(),112),2)-2  <= 0  then 
    	 ltrim(rtrim(str(convert(varchar(4),getdate(),112)-1))) + case when len( ltrim(rtrim(str(12 +  right(convert(varchar(6),getdate(),112),2) -2)))) < 2 then  
							'0'+ltrim(rtrim(str(12 +  right(convert(varchar(6),getdate(),112),2) -2)))
						   else
							ltrim(rtrim(str(12 +  right(convert(varchar(6),getdate(),112),2) -2))) end
	else
	       convert(varchar(6),getdate(),112) -1  end

set  @current2 = case when right(convert(varchar(6),getdate(),112),2)-3  <= 0  then 
    	 ltrim(rtrim(str(convert(varchar(4),getdate(),112)-1))) + case when len( ltrim(rtrim(str(12 +  right(convert(varchar(6),getdate(),112),2) -2)))) < 2 then  
							'0'+ltrim(rtrim(str(12 +  right(convert(varchar(6),getdate(),112),2) -2)))
						   else
							ltrim(rtrim(str(12 +  right(convert(varchar(6),getdate(),112),2) -2))) end
	else
	       convert(varchar(6),getdate(),112) -2  end

set  @current3 = case when right(convert(varchar(6),getdate(),112),2)-3  <= 0  then 
    	 ltrim(rtrim(str(convert(varchar(4),getdate(),112)-1))) + case when len( ltrim(rtrim(str(12 +  right(convert(varchar(6),getdate(),112),2) -3)))) < 2 then  
							'0'+ltrim(rtrim(str(12 +  right(convert(varchar(6),getdate(),112),2) -3)))
						   else
							ltrim(rtrim(str(12 +  right(convert(varchar(6),getdate(),112),2) -3))) end
	else
	       convert(varchar(6),getdate(),112) -3  end

set  @current4 = case when right(convert(varchar(6),getdate(),112),2)-4  <= 0  then 
    	 ltrim(rtrim(str(convert(varchar(4),getdate(),112)-1))) + case when len( ltrim(rtrim(str(12 +  right(convert(varchar(6),getdate(),112),2) -4)))) < 2 then  
							'0'+ltrim(rtrim(str(12 +  right(convert(varchar(6),getdate(),112),2) -4)))
						   else
							ltrim(rtrim(str(12 +  right(convert(varchar(6),getdate(),112),2) -4))) end
	else
	       convert(varchar(6),getdate(),112) -4  end

set  @current5 = case when right(convert(varchar(6),getdate(),112),2)-5  <= 0  then 
    	 ltrim(rtrim(str(convert(varchar(4),getdate(),112)-1))) + case when len( ltrim(rtrim(str(12 +  right(convert(varchar(6),getdate(),112),2) -5)))) < 2 then  
							'0'+ltrim(rtrim(str(12 +  right(convert(varchar(6),getdate(),112),2) -5)))
						   else
							ltrim(rtrim(str(12 +  right(convert(varchar(6),getdate(),112),2) -5))) end
	else
	       convert(varchar(6),getdate(),112) -5  end

set @currentmth = case right(@current,2) when '01' then @mth1 + substring(@current,3,2) 
			       when '02' then @mth2 + substring(@current,3,2) 
			       when '03' then @mth3 + substring(@current,3,2)
			       when '04' then @mth4 + substring(@current,3,2) 
			       when '05' then @mth5 + substring(@current,3,2)
			       when '06' then @mth6 + substring(@current,3,2)
			       when '07' then @mth7 + substring(@current,3,2)
			       when '08' then @mth8 + substring(@current,3,2)
			       when '09' then @mth9 + substring(@current,3,2)
			       when '10' then @mth10 + substring(@current,3,2)
			       when '11' then @mth11 + substring(@current,3,2)
			       when '12' then @mth12 + substring(@current,3,2) end
--print @currentmth
set @current1mth = case right(@current1,2) when '01' then @mth1 +  substring(@current1,3,2) 
			       when '02' then @mth2 +  substring(@current1,3,2) 
			       when '03' then @mth3 +  substring(@current1,3,2)
			       when '04' then @mth4 +  substring(@current1,3,2)
			       when '05' then @mth5 +  substring(@current1,3,2)
			       when '06' then @mth6 +  substring(@current1,3,2)
			       when '07' then @mth7 +  substring(@current1,3,2)
			       when '08' then @mth8 +  substring(@current1,3,2)
			       when '09' then @mth9 +  substring(@current1,3,2)
			       when '10' then @mth10 +  substring(@current1,3,2)
			       when '11' then @mth11 + substring(@current1,3,2)
			       when '12' then @mth12 +  substring(@current1,3,2) end
--print @current1mth

set @current2mth = case right(@current2,2) when '01' then @mth1 +  substring(@current2,3,2) 
			       when '02' then @mth2 + substring(@current2,3,2) 
			       when '03' then @mth3 +  substring(@current2,3,2)
			       when '04' then @mth4 +  substring(@current2,3,2)
			       when '05' then @mth5 +  substring(@current2,3,2)
			       when '06' then @mth6 +  substring(@current2,3,2)
			       when '07' then @mth7 +  substring(@current2,3,2)
			       when '08' then @mth8 +  substring(@current2,3,2)
			       when '09' then @mth9 +  substring(@current2,3,2)
			       when '10' then @mth10 + substring(@current2,3,2)
			       when '11' then @mth11 +  substring(@current2,3,2)
			       when '12' then @mth12 + substring(@current2,3,2) end
--print @current2mth

set @current3mth = case right(@current3,2) when '01' then @mth1 +  substring(@current3,3,2) 
			       when '02' then @mth2 +  substring(@current3,3,2) 
			       when '03' then @mth3 +  substring(@current3,3,2) 
			       when '04' then @mth4 +  substring(@current3,3,2)
			       when '05' then @mth5 +  substring(@current3,3,2)
			       when '06' then @mth6 +  substring(@current3,3,2)
			       when '07' then @mth7 +  substring(@current3,3,2)
			       when '08' then @mth8 +  substring(@current3,3,2)
			       when '09' then @mth9 +  substring(@current3,3,2)
			       when '10' then @mth10 +  substring(@current3,3,2)
			       when '11' then @mth11 +  substring(@current3,3,2)
			       when '12' then @mth12 +  substring(@current3,3,2) end
--print @current3mth

set @current4mth = case right(@current4,2) when '01' then @mth1 +  substring(@current4,3,2) 
			       when '02' then @mth2 +  substring(@current4,3,2) 
			       when '03' then @mth3 +  substring(@current4,3,2)
			       when '04' then @mth4 +  substring(@current4,3,2)
			       when '05' then @mth5 +  substring(@current4,3,2)
			       when '06' then @mth6 +  substring(@current4,3,2)
			       when '07' then @mth7 +  substring(@current4,3,2)
			       when '08' then @mth8 +  substring(@current4,3,2)
			       when '09' then @mth9 +  substring(@current4,3,2)
			       when '10' then @mth10 +  substring(@current4,3,2)
			       when '11' then @mth11 +  substring(@current4,3,2)
			       when '12' then @mth12 + substring(@current4,3,2) end
--print @current4mth

set @current5mth = case right(@current5,2) when '01' then @mth1 +  substring(@current5,3,2) 
			       when '02' then @mth2 +  substring(@current5,3,2) 
			       when '03' then @mth3 +  substring(@current5,3,2)
			       when '04' then @mth4 +  substring(@current5,3,2)
			       when '05' then @mth5 +  substring(@current5,3,2) 
			       when '06' then @mth6 +  substring(@current5,3,2)
			       when '07' then @mth7 +  substring(@current5,3,2)
			       when '08' then @mth8 +  substring(@current5,3,2)
			       when '09' then @mth9 +  substring(@current5,3,2)
			       when '10' then @mth10 +  substring(@current5,3,2)
			       when '11' then @mth11 + substring(@current5,3,2)
			       when '12' then @mth12 + substring(@current5,3,2) end
--print @current5mth


begin
	declare -- IMIMGCHKLST value
	@imcredat		int,
	@imcreno		int,
	@imimgmisno	int,
	@upddat		datetime

	declare cur_IMIMGCHKLST CURSOR
	for select
	imcredat,
	sum(imcreno),
	sum(imimgmisno),
	upddat
	FROM IMIMGCHKLST
	group by upddat, imcredat
	order by upddat ,imcredat
	set @rundat = ''

	OPEN cur_IMIMGCHKLST
	FETCH NEXT FROM cur_IMIMGCHKLST INTO
	@imcredat,
	@imcreno,
	@imimgmisno,
	@upddat
-- ******** Creat temp Table for report *******************************	

	--if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[#tmp_imimgchklst]') and OBJECTPROPERTY(id, N'IsTable') = 1)
--drop table #tmp_imr00010
	
		create table #tmp_imr00010
		(txntyp	char(1), 
		  rundat datetime,
		  lastMTH5 varchar(6),
		  lastMTH4 varchar(6),
		  lastMTH3 varchar(6),
		  lastMTH2 varchar(6),
		  lastMTH1 varchar(6),
		  lastMTH varchar(6),
		  before5creno int,
		  before4creno int,
		  before3creno int,
		  before2creno int,
		  before1creno int,
		  before0creno int,
		  ttlcreno	int,
		  before5miseno int,
		  before4miseno int,
		  before3miseno int,
		  before2miseno int,
		  before1miseno int,
		  before0miseno int,
		  ttlmisno	int,
		  ftyname 	nvarchar(20))
		

	While @@fetch_status = 0
	
		  

	Begin
		if convert(varchar(8),@upddat,112) <> convert(varchar(8),@rundat,112)	
		   Begin
		        if @rundat <>''
		               Begin 
			--print @current5mth
	                                     insert into #tmp_IMR00010
			(txntyp,
			  rundat,
			  lastMTH5 ,
			  lastMTH4 ,
			  lastMTH3 ,
			  lastMTH2 ,
			  lastMTH1 ,
			  lastMTH ,
			  before5creno ,
			  before4creno ,
			  before3creno ,
			  before2creno ,
			  before1creno ,
			  before0creno ,
			  ttlcreno	,
			  before5miseno ,
			  before4miseno ,
			  before3miseno ,
			  before2miseno ,
			  before1miseno ,
			  before0miseno ,
			  ttlmisno	) values
			('D',
			 @rundat,
			 @current5mth,
			 @current4mth,
			 @current3mth,
			 @current2mth,
			 @current1mth,
			 @currentmth,
			 @cre5,
			 @cre4,
			 @cre3,
			 @cre2,
			 @cre1,
			 @cre,
			 @ttlcre,
			 @miss5,
			 @miss4,
			 @miss3,
			 @miss2,
			 @miss1,
			 @miss,
			 @ttlmiss)

--			print ' date:' +convert(varchar(10),@rundat,21) +'********************************************************************************'
--			print 'create ' + str(@cre5) + ' ' + str(@cre4) + ' ' +str(@cre3) + ' ' +str(@cre2) + ' ' +str(@cre1) + ' ' +str(@cre) + str(@ttlcre)
--			Print 'miss ' + str(@miss5) + ' ' + str(@miss4) + ' ' + str(@miss3) + ' ' + str(@miss2) + ' ' + str(@miss1) + ' ' + str(@miss) + str(@ttlmiss) 
		                End
   	       	       set @cre = 0	
	                         set @cre1 = 0
	                         set @cre2 = 0	
	                         set @cre3 = 0
	                         set @cre4 = 0	
	                         set @cre5 = 0
		      set @ttlcre = 0
	                         set @miss = 0	
	                         set @miss1 = 0	
	                         set @miss2 = 0	
	                         set @miss3 = 0	
	                         set @miss4 = 0	
	                         set @miss5 = 0	
	                         set @ttlcre = 0
	                         set @ttlmiss=0
		      set @rundat = @upddat
		   End
	if @imcredat = @current set @cre = @cre + @imcreno
	--	print 'CRE=  ' + str(@cre)
	if @imcredat = @current1 set @cre1 = @cre1 + @imcreno
	--	print 'CRE1=' + str(@cre1)
	if @imcredat = @current2 set @cre2 = @cre2 + @imcreno
	--	print 'CRE2=' + str(@cre2)
	if @imcredat = @current3 set @cre3 = @cre3 + @imcreno
	--	print 'CRE3=' + str(@cre3)
	if @imcredat = @current4 set @cre4 = @cre4 + @imcreno
	--	print 'CRE4=' + str(@cre4)
	if @imcredat <= @current5 set @cre5 = @cre5 + @imcreno
	--	print 'CRE5=' + str(@cre5)

	if @imcredat = @current set  @miss = @miss + @imimgmisno
	--	print 'miss=  ' + str(@miss)
	if @imcredat = @current1 set  @miss1 = @miss1 + @imimgmisno
	--	print 'miss1=  ' + str(@miss1)
	if @imcredat = @current2 set  @miss2 = @miss2 + @imimgmisno
	--	print 'miss2=  ' + str(@miss2)
	if @imcredat = @current3 set  @miss3 = @miss3 + @imimgmisno
	--	print 'miss3=  ' + str(@miss3)
	if @imcredat = @current4 set  @miss4 = @miss4 + @imimgmisno
	--	print 'miss4=  ' + str(@miss4)
	if @imcredat <= @current5 set  @miss5 = @miss5 + @imimgmisno
	--	print 'miss5=  ' + str(@miss5)
	--	print 'CRE5=' + str(@cre5)
                          set @ttlcre = @ttlcre+ @imcreno
	--	print 'ttlCRE=' + str(@ttlcre)
	       set @ttlmiss = @ttlmiss + @imimgmisno
	--	print 'ttlmiss=' + str(@ttlmiss)
	       
	
	FETCH NEXT FROM cur_IMIMGCHKLST INTO
	@imcredat,
	@imcreno,
	@imimgmisno,
	@upddat
         END
--****** Complete to write the last record *****************************
		insert into #tmp_IMR00010
			(txntyp,
			  rundat,
			  lastMTH5 ,
			  lastMTH4 ,
			  lastMTH3 ,
			  lastMTH2 ,
			  lastMTH1 ,
			  lastMTH ,
			  before5creno ,
			  before4creno ,
			  before3creno ,
			  before2creno ,
			  before1creno ,
			  before0creno ,
			  ttlcreno	,
			  before5miseno ,
			  before4miseno ,
			  before3miseno ,
			  before2miseno ,
			  before1miseno ,
			  before0miseno ,
			  ttlmisno	) values
			('D',
			 @rundat,
			 @current5mth,
			 @current4mth,
			 @current3mth,
			 @current2mth,
			 @current1mth,
			 @currentmth,
			 @cre5,
			 @cre4,
			 @cre3,
			 @cre2,
			 @cre1,
			 @cre,
			 @ttlcre,
			 @miss5,
			 @miss4,
			 @miss3,
			 @miss2,
			 @miss1,
			 @miss,
			 @ttlmiss)
--			print 'create ' + str(@cre5) + ' ' + str(@cre4) + ' ' +str(@cre3) + ' ' +str(@cre2) + ' ' +str(@cre1) + ' ' +str(@cre) + str(@ttlcre)
--			Print 'miss ' + str(@miss5) + ' ' + str(@miss4) + ' ' + str(@miss3) + ' ' + str(@miss2) + ' ' + str(@miss1) + ' ' + str(@miss) + str(@ttlmiss) 

Close cur_IMIMGCHKLST
Deallocate cur_IMIMGCHKLST
/*
--***********************  Count by Factory Name ************************************************
       	       set @cre = 0	
                         set @cre1 = 0
                         set @cre2 = 0	
                         set @cre3 = 0
                         set @cre4 = 0	
                         set @cre5 = 0
	      set @ttlcre = 0

	declare -- IMIMGCHKLST value
--	@imcredat		int,
--	@imcreno		int,
--	@imimgmisno	int,
--	@upddat		datetime
	@ftycde		varchar(5),
	@ftyname		varchar(20)
	declare cur_IMIMGCHKLST CURSOR
	for select
	imcredat,
	sum(imcreno),
	sum(imimgmisno),
	--upddat
	ftycde,
	ftyname
	FROM IMIMGCHKLST
	group by  imcredat,ftycde,ftyname 
	order by ftyname
	set @runname = ''

	OPEN cur_IMIMGCHKLST
	FETCH NEXT FROM cur_IMIMGCHKLST INTO
	@imcredat,
	@imcreno,
	@imimgmisno,
--	@upddat
	@ftycde,
	@ftyname
		

	While @@fetch_status = 0
	
		  

	Begin
	if ltrim(rtrim(ftyname)) <> ''
	        Begin
		if ltrim(rtrim(ftyname)) <> ltrim(rtrim(@runname))	
		   Begin
		        if @runname <>''
		               Begin 
			--print @current5mth
	                                     insert into #tmp_IMIMGCHKLST
			(txntyp,
			  rundat,
			  lastMTH5 ,
			  lastMTH4 ,
			  lastMTH3 ,
			  lastMTH2 ,
			  lastMTH1 ,
			  lastMTH ,
			  before5creno ,
			  before4creno ,
			  before3creno ,
			  before2creno ,
			  before1creno ,
			  before0creno ,
			  ttlcreno,	
			  ftyname	) values
			('N',
			 @rundat,
			 @current5mth,
			 @current4mth,
			 @current3mth,
			 @current2mth,
			 @current1mth,
			 @currentmth,
			 @cre5,
			 @cre4,
			 @cre3,
			 @cre2,
			 @cre1,
			 @cre,
			 @ttlcre,
			 @ftyname)

--			print ' date:' +convert(varchar(10),@rundat,21) +'********************************************************************************'
--			print 'create ' + str(@cre5) + ' ' + str(@cre4) + ' ' +str(@cre3) + ' ' +str(@cre2) + ' ' +str(@cre1) + ' ' +str(@cre) + str(@ttlcre)
--			Print 'miss ' + str(@miss5) + ' ' + str(@miss4) + ' ' + str(@miss3) + ' ' + str(@miss2) + ' ' + str(@miss1) + ' ' + str(@miss) + str(@ttlmiss) 
		                End
   	       	       set @cre = 0	
	                         set @cre1 = 0
	                         set @cre2 = 0	
	                         set @cre3 = 0
	                         set @cre4 = 0	
	                         set @cre5 = 0
		      set @ttlcre = 0
		      set @runname = @ftyname
		   End
	if @imcredat = @current set @cre = @cre + @imcreno
	--	print 'CRE=  ' + str(@cre)
	if @imcredat = @current1 set @cre1 = @cre1 + @imcreno
	--	print 'CRE1=' + str(@cre1)
	if @imcredat = @current2 set @cre2 = @cre2 + @imcreno
	--	print 'CRE2=' + str(@cre2)
	if @imcredat = @current3 set @cre3 = @cre3 + @imcreno
	--	print 'CRE3=' + str(@cre3)
	if @imcredat = @current4 set @cre4 = @cre4 + @imcreno
	--	print 'CRE4=' + str(@cre4)
	if @imcredat <= @current5 set @cre5 = @cre5 + @imcreno
	--	print 'CRE5=' + str(@cre5)

	if @imcredat = @current set  @miss = @miss + @imimgmisno
	--	print 'miss=  ' + str(@miss)
	if @imcredat = @current1 set  @miss1 = @miss1 + @imimgmisno
	--	print 'miss1=  ' + str(@miss1)
	if @imcredat = @current2 set  @miss2 = @miss2 + @imimgmisno
	--	print 'miss2=  ' + str(@miss2)
	if @imcredat = @current3 set  @miss3 = @miss3 + @imimgmisno
	--	print 'miss3=  ' + str(@miss3)
	if @imcredat = @current4 set  @miss4 = @miss4 + @imimgmisno
	--	print 'miss4=  ' + str(@miss4)
	if @imcredat <= @current5 set  @miss5 = @miss5 + @imimgmisno
	--	print 'miss5=  ' + str(@miss5)
	--	print 'CRE5=' + str(@cre5)
                          set @ttlcre = @ttlcre+ @imcreno
	--	print 'ttlCRE=' + str(@ttlcre)
	       set @ttlmiss = @ttlmiss + @imimgmisno
	--	print 'ttlmiss=' + str(@ttlmiss)
                         end	       
	
	FETCH NEXT FROM cur_IMIMGCHKLST INTO
	@imcredat,
	@imcreno,
	@imimgmisno,
	@upddat
         END
--****** Complete to write the last record *****************************
		insert into #tmp_IMIMGCHKLST
			(rundat,
			  lastMTH5 ,
			  lastMTH4 ,
			  lastMTH3 ,
			  lastMTH2 ,
			  lastMTH1 ,
			  lastMTH ,
			  before5creno ,
			  before4creno ,
			  before3creno ,
			  before2creno ,
			  before1creno ,
			  before0creno ,
			  ttlcreno	,
			  before5miseno ,
			  before4miseno ,
			  before3miseno ,
			  before2miseno ,
			  before1miseno ,
			  before0miseno ,
			  ttlmisno	) values
			(@rundat,
			 @current5mth,
			 @current4mth,
			 @current3mth,
			 @current2mth,
			 @current1mth,
			 @currentmth,
			 @cre5,
			 @cre4,
			 @cre3,
			 @cre2,
			 @cre1,
			 @cre,
			 @ttlcre,
			 @miss5,
			 @miss4,
			 @miss3,
			 @miss2,
			 @miss1,
			 @miss,
			 @ttlmiss)
--			print 'create ' + str(@cre5) + ' ' + str(@cre4) + ' ' +str(@cre3) + ' ' +str(@cre2) + ' ' +str(@cre1) + ' ' +str(@cre) + str(@ttlcre)
--			Print 'miss ' + str(@miss5) + ' ' + str(@miss4) + ' ' + str(@miss3) + ' ' + str(@miss2) + ' ' + str(@miss1) + ' ' + str(@miss) + str(@ttlmiss) 

Close cur_IMIMGCHKLST
Deallocate cur_IMIMGCHKLST
*/
END
-- ******** Retrive Tmp data for report printing ******************
select * from #tmp_imr00010 where txntyp = @txntype

SET ANSI_WARNINGS ON



GO
GRANT EXECUTE ON [dbo].[sp_select_IMR00010] TO [ERPUSER] AS [dbo]
GO
