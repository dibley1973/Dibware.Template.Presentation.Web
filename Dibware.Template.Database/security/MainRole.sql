CREATE ROLE [MainRole]
    AUTHORIZATION [dbo];



GO
ALTER ROLE [MainRole] ADD MEMBER [AuthorisedUser];

