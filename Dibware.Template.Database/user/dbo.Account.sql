CREATE TABLE [user].[Account]
(
    [UserGuid]                                UNIQUEIDENTIFIER NOT NULL,
    [EmailAddress]                            NVARCHAR (256)   NOT NULL,
    [AccountStatus]                           INT              NOT NULL,
    [LastAccountStatusChangedDate]            DATETIME         NULL,
    [AccountType]                             INT              NOT NULL
    CONSTRAINT [PK_Account_UserGuid] PRIMARY KEY CLUSTERED ([UserGuid] ASC),
    CONSTRAINT [AK_Account_EmailAddress] UNIQUE(EmailAddress),
    CONSTRAINT [FK_User_Account] FOREIGN KEY ([UserGuid]) REFERENCES [security].[User] ([UserGuid])
);
GO

