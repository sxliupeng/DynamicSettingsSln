USE [master]
GO
/****** Object:  Database [SettingsManagement]    Script Date: 2019-02-26 23:28:50 ******/
CREATE DATABASE [SettingsManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SettingsManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SettingsManagement.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SettingsManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SettingsManagement_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SettingsManagement] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SettingsManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SettingsManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SettingsManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SettingsManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SettingsManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SettingsManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [SettingsManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SettingsManagement] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SettingsManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SettingsManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SettingsManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SettingsManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SettingsManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SettingsManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SettingsManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SettingsManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SettingsManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SettingsManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SettingsManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SettingsManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SettingsManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SettingsManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SettingsManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SettingsManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SettingsManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [SettingsManagement] SET  MULTI_USER 
GO
ALTER DATABASE [SettingsManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SettingsManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SettingsManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SettingsManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SettingsManagement', N'ON'
GO
USE [SettingsManagement]
GO
/****** Object:  Table [dbo].[TblGroupRights]    Script Date: 2019-02-26 23:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblGroupRights](
	[GroupID] [uniqueidentifier] NOT NULL,
	[RightID] [uniqueidentifier] NOT NULL,
	[DateCreated] [datetimeoffset](7) NOT NULL,
	[DateModified] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_TblGroupRights] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC,
	[RightID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblGroupRoles]    Script Date: 2019-02-26 23:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblGroupRoles](
	[RoleID] [uniqueidentifier] NOT NULL,
	[GroupID] [uniqueidentifier] NOT NULL,
	[DateCreated] [datetimeoffset](7) NOT NULL,
	[DateModified] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_TblGroupRoles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC,
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblGroups]    Script Date: 2019-02-26 23:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblGroups](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateCreated] [datetimeoffset](7) NOT NULL,
	[DateModified] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_TblUserGroups] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblRights]    Script Date: 2019-02-26 23:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblRights](
	[ID] [uniqueidentifier] NOT NULL,
	[Value] [int] NOT NULL,
	[DateCreated] [datetimeoffset](7) NOT NULL,
	[DateModified] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_TblRights] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblRoleRights]    Script Date: 2019-02-26 23:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblRoleRights](
	[RoleID] [uniqueidentifier] NOT NULL,
	[RightID] [uniqueidentifier] NOT NULL,
	[DateCreated] [datetimeoffset](7) NOT NULL,
	[DateModified] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_TblRoleRights] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC,
	[RightID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblRoles]    Script Date: 2019-02-26 23:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblRoles](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateCreated] [datetimeoffset](7) NOT NULL,
	[DateModified] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_TblRoles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblUserGroups]    Script Date: 2019-02-26 23:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblUserGroups](
	[UserID] [uniqueidentifier] NOT NULL,
	[GroupID] [uniqueidentifier] NOT NULL,
	[DateCreated] [datetimeoffset](7) NOT NULL,
	[DateModified] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblUserRights]    Script Date: 2019-02-26 23:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblUserRights](
	[UserID] [uniqueidentifier] NOT NULL,
	[RightID] [uniqueidentifier] NOT NULL,
	[DateCreated] [datetimeoffset](7) NOT NULL,
	[DateModified] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_TblUserRights] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[RightID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblUserRoles]    Script Date: 2019-02-26 23:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblUserRoles](
	[UserID] [uniqueidentifier] NOT NULL,
	[RoleID] [uniqueidentifier] NOT NULL,
	[DateCreated] [datetimeoffset](7) NOT NULL,
	[DateModified] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_TblUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblUsers]    Script Date: 2019-02-26 23:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblUsers](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateCreated] [datetimeoffset](7) NOT NULL,
	[DateModified] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_TblUsers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TblGroupRights]  WITH CHECK ADD  CONSTRAINT [FK_TblGroupRights_TblGroups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[TblGroups] ([ID])
GO
ALTER TABLE [dbo].[TblGroupRights] CHECK CONSTRAINT [FK_TblGroupRights_TblGroups]
GO
ALTER TABLE [dbo].[TblGroupRights]  WITH CHECK ADD  CONSTRAINT [FK_TblGroupRights_TblRights] FOREIGN KEY([RightID])
REFERENCES [dbo].[TblRights] ([ID])
GO
ALTER TABLE [dbo].[TblGroupRights] CHECK CONSTRAINT [FK_TblGroupRights_TblRights]
GO
ALTER TABLE [dbo].[TblGroupRoles]  WITH CHECK ADD  CONSTRAINT [FK_TblGroupRoles_TblGroups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[TblGroups] ([ID])
GO
ALTER TABLE [dbo].[TblGroupRoles] CHECK CONSTRAINT [FK_TblGroupRoles_TblGroups]
GO
ALTER TABLE [dbo].[TblGroupRoles]  WITH CHECK ADD  CONSTRAINT [FK_TblGroupRoles_TblRoles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[TblRoles] ([ID])
GO
ALTER TABLE [dbo].[TblGroupRoles] CHECK CONSTRAINT [FK_TblGroupRoles_TblRoles]
GO
ALTER TABLE [dbo].[TblRoleRights]  WITH CHECK ADD  CONSTRAINT [FK_TblRoleRights_TblRights] FOREIGN KEY([RightID])
REFERENCES [dbo].[TblRights] ([ID])
GO
ALTER TABLE [dbo].[TblRoleRights] CHECK CONSTRAINT [FK_TblRoleRights_TblRights]
GO
ALTER TABLE [dbo].[TblRoleRights]  WITH CHECK ADD  CONSTRAINT [FK_TblRoleRights_TblRoles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[TblRoles] ([ID])
GO
ALTER TABLE [dbo].[TblRoleRights] CHECK CONSTRAINT [FK_TblRoleRights_TblRoles]
GO
ALTER TABLE [dbo].[TblUserGroups]  WITH CHECK ADD  CONSTRAINT [FK_TblUserGroups_TblGroups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[TblGroups] ([ID])
GO
ALTER TABLE [dbo].[TblUserGroups] CHECK CONSTRAINT [FK_TblUserGroups_TblGroups]
GO
ALTER TABLE [dbo].[TblUserGroups]  WITH CHECK ADD  CONSTRAINT [FK_TblUserGroups_TblUserGroups] FOREIGN KEY([UserID])
REFERENCES [dbo].[TblUsers] ([ID])
GO
ALTER TABLE [dbo].[TblUserGroups] CHECK CONSTRAINT [FK_TblUserGroups_TblUserGroups]
GO
ALTER TABLE [dbo].[TblUserRights]  WITH CHECK ADD  CONSTRAINT [FK_TblUserRights_TblRights] FOREIGN KEY([RightID])
REFERENCES [dbo].[TblRights] ([ID])
GO
ALTER TABLE [dbo].[TblUserRights] CHECK CONSTRAINT [FK_TblUserRights_TblRights]
GO
ALTER TABLE [dbo].[TblUserRights]  WITH CHECK ADD  CONSTRAINT [FK_TblUserRights_TblUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[TblUsers] ([ID])
GO
ALTER TABLE [dbo].[TblUserRights] CHECK CONSTRAINT [FK_TblUserRights_TblUsers]
GO
ALTER TABLE [dbo].[TblUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_TblUserRoles_TblRoles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[TblRoles] ([ID])
GO
ALTER TABLE [dbo].[TblUserRoles] CHECK CONSTRAINT [FK_TblUserRoles_TblRoles]
GO
ALTER TABLE [dbo].[TblUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_TblUserRoles_TblUserRoles] FOREIGN KEY([UserID])
REFERENCES [dbo].[TblUsers] ([ID])
GO
ALTER TABLE [dbo].[TblUserRoles] CHECK CONSTRAINT [FK_TblUserRoles_TblUserRoles]
GO
USE [master]
GO
ALTER DATABASE [SettingsManagement] SET  READ_WRITE 
GO
