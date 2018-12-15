USE [TKD]
GO

/****** Object:  Table [dbo].[Poomse_Age]    Script Date: 01/17/2013 21:56:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Poomse_Age](
	[Age_Id] [int] NOT NULL,
	[Age_Desc] [nvarchar](50) NULL,
	[Age_Seq] [int] NULL,
 CONSTRAINT [PK_Poomse_Age] PRIMARY KEY CLUSTERED 
(
	[Age_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


