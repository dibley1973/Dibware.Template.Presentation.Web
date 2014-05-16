CREATE PROCEDURE [security].[Membership_UpdatePasswordFailureState]
(
    @Username nvarchar(max)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Update the state for password failure
    UPDATE
        [security].[Membership]
    SET
        [LastPasswordFailureDate] = GETDATE()
    ,   [PasswordFailuresSinceLastSuccess] = 
            [PasswordFailuresSinceLastSuccess] + 1
    WHERE
        [Username] = @Username;

    SELECT 1;
    RETURN 1;
END
GO
GRANT EXECUTE
    ON OBJECT::[security].[Membership_UpdatePasswordFailureState] TO [UnauthorisedRole]
    AS [dbo];
