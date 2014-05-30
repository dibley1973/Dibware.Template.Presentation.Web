CREATE TABLE [security].[Role] (
    [RoleKey] NVARCHAR (25)  NOT NULL,
    [Name]    NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_Role_RoleKey] PRIMARY KEY CLUSTERED ([RoleKey] ASC)
);



