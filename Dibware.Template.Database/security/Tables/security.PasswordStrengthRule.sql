CREATE TABLE [security].[PasswordStrengthRule] (
    [Id]                INT IDENTITY (1, 1) NOT NULL,
    [Sequence]          INT                 NOT NULL, 
    [RegularExpression] VARCHAR (128)       NOT NULL,
    [Description]       VARCHAR (256)       NOT NULL,
    [Notes]             VARCHAR (128)       NULL,
    CONSTRAINT [PK_PasswordStrengthRule_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
GRANT SELECT
    ON OBJECT::[security].[PasswordStrengthRule] TO [UnauthorisedRole]
    AS [dbo];


GO

CREATE UNIQUE INDEX [IX_PasswordStrengthRule_Sequence] ON [security].[PasswordStrengthRule] ([Sequence])
GO