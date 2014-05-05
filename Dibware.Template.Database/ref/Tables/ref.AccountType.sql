CREATE TABLE [ref].[AccountType]
(
    [AccountTypeId]     INT             NOT NULL PRIMARY KEY IDENTITY, 
    [Name]              NVARCHAR(50)    NOT NULL, 
    [CanSelfRegister]   BIT             NOT NULL
)
