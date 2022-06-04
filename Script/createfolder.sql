--	DATE	:	23-Nov
--	AUTHOR	:	Jitendra Zaa

CREATE PROCEDURE [dbo].[CreateFolder] (@newfolder varchar(1000)) AS  
BEGIN  
DECLARE @OLEfolder   INT  
DECLARE @OLEsource   VARCHAR(255)  
DECLARE @OLEdescription  VARCHAR(255) 
DECLARE @init   INT  
DECLARE @OLEfilesytemobject INT  
 
-- it will fail if OLE automation not enabled
EXEC @init=sp_OACreate 'Scripting.FileSystemObject', @OLEfilesytemobject OUT  
IF @init <> 0  
BEGIN  
	EXEC sp_OAGetErrorInfo @OLEfilesytemobject  
	RETURN  
END  
-- check if folder exists  
EXEC @init=sp_OAMethod @OLEfilesytemobject, 'FolderExists', @OLEfolder OUT, @newfolder  
-- if folder doesnt exist, create it  
IF @OLEfolder=0  
	BEGIN  
	EXEC @init=sp_OAMethod @OLEfilesytemobject, 'CreateFolder', @OLEfolder OUT, @newfolder  
END  
-- in case of error, raise it   
IF @init <> 0  
	BEGIN  
		EXEC sp_OAGetErrorInfo @OLEfilesytemobject, @OLEsource OUT, @OLEdescription OUT  
		SELECT @OLEdescription='Could not create folder: ' + @OLEdescription  
		RAISERROR (@OLEdescription, 16, 1)   
	END  
EXECUTE @init = sp_OADestroy @OLEfilesytemobject  
END  