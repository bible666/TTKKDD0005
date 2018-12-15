USE [TKD]
GO

/****** Object:  Table [dbo].[Poomse_Position]    Script Date: 01/17/2013 21:56:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Poomse_Position](
	[Position_Id] [int] NOT NULL,
	[Position_Desc] [nvarchar](50) NULL,
	[Position_Seq] [int] NULL,
 CONSTRAINT [PK_Poomse_Position] PRIMARY KEY CLUSTERED 
(
	[Position_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


