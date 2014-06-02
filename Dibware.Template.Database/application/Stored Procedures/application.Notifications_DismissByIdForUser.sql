
-- =============================================
-- Author:		Duane Wingett
-- Create date: 2014-05-30
-- Description:	Deletes notifications by ID for 
--              the user specified by Username
-- =============================================
CREATE PROCEDURE [application].[Notifications_DismissByIdForUser] 
(
    @NotificationId int
,   @Username varchar(MAX)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- DELETE the member-notification relationship...
	DELETE  [un]
    FROM    [application].[UserNotifications]   [un]
    
    -- ...which exists for the user...
    JOIN    [security].[Membership]             [m]
    ON      [m].[UserGuid]               =   [un].[UserGuid]
    
    -- ...for the user specifed by username...
    WHERE   [m].[Username]                  =   @Username
    
    -- ... and the notification ID matches the parameter
    AND     [un].[NotificationId]   = @NotificationId;

    -- Select / Return a value indicating success
    SELECT 1;
    RETURN 1;
END
GO
GRANT EXECUTE
    ON OBJECT::[application].[Notifications_DismissByIdForUser] TO [MainRole]
    AS [dbo];

