CREATE ROLE [UnauthorisedRole]
    AUTHORIZATION [dbo];


GO
ALTER ROLE [UnauthorisedRole] ADD MEMBER [AppUnauthorisedUser];

