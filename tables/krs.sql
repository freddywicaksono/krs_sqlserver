USE [coba]
GO

/****** Object:  Table [dbo].[krs]    Script Date: 06/01/2021 09:47:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[krs](
	[idkrs] [nvarchar](255) NULL,
	[nomor_bukti] [nvarchar](255) NULL,
	[tanggal] [nvarchar](255) NULL,
	[nim] [nvarchar](255) NULL,
	[jenis_semester] [nvarchar](255) NULL,
	[tahun_akademik] [nvarchar](255) NULL,
	[semester] [nvarchar](255) NULL,
	[nidn] [nvarchar](255) NULL,
	[indeks_prestasi] [nvarchar](255) NULL,
	[catatan] [nvarchar](255) NULL
) ON [PRIMARY]
GO

