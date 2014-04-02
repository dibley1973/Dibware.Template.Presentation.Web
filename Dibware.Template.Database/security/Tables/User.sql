CREATE TABLE [security].[User] (
    [UserGuid] UNIQUEIDENTIFIER NOT NULL,
    [Password] NVARCHAR (50)    NOT NULL,
    [UserName] NVARCHAR (MAX)   NULL,
    [Name]     NVARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_security.User] PRIMARY KEY CLUSTERED ([UserGuid] ASC)
);

