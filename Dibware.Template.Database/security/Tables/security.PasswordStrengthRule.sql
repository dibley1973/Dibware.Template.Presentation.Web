CREATE TABLE [security].[PasswordStrengthRule] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [RegularExpression] VARCHAR (128) NOT NULL,
    [Description]       VARCHAR (256) NOT NULL,
    CONSTRAINT [PK_PasswordStrengthRule_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

