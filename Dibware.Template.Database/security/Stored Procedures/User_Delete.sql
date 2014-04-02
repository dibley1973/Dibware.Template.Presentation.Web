CREATE PROCEDURE [security].[User_Delete]
    @Guid [uniqueidentifier]
AS
BEGIN
    DELETE [security].[User]
    WHERE ([UserGuid] = @Guid)
END