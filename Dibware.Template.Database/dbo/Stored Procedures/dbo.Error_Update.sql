CREATE PROCEDURE [dbo].[Error_Update]
    @ErrorId [int],
    @Message [nvarchar](max),
    @Source [nvarchar](max),
    @StackTrace [nvarchar](max),
    @Username [nvarchar](max),
    @TimeStamp [datetime]
AS
BEGIN
    UPDATE [application].[Error]
    SET [Message] = @Message, [Source] = @Source, [StackTrace] = @StackTrace, [Username] = @Username, [TimeStamp] = @TimeStamp
    WHERE ([ErrorId] = @ErrorId)
END