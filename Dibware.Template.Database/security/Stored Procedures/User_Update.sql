CREATE PROCEDURE [security].[User_Update]
    @Guid [uniqueidentifier],
    @Username [nvarchar](max),
    @Name [nvarchar](max)
AS
BEGIN
    UPDATE [security].[User]
    SET [Username] = @Username, [Name] = @Name
    WHERE ([UserGuid] = @Guid)
END