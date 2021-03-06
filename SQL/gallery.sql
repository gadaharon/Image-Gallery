
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageId] [varchar](100) NOT NULL,
	[Uri] [varchar](150) NOT NULL,
	[Height] [int] NULL,
	[Width] [int] NULL,
	[Format] [varchar](50) NULL,
	[CreatedAt] [varchar](150) NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[CreateImage]    Script Date: 9/11/2019 12:03:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateImage]
	@ImageId varchar(100),
	@Uri varchar(150),
	@Height int,
	@Width int,
	@Format varchar(50),
	@CreatedAt varchar(150)
AS
	INSERT INTO Images(ImageId, Uri, Height, Width, [Format], CreatedAt ) VALUES(@ImageId, @Uri, @Height, @Width, @Format, @CreatedAt)
	SELECT * FROM Images WHERE Id = SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[GetImages]    Script Date: 9/11/2019 12:03:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetImages]
AS
	SELECT * FROM Images;
GO
