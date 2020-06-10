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

CREATE TABLE Account(
	ID INT IDENTITY PRIMARY KEY,
	Username CHAR(100),
	DisplayName NCHAR(200),
	Password NVARCHAR(200)
)
GO

CREATE TABLE UserAcc(
	ID INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(200),
	Age INT,
	PhoneNumber NCHAR(20),
	Address NVARCHAR(200)
)
GO

CREATE PROC USP_Login
@username CHAR(100), @password NVARCHAR(200)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE Username = @username AND Password = @password
END
GO

CREATE FUNCTION [dbo].[GetUnsignString](@strInput NVARCHAR(4000)) 
RETURNS NVARCHAR(4000)
AS
BEGIN     
    IF @strInput IS NULL RETURN @strInput
    IF @strInput = '' RETURN @strInput
    DECLARE @RT NVARCHAR(4000)
    DECLARE @SIGN_CHARS NCHAR(136)
    DECLARE @UNSIGN_CHARS NCHAR (136)

    SET @SIGN_CHARS       = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệếìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵýĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ'+NCHAR(272)+ NCHAR(208)
    SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeeeiiiiiooooooooooooooouuuuuuuuuuyyyyyAADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD'

    DECLARE @COUNTER int
    DECLARE @COUNTER1 int
    SET @COUNTER = 1
 
    WHILE (@COUNTER <=LEN(@strInput))
    BEGIN   
      SET @COUNTER1 = 1
      --Tim trong chuoi mau
       WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1)
       BEGIN
     IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) )
     BEGIN           
          IF @COUNTER=1
              SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1)                   
          ELSE
              SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER)    
              BREAK         
               END
             SET @COUNTER1 = @COUNTER1 +1
       END
      --Tim tiep
       SET @COUNTER = @COUNTER +1
    END
    RETURN @strInput
END
GO

CREATE PROC USP_AddBook
@title NVARCHAR(200), @author NVARCHAR(100), @category NVARCHAR(100), @releaseDate DATE, @pubilsher NVARCHAR(200)
AS
BEGIN
	INSERT dbo.Book
	(
	    Title,
	    Author,
	    Category,
	    ReleaseDate,
	    Publisher
	)
	VALUES
	(   @title,       -- Title - nvarchar(200)
	    @author,       -- Author - nvarchar(100)
	    @category,       -- Category - nvarchar(100)
	    @releaseDate, -- ReleaseDate - date
	    @pubilsher        -- Publisher - nvarchar(200)
	    )
END
GO

ALTER PROC USP_SearchBook
@title NVARCHAR(200)
AS
BEGIN
	SELECT Title, Author, Category, ReleaseDate AS [Release Date], Publisher FROM dbo.Book WHERE dbo.GetUnsignString(Title) LIKE N'%' + dbo.GetUnsignString(@title) + N'%'
END
GO

CREATE PROC USP_GetIDBook
@title NVARCHAR(200), @author NVARCHAR(100), @releaseDate DATE, @pubilsher NVARCHAR(200)
AS
BEGIN
	SELECT ID FROM dbo.Book WHERE Title = @title AND Author = @author AND Publisher = @pubilsher AND ReleaseDate = @releaseDate
END
GO

CREATE PROC USP_EditBook
@title NVARCHAR(200), @author NVARCHAR(100), @category NVARCHAR(100), @releaseDate DATE, @pubilsher NVARCHAR(200), @id INT
AS
BEGIN
	UPDATE dbo.Book SET Title = @title, Author = @author, Category = @category, ReleaseDate = @releaseDate, Publisher = @pubilsher WHERE id = @id
END
GO

INSERT dbo.UserAcc
(
    Name,
    Age,
    PhoneNumber,
    Address
)
VALUES
(   N'Nguyễn Hữu Lâm', -- Name - nvarchar(200)
    17,   -- Age - int
    N'11111', -- PhoneNumber - nchar(20)
    N'VP'  -- Address - nvarchar(200)
    )
GO 

ALTER PROC USP_SearchUser
@name NVARCHAR(200)
AS
BEGIN
	SELECT Name AS [Name], Age AS [Age], PhoneNumber AS [Phone number], Address AS [Address] FROM dbo.UserAcc WHERE dbo.GetUnsignString(Name) LIKE N'%' + dbo.GetUnsignString(@name) + N'%'
END
GO	

CREATE PROC USP_AddUser
@name NVARCHAR(200), @age INT, @phoneNumber NCHAR(20), @address NVARCHAR(200)
AS
BEGIN
	INSERT dbo.UserAcc
	(
	    Name,
	    Age,
	    PhoneNumber,
	    Address
	)
	VALUES
	(   @name, -- Name - nvarchar(200)
	    @age,   -- Age - int
	    @phoneNumber, -- PhoneNumber - nchar(20)
	    @address  -- Address - nvarchar(200)
	    )
END
GO


