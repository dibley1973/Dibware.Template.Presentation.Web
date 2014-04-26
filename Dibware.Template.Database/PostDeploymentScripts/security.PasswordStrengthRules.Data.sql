
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
MERGE INTO [security].[PasswordStrengthRule] AS Target 
USING (VALUES 
  (1,1,N'^', N'The start of the sequence', N''),
  (2,2,N'(?=^.{8,25}$)', N'Password length range from 8 to 25', N'The numbers are adjustable'), 
  (3,3,N'(?=(?:.*?[!@#$%*()_+^&}{:;?.]){1})', N'At least 1 special characters (!@#$%*()_+^&}{:;?.})', N'This number is adjustable'), 
  (4,4,N'(?=(?:.*?\d){2})', N'At least 2 digits', N'This number is adjustable'), 
  (5,5,N'(?=.*[a-z])', N'Characters a-z', N''), 
  (6,6,N'(?=(?:.*?[A-Z]){2})', N'At least 2 upper case characters', N'This number is adjustable'),
  (7,7,N'[0-9a-zA-Z!@#$%*()_+^&]*$', N'The start of the sequence can have any chars', N'')
) 
AS Source ([Id], [Sequence], [RegularExpression], [Description], [Notes]) 
ON Target.Id = Source.Id 
-- update matched rows 
WHEN MATCHED THEN 
	UPDATE SET 
		[Sequence] = Source.[Sequence]
	,   [RegularExpression] = Source.[RegularExpression]
	,	[Description] = Source.[Description]
	,	[Notes] = Source.[Notes]

-- insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
	INSERT ([Sequence], [RegularExpression], [Description], [Notes]) 
	VALUES ([Sequence], [RegularExpression], [Description], [Notes]) 

-- delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;
