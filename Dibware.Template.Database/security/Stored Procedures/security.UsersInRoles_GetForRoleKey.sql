
-- =============================================
-- Author:		Duane Wingett
-- Create date: 2014-05-08
-- Description:	Gets users in a specified role
-- =============================================
CREATE PROCEDURE [security].[UsersInRoles_GetForRoleKey] 
(
    @RoleKey nvarchar(25)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert the user and role relationship
	SELECT  [UserGuid]
    ,       [RoleKey]
    FROM    [security].[UsersInRoles]
    WHERE   [RoleKey] = @RoleKey;
END