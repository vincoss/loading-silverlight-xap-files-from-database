USE [SilverlightXapDb]
GO
/****** Object:  Table [dbo].[BinaryStreams]    Script Date: 03/29/2011 10:02:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BinaryStreams](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](128) NOT NULL,
	[ContentType] [nvarchar](128) NOT NULL,
	[Size] [bigint] NOT NULL,
	[BlobData] [varbinary](max) NULL,
 CONSTRAINT [PK_BinaryStreams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
