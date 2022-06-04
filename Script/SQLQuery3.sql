USE [GEMTQ_Arch]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter TRIGGER export_data ON  [dbo].[DataTableTmp]
after  delete
  
AS

BEGIN
   DECLARE @id int;
   DECLARE @ImageFolderPath NVARCHAR (1000);
   DECLARE @Filename NVARCHAR (1000);
   DECLARE @Path2OutFile NVARCHAR (2000);
   DECLARE @tsql NVARCHAR (2000);
   DECLARE @ext nvarchar(50);
   DECLARE @kindname nvarchar(50);
    SET NOCOUNT ON
	if exists (select * from deleted where DocID=@id)
 SELECT  @ImageFolderPath=(select StorePath from KindDocuments,DocumentsArch
   where KindDocuments.KindID=DocumentsArch.KindID and DocumentsArch.DocID=@id)
   SELECT  @Filename=( select DocName from DocumentsArch where  DocumentsArch.DocID=@id)
   SELECT  @ext=(select FILEex from DocumentsArch where  DocumentsArch.DocID=@id)
   SELECT  @kindname=(select KindName from KindDocuments,DocumentsArch
   where KindDocuments.KindID=DocumentsArch.KindID and DocumentsArch.DocID=@id)
	  SET @Path2OutFile = @ImageFolderPath+'\'+@kindname +'\'+convert(varchar,@id)+'_'+@Filename+@ext
	 
	   SET @tsql = 'insert into DataTableTmp (DocID, DataFile) ' + ' SELECT ' + '''' + @id + '''' + ', * ' + 
               'FROM Openrowset( Bulk ' + '''' + @Path2OutFile + '''' + ', Single_Blob) as img'
   EXEC (@tsql)
   SET NOCOUNT OFF
END;