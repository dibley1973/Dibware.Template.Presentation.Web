CREATE PROCEDURE [application].[Error_Insert]
    @Message [nvarchar](max),
    @Source [nvarchar](max),
    @StackTrace [nvarchar](max),
    @Username [nvarchar](max),
    @TimeStamp [datetime]
AS
BEGIN
    INSERT [application].[Error]([Message], [Source], [StackTrace], [Username], [TimeStamp])
    VALUES (@Message, @Source, @StackTrace, @Username, @TimeStamp)
    
    DECLARE @ErrorId int
    SELECT @ErrorId = [ErrorId]
    FROM [application].[Error]
    WHERE @@ROWCOUNT > 0 AND [ErrorId] = scope_identity()
    
    SELECT t0.[ErrorId]
    FROM [application].[Error] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[ErrorId] = @ErrorId
END