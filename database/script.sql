USE [vcenter]
GO
/****** Object:  Table [dbo].[VM_Aanvragen]    Script Date: 6/9/2020 9:46:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VM_Aanvragen](
	[AanvraagID] [int] IDENTITY(1,1) NOT NULL,
	[Datum] [datetime] NULL,
	[Naam] [varchar](25) NOT NULL,
	[Vmnaam] [varchar](25) NOT NULL,
	[OS] [varchar](25) NOT NULL,
	[CPU] [int] NOT NULL,
	[RAM] [int] NOT NULL,
	[Netwerk] [varchar](25) NOT NULL,
	[Folder] [varchar](25) NOT NULL,
	[Datacenter] [varchar](25) NOT NULL,
	[Datastore] [varchar](25) NOT NULL,
	[Reden] [varchar](3000) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AanvraagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VM_archief]    Script Date: 6/9/2020 9:46:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VM_archief](
	[AanvraagID] [int] NOT NULL,
	[Datum] [datetime] NULL,
	[Naam] [varchar](25) NOT NULL,
	[Vmnaam] [varchar](25) NOT NULL,
	[OS] [varchar](25) NOT NULL,
	[CPU] [int] NOT NULL,
	[RAM] [int] NOT NULL,
	[Netwerk] [varchar](25) NOT NULL,
	[Folder] [varchar](25) NOT NULL,
	[Datacenter] [varchar](25) NOT NULL,
	[Datastore] [varchar](25) NOT NULL,
	[Reden] [varchar](3000) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AanvraagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VM_Netwerk]    Script Date: 6/9/2020 9:46:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VM_Netwerk](
	[Groep] [varchar](25) NULL,
	[Portgroup] [varchar](25) NULL
) ON [PRIMARY]
GO
