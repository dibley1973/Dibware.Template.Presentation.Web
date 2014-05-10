CREATE TABLE [application].[Configuration] (
    [ConfigurationId]             INT           IDENTITY (1, 1) NOT NULL,
    [InitialAccountStatus]        INT           NOT NULL,
    [DefaultAccountType]          INT           NOT NULL,
    [DefaultRoleKey]              NVARCHAR (25) NOT NULL,
    [DefaultMemberShipIsApproved] BIT           NOT NULL,
    CONSTRAINT [PK_Configuration_ConfigurationId] PRIMARY KEY CLUSTERED ([ConfigurationId] ASC)
);






