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

	-- 
	SELECT TOP(1)	[m].[Password]	[Password]
	FROM			[security].[Membership] [m]
	JOIN			[security].[User] [u]
	ON				[m].[UserGuid] = [u].UserGuid
	WHERE			[u].[Username] = @Username;

END
GO
GRANT EXECUTE
    ON OBJECT::[security].[Membership_GetPassword] TO [UnauthorisedRole]
    AS [dbo];

