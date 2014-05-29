CREATE TABLE [security].[Membership] (
    [UserGuid]                                UNIQUEIDENTIFIER DEFAULT (newsequentialid()) NOT NULL,
    [Username]                                NVARCHAR (256)   NOT NULL,
    [Password]                                NVARCHAR (128)   NOT NULL,
    [EmailAddress]                            NVARCHAR (256)   NOT NULL,
    [IsApproved]                              BIT              DEFAULT ((0)) NOT NULL,
    [IsConfirmed]                             BIT              DEFAULT ((0)) NOT NULL,
    [IsOnline]                                BIT              DEFAULT ((0)) NOT NULL,
    [IsLockedOut]                             BIT              DEFAULT ((0)) NOT NULL,
    [ConfirmationToken]                       NVARCHAR (128)   NULL,
    [CreationDate]                            DATETIME         DEFAULT (getdate()) NOT NULL,
    [LastActivityDate]                        DATETIME         DEFAULT (getdate()) NOT NULL,
    [LastLoginDate]                           DATETIME         DEFAULT (dateadd(day,(-1),getdate())) NOT NULL,
    [LastLockedOutDate ]                      DATETIME         DEFAULT (dateadd(day,(-1),getdate())) NOT NULL,
    [LastPasswordSuccessDate]                 DATETIME         NULL,
    [LastPasswordFailureDate]                 DATETIME         DEFAULT (dateadd(day,(-1),getdate())) NOT NULL,
    [LastPasswordChangedDate]                 DATETIME         DEFAULT (dateadd(day,(-1),getdate())) NOT NULL,
    [PasswordVerificationTokenExpirationDate] DATETIME         NULL,
    [PasswordVerificationToken]               NVARCHAR (128)   NULL,
    [PasswordFailuresSinceLastSuccess]        INT              DEFAULT ((0)) NOT NULL,
    [PasswordQuestion]                        NVARCHAR (256)   NULL,
    [PasswordAnswer]                          NVARCHAR (256)   NULL,
    [Comment]                                 VARCHAR (MAX)    NULL,
    CONSTRAINT [PK_Membership_UserGuid] PRIMARY KEY NONCLUSTERED ([UserGuid] ASC),
    CONSTRAINT [AK_Membership_EmailAddress] UNIQUE NONCLUSTERED ([EmailAddress] ASC),
    CONSTRAINT [AK_Membership_Username] UNIQUE NONCLUSTERED ([Username] ASC)
);




GO
GRANT SELECT
    ON OBJECT::[security].[Membership] TO [UnauthorisedRole]
    AS [dbo];


GO

GO
GRANT UPDATE
    ON OBJECT::[security].[Membership] TO [UnauthorisedRole]
    AS [dbo];

