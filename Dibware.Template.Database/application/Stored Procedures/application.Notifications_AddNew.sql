
-- =============================================
-- Author:		Duane Wingett
-- Create date: 2014-05-31
-- Description:	Add a new notification to the system 
--              and assignes it to all current users
-- =============================================
CREATE PROCEDURE [application].[Notifications_AddNew] 
(
    @EffectiveFrom  smalldatetime
,   @EffectiveTo    smalldatetime
,   @Description    varchar(max)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- First declare a variable to hold the Id of
    -- the newly inserted notifcation
    DECLARE @NotificationId int;

    -- Insert the new notification
    INSERT INTO 
        [application].[Notification]
    (
        [EffectiveFrom]
    ,   [EffectiveTo]
    ,   [Description]
    )
    VALUES
    (
        @EffectiveFrom
    ,   @EffectiveTo
    ,   @Description
    )

    -- Store the ID of the notification
    SELECT  @NotificationId = SCOPE_IDENTITY();

    -- Insert a member-notification relationship for
    -- the new notification for all current members
    -- INSERT a member-notification relationship...
    INSERT INTO 
            [application].[UserNotifications]
    (
        [NotificationId]
    ,   [UserGuid]
    )
    -- ...for all members...
    SELECT
        @NotificationId
    ,   [UserGuid]
    FROM
        [security].[Membership];

END