CREATE TABLE [security].[User] (
    [UserGuid] UNIQUEIDENTIFIER NOT NULL,
    [Username] NVARCHAR (MAX)   NOT NULL,
    [Name]     NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_security.User] PRIMARY KEY CLUSTERED ([UserGuid] ASC)
);




GO
GRANT SELECT
    ON OBJECT::[security].[User] TO [UnauthorisedRole]
    AS [dbo];

