CREATE TABLE [security].[UsersInRoles] (
    [UserGuid]      uniqueidentifier NOT NULL,
    [RoleKey]       nvarchar(25) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserGuid] ASC, [RoleKey] ASC),
    CONSTRAINT [FK_Role_UsersInRoles] FOREIGN KEY ([RoleKey]) REFERENCES [security].[Role] ([RoleKey]),
    CONSTRAINT [FK_User_UsersInRoles] FOREIGN KEY ([UserGuid]) REFERENCES [security].[User] ([UserGuid])
);

