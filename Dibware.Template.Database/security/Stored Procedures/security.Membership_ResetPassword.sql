CREATE PROCEDURE [security].[Membership_ResetPassword]
(
    @PasswordConfirmationToken  varchar(128)
,   @NewPassword                varchar(128))
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @TokenCount int;
    SELECT  @TokenCount =
    (
        SELECT  COUNT([Username])
        FROM    [security].[Membership]
        WHERE   [PasswordVerificationToken] = @PasswordConfirmationToken
    );

    -- Check if no token was found
    If (@TokenCount = 0) BEGIN
        RAISERROR (
            50009,  -- Password reset token does not exist. 
            16,     -- Severity,
            1,      -- State,
            @PasswordConfirmationToken
        );
        RETURN -1;
    END

    -- Check if more than one token was found
    -- This should be highly unlikely!
    If (@TokenCount > 1) BEGIN
        RAISERROR (
            50010,  -- Password reset token exists multiple times. 
            16,     -- Severity,
            1,      -- State,
            @PasswordConfirmationToken
        );
        RETURN -1;
    END

    -- Check token has if expired...
    DECLARE @TokenExpiry smalldatetime;
    SELECT  @TokenExpiry =
    (
        SELECT TOP 1
                [PasswordVerificationTokenExpirationDate]
        FROM    [security].[Membership]
        WHERE   [PasswordVerificationToken] = @PasswordConfirmationToken
    );
    IF (GETDATE() < @TokenExpiry) BEGIN
        RAISERROR (
            50011,  -- Password reset token has expired. 
            16,     -- Severity,
            1,      -- State,
            @PasswordConfirmationToken
        );
        RETURN -1;
    END

    -- Now we have the user, update password
	UPDATE
		[security].[Membership]
	SET
		[Password] = @NewPassword
    ,   [PasswordVerificationToken] = ''
    ,   [PasswordVerificationTokenExpirationDate] = NULL
	WHERE
		[PasswordVerificationToken] = @PasswordConfirmationToken

	-- Select a status of 1 to signify success
	SELECT 1;
	RETURN 1;
END
GO

GRANT EXECUTE
    ON OBJECT::[security].[Membership_ResetPassword] TO [UnauthorisedRole]
    AS [dbo];
GO