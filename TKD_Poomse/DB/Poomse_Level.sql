USE [TKD]
GO

/****** Object:  Table [dbo].[Poomse_Level]    Script Date: 01/17/2013 21:56:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Poomse_Level](
	[Level_Id] [int] NOT NULL,
	[Level_Desc] [nvarchar](50) NULL,
 CONSTRAINT [PK_Poomse_Level] PRIMARY KEY CLUSTERED 
(
	[Level_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


