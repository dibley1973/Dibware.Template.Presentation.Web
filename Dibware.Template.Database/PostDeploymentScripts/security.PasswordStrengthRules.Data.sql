-- Reference:
--	http://blogs.msdn.com/b/ssdt/archive/2012/02/02/including-data-in-an-sql-server-database-project.aspx


/*
1	(?=^.{8,25}$)	Password length range from 8 to 25, the numbers are adjustable 
2	(?=(?:.*?[!@#$%*()_+^&}{:;?.]){1})	At least 1 special characters (!@#$%*()_+^&}{:;?.}) , the number is adjustable 
3	(?=(?:.*?\d){2})	At least 2 digits, the number is adjustable
4	(?=.*[a-z])	Characters a-z
5	(?=(?:.*?[A-Z]){2})	At least 2 upper case characters, the number is adjustable 
*/

-- Reference Data for PasswordStrengthRules 
MERGE INTO [security].[PasswordStrengthRules] AS Target 
USING (VALUES 
  (0, N'Undefined'), 
  (1, N'Billing'), 
  (2, N'Home'), 
  (3, N'Main Office'), 
  (4, N'Primary'), 
  (5, N'Shipping'), 
  (6, N'Archive') 
) 
AS Source (AddressTypeID, Name) 
ON Target.AddressTypeID = Source.AddressTypeID 
-- update matched rows 
WHEN MATCHED THEN 
UPDATE SET Name = Source.Name 
-- insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (AddressTypeID, Name) 
VALUES (AddressTypeID, Name) 
-- delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
DELETE;