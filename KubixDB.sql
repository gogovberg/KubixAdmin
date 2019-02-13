USE [KubixDB]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 13. 02. 2019 17:34:06 ******/
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
/****** Object:  Table [dbo].[Materials]    Script Date: 13. 02. 2019 17:34:06 ******/
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
/****** Object:  Table [dbo].[Projects]    Script Date: 13. 02. 2019 17:34:06 ******/
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
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 13. 02. 2019 17:34:06 ******/
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
SET IDENTITY_INSERT [dbo].[Materials] OFF
GO
SET IDENTITY_INSERT [dbo].[Projects] ON 

GO
INSERT [dbo].[Projects] ([ProjectID], [CustomerID], [Name], [Address], [IsFinished], [ExpirationDate], [ExpectedPrice], [ActualPrice]) VALUES (1, 1, N'Terasa ', N'Doma', 0, CAST(N'2019-02-21 00:00:00.000' AS DateTime), CAST(125.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)))
GO
SET IDENTITY_INSERT [dbo].[Projects] OFF
GO
