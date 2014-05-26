CREATE PROCEDURE [application].[TermAndCondition_Insert]
(
    @EffectiveFrom  smalldatetime
,   @Description    varchar(Max)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO
        [application].[TermAndCondition]
    (
        [EffectiveFrom]
    ,   [Description]
    )
    VALUES
    (
        @EffectiveFrom
    ,   @Description
    );

    -- Select 
    DECLARE @TermId int;
    SELECT  @TermId = SCOPE_IDENTITY();

    SELECT @TermId  [TermId];
    RETURN @TermId;
END
GO