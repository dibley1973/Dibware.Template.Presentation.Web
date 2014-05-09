CREATE PROCEDURE [security].[Membership_IsConfirmed]
(
    @Username nvarchar(max)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @IsConfirmed    bit;

    -- Detect if the user's membership has been 
    -- confirmed and return the result
    SELECT  @IsConfirmed            = [IsConfirmed] 
    FROM    [security].[Membership] [m]
    JOIN    [security].[User]       [u]
    ON      [u].[UserGuid]          = [m].[UserGuid]
    WHERE   [u].[Username]          = @Username;

    -- Detect if the user does not exist
    If (@IsConfirmed) = NULL BEGIN
        -- Raise the appropriate error
        RAISERROR (
            50004,
            16, -- Severity,
            1,  -- State,
            @Username
        );
        RETURN -1;
    END

    -- Otherwise return confirmed state
    SELECT @IsConfirmed [IsConfirmed];
    RETURN;
END
GO
GRANT EXECUTE
    ON OBJECT::[security].[Membership_IsConfirmed] TO [UnauthorisedRole]
    AS [dbo];

