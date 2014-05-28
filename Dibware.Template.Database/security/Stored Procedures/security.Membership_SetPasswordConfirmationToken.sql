-- =============================================
-- Author:		    Duane Wingett
-- Create date:     20140528-0646
-- Description:	    sets the password confirmation token and expiry time
-- =============================================
CREATE PROCEDURE [security].[Membership_SetPasswordConfirmationToken]
(
	@Username                   varchar(max)
,   @PasswordConfirmationToken  varchar(128) 
,   @TokenExpirationTime        smalldatetime
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    
	-- First check if a user of that username does
    -- not exists and if it does not, throw an error
    IF NOT EXISTS
    (
        SELECT  1
        FROM    [security].[Membership]
        WHERE   [Username] = @Username
    )
    BEGIN
        RAISERROR (
            50004,  -- Username does not exist. 
            16,     -- Severity,
            1,      -- State,
            @Username
        );
        RETURN -1;
    END

    -- So we do have the user so update the stored procedure
	UPDATE
		[security].[Membership]
	SET
		[PasswordVerificationToken] = @PasswordConfirmationToken,
        [PasswordVerificationTokenExpirationDate] = @TokenExpirationTime
	WHERE
		[Username] = @Username;

	-- Select a status of 1 to signify success
	SELECT 1;
	RETURN 1;
END
GO


GRANT EXECUTE
    ON OBJECT::[security].[Membership_SetPasswordConfirmationToken] TO [UnauthorisedRole]
    AS [dbo];
GO