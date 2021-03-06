USE [Crawler]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 2019/11/21 下午 12:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[Id] [varchar](50) NOT NULL,
	[PostId] [varchar](50) NULL,
	[Anonymous] [bit] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[Floor] [int] NOT NULL,
	[Content] [nvarchar](max) NULL,
	[LikeCount] [int] NOT NULL,
	[WithNickname] [bit] NOT NULL,
	[HiddenByAuthor] [bit] NOT NULL,
	[Gender] [nvarchar](max) NULL,
	[School] [nvarchar](max) NULL,
	[Host] [bit] NOT NULL,
	[ReportReason] [nvarchar](max) NULL,
	[Hidden] [bit] NOT NULL,
	[InReview] [bit] NOT NULL,
	[ReportReasonText] [nvarchar](max) NULL,
	[PostAvatar] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Comment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Media]    Script Date: 2019/11/21 下午 12:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Media](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PostId] [varchar](50) NULL,
	[Url] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Media] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MediaMeta]    Script Date: 2019/11/21 下午 12:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MediaMeta](
	[Id] [varchar](50) NOT NULL,
	[PostId] [varchar](50) NULL,
	[CommentId] [varchar](50) NULL,
	[Url] [nvarchar](max) NULL,
	[NormalizedUrl] [nvarchar](max) NULL,
	[Thumbnail] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.MediaMeta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meta]    Script Date: 2019/11/21 下午 12:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PostId] [varchar](50) NULL,
	[CommentId] [varchar](50) NULL,
	[Layout] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Meta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 2019/11/21 下午 12:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[Id] [varchar](50) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[Excerpt] [nvarchar](max) NULL,
	[AnonymousSchool] [bit] NOT NULL,
	[AnonymousDepartment] [bit] NOT NULL,
	[Pinned] [bit] NOT NULL,
	[ForumId] [nvarchar](max) NULL,
	[ReplyId] [int] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[CommentCount] [int] NOT NULL,
	[LikeCount] [int] NOT NULL,
	[SupportedReactions] [nvarchar](max) NULL,
	[WithNickname] [bit] NOT NULL,
	[ReportReason] [nvarchar](max) NULL,
	[HiddenByAuthor] [bit] NOT NULL,
	[ForumName] [nvarchar](max) NULL,
	[ForumAlias] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[ReplyTitle] [nvarchar](max) NULL,
	[PersonaSubscriptable] [bit] NOT NULL,
	[Hidden] [bit] NOT NULL,
	[CustomStyle] [nvarchar](max) NULL,
	[Layout] [nvarchar](max) NULL,
	[WithImages] [bit] NOT NULL,
	[WithVideos] [bit] NOT NULL,
	[ReportReasonText] [nvarchar](max) NULL,
	[PostAvatar] [nvarchar](max) NULL,
	[Reacted] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Post] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostTopic]    Script Date: 2019/11/21 下午 12:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostTopic](
	[PostId] [varchar](50) NOT NULL,
	[TopicId] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PostTopic] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC,
	[TopicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 2019/11/21 下午 12:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PostId] [varchar](50) NULL,
	[MediaMetaId] [varchar](50) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Tag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topic]    Script Date: 2019/11/21 下午 12:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topic](
	[Id] [varchar](50) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Topic] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Comment_dbo.Post_PostId] FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([Id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_dbo.Comment_dbo.Post_PostId]
GO
ALTER TABLE [dbo].[Media]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Media_dbo.Post_PostId] FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([Id])
GO
ALTER TABLE [dbo].[Media] CHECK CONSTRAINT [FK_dbo.Media_dbo.Post_PostId]
GO
ALTER TABLE [dbo].[MediaMeta]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MediaMeta_dbo.Post_PostId] FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([Id])
GO
ALTER TABLE [dbo].[MediaMeta] CHECK CONSTRAINT [FK_dbo.MediaMeta_dbo.Post_PostId]
GO
ALTER TABLE [dbo].[MediaMeta]  WITH CHECK ADD  CONSTRAINT [FK_MediaMeta_Comment] FOREIGN KEY([CommentId])
REFERENCES [dbo].[Comment] ([Id])
GO
ALTER TABLE [dbo].[MediaMeta] CHECK CONSTRAINT [FK_MediaMeta_Comment]
GO
ALTER TABLE [dbo].[Meta]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Meta_dbo.Post_PostId] FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([Id])
GO
ALTER TABLE [dbo].[Meta] CHECK CONSTRAINT [FK_dbo.Meta_dbo.Post_PostId]
GO
ALTER TABLE [dbo].[Meta]  WITH CHECK ADD  CONSTRAINT [FK_Meta_Comment] FOREIGN KEY([CommentId])
REFERENCES [dbo].[Comment] ([Id])
GO
ALTER TABLE [dbo].[Meta] CHECK CONSTRAINT [FK_Meta_Comment]
GO
ALTER TABLE [dbo].[PostTopic]  WITH CHECK ADD  CONSTRAINT [FK_PostTopic_Post] FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([Id])
GO
ALTER TABLE [dbo].[PostTopic] CHECK CONSTRAINT [FK_PostTopic_Post]
GO
ALTER TABLE [dbo].[PostTopic]  WITH CHECK ADD  CONSTRAINT [FK_PostTopic_Topic] FOREIGN KEY([TopicId])
REFERENCES [dbo].[Topic] ([Id])
GO
ALTER TABLE [dbo].[PostTopic] CHECK CONSTRAINT [FK_PostTopic_Topic]
GO
ALTER TABLE [dbo].[Tag]  WITH CHECK ADD  CONSTRAINT [FK_Tag_MediaMeta] FOREIGN KEY([MediaMetaId])
REFERENCES [dbo].[MediaMeta] ([Id])
GO
ALTER TABLE [dbo].[Tag] CHECK CONSTRAINT [FK_Tag_MediaMeta]
GO
ALTER TABLE [dbo].[Tag]  WITH CHECK ADD  CONSTRAINT [FK_Tag_Post] FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([Id])
GO
ALTER TABLE [dbo].[Tag] CHECK CONSTRAINT [FK_Tag_Post]
GO
