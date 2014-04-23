CREATE TABLE [security].[PasswordStrengthRules] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [RegularExpression] VARCHAR (128) NOT NULL,
    [Description]       VARCHAR (256) NOT NULL,
    CONSTRAINT [PK_PasswordStrengthRegularExpressions] PRIMARY KEY CLUSTERED ([Id] ASC)
);

