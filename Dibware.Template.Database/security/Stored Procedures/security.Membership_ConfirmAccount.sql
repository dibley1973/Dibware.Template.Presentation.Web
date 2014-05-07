CREATE PROCEDURE [security].[Membership_ConfirmAccount]
    @ConfirmationToken  varchar(128)
,   @Username           varchar(max) = ''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- First get the user GUID for a user with the specified
    -- confirmation token, and also username if it was supplied.
    DECLARE @UserGuid uniqueidentifier;
    SELECT  @UserGuid               = [m].[UserGuid]
    FROM    [security].[User]       [u]
    JOIN    [security].[Membership] [m]
    ON      [u].UserGuid            = [m].[UserGuid]
    WHERE   [m].ConfirmationToken   = @ConfirmationToken
    AND
    (
        [u].[Username] = @Username
    OR
        @Username = ''
    );

    IF (@UserGuid IS NULL) BEGIN
        -- Return ZERO (False) to indicate there is either no
        -- such user with that token, or no such user with that
        -- token and name combination
        SELECT 0
        RETURN;

    END ELSE BEGIN
        -- We do have a user with either taht token or that
        -- username and token combination, so get the "Confirmed"
        -- AccounStatusId
        DECLARE @ConfirmedStatus int;
        SELECT  @ConfirmedStatus = 2    -- Confirmed

        -- Update the membership record to "Confirmed" state
        UPDATE  [user].[Account]
        SET     [AccountStatus]                 = @ConfirmedStatus
        ,       [LastAccountStatusChangedDate]  = GETDATE()
        WHERE   [UserGuid]                      = @UserGuid;
        RETURN;
    END
END
GO
GRANT EXECUTE
    ON OBJECT::[security].[Membership_ConfirmAccount] TO [UnauthorisedRole]
    AS [dbo];

