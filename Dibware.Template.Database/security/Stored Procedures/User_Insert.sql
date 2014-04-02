CREATE PROCEDURE [security].[User_Insert]
    @UserGuid [uniqueidentifier],
    @Password [nvarchar](50),
    @UserName [nvarchar](max),
    @Name [nvarchar](50)
AS
BEGIN
    INSERT [security].[User]([UserGuid], [Password], [UserName], [Name])
    VALUES (@UserGuid, @Password, @UserName, @Name)
END