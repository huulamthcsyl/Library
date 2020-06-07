CREATE DATABASE Library
GO

USE Library
GO

CREATE TABLE Book(
	ID INT IDENTITY PRIMARY KEY,
	Title NVARCHAR(200) NOT NULL,
	Author NVARCHAR(100),
	Category NVARCHAR(100),
	ReleaseDate DATE,
	Publisher NVARCHAR(200),
)
GO

DROP TABLE dbo.Book
GO

INSERT dbo.Book
(
    Title,
    Author,
    Category,
    ReleaseDate,
    Publisher
)
VALUES
(   N'Ngữ Văn',       -- Name - nvarchar(200)
    N'ABC',       -- Author - nvarchar(100)
    N'SGK',       -- Category - nvarchar(100)
    GETDATE(), -- ReleaseDate - datetime
    N'BGD'        -- Publisher - nvarchar(200)
    )

INSERT dbo.Book
(
    Title,
    Author,
    Category,
    ReleaseDate,
    Publisher
)
VALUES
(   N'Toán',       -- Name - nvarchar(200)
    N'ABC',       -- Author - nvarchar(100)
    N'SGK',       -- Category - nvarchar(100)
    GETDATE(), -- ReleaseDate - datetime
    N'BGD'        -- Publisher - nvarchar(200)
    )

INSERT dbo.Book
(
    Title,
    Author,
    Category,
    ReleaseDate,
    Publisher
)
VALUES
(   N'Mắt biếc',       -- Name - nvarchar(200)
    N'Nguyễn Nhật Ánh',       -- Author - nvarchar(100)
    N'Truyện ngắn',       -- Category - nvarchar(100)
    GETDATE(), -- ReleaseDate - datetime
    N'BCD'        -- Publisher - nvarchar(200)
    )

SELECT  FROM dbo.Book
