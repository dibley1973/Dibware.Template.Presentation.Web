-- =============================================
-- Author:		Duane Wingett
-- Create date: 20140412-1944
-- Description:	Gets the password for the specified username
-- =============================================
CREATE PROCEDURE [security].[Membership_GetPassword] 
	@Username varchar(max) = ''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Declare a variable to hold our result
	DECLARE @Result int;

	-- Get the password for the username
	SELECT TOP(1)	[Password]
	FROM			[security].[Membership]
	WHERE			[Username] = @Username;

END
GO
GRANT EXECUTE
    ON OBJECT::[security].[Membership_GetPassword] TO [UnauthorisedRole]
    AS [dbo];

