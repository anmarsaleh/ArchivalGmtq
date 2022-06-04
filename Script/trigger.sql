use GEMTQ_Arch
go
ALTER TRIGGER importdata ON  DataTableTmp
  AFTER INSERT
AS
BEGIN
   DECLARE @ID INT 
   DECLARE @Filename NVARCHAR(1000);
   DECLARE @ImageFolderPath NVARCHAR(1000);
   DECLARE @ImageData varbinary (max) ;
   DECLARE @Path2OutFile NVARCHAR (2000);
   DECLARE @Obj INT;
   declare @ext nvarchar(50);
   declare @kindname nvarchar(50);
   DECLARE @outPutPath varchar(50);
   DECLARE @folderPath  varchar(max); 
   SELECT TOP 1 @ID =DocID FROM INSERTED;
   SELECT @ImageData = (
   SELECT convert (varbinary (max), DataFile) FROM DataTableTmp   WHERE  DataTableTmp.DocID=@ID)
   SELECT  @ImageFolderPath=(select StorePath from KindDocuments,DocumentsArch
   where KindDocuments.KindID=DocumentsArch.KindID and DocumentsArch.DocID=@ID)
   SELECT  @Filename=(select DocName from DocumentsArch,DataTableTmp
   where  DataTableTmp.DocID=@ID and DataTableTmp.DocID=DocumentsArch.DocID)
   SELECT  @ext=(select FILEex from DocumentsArch,DataTableTmp
   where  DataTableTmp.DocID=@ID and DataTableTmp.DocID=DocumentsArch.DocID)
    SELECT  @kindname=(select KindName from KindDocuments,DocumentsArch
   where KindDocuments.KindID=DocumentsArch.KindID and DocumentsArch.DocID=@ID)

   SET @Path2OutFile = @ImageFolderPath+'\'+@kindname +'\'+ @Filename+@ext
	set @folderPath=@ImageFolderPath+'\'+@kindname
     BEGIN TRY
	 EXEC  [dbo].[CreateFolder]  @folderPath
     EXEC sp_OACreate 'ADODB.Stream' ,@Obj OUTPUT;
     EXEC sp_OASetProperty @Obj ,'Type',1;
     EXEC sp_OAMethod @Obj,'Open';
     EXEC sp_OAMethod @Obj,'Write', NULL, @ImageData;
     EXEC sp_OAMethod @Obj,'SaveToFile', NULL, @Path2OutFile, 2;
     EXEC sp_OAMethod @Obj,'Close';
     EXEC sp_OADestroy @Obj;
     END TRY
     BEGIN CATCH
     EXEC sp_OADestroy @Obj;
     END CATCH
     delete from DataTableTmp where DocID=@ID
END;