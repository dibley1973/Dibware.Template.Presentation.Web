
-- Reference:
--	http://blogs.msdn.com/b/ssdt/archive/2012/02/02/including-data-in-an-sql-server-database-project.aspx


/*
1	(?=^.{8,25}$)	Password length range from 8 to 25, the numbers are adjustable 
2	(?=(?:.*?[!@#$%*()_+^&}{:;?.]){1})	At least 1 special characters (!@#$%*()_+^&}{:;?.}), the number is adjustable 
3	(?=(?:.*?\d){2})	At least 2 digits, the number is adjustable
4	(?=.*[a-z])	Characters a-z
5	(?=(?:.*?[A-Z]){2})	At least 2 upper case characters, the number is adjustable 
*/

-- Reference Data for PasswordStrengthRules 
MERGE INTO [security].[PasswordStrengthRules] AS Target 
USING (VALUES 
  (1,N'(?=^.{8,25}$)', N'Password length range from 8 to 25, the numbers are adjustable'), 
  (2,N'(?=(?:.*?[!@#$%*()_+^&}{:;?.]){1})', N'At least 1 special characters (!@#$%*()_+^&}{:;?.}), the number is adjustable '), 
  (3,N'(?=(?:.*?\d){2})', N'At least 2 digits, the number is adjustable'), 
  (4,N'(?=.*[a-z])', N'Characters a-z'), 
  (5,N'(?=(?:.*?[A-Z]){2})', N'At least 2 upper case characters, the number is adjustable') 
) 
AS Source ([Id],[RegularExpression], [Description]) 
ON Target.Id = Source.Id 
-- update matched rows 
WHEN MATCHED THEN 
	UPDATE SET 
		[RegularExpression] = Source.[RegularExpression],
		[Description] = Source.[Description]

-- insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
	INSERT ([RegularExpression], [Description]) 
	VALUES ([RegularExpression], [Description]) 

-- delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;
