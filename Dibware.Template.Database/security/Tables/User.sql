CREATE TABLE [security].[User] (
    [UserGuid] UNIQUEIDENTIFIER NOT NULL,
    [UserName] NVARCHAR (MAX)   NOT NULL,
    [Name]     NVARCHAR (MAX)    NOT NULL,
    CONSTRAINT [PK_security.User] PRIMARY KEY CLUSTERED ([UserGuid] ASC)
);

