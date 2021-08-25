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
	[CompanyEmail] [nvarchar](100) NULL,
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


USE [Medical]
GO

/****** Object:  Table [dbo].[Medical_Log]    Script Date: 15-08-2021 03:09:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[Medical_Log]    Script Date: 8/15/2021 2:12:26 AM ******/

CREATE TABLE [dbo].[Medical_Log](
	[SequentialId] [int] IDENTITY(1,1) NOT NULL,
	[EventDateTime] [datetime2](7) NULL,
	[EventLevel] [nvarchar](10) NULL,
	[EventMessage] [nvarchar](500) NULL,
	[EventProperties] [nvarchar](max) NULL,
	[EventGuid] [nvarchar](38) NULL,
	[MachineName] [nvarchar](100) NULL,
	[ProcessId] [int] NULL,
	[ProcessName] [nvarchar](100) NULL,
	[AppDomainId] [int] NULL,
	[AppDomainName] [nvarchar](100) NULL,
	[ThreadId] [int] NULL,
	[ThreadName] [nvarchar](100) NULL,
	[SiteName] [nvarchar](100) NULL,
	[LoggerName] [nvarchar](100) NULL,
	[ThreadIdentity] [nvarchar](100) NULL,
	[WebIdentity] [nvarchar](100) NULL,
	[ExceptionMessage] [nvarchar](max) NULL,
	[ExceptionType] [nvarchar](300) NULL,
	[ExceptionData] [nvarchar](max) NULL,
	[ExceptionStackTrace] [nvarchar](max) NULL,
	[HttpRequest] [nvarchar](max) NULL,
	[IpAddress] [nvarchar](100) NULL,
	[SessionId] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


GO

CREATE PROCEDURE [dbo].[spWebLogInsert]
	@EventDateTime datetime2(7),
	@EventLevel nvarchar(10),
	@EventMessage nvarchar(500) = NULL,
	@EventProperties nvarchar(max) = NULL,
	@EventGuid nvarchar(38) = NULL,
	@MachineName nvarchar(100),
	@ProcessId int,
	@ProcessName nvarchar(100),
	@AppDomainId int,
	@AppDomainName nvarchar(100) = NULL,
	@ThreadId int,
	@ThreadName nvarchar(100) = NULL,
	@SiteName nvarchar(100),
	@LoggerName nvarchar(100),
	@ThreadIdentity nvarchar(100) = NULL,
	@WebIdentity nvarchar(100) = NULL,
	@ExceptionMessage nvarchar(max) = NULL,
	@ExceptionType nvarchar(300) = NULL,
	@ExceptionData nvarchar(max) = NULL,
	@ExceptionStackTrace nvarchar(max) = NULL,
	@HttpRequest nvarchar(max) = NULL,
	@IpAddress nvarchar(100) NULL,
	@SessionId nvarchar(max) NULL
AS
BEGIN

    DECLARE @V2LogId TABLE (Id INT)

	INSERT INTO [dbo].[Medical_Log]
			   ([EventDateTime]
			   ,[EventLevel]
			   ,[EventMessage]
			   ,[EventProperties]
			   ,[EventGuid]
			   ,[MachineName]
			   ,[ProcessId]
			   ,[ProcessName]
			   ,[AppDomainId]
			   ,[AppDomainName]
			   ,[ThreadId]
			   ,[ThreadName]
			   ,[SiteName]
			   ,[LoggerName]
			   ,[ThreadIdentity]
			   ,[WebIdentity]
			   ,[ExceptionMessage]
			   ,[ExceptionType]
			   ,[ExceptionData]
			   ,[ExceptionStackTrace]
			   ,[HttpRequest]
			   ,[IpAddress]
			   ,[SessionId])
		 OUTPUT INSERTED.SequentialId INTO @V2LogId
		 VALUES
			   (@EventDateTime,
				NULLIF(@EventLevel, ''),
				NULLIF(@EventMessage, ''),
				NULLIF(@EventProperties, ''),
				(SELECT CONVERT(uniqueidentifier, @EventGuid) WHERE REPLACE(REPLACE(@EventGuid, '{', ''), '}', '') LIKE REPLACE('00000000-0000-0000-0000-000000000000', '0', '[0-9a-fA-F') COLLATE Latin1_General_BIN),
				NULLIF(@MachineName, ''),
				@ProcessId,
				NULLIF(@ProcessName, ''),
				@AppDomainId,
				NULLIF(@AppDomainName, ''),
				@ThreadId,
				NULLIF(@ThreadName, ''),
				NULLIF(@SiteName, ''),
				NULLIF(@LoggerName, ''),
				CASE @ThreadIdentity WHEN 'notauth::' THEN NULL WHEN '' THEN NULL ELSE @ThreadIdentity END,
				CASE @WebIdentity WHEN 'notauth::' THEN NULL WHEN '' THEN NULL ELSE @WebIdentity END,
				NULLIF(@ExceptionMessage, ''),
				NULLIF(@ExceptionType, ''),
				NULLIF(@ExceptionData, ''),
				NULLIF(@ExceptionStackTrace, ''),
				CASE LTRIM(@HttpRequest) WHEN '' THEN NULL WHEN CHAR(13) + CHAR(10) THEN NULL ELSE @HttpRequest END,
				NULLIF(@IpAddress, ''),
				NULLIF(@SessionId, ''))

   
END
GO






CREATE PROCEDURE [dbo].[InsertEmployeeDetails]
	@UserName nvarchar(100),
	@Password nvarchar(100),
	@CreatedBy int,
	@Place nvarchar(100),
	@City nvarchar(100),
	@District nvarchar(100),
	@State nvarchar(100),
	@Country nvarchar(100),
	@ZipCode nvarchar(100)



AS
BEGIN
    --SET NOCOUNT ON;
BEGIN TRANSACTION
	BEGIN TRY
		INSERT INTO [dbo].[Employee] (
				[UserName],
				[Password], 
				[IsActive],
				[IsDeleted], 
				[CreatedBy], 
				[CreatedDate]
			)
		VALUES(
			@UserName,
			@Password,
			1,
			0,
			@CreatedBy,
			GETDATE()
			)

		INSERT INTO [dbo].[EmployeeDetails] (
			Fk_EmployeeID,
			Place,
			City,
			District,
			[State],
			Country,
			ZipCode
		)
		VALUES(
			1,
			@Place,
			@City,
			@District,
			@State,
			@Country,
			@ZipCode
		)
	COMMIT 
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		exec [dbo].[spWebLogInsert] '','','','','','','','','','','','','','','','','',''
	END CATCH

END



GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE InsertCompanyDetails
	@ComapnyOwnerID int,
	@CompanyName nvarchar(max),
	@CompanyCode nvarchar(max),
	@CompanyEmail nvarchar(max),
	@District nvarchar(max),
	@State nvarchar(max),
	@Place nvarchar(max),
	@City nvarchar(max),
	@Country nvarchar(max),
	@ZipCode nvarchar(max),
	@CreatedBy nvarchar(max),
	@CreatedDate nvarchar(max)

AS
BEGIN
	INSERT INTO [dbo].[Company](
					ComapnyOwnerID, 
					CompanyName, 
					CompanyCode, 
					CompanyEmail, 
					Place, 
					City, 
					District, 
					[State], 
					Country, 
					ZipCode, 
					IsActive,
					IsDeleted, 
					CreatedBy, 
					CreatedDate, 
					ModifiedBy,
					ModifiedDate
				)
				VALUES(
					@ComapnyOwnerID, 
					@CompanyName, 
					@CompanyCode, 
					@CompanyEmail, 
					@Place, 
					@City, 
					@District, 
					@State, 
					@Country, 
					@ZipCode, 
					1,
					0, 
					1, 
					GETDATE(), 
					1,
					GETDATE()
				)
	
END
GO


CREATE PROCEDURE [dbo].[getLoginDetails]
@UserName nvarchar(max),
@Password nvarchar(max)
	
AS
BEGIN
Select *from [dbo].[Employee] where UserName=@UserName AND [Password]=@Password
END
