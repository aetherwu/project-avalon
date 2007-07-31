if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_Comment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_Comment]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_Post]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_Post]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_Refer]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_Refer]
GO

CREATE TABLE [dbo].[blog_Comment] (
	[comm_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[log_PostTime] [datetime] NOT NULL ,
	[comm_Author] [nvarchar] (24) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[comm_Content] [ntext] COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[comm_HomePage] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[comm_PostTime] [datetime] NULL ,
	[comm_IP] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[blog_Post] (
	[log_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[log_Content] [ntext] COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[log_PostTime] [datetime] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[blog_Refer] (
	[re_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[log_PostTime] [datetime] NOT NULL ,
	[re_URL] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[re_Date] [datetime] NOT NULL 
) ON [PRIMARY]
GO

