USE [coba]
GO

/****** Object:  Table [dbo].[dosen]    Script Date: 06/01/2021 09:37:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[dosen](
	[iddsn] [float] NULL,
	[nidn] [float] NULL,
	[nama_lengkap] [nvarchar](255) NULL,
	[jk] [nvarchar](255) NULL,
	[email] [nvarchar](255) NULL,
	[telpon] [float] NULL,
	[kode_fakultas] [nvarchar](255) NULL,
	[kode_prodi] [nvarchar](255) NULL,
	[passwd] [nvarchar](255) NULL
) ON [PRIMARY]
GO

