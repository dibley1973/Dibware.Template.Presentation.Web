CREATE TABLE [security].[Membership] (
    [UserGuid]                                UNIQUEIDENTIFIER NOT NULL,
    [CreateDate]                              DATETIME         NULL,
    [ConfirmationToken]                       NVARCHAR (128)   NULL,
    [IsConfirmed]                             BIT              DEFAULT ((0)) NULL,
    [LastPasswordFailureDate]                 DATETIME         NULL,
    [PasswordFailuresSinceLastSuccess]        INT              DEFAULT ((0)) NOT NULL,
    [Password]                                NVARCHAR (128)   NOT NULL,
    [PasswordChangedDate]                     DATETIME         NULL,
    [PasswordVerificationToken]               NVARCHAR (128)   NULL,
    [PasswordVerificationTokenExpirationDate] DATETIME         NULL,
    PRIMARY KEY CLUSTERED ([UserGuid] ASC),
    CONSTRAINT [FK_User_Membership] FOREIGN KEY ([UserGuid]) REFERENCES [security].[User] ([UserGuid])
);



