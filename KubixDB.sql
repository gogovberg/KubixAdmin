USE [master]
GO
/****** Object:  Database [KubixDB]    Script Date: 1. 03. 2019 16:30:39 ******/
CREATE DATABASE [KubixDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KubixDB', FILENAME = N'C:\Users\aleksandar.gogov\KubixDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KubixDB_log', FILENAME = N'C:\Users\aleksandar.gogov\KubixDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KubixDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KubixDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KubixDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KubixDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KubixDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KubixDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [KubixDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KubixDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KubixDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KubixDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KubixDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KubixDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KubixDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KubixDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KubixDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KubixDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KubixDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KubixDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KubixDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KubixDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KubixDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KubixDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KubixDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KubixDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KubixDB] SET  MULTI_USER 
GO
ALTER DATABASE [KubixDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KubixDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KubixDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KubixDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KubixDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [KubixDB]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 1. 03. 2019 16:30:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[CreationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Materials]    Script Date: 1. 03. 2019 16:30:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materials](
	[MaterialID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[UnitMeasurement] [nvarchar](50) NOT NULL,
	[UnitPrice] [int] NOT NULL,
	[Type] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaterialID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Projects]    Script Date: 1. 03. 2019 16:30:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[IsFinished] [bit] NOT NULL,
	[ExpirationDate] [datetime] NULL,
	[ExpectedPrice] [decimal](19, 4) NULL,
	[ActualPrice] [decimal](19, 4) NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC,
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProjectServices]    Script Date: 1. 03. 2019 16:30:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectServices](
	[ProjectID] [int] NOT NULL,
	[ServiceID] [int] NOT NULL,
	[UnitsPerService] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC,
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ServiceMaterials]    Script Date: 1. 03. 2019 16:30:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceMaterials](
	[ServiceID] [int] NOT NULL,
	[MaterialID] [int] NOT NULL,
	[MaterialPerUnit] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaterialID] ASC,
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Services]    Script Date: 1. 03. 2019 16:30:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[WorkPrice] [int] NOT NULL,
	[WorkTime] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 1. 03. 2019 16:30:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sysdiagrams](
	[name] [nvarchar](128) NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
 CONSTRAINT [PK_sysdiagrams] PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Surname], [Address], [PhoneNumber], [Email], [CreationDate]) VALUES (1, N'Kiro', N'Pokrajchevaliev', N'zelena jama', N'070185125', N'kiro@kiro.kiro', CAST(N'2019-02-13 11:10:52.653' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Materials] ON 

GO
INSERT [dbo].[Materials] ([MaterialID], [Name], [Description], [UnitMeasurement], [UnitPrice], [Type]) VALUES (1, N'Bela barva', N'bela barva za krechenje u dnevna soba be peer', N'liters', 10, N'Strumichka')
GO
INSERT [dbo].[Materials] ([MaterialID], [Name], [Description], [UnitMeasurement], [UnitPrice], [Type]) VALUES (2, N'Bela boja 5l', N'Bela boja so e 5 litra i e poeftina', N'litar ', 10, N'marka posebna')
GO
INSERT [dbo].[Materials] ([MaterialID], [Name], [Description], [UnitMeasurement], [UnitPrice], [Type]) VALUES (3, N'Ogled in izmere', N'ogled in izmere tam i=asfasd', N'time', 1, N'')
GO
INSERT [dbo].[Materials] ([MaterialID], [Name], [Description], [UnitMeasurement], [UnitPrice], [Type]) VALUES (4, N'Test material 1', N'test material 1', N'cm', 10, N'tip')
GO
INSERT [dbo].[Materials] ([MaterialID], [Name], [Description], [UnitMeasurement], [UnitPrice], [Type]) VALUES (5, N'Test material 2', N'Test material 2', N'm', 15, N'tip')
GO
INSERT [dbo].[Materials] ([MaterialID], [Name], [Description], [UnitMeasurement], [UnitPrice], [Type]) VALUES (6, N'Test material 3', N'test material 3', N'm2', 20, N'tip')
GO
SET IDENTITY_INSERT [dbo].[Materials] OFF
GO
SET IDENTITY_INSERT [dbo].[Projects] ON 

GO
INSERT [dbo].[Projects] ([ProjectID], [CustomerID], [Name], [Address], [IsFinished], [ExpirationDate], [ExpectedPrice], [ActualPrice]) VALUES (1, 1, N'Terasa ', N'Doma', 0, CAST(N'2019-02-21 00:00:00.000' AS DateTime), CAST(125.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)))
GO
SET IDENTITY_INSERT [dbo].[Projects] OFF
GO
INSERT [dbo].[ServiceMaterials] ([ServiceID], [MaterialID], [MaterialPerUnit]) VALUES (2, 1, 10)
GO
INSERT [dbo].[ServiceMaterials] ([ServiceID], [MaterialID], [MaterialPerUnit]) VALUES (2, 2, 10)
GO
INSERT [dbo].[ServiceMaterials] ([ServiceID], [MaterialID], [MaterialPerUnit]) VALUES (2, 4, 10)
GO
INSERT [dbo].[ServiceMaterials] ([ServiceID], [MaterialID], [MaterialPerUnit]) VALUES (2, 5, 10)
GO
INSERT [dbo].[ServiceMaterials] ([ServiceID], [MaterialID], [MaterialPerUnit]) VALUES (2, 6, 10)
GO
SET IDENTITY_INSERT [dbo].[Services] ON 

GO
INSERT [dbo].[Services] ([ServiceID], [Name], [Description], [WorkPrice], [WorkTime]) VALUES (1, N'pleskanje', N'not spanking', 10, 102)
GO
INSERT [dbo].[Services] ([ServiceID], [Name], [Description], [WorkPrice], [WorkTime]) VALUES (2, N'Test service', N'service for testing', 100, 100)
GO
SET IDENTITY_INSERT [dbo].[Services] OFF
GO
USE [master]
GO
ALTER DATABASE [KubixDB] SET  READ_WRITE 
GO
