CREATE PROCEDURE [security].[Membership_ConfirmAccount]
(
    @ConfirmationToken  varchar(128)
,   @Username           varchar(max) = ''
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- First get the user GUID for a user with the specified
    -- confirmation token, and also username if it was supplied.
    DECLARE @UserGuid uniqueidentifier;
    SELECT  @UserGuid               = [UserGuid]
    FROM    [security].[Membership]
    WHERE   [ConfirmationToken]   = @ConfirmationToken
    AND
    (
        [Username] = @Username
    OR
        @Username = ''
    );

    -- Check if the GUID exists...
    IF (@UserGuid IS NULL) BEGIN
        -- ... It does nots os return ZERO (False) to indicate 
        -- there is either no such user with that token, or no 
        -- such user with that token and name combination
        SELECT 0 [IsConfirmed];
        RETURN;
    END

    -- See if the membership for this GUID is already confirmed
    DECLARE @AlreadyConfirmed BIT;
    SELECT  @AlreadyConfirmed           = [IsConfirmed]
    FROM    [security].[Membership]
    WHERE   [UserGuid]                  = @UserGuid;
    IF (@AlreadyConfirmed = 1) BEGIN
        -- We need to raise an error
        RAISERROR (
            50003,
            16,     -- Severity,
            1       -- State
        );
        RETURN 0;
    END

    -- We do have a user with either that token or that
    -- username and token combination, and the membership
    -- has not been confirmed. so now get the "Confirmed" 
    -- AccounStatusId
    DECLARE @ConfirmedStatus int;
    SELECT  @ConfirmedStatus = 2    -- Confirmed

    -- Update the membership record to "Confirmed" state
	UPDATE	[security].[Membership]
	SET		[IsConfirmed]					= 1
	WHERE	[UserGuid]                      = @UserGuid;

	-- Update user account to confirmed status
    UPDATE  [user].[Account]
    SET     [AccountStatus]                 = @ConfirmedStatus
    ,       [LastAccountStatusChangedDate]  = GETDATE()
    WHERE   [UserGuid]                      = @UserGuid;

	-- Get the default role
	DECLARE	@DefaultRoleKey		nvarchar(25);
	SELECT	@DefaultRoleKey		= [DefaultRoleKey]
	FROM	[application].[Configuration]
	WHERE	[ConfigurationId]    = 1;

	-- Add the user to the default role
	EXEC [security].[UsersInRoles_Add] @UserGuid, @DefaultRoleKey;

    SELECT 1 [IsConfirmed];
    RETURN;

END
GO
GRANT EXECUTE
    ON OBJECT::[security].[Membership_ConfirmAccount] TO [UnauthorisedRole]
    AS [dbo];

