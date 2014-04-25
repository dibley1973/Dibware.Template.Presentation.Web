CREATE TABLE [security].[User] (
    [UserGuid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),
    [Username] NVARCHAR (MAX)   NOT NULL,
    [Name]     NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_User_UserGuid] PRIMARY KEY NONCLUSTERED ([UserGuid] ASC)
);






GO
GRANT SELECT
    ON OBJECT::[security].[User] TO [UnauthorisedRole]
    AS [dbo];

