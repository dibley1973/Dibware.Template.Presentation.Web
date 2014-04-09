CREATE PROCEDURE [security].[User_Update]
    @Guid [uniqueidentifier],
    @UserName [nvarchar](max),
    @Name [nvarchar](max)
AS
BEGIN
    UPDATE [security].[User]
    SET [UserName] = @UserName, [Name] = @Name
    WHERE ([UserGuid] = @Guid)
END