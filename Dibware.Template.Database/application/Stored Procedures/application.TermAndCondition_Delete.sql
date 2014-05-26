CREATE PROCEDURE [application].[TermAndCondition_Delete]
(
    @TermId         int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Get the effective date for the T&C we are trying to DELETE
    DECLARE @ExistingEffectiveDate smalldatetime;
    SELECT  @ExistingEffectiveDate =
    (
        SELECT      [EffectiveFrom]
        FROM        [application].[TermAndCondition]
        WHERE       [TermId] = @TermId
    );

    -- Check if effective date is null, 
    -- indicating the record does not exist
    If (@ExistingEffectiveDate is NULL) BEGIN
        -- Warn the user that T&Cs does not exists
        RAISERROR (
            50006,  -- That term does not exists in the system. 
            16,     -- Severity,
            1,      -- State,
            @TermId
        );
        RETURN -1;
    END

    -- Check if the effective date is in the past, 
    -- indictaing the record has been active
    If (@ExistingEffectiveDate < GETDATE()) BEGIN
        -- Warn the user that active T&Cs cannot be DELETED
        RAISERROR (
            50007,  -- Cannot delete a term that has been active in the system. 
            16,     -- Severity,
            1,      -- State,
            @TermId
        );
        RETURN -1;
    END

    -- Finally if we get here then the T&C can be DELETED
    DELETE FROM
        [application].[TermAndCondition]
    WHERE
        [TermId]        = @TermId;

    -- Select / return the DELETED Term Id
    SELECT @TermId;
    RETURN 1;
END
GO