USE [MainProject]
GO
/****** Object:  StoredProcedure [dbo].[getdata]    Script Date: 6/5/2021 12:10:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getdata] 
	@id as int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TQ.TestId, TP.RegistrationId,S.Name,Q.Question,Q.QuestionType,C.Label,TP.MarkScored
	FROM [dbo].[TestXQuestion]TQ
	INNER JOIN Question Q ON  Q.Qid = TQ.QuestionId
	INNER JOIN TestXPaper TP ON TP.TestXQuestionId = TQ.Id
	INNER JOIN Student S ON S.Id = TP.RegistrationId
	INNER JOIN Choice C ON C.ChoiceId = TP.ChoiceId
END
GO
/****** Object:  Table [dbo].[Choice]    Script Date: 6/5/2021 12:10:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Choice](
	[ChoiceId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionId] [int] NOT NULL,
	[Label] [nvarchar](max) NOT NULL,
	[points] [decimal](13, 2) NOT NULL,
	[isactive] [bit] NOT NULL,
 CONSTRAINT [PK_Choice] PRIMARY KEY CLUSTERED 
(
	[ChoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExamRegistration]    Script Date: 6/5/2021 12:10:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamRegistration](
	[ExamId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[TestId] [int] NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[Token] [uniqueidentifier] NOT NULL,
	[TokenExpireTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ExamRegistration] PRIMARY KEY CLUSTERED 
(
	[ExamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Exhibit]    Script Date: 6/5/2021 12:10:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Exhibit](
	[Eid] [int] IDENTITY(1,1) NOT NULL,
	[ExhibitData] [varchar](50) NULL,
 CONSTRAINT [PK_Exhibit] PRIMARY KEY CLUSTERED 
(
	[Eid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Notification]    Script Date: 6/5/2021 12:10:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Notification](
	[Nid] [int] NULL,
	[Notification] [varchar](max) NULL,
	[Status] [varchar](50) NULL,
	[Date] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Question]    Script Date: 6/5/2021 12:10:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Question](
	[Qid] [int] IDENTITY(1,1) NOT NULL,
	[QCid] [int] NOT NULL,
	[QuestionType] [varchar](50) NOT NULL,
	[Question] [varchar](max) NOT NULL,
	[ExhibitId] [int] NULL,
	[points] [int] NOT NULL,
	[isactive] [bit] NOT NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[Qid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuestionCategory]    Script Date: 6/5/2021 12:10:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QuestionCategory](
	[Cid] [int] IDENTITY(1,1) NOT NULL,
	[Category] [varchar](50) NULL,
 CONSTRAINT [PK_QuestionCategory] PRIMARY KEY CLUSTERED 
(
	[Cid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuestionXDuration]    Script Date: 6/5/2021 12:10:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionXDuration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationId] [int] NOT NULL,
	[TestXQuestionId] [int] NOT NULL,
	[RequestTime] [datetime] NOT NULL,
	[LeaveTime] [datetime] NULL,
	[AnsweredTime] [datetime] NULL,
 CONSTRAINT [PK_QuestionXDuration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Registration]    Script Date: 6/5/2021 12:10:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Registration](
	[Rid] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Department] [varchar](50) NULL,
	[EntryDate] [datetime] NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Image] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
	[Role] [varchar](50) NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[Rid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student]    Script Date: 6/5/2021 12:10:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[AccessLevel] [int] NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[PassHash] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Table_1]    Script Date: 6/5/2021 12:10:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_1](
	[ChoiceId] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Test]    Script Date: 6/5/2021 12:10:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Test](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[isactive] [bit] NOT NULL,
	[DurationInMinute] [int] NOT NULL,
 CONSTRAINT [PK_Test_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TestXPaper]    Script Date: 6/5/2021 12:10:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestXPaper](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationId] [int] NOT NULL,
	[TestXQuestionId] [int] NOT NULL,
	[ChoiceId] [int] NOT NULL,
	[Answer] [nvarchar](max) NULL,
	[MarkScored] [decimal](13, 2) NULL,
 CONSTRAINT [PK_TestXPaper] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestXQuestion]    Script Date: 6/5/2021 12:10:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestXQuestion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TestId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL,
	[QuestionNumber] [int] NOT NULL,
	[isactive] [bit] NOT NULL,
 CONSTRAINT [PK_TestXQuestion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Choice] ON 

INSERT [dbo].[Choice] ([ChoiceId], [QuestionId], [Label], [points], [isactive]) VALUES (2, 1, N'5 (Five)', CAST(0.00 AS Decimal(13, 2)), 1)
INSERT [dbo].[Choice] ([ChoiceId], [QuestionId], [Label], [points], [isactive]) VALUES (3, 1, N'3 (Three)', CAST(100.00 AS Decimal(13, 2)), 1)
INSERT [dbo].[Choice] ([ChoiceId], [QuestionId], [Label], [points], [isactive]) VALUES (4, 1, N'2 (Two)', CAST(0.00 AS Decimal(13, 2)), 1)
INSERT [dbo].[Choice] ([ChoiceId], [QuestionId], [Label], [points], [isactive]) VALUES (5, 2, N'1 (One)', CAST(0.00 AS Decimal(13, 2)), 1)
INSERT [dbo].[Choice] ([ChoiceId], [QuestionId], [Label], [points], [isactive]) VALUES (6, 2, N'7 (Seven)', CAST(0.00 AS Decimal(13, 2)), 1)
INSERT [dbo].[Choice] ([ChoiceId], [QuestionId], [Label], [points], [isactive]) VALUES (7, 2, N'5 (Five)', CAST(0.00 AS Decimal(13, 2)), 1)
INSERT [dbo].[Choice] ([ChoiceId], [QuestionId], [Label], [points], [isactive]) VALUES (8, 3, N'3 (Three)', CAST(100.00 AS Decimal(13, 2)), 1)
INSERT [dbo].[Choice] ([ChoiceId], [QuestionId], [Label], [points], [isactive]) VALUES (9, 3, N'2 (Two)', CAST(0.00 AS Decimal(13, 2)), 1)
INSERT [dbo].[Choice] ([ChoiceId], [QuestionId], [Label], [points], [isactive]) VALUES (10, 3, N'1 (One)', CAST(0.00 AS Decimal(13, 2)), 1)
INSERT [dbo].[Choice] ([ChoiceId], [QuestionId], [Label], [points], [isactive]) VALUES (11, 1, N'7 (Seven)', CAST(0.00 AS Decimal(13, 2)), 1)
SET IDENTITY_INSERT [dbo].[Choice] OFF
SET IDENTITY_INSERT [dbo].[ExamRegistration] ON 

INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (1, 1, 3, CAST(0x0000AD2B00D7606A AS DateTime), N'82e46a3b-a6d0-487e-acfc-18f4f3a9f49e', CAST(0x0000AD2B00D7606A AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (2, 1, 3, CAST(0x0000AD2B00DE1AF8 AS DateTime), N'1e30e0ed-abcb-40de-8cb4-611c2f774c54', CAST(0x0000AD2B00DE1B0B AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (3, 1, 3, CAST(0x0000AD2B00E35225 AS DateTime), N'7f188492-ecc0-45cc-b7db-788e349d6c18', CAST(0x0000AD2B00E3523F AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (4, 1, 3, CAST(0x0000AD2B00E386DE AS DateTime), N'c19180e6-0342-4170-a703-fee9be470274', CAST(0x0000AD2B00E386E5 AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (7, 13, 3, CAST(0x0000AD2D007614B9 AS DateTime), N'09f91cd1-7010-41c6-b453-67984e0c5cd2', CAST(0x0000AD2D007E5221 AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (8, 14, 3, CAST(0x0000AD2D007C7E66 AS DateTime), N'1ca7e05a-7423-405a-b2fa-0c3662a337e5', CAST(0x0000AD2D0084BBC6 AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (9, 15, 3, CAST(0x0000AD2D00A43EE2 AS DateTime), N'60cf400a-ceb7-4531-a81b-8b312399ca94', CAST(0x0000AD2D00AC7C42 AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (10, 16, 3, CAST(0x0000AD2D00DC81A0 AS DateTime), N'e408f5b1-8661-44f6-8ac3-c7fc6afd3c8d', CAST(0x0000AD2D00E4BF00 AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (11, 17, 3, CAST(0x0000AD2D00EE03AB AS DateTime), N'c6ac6d7c-7e9a-42e6-a7b3-1b75b34b3b68', CAST(0x0000AD2D00F6410B AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (12, 18, 5, CAST(0x0000AD2E00D96A79 AS DateTime), N'5339d199-67f2-482c-ae7a-515614732e5b', CAST(0x0000AD2E00E1A7D9 AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (13, 18, 3, CAST(0x0000AD2E00DA666A AS DateTime), N'0e41f67d-187a-4dad-aa44-5f5410c2c618', CAST(0x0000AD2E00E2A3CA AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (1005, 1011, 3, CAST(0x0000AD2E0116BF8C AS DateTime), N'9a8e5e3c-b7b4-4cd1-b447-7ffffff8fa2d', CAST(0x0000AD2E011EFCEC AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (1006, 1012, 3, CAST(0x0000AD2E01173017 AS DateTime), N'5bab7705-d633-4574-a18b-a43e7e362c49', CAST(0x0000AD2E011F6D77 AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (1007, 3, 3, CAST(0x0000AD32009D76F9 AS DateTime), N'841a868c-237a-46c6-a112-6d703aad2d1f', CAST(0x0000AD3200A5B459 AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (1008, 1013, 3, CAST(0x0000AD3200A5D8EE AS DateTime), N'fe88279c-9e0a-49db-8fac-eba466578b44', CAST(0x0000AD3200AE164E AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (1009, 1013, 3, CAST(0x0000AD3200B15096 AS DateTime), N'b02fe68a-13a2-4484-8b46-dc84c9cec8ab', CAST(0x0000AD3200B98DF6 AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (1010, 1014, 3, CAST(0x0000AD3200B21AF8 AS DateTime), N'017b71c7-a9fa-499c-a348-7196533c3945', CAST(0x0000AD3200BA5858 AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (1011, 1014, 3, CAST(0x0000AD3200BAF9C9 AS DateTime), N'87fef593-3028-41f0-90fe-6b10b9ed8f21', CAST(0x0000AD3200C33729 AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (1012, 1015, 3, CAST(0x0000AD3200BD1C6C AS DateTime), N'ffcc31bb-d8ba-4e4a-bb52-630483fdce89', CAST(0x0000AD3200C559CC AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (1013, 1016, 3, CAST(0x0000AD3200FBC3EA AS DateTime), N'cf43a811-0b34-489e-af46-fa80c27ecd84', CAST(0x0000AD320104014A AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (1014, 1017, 3, CAST(0x0000AD32011349E2 AS DateTime), N'74a1a7f1-b49c-4dab-a2f4-0649441d2e51', CAST(0x0000AD32011B8742 AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (1015, 1018, 3, CAST(0x0000AD32011EC0EA AS DateTime), N'e5560de0-8972-497b-aa5f-2d58ea16366a', CAST(0x0000AD320126FE4A AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (1016, 1019, 3, CAST(0x0000AD3300284F1E AS DateTime), N'381c36be-8831-489b-8022-fc2190037599', CAST(0x0000AD3300308C7E AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (1017, 1020, 3, CAST(0x0000AD33003FA56D AS DateTime), N'094e34ab-e3f0-4643-9299-79bc1702b6f7', CAST(0x0000AD330047E2CD AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (1018, 1021, 3, CAST(0x0000AD3300DE10A0 AS DateTime), N'3258d4b3-de78-4d9d-aa14-cb9647d7097a', CAST(0x0000AD3300E64E00 AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (1019, 1022, 3, CAST(0x0000AD3300E5CF73 AS DateTime), N'73988fda-e8dc-4684-ae9f-d588223171f0', CAST(0x0000AD3300EE0CD3 AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (1020, 1023, 3, CAST(0x0000AD3300EAC658 AS DateTime), N'b30c3d10-abca-4e86-b123-f8c759c91530', CAST(0x0000AD3300F303B8 AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (1021, 1024, 3, CAST(0x0000AD3500A7928D AS DateTime), N'a4bc6d1f-1382-49e1-b513-3bc875b0589e', CAST(0x0000AD3500AFCFED AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (1022, 1025, 3, CAST(0x0000AD3500ADD8FD AS DateTime), N'c6e45503-3256-4dd7-ba1c-91341a41e7bb', CAST(0x0000AD3500B6165D AS DateTime))
INSERT [dbo].[ExamRegistration] ([ExamId], [StudentId], [TestId], [RegistrationDate], [Token], [TokenExpireTime]) VALUES (1023, 1026, 3, CAST(0x0000AD3500BA1C07 AS DateTime), N'311d0543-b8f8-4624-b364-1221ac28f7bb', CAST(0x0000AD3500C25967 AS DateTime))
SET IDENTITY_INSERT [dbo].[ExamRegistration] OFF
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([Qid], [QCid], [QuestionType], [Question], [ExhibitId], [points], [isactive]) VALUES (1, 1, N'RADIO', N'What is the Result of summation of 1 and 2 <b> (1+2 = ? ) </b>?', NULL, 100, 1)
INSERT [dbo].[Question] ([Qid], [QCid], [QuestionType], [Question], [ExhibitId], [points], [isactive]) VALUES (2, 2, N'RADIO', N'describe yu', NULL, 100, 1)
INSERT [dbo].[Question] ([Qid], [QCid], [QuestionType], [Question], [ExhibitId], [points], [isactive]) VALUES (3, 3, N'Text', N'Describr MVC', NULL, 100, 1)
INSERT [dbo].[Question] ([Qid], [QCid], [QuestionType], [Question], [ExhibitId], [points], [isactive]) VALUES (7, 2, N'CheckBox', N'Choose interpretted Language', NULL, 100, 1)
INSERT [dbo].[Question] ([Qid], [QCid], [QuestionType], [Question], [ExhibitId], [points], [isactive]) VALUES (1004, 1, N'RADIO', N'Choose option', NULL, 100, 1)
INSERT [dbo].[Question] ([Qid], [QCid], [QuestionType], [Question], [ExhibitId], [points], [isactive]) VALUES (1005, 1, N'RADIO', N'Whats your name', NULL, 100, 0)
INSERT [dbo].[Question] ([Qid], [QCid], [QuestionType], [Question], [ExhibitId], [points], [isactive]) VALUES (1006, 1, N'RADIO', N'Whats your swer', NULL, 100, 0)
INSERT [dbo].[Question] ([Qid], [QCid], [QuestionType], [Question], [ExhibitId], [points], [isactive]) VALUES (1007, 1, N'RADIO', N'Whats your motherlang', NULL, 100, 0)
SET IDENTITY_INSERT [dbo].[Question] OFF
SET IDENTITY_INSERT [dbo].[QuestionCategory] ON 

INSERT [dbo].[QuestionCategory] ([Cid], [Category]) VALUES (1, N'Development Fundamentals')
INSERT [dbo].[QuestionCategory] ([Cid], [Category]) VALUES (2, N'Development Fundamentals')
INSERT [dbo].[QuestionCategory] ([Cid], [Category]) VALUES (3, N'RADIO')
INSERT [dbo].[QuestionCategory] ([Cid], [Category]) VALUES (4, N'Text')
INSERT [dbo].[QuestionCategory] ([Cid], [Category]) VALUES (5, N'Checkbox')
SET IDENTITY_INSERT [dbo].[QuestionCategory] OFF
SET IDENTITY_INSERT [dbo].[Registration] ON 

INSERT [dbo].[Registration] ([Rid], [Name], [Department], [EntryDate], [Email], [Phone], [Password], [Image], [Status], [Role]) VALUES (11, N'anju', N'EEE', CAST(0x0000AD2100EF41F5 AS DateTime), N'anjuvigil212@gmail.com', N'1234512345', N'anjus', N'pp3.jpg', N'A', N'Admin')
INSERT [dbo].[Registration] ([Rid], [Name], [Department], [EntryDate], [Email], [Phone], [Password], [Image], [Status], [Role]) VALUES (12, N'ivan', N'MECH', CAST(0x0000AD2100FC4B06 AS DateTime), N'ivan@gmail', N'123', N'ivan', N'pp3.jpg', N'A', N'notdefined')
INSERT [dbo].[Registration] ([Rid], [Name], [Department], [EntryDate], [Email], [Phone], [Password], [Image], [Status], [Role]) VALUES (13, N'swathy', N'EEE', CAST(0x0000AD2100FF739B AS DateTime), N'swathy@gm', N'12345', N'efrwd', N'pp2.jpg', N'A', N'notdefined')
INSERT [dbo].[Registration] ([Rid], [Name], [Department], [EntryDate], [Email], [Phone], [Password], [Image], [Status], [Role]) VALUES (14, N'meera', N'ECE', CAST(0x0000AD21011CAD67 AS DateTime), N'dsfv@g', N'123', N'ghjf', N'pp2.jpg', N'A', N'notdefined')
INSERT [dbo].[Registration] ([Rid], [Name], [Department], [EntryDate], [Email], [Phone], [Password], [Image], [Status], [Role]) VALUES (15, N'swathy', N'EEE', CAST(0x0000AD21011D0F89 AS DateTime), N'swathy', N'1234567890', N'xfcgh', N'pp2.jpg', N'R', N'notdefined')
INSERT [dbo].[Registration] ([Rid], [Name], [Department], [EntryDate], [Email], [Phone], [Password], [Image], [Status], [Role]) VALUES (16, N'meera', N'EEE', CAST(0x0000AD21011D76E0 AS DateTime), N'meera@gmail.com', N'1234567890', N'meera', N'pp3.jpg', N'A', N'notdefined')
INSERT [dbo].[Registration] ([Rid], [Name], [Department], [EntryDate], [Email], [Phone], [Password], [Image], [Status], [Role]) VALUES (17, N'yadhu', N'CIVIL', CAST(0x0000AD2101284C7E AS DateTime), N'yadhu@gmail.com', N'1234567890', N'yadhus', N'pp3.jpg', N'A', N'Eval')
INSERT [dbo].[Registration] ([Rid], [Name], [Department], [EntryDate], [Email], [Phone], [Password], [Image], [Status], [Role]) VALUES (18, N'ajin', N'CIVIL', NULL, N'ajin@gmail.com', N'1234567890', N'arya', NULL, N'R', NULL)
INSERT [dbo].[Registration] ([Rid], [Name], [Department], [EntryDate], [Email], [Phone], [Password], [Image], [Status], [Role]) VALUES (19, N'swathy', N'CIVIL', CAST(0x0000AD210146F200 AS DateTime), N'swadffthy@gmail.com', N'1234567890', N'fgfgf', N'pp1.jpg', N'R', N'notdefined')
INSERT [dbo].[Registration] ([Rid], [Name], [Department], [EntryDate], [Email], [Phone], [Password], [Image], [Status], [Role]) VALUES (20, N'adel', N'EEE', CAST(0x0000AD21014A23C2 AS DateTime), N'adel@gmail.com', N'123', N'adel', NULL, N'A', N'notdefined')
INSERT [dbo].[Registration] ([Rid], [Name], [Department], [EntryDate], [Email], [Phone], [Password], [Image], [Status], [Role]) VALUES (21, N'sruthy', N'CIVIL', CAST(0x0000AD2300BF3CB6 AS DateTime), N'sruthy@gmail.com', N'1234567890', N'sruthy', N'pp2.jpg', N'A', N'notdefined')
INSERT [dbo].[Registration] ([Rid], [Name], [Department], [EntryDate], [Email], [Phone], [Password], [Image], [Status], [Role]) VALUES (22, N'vigilwilson', N'MECH', CAST(0x0000AD2400DB8F40 AS DateTime), N'vigilwilson@gmail.com', N'1234567890', N'vigil', N'pp3.jpg', N'A', N'notdefined')
SET IDENTITY_INSERT [dbo].[Registration] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (1, N'meera', 100, CAST(0x0000AD2B00D76037 AS DateTime), N'meera@gmail.com', N'1234567890', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (2, N'veena', 100, CAST(0x0000AD2B00E3EE2C AS DateTime), N'veena@gmail.com', N'1234567890', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (3, N'Adel', 100, CAST(0x0000AD2B00FACCDF AS DateTime), N'adel@gmail.com', N'1234567890', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (4, N'sruthy', 100, CAST(0x0000AD2B00FD8384 AS DateTime), N'sruthy@gmail.com', N'1234512345', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (5, N'anju', 100, CAST(0x0000AD2B011E1FFC AS DateTime), N'anjuvigil212@gmail.com', N'1234567890', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (6, N'anjus', 100, CAST(0x0000AD2B011EFB9D AS DateTime), N'anjusvigil212@gmail.com', N'1234567890', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (7, N'sdd', 100, CAST(0x0000AD2C0052F9D6 AS DateTime), N'sdsd@gmail.com', N'1234512345', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (8, N'veenaas', 100, CAST(0x0000AD2C00569AE9 AS DateTime), N'veenasaa@gmail.com', N'1234567892', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (9, N'anjusssad', 100, CAST(0x0000AD2C0061449C AS DateTime), N'anjusas@gmail.com', N'1234512345', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (10, N'meeraaa', 100, CAST(0x0000AD2C00919D35 AS DateTime), N'meeraaa@gmail.com', N'1234512345', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (11, N'neenu', 100, CAST(0x0000AD2D006F85DB AS DateTime), N'neenu@gmail.com', N'1234567890', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (12, N'rithu', 100, CAST(0x0000AD2D0071E0A7 AS DateTime), N'rithu@gmail.com', N'1234567890', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (13, N'jubin', 100, CAST(0x0000AD2D0075DCDE AS DateTime), N'jubin@gmail.com', N'1234567890', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (14, N'suni', 100, CAST(0x0000AD2D007C75E0 AS DateTime), N'suni@gmail.com', N'1234512345', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (15, N'chinju', 100, CAST(0x0000AD2D00A439B6 AS DateTime), N'chinju@gmail.com', N'1234512345', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (16, N'druthi', 100, CAST(0x0000AD2D00DC7B14 AS DateTime), N'druthi@gmail.com', N'1234567890', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (17, N'veenas', 100, CAST(0x0000AD2D00EDFDA0 AS DateTime), N'veenasaea@gmail.com', N'1234567890', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (18, N'dudu', 100, CAST(0x0000AD2E00D96449 AS DateTime), N'dudu@gmail.com', N'1234567890', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (1011, N'vigilwilson', 100, CAST(0x0000AD2E0116BA98 AS DateTime), N'vigil@gmail.com', N'1234567890', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (1012, N'vigilwilsonbhh', 100, CAST(0x0000AD2E01172B75 AS DateTime), N'vigilxdgfg@gmail.com', N'1234567890', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (1013, N'adelsggr', 100, CAST(0x0000AD3200A5D120 AS DateTime), N'adelsrg@gmail.com', N'1232464', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (1014, N'sundar', 100, CAST(0x0000AD3200B213E1 AS DateTime), N'sundar@gmail.com', N'1232464', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (1015, N'sundardf', 100, CAST(0x0000AD3200BD1763 AS DateTime), N'sundardf@gmail.com', N'1232464', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (1016, N'meerasqwdw', 100, CAST(0x0000AD3200FBBF70 AS DateTime), N'meeraasweq@gmail.com', N'1234567890', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (1017, N'meerawer', 100, CAST(0x0000AD320113472B AS DateTime), N'meerawer@gmail.com', N'1234567890', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (1018, N'meeradgsfywt', 100, CAST(0x0000AD32011EBE09 AS DateTime), N'meerajhjqwg@gmail.com', N'1234567890', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (1019, N'meeraqwerere', 100, CAST(0x0000AD3300284C60 AS DateTime), N'meeraerqwree@gmail.com', N'1234567890', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (1020, N'meeradafdf', 100, CAST(0x0000AD33003FA29D AS DateTime), N'meeradafsfd@gmail.com', N'1234567890', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (1021, N'meerarggehh', 100, CAST(0x0000AD3300DE0DCB AS DateTime), N'meeraeghrtujr@gmail.com', N'1234567890', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (1022, N'meerafghjrhjtk', 100, CAST(0x0000AD3300E5C31D AS DateTime), N'meeramnhfjktku@gmail.com', N'1234567890', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (1023, N'meerafghjrhjtkiuyt', 100, CAST(0x0000AD3300EAC310 AS DateTime), N'meeramnhfjktkuoiuyu@gmail.com', N'1234567890', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (1024, N'sethu', 100, CAST(0x0000AD3500A78A3F AS DateTime), N'sethu@gmail.com', N'1234567890', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (1025, N'swethap', 100, CAST(0x0000AD3500ADD594 AS DateTime), N'swethap@gmail.com', N'1234567890', NULL)
INSERT [dbo].[Student] ([Id], [Name], [AccessLevel], [EntryDate], [Email], [Phone], [PassHash]) VALUES (1026, N'soniyadskf', 100, CAST(0x0000AD3500BA19A4 AS DateTime), N'soniyadasfd@gmail.com', N'1234567890', NULL)
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[Test] ON 

INSERT [dbo].[Test] ([Id], [Name], [Description], [isactive], [DurationInMinute]) VALUES (3, N'MVC Essentials', N'This test is for MVC Beginners Level', 1, 30)
INSERT [dbo].[Test] ([Id], [Name], [Description], [isactive], [DurationInMinute]) VALUES (4, N'MVC Essentials', N'This test is for MVC Beginners Level', 1, 30)
INSERT [dbo].[Test] ([Id], [Name], [Description], [isactive], [DurationInMinute]) VALUES (5, N'Java', N'This test for beginers', 1, 30)
SET IDENTITY_INSERT [dbo].[Test] OFF
SET IDENTITY_INSERT [dbo].[TestXPaper] ON 

INSERT [dbo].[TestXPaper] ([Id], [RegistrationId], [TestXQuestionId], [ChoiceId], [Answer], [MarkScored]) VALUES (7, 1, 11, 2, N'1', CAST(1.00 AS Decimal(13, 2)))
INSERT [dbo].[TestXPaper] ([Id], [RegistrationId], [TestXQuestionId], [ChoiceId], [Answer], [MarkScored]) VALUES (10, 1025, 11, 2, N'CHECKED', CAST(0.00 AS Decimal(13, 2)))
INSERT [dbo].[TestXPaper] ([Id], [RegistrationId], [TestXQuestionId], [ChoiceId], [Answer], [MarkScored]) VALUES (11, 1025, 13, 5, N'CHECKED', CAST(0.00 AS Decimal(13, 2)))
INSERT [dbo].[TestXPaper] ([Id], [RegistrationId], [TestXQuestionId], [ChoiceId], [Answer], [MarkScored]) VALUES (12, 1025, 14, 8, N'jhdsnm', CAST(1.00 AS Decimal(13, 2)))
INSERT [dbo].[TestXPaper] ([Id], [RegistrationId], [TestXQuestionId], [ChoiceId], [Answer], [MarkScored]) VALUES (13, 1025, 15, 5, N'CHECKED', CAST(0.00 AS Decimal(13, 2)))
INSERT [dbo].[TestXPaper] ([Id], [RegistrationId], [TestXQuestionId], [ChoiceId], [Answer], [MarkScored]) VALUES (14, 1025, 11, 2, N'CHECKED', CAST(0.00 AS Decimal(13, 2)))
INSERT [dbo].[TestXPaper] ([Id], [RegistrationId], [TestXQuestionId], [ChoiceId], [Answer], [MarkScored]) VALUES (15, 1026, 11, 2, N'CHECKED', CAST(0.00 AS Decimal(13, 2)))
INSERT [dbo].[TestXPaper] ([Id], [RegistrationId], [TestXQuestionId], [ChoiceId], [Answer], [MarkScored]) VALUES (16, 1026, 13, 5, N'CHECKED', CAST(0.00 AS Decimal(13, 2)))
INSERT [dbo].[TestXPaper] ([Id], [RegistrationId], [TestXQuestionId], [ChoiceId], [Answer], [MarkScored]) VALUES (17, 1026, 14, 8, N'hai', CAST(1.00 AS Decimal(13, 2)))
INSERT [dbo].[TestXPaper] ([Id], [RegistrationId], [TestXQuestionId], [ChoiceId], [Answer], [MarkScored]) VALUES (18, 1026, 14, 8, N'hai', CAST(1.00 AS Decimal(13, 2)))
INSERT [dbo].[TestXPaper] ([Id], [RegistrationId], [TestXQuestionId], [ChoiceId], [Answer], [MarkScored]) VALUES (19, 1026, 15, 6, N'CHECKED', CAST(0.00 AS Decimal(13, 2)))
INSERT [dbo].[TestXPaper] ([Id], [RegistrationId], [TestXQuestionId], [ChoiceId], [Answer], [MarkScored]) VALUES (20, 1026, 11, 2, N'CHECKED', CAST(0.00 AS Decimal(13, 2)))
SET IDENTITY_INSERT [dbo].[TestXPaper] OFF
SET IDENTITY_INSERT [dbo].[TestXQuestion] ON 

INSERT [dbo].[TestXQuestion] ([Id], [TestId], [QuestionId], [QuestionNumber], [isactive]) VALUES (11, 3, 1, 1, 1)
INSERT [dbo].[TestXQuestion] ([Id], [TestId], [QuestionId], [QuestionNumber], [isactive]) VALUES (12, 4, 1, 1, 1)
INSERT [dbo].[TestXQuestion] ([Id], [TestId], [QuestionId], [QuestionNumber], [isactive]) VALUES (13, 3, 2, 2, 1)
INSERT [dbo].[TestXQuestion] ([Id], [TestId], [QuestionId], [QuestionNumber], [isactive]) VALUES (14, 3, 3, 3, 1)
INSERT [dbo].[TestXQuestion] ([Id], [TestId], [QuestionId], [QuestionNumber], [isactive]) VALUES (15, 3, 2, 4, 1)
SET IDENTITY_INSERT [dbo].[TestXQuestion] OFF
ALTER TABLE [dbo].[Choice] ADD  CONSTRAINT [DF_Choice_points]  DEFAULT ((0.0)) FOR [points]
GO
ALTER TABLE [dbo].[Choice] ADD  CONSTRAINT [DF_Choice_isactive]  DEFAULT ((1)) FOR [isactive]
GO
ALTER TABLE [dbo].[ExamRegistration] ADD  CONSTRAINT [DF_ExamRegistration_RegistrationDate]  DEFAULT (getutcdate()) FOR [RegistrationDate]
GO
ALTER TABLE [dbo].[ExamRegistration] ADD  CONSTRAINT [DF_ExamRegistration_Token]  DEFAULT (newid()) FOR [Token]
GO
ALTER TABLE [dbo].[ExamRegistration] ADD  CONSTRAINT [DF_ExamRegistration_TokenExpireTime]  DEFAULT (dateadd(minute,(60),getutcdate())) FOR [TokenExpireTime]
GO
ALTER TABLE [dbo].[Question] ADD  CONSTRAINT [DF_Question_isactive]  DEFAULT ((1)) FOR [isactive]
GO
ALTER TABLE [dbo].[Student] ADD  DEFAULT ((100)) FOR [AccessLevel]
GO
ALTER TABLE [dbo].[Student] ADD  DEFAULT (getutcdate()) FOR [EntryDate]
GO
ALTER TABLE [dbo].[Test] ADD  CONSTRAINT [DF_Test_isactive]  DEFAULT ((1)) FOR [isactive]
GO
ALTER TABLE [dbo].[Test] ADD  CONSTRAINT [DF_Test_DurationInMinute]  DEFAULT ((60)) FOR [DurationInMinute]
GO
ALTER TABLE [dbo].[TestXQuestion] ADD  CONSTRAINT [DF_TestXQuestion_QuestionNumber]  DEFAULT ((1)) FOR [QuestionNumber]
GO
ALTER TABLE [dbo].[TestXQuestion] ADD  CONSTRAINT [DF_TestXQuestion_isactive]  DEFAULT ((1)) FOR [isactive]
GO
ALTER TABLE [dbo].[Choice]  WITH CHECK ADD  CONSTRAINT [FK_Choice_Choice] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([Qid])
GO
ALTER TABLE [dbo].[Choice] CHECK CONSTRAINT [FK_Choice_Choice]
GO
ALTER TABLE [dbo].[ExamRegistration]  WITH CHECK ADD  CONSTRAINT [FK_ExamRegistration_Registration] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[ExamRegistration] CHECK CONSTRAINT [FK_ExamRegistration_Registration]
GO
ALTER TABLE [dbo].[ExamRegistration]  WITH CHECK ADD  CONSTRAINT [FK_ExamRegistration_Test] FOREIGN KEY([TestId])
REFERENCES [dbo].[Test] ([Id])
GO
ALTER TABLE [dbo].[ExamRegistration] CHECK CONSTRAINT [FK_ExamRegistration_Test]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Exhibit] FOREIGN KEY([ExhibitId])
REFERENCES [dbo].[Exhibit] ([Eid])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Exhibit]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_QuestionCategory] FOREIGN KEY([QCid])
REFERENCES [dbo].[QuestionCategory] ([Cid])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_QuestionCategory]
GO
ALTER TABLE [dbo].[QuestionXDuration]  WITH CHECK ADD  CONSTRAINT [FK_QuestionXDuration_ExamRegistration] FOREIGN KEY([RegistrationId])
REFERENCES [dbo].[ExamRegistration] ([ExamId])
GO
ALTER TABLE [dbo].[QuestionXDuration] CHECK CONSTRAINT [FK_QuestionXDuration_ExamRegistration]
GO
ALTER TABLE [dbo].[QuestionXDuration]  WITH CHECK ADD  CONSTRAINT [FK_QuestionXDuration_TestXQuestion] FOREIGN KEY([TestXQuestionId])
REFERENCES [dbo].[TestXQuestion] ([Id])
GO
ALTER TABLE [dbo].[QuestionXDuration] CHECK CONSTRAINT [FK_QuestionXDuration_TestXQuestion]
GO
ALTER TABLE [dbo].[TestXPaper]  WITH CHECK ADD  CONSTRAINT [FK_TestXPaper_Choice] FOREIGN KEY([ChoiceId])
REFERENCES [dbo].[Choice] ([ChoiceId])
GO
ALTER TABLE [dbo].[TestXPaper] CHECK CONSTRAINT [FK_TestXPaper_Choice]
GO
ALTER TABLE [dbo].[TestXPaper]  WITH CHECK ADD  CONSTRAINT [FK_TestXPaper_TestXQuestion] FOREIGN KEY([TestXQuestionId])
REFERENCES [dbo].[TestXQuestion] ([Id])
GO
ALTER TABLE [dbo].[TestXPaper] CHECK CONSTRAINT [FK_TestXPaper_TestXQuestion]
GO
ALTER TABLE [dbo].[TestXQuestion]  WITH CHECK ADD  CONSTRAINT [FK_TestXQuestion_Question] FOREIGN KEY([TestId])
REFERENCES [dbo].[Test] ([Id])
GO
ALTER TABLE [dbo].[TestXQuestion] CHECK CONSTRAINT [FK_TestXQuestion_Question]
GO
ALTER TABLE [dbo].[TestXQuestion]  WITH CHECK ADD  CONSTRAINT [FK_TestXQuestion_Question2] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([Qid])
GO
ALTER TABLE [dbo].[TestXQuestion] CHECK CONSTRAINT [FK_TestXQuestion_Question2]
GO
