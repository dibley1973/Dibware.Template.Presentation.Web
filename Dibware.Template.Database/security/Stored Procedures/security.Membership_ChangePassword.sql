CREATE PROCEDURE [security].[Membership_ChangePassword]
(
	@Username           varchar(max)
,   @NewPassword        varchar(128)
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
		[Password] = @NewPassword
	WHERE
		[Username] = @Username;

	-- Select a status of 1 to signify success
	SELECT 1;
	RETURN 1;
END
GO
GRANT EXECUTE
    ON OBJECT::[security].[Membership_ChangePassword] TO [UnauthorisedRole]
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[security].[Membership_ChangePassword] TO [MainRole]
    AS [dbo];

