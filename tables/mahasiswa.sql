USE [coba]
GO

/****** Object:  Table [dbo].[mahasiswa]    Script Date: 06/01/2021 09:47:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[mahasiswa](
	[idmhs] [float] NULL,
	[nim] [float] NULL,
	[nama_lengkap] [nvarchar](255) NULL,
	[jk] [nvarchar](255) NULL,
	[tanggal_lahir] [datetime] NULL,
	[kode_fakultas] [nvarchar](255) NULL,
	[kode_prodi] [nvarchar](255) NULL,
	[nidn_dosenwali] [float] NULL,
	[passwd] [nvarchar](255) NULL
) ON [PRIMARY]
GO

