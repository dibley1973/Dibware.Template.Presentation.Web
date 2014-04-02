CREATE PROCEDURE [security].[Role_Delete]
    @RoleKey [nvarchar](25)
AS
BEGIN
    DELETE [security].[Role]
    WHERE ([RoleKey] = @RoleKey)
END