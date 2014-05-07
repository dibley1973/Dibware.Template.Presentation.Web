CREATE PROCEDURE [security].[User_Insert]
    @UserGuid [uniqueidentifier],
    @Username [nvarchar](max),
    @Name [nvarchar](max)
AS
BEGIN
    INSERT [security].[User]([UserGuid], [Username], [Name])
    VALUES (@UserGuid, @Username, @Name)
END