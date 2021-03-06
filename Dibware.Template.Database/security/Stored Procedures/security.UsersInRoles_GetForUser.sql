﻿
-- =============================================
-- Author:		Duane Wingett
-- Create date: 2014-05-10
-- Description:	Gets roles for the user specified
--              buy GUID
-- =============================================
CREATE PROCEDURE [security].[UsersInRoles_GetForUser] 
(
    @Username varchar(MAX)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- get the roles for the user
	SELECT  [r].[Name]
    FROM    [security].[Role]           [r]

    JOIN    [security].[UsersInRoles]   [uir]
            ON [uir].[RoleKey]          = [r].[RoleKey]

    JOIN    [security].[Membership]     [m]
            ON [m].[UserGuid]           = [uir].[UserGuid]

    WHERE   [m].[Username]              = @Username;
END
GO
GRANT EXECUTE
    ON OBJECT::[security].[UsersInRoles_GetForUser] TO [MainRole]
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[security].[UsersInRoles_GetForUser] TO [UnauthorisedRole]
    AS [dbo];

