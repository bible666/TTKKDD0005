USE [TKD]
GO

/****** Object:  Table [dbo].[Poomse_Type]    Script Date: 01/17/2013 21:56:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Poomse_Type](
	[Type_Id] [int] NOT NULL,
	[Type_Desc] [nvarchar](50) NULL,
	[Type_Seq] [nchar](10) NULL,
 CONSTRAINT [PK_Poomse_Type] PRIMARY KEY CLUSTERED 
(
	[Type_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


