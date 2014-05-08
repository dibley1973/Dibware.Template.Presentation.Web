
-- Reference Data for Role 
MERGE INTO [security].[Role] AS TARGET
USING
(
    VALUES 
    (N'admin',N'Admin'),
    (N'main',N'Main'),
    (N'super',N'Super'),
    (N'unknown',N'Unknown')
) 
AS Source ([RoleKey], [Name]) 
ON TARGET.[RoleKey] = Source.[RoleKey]

-- Update matched rows 
WHEN MATCHED THEN 
    UPDATE SET 
        [Name]              = Source.[Name]

-- Insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
    INSERT ([RoleKey], [Name]) 
    VALUES ([RoleKey], [Name]) 

-- Delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
    DELETE;
