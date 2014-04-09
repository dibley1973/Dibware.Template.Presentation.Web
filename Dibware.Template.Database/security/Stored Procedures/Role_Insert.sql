CREATE PROCEDURE [security].[Role_Insert]
    @RoleKey [nvarchar](25),
    @Name [nvarchar](256)
AS
BEGIN
    INSERT [security].[Role]([RoleKey], [Name])
    VALUES (@RoleKey, @Name)
END