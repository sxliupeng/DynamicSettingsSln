USE [master]
GO
/****** Object:  Database [DynamicSettingsDbContext]    Script Date: 2019-02-26 23:29:22 ******/
CREATE DATABASE [DynamicSettingsDbContext]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DynamicSettingsDbContext', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DynamicSettingsDbContext.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DynamicSettingsDbContext_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DynamicSettingsDbContext_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DynamicSettingsDbContext] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DynamicSettingsDbContext].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DynamicSettingsDbContext] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET ARITHABORT OFF 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET RECOVERY FULL 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET  MULTI_USER 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DynamicSettingsDbContext] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DynamicSettingsDbContext] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DynamicSettingsDbContext', N'ON'
GO
USE [DynamicSettingsDbContext]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddTable]    Script Date: 2019-02-26 23:29:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_AddTable]
	@RawJson nvarchar(4000),
	@TblID uniqueidentifier output
as
begin
	declare @TblName nvarchar(20)
	declare @DateCreated datetime
	declare @ColumnJSON nvarchar(4000)

	--set @TblName=
end



--Initial
select name from sys.types
GO
/****** Object:  Table [dbo].[TblCells_NCARCHAR_4000]    Script Date: 2019-02-26 23:29:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblCells_NCARCHAR_4000](
	[ID] [uniqueidentifier] NOT NULL,
	[Order] [int] NULL,
	[TblID] [uniqueidentifier] NULL,
	[ColID] [uniqueidentifier] NULL,
	[RowID] [uniqueidentifier] NULL,
	[Value] [nvarchar](4000) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblCellTypes]    Script Date: 2019-02-26 23:29:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblCellTypes](
	[TypID] [uniqueidentifier] NOT NULL,
	[TableName] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TypID] ASC,
	[TableName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblColumns]    Script Date: 2019-02-26 23:29:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblColumns](
	[ID] [uniqueidentifier] NOT NULL,
	[Order] [int] NULL,
	[Name] [nvarchar](20) NULL,
	[IsAllowNull] [bit] NULL,
	[IsPrimaryKey] [bit] NULL,
	[TblID] [uniqueidentifier] NULL,
	[TypID] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblRows]    Script Date: 2019-02-26 23:29:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblRows](
	[ID] [uniqueidentifier] NOT NULL,
	[Order] [int] NULL,
	[TblID] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblTables]    Script Date: 2019-02-26 23:29:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblTables](
	[ID] [uniqueidentifier] NOT NULL,
	[Order] [int] NULL,
	[Name] [nvarchar](20) NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblTypes]    Script Date: 2019-02-26 23:29:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblTypes](
	[ID] [uniqueidentifier] NOT NULL,
	[Order] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[MaxLength] [smallint] NOT NULL,
	[IsNullable] [bit] NOT NULL,
	[IsUserDefined] [bit] NOT NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TblCells_NCARCHAR_4000]  WITH CHECK ADD FOREIGN KEY([ColID])
REFERENCES [dbo].[TblColumns] ([ID])
GO
ALTER TABLE [dbo].[TblCells_NCARCHAR_4000]  WITH CHECK ADD FOREIGN KEY([RowID])
REFERENCES [dbo].[TblRows] ([ID])
GO
ALTER TABLE [dbo].[TblCells_NCARCHAR_4000]  WITH CHECK ADD FOREIGN KEY([TblID])
REFERENCES [dbo].[TblTables] ([ID])
GO
ALTER TABLE [dbo].[TblColumns]  WITH CHECK ADD FOREIGN KEY([TblID])
REFERENCES [dbo].[TblTables] ([ID])
GO
ALTER TABLE [dbo].[TblColumns]  WITH CHECK ADD FOREIGN KEY([TypID])
REFERENCES [dbo].[TblTypes] ([ID])
GO
ALTER TABLE [dbo].[TblRows]  WITH CHECK ADD FOREIGN KEY([TblID])
REFERENCES [dbo].[TblTables] ([ID])
GO
USE [master]
GO
ALTER DATABASE [DynamicSettingsDbContext] SET  READ_WRITE 
GO
