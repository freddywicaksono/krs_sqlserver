USE [coba]
GO

/****** Object:  Table [dbo].[prodi]    Script Date: 06/01/2021 09:47:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[prodi](
	[idprodi] [float] NULL,
	[kode_prodi] [nvarchar](255) NULL,
	[nama_prodi] [nvarchar](255) NULL,
	[kode_fakultas] [nvarchar](255) NULL
) ON [PRIMARY]
GO

