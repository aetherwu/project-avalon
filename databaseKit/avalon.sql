if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_Comment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_Comment]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[live_Clip]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[live_Clip]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[live_Source]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[live_Source]
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

CREATE TABLE [dbo].[live_Clip] (
	[c_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[content] [ntext] COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[postTime] [datetime] NOT NULL ,
	[sourceID] [int] NOT NULL ,
	[link] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[live_Source] (
	[s_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[owner] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[type] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[site] [nvarchar] (500) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[source] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[lastUpdate] [datetime] NOT NULL ,
	[tomezone] [int] NOT NULL ,
	[updateHit] [int] NOT NULL 
) ON [PRIMARY]
GO

