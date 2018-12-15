USE [TKD]
GO

/****** Object:  Table [dbo].[Poomse_Sex]    Script Date: 01/17/2013 21:56:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Poomse_Sex](
	[Sex_Id] [int] NOT NULL,
	[Sex_Desc] [nvarchar](50) NULL,
	[Sex_Seq] [nchar](10) NULL,
 CONSTRAINT [PK_Poomse_Sex] PRIMARY KEY CLUSTERED 
(
	[Sex_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


