CREATE PROCEDURE [security].[Role_Update]
    @RoleKey [nvarchar](25),
    @Name [nvarchar](25)
AS
BEGIN
    UPDATE [security].[Role]
    SET [Name] = @Name
    WHERE ([RoleKey] = @RoleKey)
END