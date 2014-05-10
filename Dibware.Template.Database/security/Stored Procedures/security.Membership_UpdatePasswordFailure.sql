CREATE PROCEDURE [security].[Membership_UpdatePasswordFailure]
(
    @Username           varchar(max) = ''
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Get the GUID for the user
    DECLARE @UserGuid   uniqueidentifier;
    SELECT  @UserGuid   = [UserGuid]
    FROM    
        [security].[Membership]
    WHERE
        [Username]      = @Username;
    
    -- Update the 

    UPDATE
        [security].[Membership]
    SET
        [PasswordFailuresSinceLastSuccess] = 
            ([PasswordFailuresSinceLastSuccess] + 1)
    ,   [LastPasswordFailureDate]           = GETDATE()
    WHERE
        [UserGuid]                          = @UserGuid;
        

END