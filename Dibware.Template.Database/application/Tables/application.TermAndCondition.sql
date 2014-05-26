CREATE TABLE [application].[TermAndCondition] (
    [TermId]        INT           IDENTITY (1, 1) NOT NULL,
    [EffectiveFrom] SMALLDATETIME NOT NULL,
    [Description]   VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Terms] PRIMARY KEY CLUSTERED ([TermId] ASC)
);

