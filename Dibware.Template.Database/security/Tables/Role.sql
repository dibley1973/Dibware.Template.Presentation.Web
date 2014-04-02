CREATE TABLE [security].[Role] (
    [RoleKey] NVARCHAR (25) NOT NULL,
    [Name]    NVARCHAR (25) NOT NULL,
    CONSTRAINT [PK_security.Role] PRIMARY KEY CLUSTERED ([RoleKey] ASC)
);

