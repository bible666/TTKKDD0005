USE [TKD]
GO

/****** Object:  Table [dbo].[Poomse_Athlete]    Script Date: 01/17/2013 21:56:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Poomse_Athlete](
	[Athlete_Id] [int] NOT NULL,
	[Athlete_Name] [nvarchar](2500) NULL,
	[Athlete_Team] [nvarchar](200) NULL,
	[Age_Id] [int] NULL,
	[Sex_Id] [int] NULL,
	[Level_Id] [int] NULL,
	[Type_Id] [int] NULL,
	[Position_Id] [int] NULL,
 CONSTRAINT [PK_Poomse_Athlete] PRIMARY KEY CLUSTERED 
(
	[Athlete_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Poomse_Athlete]  WITH CHECK ADD  CONSTRAINT [FK_Poomse_Athlete_Poomse_Level] FOREIGN KEY([Level_Id])
REFERENCES [dbo].[Poomse_Level] ([Level_Id])
GO

ALTER TABLE [dbo].[Poomse_Athlete] CHECK CONSTRAINT [FK_Poomse_Athlete_Poomse_Level]
GO


