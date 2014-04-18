CREATE PROCEDURE [application].[Error_Delete]
    @ErrorId [int]
AS
BEGIN
    DELETE [application].[Error]
    WHERE ([ErrorId] = @ErrorId)
END