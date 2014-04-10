-- =============================================
-- Author:		Duane Wingett
-- Create date: 20140410-0516
-- Description:	Validates a user login vs password
-- =============================================
CREATE PROCEDURE security.Membership_ValidateUser 
	-- Add the parameters for the stored procedure here
	@Username varchar(max) = '', 
	@Password varchar(max) = ''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Declare a variable to hold our result
	DECLARE @Result int;

    -- Set the result
	SELECT @Result =
	(
		SELECT TOP(1)	[u].[Username]
		FROM			[security].[User] [u]
		JOIN			[security].[Membership] [m]
		ON				[m].[UserGuid] = [u].UserGuid
		WHERE			[u].[Username] = @Username
		AND				[m].[Password] = @Password
	);
	Select @Result;
END