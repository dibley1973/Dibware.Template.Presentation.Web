
-- =============================================
-- Author:		Duane Wingett
-- Create date: 2014-05-30
-- Description:	Gets notifications for the user specified
--              buy USername
-- =============================================
CREATE PROCEDURE [application].[Notifications_GetForUser] 
(
    @Username varchar(MAX)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Get all of the notifications...
	SELECT  [n].[NotificationId]
    ,       [n].[EffectiveFrom]
    ,       [n].[EffectiveTo]
    ,       [n].[Description]
    FROM    [application].[Notification]        [n]

    -- ...which exists for the user...
    JOIN    [application].[UserNotifications]   [un]
            ON [un].[NotificationId]        =   [n].[NotificationId]
    JOIN    [security].[Membership]             [m]
            ON [m].[UserGuid]               =   [un].[UserGuid]
    
    -- ...for the user specifed by username...
    WHERE   [m].[Username]                  =   @Username

    -- ...and the current date is between the effective dates
    AND     GETDATE() BETWEEN [n].[EffectiveFrom] AND [n].[EffectiveTo];
END
GO
GRANT EXECUTE
    ON OBJECT::[application].[Notifications_GetForUser] TO [MainRole]
    AS [dbo];

