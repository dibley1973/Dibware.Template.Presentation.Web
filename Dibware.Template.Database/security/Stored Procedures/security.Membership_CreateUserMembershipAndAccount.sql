-- =============================================
-- Author:		    Duane Wingett
-- Create date:     20140418-1506
-- Updated date:    20140421-0341
-- Description:	    Creates a new user, membership and account
-- =============================================
CREATE PROCEDURE [security].[Membership_CreateUserMembershipAndAccount]
(
	@Username           varchar(max)
,	@Name               varchar(max)
,   @Password           varchar(128)
,   @EmailAddress       varchar(max)
,	@ConfirmationToken  varchar(128) 
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- First check if a user of that username exists
    -- and if it does throw an error
    IF EXISTS
    (
        SELECT  1
        FROM    [security].[User]
        WHERE   [Username] = @Username
    )
    BEGIN
        RAISERROR (
            N'Username %s already exists. Please choose another username.',
            16, -- Severity,
            1,  -- State,
            @Username
        )
        RETURN -1
    END

	-- Then check if that email address exists
    -- and if it does throw an error
    IF EXISTS
    (
        SELECT  1
        FROM    [user].[Account]
        WHERE   [EmailAddress] = @EmailAddress
    )
    BEGIN
        RAISERROR (
            N'Email address %s already exists in the system. Please choose another email address.',
            16, -- Severity,
            1,  -- State,
            @Username
        )
        RETURN -1
    END

    BEGIN TRY
        BEGIN TRANSACTION

        -- Create a new GUID for the user
	    DECLARE	@UserGuid uniqueidentifier;
	    SET		@UserGuid = NEWID();

	    -- Create user details
	    INSERT INTO [security].[User]
		(
            [UserGuid]
		,   [Username]
		,   [Name]
        )
	    VALUES
		(
            @UserGuid
		,   @Username
		,   @Name
        );

        -- Create membership details
        INSERT INTO [security].[Membership]
        (
            [UserGuid]
        ,   [CreateDate]
        ,   [ConfirmationToken]
        ,   [IsConfirmed]
        ,   [LastPasswordFailureDate]
        ,   [PasswordFailuresSinceLastSuccess]
        ,   [Password]
        ,   [PasswordChangedDate]
        ,   [PasswordVerificationToken]
        ,   [PasswordVerificationTokenExpirationDate]
        )
        VALUES
        (
            @UserGuid
        ,   GETDATE()
        ,   @ConfirmationToken
        ,   0               -- Not confirmed
        ,   null            -- Never failed
        ,   0               -- never failed
        ,   @Password
        ,   null            -- Never changed
        ,   null            -- Never set
        ,   null            -- Never set
        );

        -- Load up some default values for the user account
        DECLARE @InitialAccountStatus   int;
        DECLARE @DefaultAccountType     int;

        SELECT TOP 1                -- Should only ever be one row anyway!
            @InitialAccountStatus   = [InitialAccountStatus]
        ,   @DefaultAccountType     = [DefaultAccountType]
        FROM
            [application].[Configuration]

        -- Create account details
        INSERT INTO [user].Account
        (
            [UserGuid]
        ,   [EmailAddress]
        ,   [AccountStatus]
        ,   [LastAccountStatusChangedDate]
        ,   [AccountType]
        )
        VALUES
        (
            @UserGuid
        ,   @EmailAddress
        ,   @InitialAccountStatus
        ,   null
        ,   @DefaultAccountType
        );

        SELECT @UserGuid;

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        DECLARE @ErrorSeverity INT,
                    @ErrorNumber   INT,
                    @ErrorMessage nvarchar(4000),
                    @ErrorState INT,
                    @ErrorLine  INT,
                    @ErrorProc nvarchar(200)
                    -- Grab error information from SQL functions
            SET @ErrorSeverity = ERROR_SEVERITY()
            SET @ErrorNumber   = ERROR_NUMBER()
            SET @ErrorMessage  = ERROR_MESSAGE()
            SET @ErrorState    = ERROR_STATE()
            SET @ErrorLine     = ERROR_LINE()
            SET @ErrorProc     = ERROR_PROCEDURE()
            SET @ErrorMessage  = 'Problem updating users''s information.' + CHAR(13) + 'SQL Server Error Message is: ' + CAST(@ErrorNumber AS VARCHAR(10)) + ' in procedure: ' + @ErrorProc + ' Line: ' + CAST(@ErrorLine AS VARCHAR(10)) + ' Error text: ' + @ErrorMessage
            -- Not all errors generate an error state, to set to 1 if it's zero
            IF @ErrorState = 0
            BEGIN
                SET @ErrorState = 1
            END
            -- If the error renders the transaction as uncommittable or we have open transactions, we may want to rollback
            IF @@TRANCOUNT > 0
            BEGIN
                    --print 'Rollback transaction'
                    ROLLBACK TRANSACTION
            END
            RAISERROR (@ErrorMessage , @ErrorSeverity, @ErrorState, @ErrorNumber)
    END CATCH
    RETURN @@ERROR
END
GO
GRANT EXECUTE
    ON OBJECT::[security].[Membership_CreateUserMembershipAndAccount] TO [UnauthorisedRole]
    AS [dbo];

