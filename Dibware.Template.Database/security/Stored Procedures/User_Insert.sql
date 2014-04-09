CREATE PROCEDURE [security].[User_Insert]
    @UserGuid [uniqueidentifier],
    @UserName [nvarchar](max),
    @Name [nvarchar](max)
AS
BEGIN
    INSERT [security].[User]([UserGuid], [UserName], [Name])
    VALUES (@UserGuid, @UserName, @Name)
END