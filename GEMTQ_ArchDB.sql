USE [master]
GO
/****** Object:  Database [GEMTQ_Arch]    Script Date: 3/18/2018 07:17:03 م ******/
CREATE DATABASE [GEMTQ_Arch]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GEMTQ_Arch', FILENAME = N'C:\GEMTQ_ArchData\GEMTQ_Arch.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GEMTQ_Arch_log', FILENAME = N'C:\GEMTQ_ArchData\GEMTQ_Arch_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GEMTQ_Arch] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GEMTQ_Arch].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GEMTQ_Arch] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GEMTQ_Arch] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GEMTQ_Arch] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GEMTQ_Arch] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GEMTQ_Arch] SET ARITHABORT OFF 
GO
ALTER DATABASE [GEMTQ_Arch] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GEMTQ_Arch] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GEMTQ_Arch] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GEMTQ_Arch] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GEMTQ_Arch] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GEMTQ_Arch] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GEMTQ_Arch] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GEMTQ_Arch] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GEMTQ_Arch] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GEMTQ_Arch] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GEMTQ_Arch] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GEMTQ_Arch] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GEMTQ_Arch] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GEMTQ_Arch] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GEMTQ_Arch] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GEMTQ_Arch] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GEMTQ_Arch] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GEMTQ_Arch] SET RECOVERY FULL 
GO
ALTER DATABASE [GEMTQ_Arch] SET  MULTI_USER 
GO
ALTER DATABASE [GEMTQ_Arch] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GEMTQ_Arch] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GEMTQ_Arch] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GEMTQ_Arch] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [GEMTQ_Arch] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'GEMTQ_Arch', N'ON'
GO
USE [GEMTQ_Arch]
GO
/****** Object:  User [Saleh]    Script Date: 3/18/2018 07:17:04 م ******/
CREATE USER [Saleh] FOR LOGIN [Saleh] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Saleh]
GO
/****** Object:  Table [dbo].[Audits]    Script Date: 3/18/2018 07:17:04 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Audits](
	[AuditID] [int] NOT NULL,
	[DocArchID] [int] NULL,
	[UserID] [int] NULL,
	[DateArch] [datetime] NULL,
 CONSTRAINT [PK_Audits] PRIMARY KEY CLUSTERED 
(
	[AuditID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DataTableTempSecondary]    Script Date: 3/18/2018 07:17:04 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataTableTempSecondary](
	[DocID] [int] NULL,
	[Extintions] [nvarchar](50) NULL,
	[Datapath] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DataTableTmp]    Script Date: 3/18/2018 07:17:04 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DataTableTmp](
	[DataID] [int] IDENTITY(1,1) NOT NULL,
	[DocID] [int] NULL,
	[DataFile] [varbinary](max) NULL,
 CONSTRAINT [PK_DataTableTmp] PRIMARY KEY CLUSTERED 
(
	[DataID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DepartmentArch]    Script Date: 3/18/2018 07:17:04 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartmentArch](
	[DepartID] [int] IDENTITY(1,1) NOT NULL,
	[DepartName] [nvarchar](50) NULL,
 CONSTRAINT [PK_DepartmentArch] PRIMARY KEY CLUSTERED 
(
	[DepartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DistenationArch]    Script Date: 3/18/2018 07:17:04 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DistenationArch](
	[DistID] [int] IDENTITY(1,1) NOT NULL,
	[DistName] [nvarchar](50) NULL,
 CONSTRAINT [PK_DistenationArch] PRIMARY KEY CLUSTERED 
(
	[DistID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DocumentsArch]    Script Date: 3/18/2018 07:17:04 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DocumentsArch](
	[DocID] [int] IDENTITY(1,1) NOT NULL,
	[KindID] [int] NULL,
	[PublicN] [nchar](10) NULL,
	[InnerN] [nchar](10) NULL,
	[DateOfDoc] [varchar](50) NULL,
	[DistID] [int] NULL,
	[DepartID] [int] NULL,
	[SubjectDoc] [nvarchar](max) NULL,
	[DocName] [nvarchar](50) NULL,
	[FILEex] [nvarchar](50) NULL,
	[RemaindDate] [varchar](50) NULL,
	[UserID] [nchar](10) NULL,
	[CreatedDate] [varchar](50) NULL,
 CONSTRAINT [PK_DocumentsArch] PRIMARY KEY CLUSTERED 
(
	[DocID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KindDocuments]    Script Date: 3/18/2018 07:17:04 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KindDocuments](
	[KindID] [int] IDENTITY(1,1) NOT NULL,
	[StorePath] [nvarchar](max) NULL,
	[KindName] [varchar](50) NULL,
 CONSTRAINT [PK_KindDocuments] PRIMARY KEY CLUSTERED 
(
	[KindID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TransFiles]    Script Date: 3/18/2018 07:17:04 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransFiles](
	[TransID] [int] IDENTITY(1,1) NOT NULL,
	[DocID] [int] NULL,
	[TranUserID] [int] NULL,
	[ReciveUserID] [int] NULL,
	[TransDate] [nvarchar](50) NULL,
	[IsReciveFile] [bit] NULL,
	[ReciveDate] [datetime] NULL,
	[TransNote] [nvarchar](max) NULL,
	[RespondNote] [nvarchar](max) NULL,
 CONSTRAINT [PK_TransFiles] PRIMARY KEY CLUSTERED 
(
	[TransID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/18/2018 07:17:04 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[ActiveUser] [bit] NULL,
	[EndActive] [date] NULL,
	[CanModyfied] [bit] NULL,
	[CanDelete] [bit] NULL,
	[CanView] [bit] NULL,
	[IsAdmin] [bit] NULL,
	[UserPW] [nchar](10) NULL,
	[IsLogin] [bit] NULL,
	[PcName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[CreateFolder]    Script Date: 3/18/2018 07:17:04 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[selectdata]    Script Date: 3/18/2018 07:17:04 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[selectdata](
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
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'public number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DocumentsArch', @level2type=N'COLUMN',@level2name=N'PublicN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'internal number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DocumentsArch', @level2type=N'COLUMN',@level2name=N'InnerN'
GO
USE [master]
GO
ALTER DATABASE [GEMTQ_Arch] SET  READ_WRITE 
GO
