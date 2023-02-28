USE [projectLS]
GO

/****** Object:  Table [dbo].[UserProfilePic]    Script Date: 2/28/2023 6:27:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserProfilePic](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Pic] [varchar](max) NOT NULL,
 CONSTRAINT [PK_UserProfilePic] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserProfilePic]  WITH CHECK ADD  CONSTRAINT [FK_UserProfilePic_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[UserProfilePic] CHECK CONSTRAINT [FK_UserProfilePic_User]
GO


