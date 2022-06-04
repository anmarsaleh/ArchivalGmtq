alter PROC selectdata(
 @id int
)
AS
BEGIN
SET NOCOUNT ON 
   
   DECLARE @ImageFolderPath NVARCHAR (1000);
   DECLARE @Filename NVARCHAR (1000);
   DECLARE @Path2OutFile NVARCHAR (2000);
   DECLARE @tsql NVARCHAR (2000);
   DECLARE @ext nvarchar(50);
   DECLARE @kindname nvarchar(50);
    SET NOCOUNT ON
 SELECT  @ImageFolderPath=(select StorePath from KindDocuments,DocumentsArch
   where KindDocuments.KindID=DocumentsArch.KindID and DocumentsArch.DocID=@id)
   SELECT  @Filename=( select DocName from DocumentsArch where  DocumentsArch.DocID=@id)
   SELECT  @ext=(select FILEex from DocumentsArch where  DocumentsArch.DocID=@id)
   SELECT  @kindname=(select KindName from KindDocuments,DocumentsArch
   where KindDocuments.KindID=DocumentsArch.KindID and DocumentsArch.DocID=@id)
	  SET @Path2OutFile  =concat(
	   @ImageFolderPath
	  ,@kindname 
	  ,'\'
	  ,convert(varchar,@id)
	  ,'_'
	  ,@Filename
	  ,@ext)
	  
	   insert into DataTableTempSecondary (DocID, Extintions, Datapath) 
                SELECT  @id , @ext, @Path2OutFile
   SET NOCOUNT OFF
END;