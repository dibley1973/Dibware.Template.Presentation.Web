-- Allow identity insertion
SET IDENTITY_INSERT [ref].[AccountStatus] ON;

-- Reference Data for AccountStatus 
MERGE INTO [ref].[AccountStatus] AS TARGET
USING
(
    VALUES 
    (1,N'Created'),
    (2,N'Confirmed'),
    (3,N'Active'), 
    (4,N'Dormant'), 
    (5,N'OnHold'), 
    (6,N'Suspended'),
    (7,N'Deactivated'),
    (8,N'Deleted')
) 
AS Source ([AccountStatusId], [Name]) 
ON TARGET.[AccountStatusId] = Source.[AccountStatusId]

-- Update matched rows 
WHEN MATCHED THEN 
    UPDATE SET 
        [Name] = Source.[Name]

-- Insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
    INSERT ([AccountStatusId], [Name]) 
    VALUES ([AccountStatusId], [Name]) 

-- Delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
    DELETE;

-- Revoke identity insertion
SET IDENTITY_INSERT [ref].[AccountStatus] OFF;