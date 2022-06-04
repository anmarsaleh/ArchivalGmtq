alter PROCEDURE export_image(
    @ID int
   )
AS
BEGIN
   DECLARE @Filename NVARCHAR(1000)
   DECLARE @ImageFolderPath NVARCHAR(1000)
   DECLARE @ImageData VARBINARY (max);
   DECLARE @Path2OutFile NVARCHAR (2000);
   DECLARE @Obj INT
   SET NOCOUNT ON
   SELECT @ImageData = (
         SELECT convert (VARBINARY (max), DataFile)
         FROM DataTableTmp 
         WHERE  DataTableTmp.DocID=@ID
         )
select  @ImageFolderPath=(select StorePath from KindDocuments,DocumentsArch,DataTableTmp
where KindDocuments.KindID=DocumentsArch.KindID and DataTableTmp.DocID=DocumentsArch.DocID and DataTableTmp.DocID=@ID)
select  @Filename=(select DocName from DocumentsArch,DataTableTmp
where  DataTableTmp.DocID=@ID and DataTableTmp.DocID=DocumentsArch.DocID)
   SET @Path2OutFile = CONCAT (
         @ImageFolderPath
         ,'\'
         , @Filename
         );
    BEGIN TRY
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
 

   SET NOCOUNT OFF
END
GO

