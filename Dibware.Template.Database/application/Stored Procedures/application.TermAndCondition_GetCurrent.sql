CREATE PROCEDURE [application].[TermAndCondition_GetCurrent]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Get the ID of the latest terms record for
    -- which the effective date is in the past.
    DECLARE @CurrentTermId int;
    SELECT  @CurrentTermId =
    (
        SELECT TOP 1
            [TermId]
        FROM
            [application].[TermAndCondition]
        WHERE
            [EffectiveFrom] < GETDATE()
        ORDER BY
            [EffectiveFrom] DESC
    );

    -- Detect if a current term ID was found...
    IF  (@CurrentTermId Is NULL) BEGIN
        -- ... one was not so we need to raise an error
        RAISERROR (
            50005,  -- No current Term has been found in system
            16,     -- Severity,
            1       -- State
        );
        RETURN -1;
    END ELSE BEGIN
        -- Get the record for the term ID
         SELECT
            [TermId]
        ,   [EffectiveFrom]
        ,   [Description]
        FROM
            [application].[TermAndCondition]
        WHERE
            [TermId] = @CurrentTermId;
        RETURN 1;
    END
END
GO
GRANT EXECUTE
    ON OBJECT::[application].[TermAndCondition_GetCurrent] TO [UnauthorisedRole]
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[application].[TermAndCondition_GetCurrent] TO [MainRole]
    AS [dbo];

