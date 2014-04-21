CREATE TABLE [application].[Configuration] (
    [ConfigurationId]      INT NOT NULL,
    [InitialAccountStatus] INT NOT NULL,
    [DefaultAccountType]   INT NOT NULL,
    CONSTRAINT [PK_Configuration_ConfigurationId] PRIMARY KEY CLUSTERED ([ConfigurationId] ASC)
);


