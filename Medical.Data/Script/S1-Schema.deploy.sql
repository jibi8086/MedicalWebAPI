USE [Medical]
GO

/****** Object:  Table [dbo].[Company]    Script Date: 8/15/2021 1:55:34 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Company](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ComapnyOwnerID] [int] NULL,
	[CompanyName] [nvarchar](max) NULL,
	[CompanyCode] [nvarchar](50) NULL,
	[Place] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[District] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[ZipCode] [nvarchar](50) NULL,
	[IsActive] bit NULL,
	[IsDeleted] bit NULL,
	[CreatedBy] int NULL,
	[CreatedDate] datetime NULL,
	[ModifiedBy] int NULL,
	[ModifiedDate] datetime NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


USE [Medical]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 8/15/2021 2:05:06 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [Medical]
GO

/****** Object:  Table [dbo].[EmployeeDetails]    Script Date: 8/15/2021 2:12:26 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmployeeDetails](
	[ID] [int] NULL,
	[Fk_EmployeeID] [int] NULL,
	[Image] [varbinary](max) NULL,
	[Place] [nvarchar](100) NULL,
	[City] [nvarchar](100) NULL,
	[District] [nvarchar](100) NULL,
	[State] [nvarchar](100) NULL,
	[Country] [nvarchar](100) NULL,
	[ZipCode] [nvarchar](100) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
