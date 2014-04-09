CREATE TABLE [security].[OAuthMembership] (
    [Provider]          NVARCHAR (30)  NOT NULL,
    [ProviderUserId]    NVARCHAR (100) NOT NULL,
    [UserGuid]          uniqueidentifier NOT NULL,
    PRIMARY KEY CLUSTERED ([Provider] ASC, [ProviderUserId] ASC)
);

