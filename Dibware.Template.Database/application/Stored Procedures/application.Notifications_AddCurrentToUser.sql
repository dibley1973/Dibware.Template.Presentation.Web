
-- =============================================
-- Author:		Duane Wingett
-- Create date: 2014-05-30
-- Description:	Add all notifications that have not 
--              expired for the specifed user. This
--              is normally used for NEW users
-- =============================================
CREATE PROCEDURE [application].[Notifications_AddCurrentToUser] 
(
    @Username varchar(MAX)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- First get the user's GUID
    DECLARE	@UserGuid UNIQUEIDENTIFIER;
    SELECT  @UserGuid =
    (
        SELECT  [UserGuid]
        FROM    [security].[Membership]
        WHERE   [Membership].[Username] = @Username
    );

    -- check if the user actually exists
    IF (@UserGuid is NULL) BEGIN
        RAISERROR (
            50004,
            16, -- Severity,
            1,  -- State,
            @Username
        );
        RETURN -1;
    END

    -- INSERT a member-notification relationship...
    INSERT INTO 
            [application].[UserNotifications]
    (
        [NotificationId]
    ,   [UserGuid]
    )
    -- ...for all notifications...
    SELECT
        [NotificationId]
    ,   @UserGuid
    FROM
        [application].[Notification]
    
    -- ...which have not yet expired
    WHERE
        [EffectiveTo] > GETDATE();
END