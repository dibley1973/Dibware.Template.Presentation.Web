
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

    -- Insert the user and role relationship
	SELECT  [r].[Name]
    FROM    [security].[Role]           [r]

    JOIN    [security].[UsersInRoles]   [uir]
            ON [uir].[RoleKey]          = [r].[RoleKey]

    JOIN    [security].[Membership]     [m]
            ON [m].[UserGuid]           = [uir].[UserGuid]

    WHERE   [m].[Username]              = @Username;
END