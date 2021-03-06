USE [Test]
GO
/****** Object:  Table [dbo].[InvoiceDetail]    Script Date: 2/18/2021 7:27:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetail](
	[RequestNumber] [varchar](50) NOT NULL,
	[DetailName] [varchar](500) NOT NULL,
	[Qty] [decimal](18, 2) NULL,
	[UoMID] [int] NULL,
	[Rate] [decimal](18, 2) NULL,
 CONSTRAINT [PK_InvoiceDetail] PRIMARY KEY CLUSTERED 
(
	[RequestNumber] ASC,
	[DetailName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceHeader]    Script Date: 2/18/2021 7:27:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceHeader](
	[RequestNumber] [varchar](50) NOT NULL,
	[LanguageID] [int] NULL,
	[CurrencyID] [int] NULL,
	[InvoiceFrom] [varchar](500) NULL,
	[VendorID] [int] NULL,
	[InvoiceDate] [datetime] NULL,
	[Status] [varchar](50) NULL,
	[PoNumber] [varchar](10) NULL,
	[Discount] [decimal](18, 2) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](100) NULL,
 CONSTRAINT [PK_InvoiceHeader] PRIMARY KEY CLUSTERED 
(
	[RequestNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterCurrency]    Script Date: 2/18/2021 7:27:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterCurrency](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Code] [varchar](5) NULL,
 CONSTRAINT [PK_MasterCurrency] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterLanguage]    Script Date: 2/18/2021 7:27:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterLanguage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
 CONSTRAINT [PK_MasterLanguage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterUoM]    Script Date: 2/18/2021 7:27:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterUoM](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Code] [varchar](50) NULL,
 CONSTRAINT [PK_MasterUoM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterVendor]    Script Date: 2/18/2021 7:27:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterVendor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[ContactName] [varchar](100) NULL,
	[Address] [varchar](500) NULL,
 CONSTRAINT [PK_MasterVendor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseOrder]    Script Date: 2/18/2021 7:27:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrder](
	[PONumber] [varchar](10) NOT NULL,
	[Name] [varchar](100) NULL,
 CONSTRAINT [PK_PurchaseOrder] PRIMARY KEY CLUSTERED 
(
	[PONumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[InvoiceDetail] ([RequestNumber], [DetailName], [Qty], [UoMID], [Rate]) VALUES (N'INV-00001', N'ABC', CAST(1.00 AS Decimal(18, 2)), 1, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceDetail] ([RequestNumber], [DetailName], [Qty], [UoMID], [Rate]) VALUES (N'INV-00001', N'ABCD', CAST(1.00 AS Decimal(18, 2)), 1, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceDetail] ([RequestNumber], [DetailName], [Qty], [UoMID], [Rate]) VALUES (N'INV-0001', N'ABC', CAST(1.00 AS Decimal(18, 2)), 1, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceDetail] ([RequestNumber], [DetailName], [Qty], [UoMID], [Rate]) VALUES (N'INV-0001', N'ABCD', CAST(1.00 AS Decimal(18, 2)), 1, CAST(1.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[InvoiceHeader] ([RequestNumber], [LanguageID], [CurrencyID], [InvoiceFrom], [VendorID], [InvoiceDate], [Status], [PoNumber], [Discount], [CreatedDate], [CreatedBy]) VALUES (N'INV-00001', 1, 1, N'Test', 1, CAST(N'2021-02-18T14:50:54.767' AS DateTime), N'PAID', N'PO-100001', CAST(10.00 AS Decimal(18, 2)), CAST(N'2021-02-18T14:50:54.767' AS DateTime), N'User')
INSERT [dbo].[InvoiceHeader] ([RequestNumber], [LanguageID], [CurrencyID], [InvoiceFrom], [VendorID], [InvoiceDate], [Status], [PoNumber], [Discount], [CreatedDate], [CreatedBy]) VALUES (N'INV-0001', 1, 1, N'Test', 1, CAST(N'2021-02-18T14:50:54.767' AS DateTime), N'PAID', N'PO-100001', CAST(10.00 AS Decimal(18, 2)), CAST(N'2021-02-18T14:50:54.767' AS DateTime), N'User')
GO
SET IDENTITY_INSERT [dbo].[MasterCurrency] ON 

INSERT [dbo].[MasterCurrency] ([ID], [Name], [Code]) VALUES (1, N'Indonesia Rupiah', N'IDR')
INSERT [dbo].[MasterCurrency] ([ID], [Name], [Code]) VALUES (2, N'Unites States Dollar', N'USD')
SET IDENTITY_INSERT [dbo].[MasterCurrency] OFF
GO
SET IDENTITY_INSERT [dbo].[MasterLanguage] ON 

INSERT [dbo].[MasterLanguage] ([ID], [Name]) VALUES (1, N'INDONESIA')
SET IDENTITY_INSERT [dbo].[MasterLanguage] OFF
GO
SET IDENTITY_INSERT [dbo].[MasterUoM] ON 

INSERT [dbo].[MasterUoM] ([ID], [Name], [Code]) VALUES (1, N'Hour', N'hr')
INSERT [dbo].[MasterUoM] ([ID], [Name], [Code]) VALUES (2, N'Monthly', N'Monthly')
SET IDENTITY_INSERT [dbo].[MasterUoM] OFF
GO
SET IDENTITY_INSERT [dbo].[MasterVendor] ON 

INSERT [dbo].[MasterVendor] ([ID], [Name], [ContactName], [Address]) VALUES (1, N'PT ABC', N'ABC Name', N'Jl Tanah Kusir 2 , Jakarta Selatan, DKI Jakarta, Indonesia')
INSERT [dbo].[MasterVendor] ([ID], [Name], [ContactName], [Address]) VALUES (2, N'PT Test', N'Test Name', N'Jepara Bangsri No 182  , Jepara, Central Java, Indonesia')
SET IDENTITY_INSERT [dbo].[MasterVendor] OFF
GO
INSERT [dbo].[PurchaseOrder] ([PONumber], [Name]) VALUES (N'PO-100001', N'PO Test')
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_InvoiceHeader] FOREIGN KEY([RequestNumber])
REFERENCES [dbo].[InvoiceHeader] ([RequestNumber])
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_InvoiceHeader]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_MasterUoM] FOREIGN KEY([UoMID])
REFERENCES [dbo].[MasterUoM] ([ID])
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_MasterUoM]
GO
ALTER TABLE [dbo].[InvoiceHeader]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceHeader_InvoiceHeader] FOREIGN KEY([RequestNumber])
REFERENCES [dbo].[InvoiceHeader] ([RequestNumber])
GO
ALTER TABLE [dbo].[InvoiceHeader] CHECK CONSTRAINT [FK_InvoiceHeader_InvoiceHeader]
GO
ALTER TABLE [dbo].[InvoiceHeader]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceHeader_MasterCurrency] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[MasterCurrency] ([ID])
GO
ALTER TABLE [dbo].[InvoiceHeader] CHECK CONSTRAINT [FK_InvoiceHeader_MasterCurrency]
GO
ALTER TABLE [dbo].[InvoiceHeader]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceHeader_MasterLanguage] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[MasterLanguage] ([ID])
GO
ALTER TABLE [dbo].[InvoiceHeader] CHECK CONSTRAINT [FK_InvoiceHeader_MasterLanguage]
GO
ALTER TABLE [dbo].[InvoiceHeader]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceHeader_MasterVendor] FOREIGN KEY([VendorID])
REFERENCES [dbo].[MasterVendor] ([ID])
GO
ALTER TABLE [dbo].[InvoiceHeader] CHECK CONSTRAINT [FK_InvoiceHeader_MasterVendor]
GO
