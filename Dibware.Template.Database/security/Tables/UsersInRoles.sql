CREATE TABLE [security].[UsersInRoles] (
    [UserGuid] UNIQUEIDENTIFIER NOT NULL,
    [RoleKey]  NVARCHAR (25)    NOT NULL,
    CONSTRAINT [PK_UsersInRoles_UserGuid_RoleKey] PRIMARY KEY ([UserGuid] ASC, [RoleKey] ASC),
    CONSTRAINT [FK_Role_UsersInRoles] FOREIGN KEY ([RoleKey])   REFERENCES [security].[Role] ([RoleKey]),
    CONSTRAINT [FK_Membership_UsersInRoles] FOREIGN KEY ([UserGuid])  REFERENCES [security].[Membership] ([UserGuid])
);



