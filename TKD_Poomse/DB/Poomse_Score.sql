USE [TKD]
GO

/****** Object:  Table [dbo].[Poomse_Score]    Script Date: 01/17/2013 21:56:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Poomse_Score](
	[Athlete_Id] [int] NOT NULL,
	[Round] [int] NOT NULL,
	[Final] [decimal](18, 2) NULL,
	[Acc_1] [decimal](18, 2) NULL,
	[Acc_2] [decimal](18, 2) NULL,
	[Acc_3] [decimal](18, 2) NULL,
	[Acc_4] [decimal](18, 2) NULL,
	[Acc_5] [decimal](18, 2) NULL,
	[Acc_6] [decimal](18, 2) NULL,
	[Acc_7] [decimal](18, 2) NULL,
	[Pre_1] [decimal](18, 2) NULL,
	[Pre_2] [decimal](18, 2) NULL,
	[Pre_3] [decimal](18, 2) NULL,
	[Pre_4] [decimal](18, 2) NULL,
	[Pre_5] [decimal](18, 2) NULL,
	[Pre_6] [decimal](18, 2) NULL,
	[Pre_7] [decimal](18, 2) NULL,
	[K] [int] NULL,
 CONSTRAINT [PK_Poomse_Score] PRIMARY KEY CLUSTERED 
(
	[Athlete_Id] ASC,
	[Round] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


