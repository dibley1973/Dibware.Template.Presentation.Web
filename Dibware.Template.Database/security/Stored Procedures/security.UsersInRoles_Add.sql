
-- =============================================
-- Author:		Duane Wingett
-- Create date: 2014-05-08
-- Description:	Adds a user to a role
-- =============================================
CREATE PROCEDURE [security].[UsersInRoles_Add] 
(
    @UserGuid       uniqueidentifier
,   @DefaultRoleKey nvarchar(25)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert the user and role relationship
	INSERT INTO [security].[UsersInRoles]
    (
        [UserGuid]
    ,   [RoleKey]
    )
    VALUES
    (
        @UserGuid
    ,   @DefaultRoleKey
    );
END