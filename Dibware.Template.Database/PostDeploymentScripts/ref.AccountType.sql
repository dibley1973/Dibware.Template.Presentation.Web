-- Allow identity insertion
SET IDENTITY_INSERT [ref].[AccountType] ON;

-- Reference Data for AccountType 
MERGE INTO [ref].[AccountType] AS TARGET
USING
(
    VALUES 
    (1,N'PrivateIndividual',1),
    (2,N'Organisation',1),
    (3,N'Business',1), 
    (4,N'Admin',0), 
    (5,N'SystemAdmin',0)
) 
AS Source ([AccountTypeId], [Name], [CanSelfRegister]) 
ON TARGET.[AccountTypeId] = Source.[AccountTypeId]

-- Update matched rows 
WHEN MATCHED THEN 
    UPDATE SET 
        [Name]              = Source.[Name]
    ,   [CanSelfRegister]   = source.[CanSelfRegister]

-- Insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
    INSERT ([AccountTypeId], [Name], [CanSelfRegister]) 
    VALUES ([AccountTypeId], [Name], [CanSelfRegister]) 

-- Delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
    DELETE;

-- Revoke identity insertion
SET IDENTITY_INSERT [ref].[AccountType] OFF;