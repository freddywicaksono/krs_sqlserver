USE [coba]
GO

/****** Object:  Table [dbo].[krsdetail]    Script Date: 06/01/2021 09:47:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[krsdetail](
	[iddetail] [nvarchar](255) NULL,
	[nomor_bukti] [nvarchar](255) NULL,
	[kodemk] [nvarchar](255) NULL,
	[sks] [nvarchar](255) NULL,
	[keterangan] [nvarchar](255) NULL,
	[nilai_khd] [nvarchar](255) NULL,
	[nilai_tgs] [nvarchar](255) NULL,
	[nilai_uts] [nvarchar](255) NULL,
	[nilai_uas] [nvarchar](255) NULL,
	[nilai_akhir] [nvarchar](255) NULL,
	[nilai_mutu] [nvarchar](255) NULL
) ON [PRIMARY]
GO

