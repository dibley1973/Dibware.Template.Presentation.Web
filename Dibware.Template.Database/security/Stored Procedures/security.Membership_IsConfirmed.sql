CREATE PROCEDURE [security].[Membership_IsConfirmed]
(
    @Username nvarchar(max)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Detect if the user's membership has been 
    -- confirmed and return the result
    SELECT  [IsConfirmed] 
    FROM    [security].[Membership] [m]
    JOIN    [security].[User]       [u]
    ON      [u].[UserGuid]          = [m].[UserGuid]
    WHERE   [u].[Username]          = @Username;
END
GO
GRANT EXECUTE
    ON OBJECT::[security].[Membership_IsConfirmed] TO [UnauthorisedRole]
    AS [dbo];

