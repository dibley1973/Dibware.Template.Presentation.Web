CREATE PROCEDURE [security].[User_Update]
    @Guid [uniqueidentifier],
    @Password [nvarchar](50),
    @UserName [nvarchar](max),
    @Name [nvarchar](50)
AS
BEGIN
    UPDATE [security].[User]
    SET [Password] = @Password, [UserName] = @UserName, [Name] = @Name
    WHERE ([UserGuid] = @Guid)
END