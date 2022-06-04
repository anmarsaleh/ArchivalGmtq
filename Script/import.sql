use GEMTQ_Arch
go
create TRIGGER select_data ON  DataTableTmp
after insert ,update,delete
AS
BEGIN
   DECLARE  @PicName NVARCHAR (100)
  DECLARE  @ImageFolderPath NVARCHAR (1000)
   DECLARE @Filename NVARCHAR (1000)
   DECLARE @Path2OutFile NVARCHAR (2000);
   DECLARE @tsql NVARCHAR (2000);
   SET NOCOUNT ON
   SET @Path2OutFile = CONCAT (
         @ImageFolderPath
         ,'\'
         , @Filename
         );
   SET @tsql = 'insert into Pictures (pictureName, picFileName, PictureData) ' +
               ' SELECT ' + '''' + @PicName + '''' + ',' + '''' + @Filename + '''' + ', * ' + 
               'FROM Openrowset( Bulk ' + '''' + @Path2OutFile + '''' + ', Single_Blob) as img'
   EXEC (@tsql)
   SET NOCOUNT OFF
END;


