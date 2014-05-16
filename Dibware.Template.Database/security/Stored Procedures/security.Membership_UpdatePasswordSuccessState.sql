CREATE PROCEDURE [security].[Membership_UpdatePasswordSuccessState]
(
    @Username nvarchar(max)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Update the state for password success
    UPDATE
        [security].[Membership]
    SET
        [LastPasswordSuccessDate] = GETDATE()
    ,   [PasswordFailuresSinceLastSuccess] = 0
    WHERE
        [Username] = @Username;

    SELECT 1;
    RETURN 1;
END
GO
GRANT EXECUTE
    ON OBJECT::[security].[Membership_UpdatePasswordSuccessState] TO [UnauthorisedRole]
    AS [dbo];
