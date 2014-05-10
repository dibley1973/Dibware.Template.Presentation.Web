CREATE TABLE [security].[Membership] (
    [UserGuid]                                  UNIQUEIDENTIFIER DEFAULT(newsequentialid()) NOT NULL,
    [Username]                                  NVARCHAR (256)   NOT NULL,
    [Password]                                  NVARCHAR (128)   NOT NULL,
    [EmailAddress]                              NVARCHAR (256)   NOT NULL,
    [IsApproved]                                BIT              DEFAULT ((0)) NOT NULL,
    [IsConfirmed]                               BIT              DEFAULT ((0)) NOT NULL,
    [IsOnline]                                  BIT              DEFAULT ((0)) NOT NULL,
    [IsLockedOut]                               BIT              DEFAULT ((0)) NOT NULL,
    [ConfirmationToken]                         NVARCHAR (128)   NULL,
    [CreationDate]                              DATETIME         NOT NULL DEFAULT (GETDATE()),
    [LastActivityDate]                          DATETIME         NOT NULL DEFAULT (GETDATE()),
    [LastLoginDate]                             DATETIME         NULL,
    [LastLockedOutDate ]                        DATETIME         NULL,
    [LastPasswordSuccessDate]                   DATETIME         NULL,
    [LastPasswordFailureDate]                   DATETIME         NULL,
    [LastPasswordChangedDate]                   DATETIME         NULL,
    [PasswordVerificationTokenExpirationDate]   DATETIME         NULL,
    [PasswordVerificationToken]                 NVARCHAR (128)   NULL,
    [PasswordFailuresSinceLastSuccess]          INT              DEFAULT ((0)) NOT NULL,
    [Comment]                                   VARCHAR(MAX)     NULL,
    CONSTRAINT [PK_Membership_UserGuid]     PRIMARY KEY NONCLUSTERED    ([UserGuid] ASC),
    CONSTRAINT [AK_Membership_Username]     UNIQUE NONCLUSTERED         ([Username] ASC),
    CONSTRAINT [AK_Membership_EmailAddress] UNIQUE NONCLUSTERED         ([EmailAddress] ASC)
);








GO
GRANT SELECT
    ON OBJECT::[security].[Membership] TO [UnauthorisedRole]
    AS [dbo];

