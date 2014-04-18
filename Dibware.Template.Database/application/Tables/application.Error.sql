CREATE TABLE [application].[Error] (
    [ErrorId]    INT            IDENTITY (1, 1) NOT NULL,
    [Message]    NVARCHAR (MAX) NOT NULL,
    [Source]     NVARCHAR (MAX) NOT NULL,
    [StackTrace] NVARCHAR (MAX) NOT NULL,
    [Username]   NVARCHAR (MAX) NULL,
    [TimeStamp]  DATETIME       NOT NULL,
    CONSTRAINT [PK_application.Error] PRIMARY KEY CLUSTERED ([ErrorId] ASC)
);

