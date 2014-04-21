CREATE TABLE [security].[User] (
    [UserGuid] UNIQUEIDENTIFIER NOT NULL,
    [Username] NVARCHAR (MAX)   NOT NULL,
    [Name]     NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_User_UserGuid] PRIMARY KEY CLUSTERED ([UserGuid] ASC)
);






GO
GRANT SELECT
    ON OBJECT::[security].[User] TO [UnauthorisedRole]
    AS [dbo];

