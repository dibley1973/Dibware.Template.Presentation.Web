﻿-- =============================================
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
        FROM    [security].[Membership]
        WHERE   [Username] = @Username
    )
    BEGIN
        RAISERROR (
            50001,
            16, -- Severity,
            1,  -- State,
            @Username
        );
        RETURN -1;
    END

	-- Then check if that email address exists
    -- and if it does throw an error
    IF EXISTS
    (
        SELECT  1
        FROM    [security].[Membership]
        WHERE   [EmailAddress] = @EmailAddress
    )
    BEGIN
        RAISERROR (
            50002,
            16, -- Severity,
            1,  -- State,
            @EmailAddress
        );
        RETURN -1;
    END

    BEGIN TRY
        BEGIN TRANSACTION

        -- Create a new GUID for the user
	    DECLARE	@UserGuid UNIQUEIDENTIFIER;

        DECLARE @OutPutTable TABLE (
            UserGuid uniqueidentifier
        );

	 --   -- Create user details
	 --   INSERT INTO [security].[User]
		--(
  --          --[UserGuid]
		--    [Username]
		--,   [Name]
  --      )
  --      OUTPUT inserted.UserGuid INTO @OutPutTable
	 --   VALUES
		--(
  --          --@UserGuid
		--    @Username
		--,   @Name
  --      );

        -- Get identity of the newly inserted record
        --SET @UserGuid = SCOPE_IDENTITY();
        --SELECT @UserGuid = UserGuid FROM @OutPutTable;

        -- Load up some default values for the user account
        DECLARE @InitialAccountStatus           int
        ,       @DefaultAccountType             int
        ,       @DefaultMemberShipIsApproved    bit;
        SELECT TOP 1                        -- Should only ever be one row anyway!
            @InitialAccountStatus           = [InitialAccountStatus]
        ,   @DefaultAccountType             = [DefaultAccountType]
        ,   @DefaultMemberShipIsApproved    = [DefaultMemberShipIsApproved]
        FROM
            [application].[Configuration];

        

        -- Create membership details
        INSERT INTO [security].[Membership]
        (
		    [Username]
        ,   [Password]
        ,   [EmailAddress]
        ,   [IsApproved]
        ,   [ConfirmationToken]

        --,   [IsConfirmed]
        --,   [LastPasswordFailureDate]
        --,   [PasswordFailuresSinceLastSuccess]
        --,   [LastPasswordChangedDate]
        --,   [PasswordVerificationToken]
        --,   [PasswordVerificationTokenExpirationDate]
        ) 
        OUTPUT inserted.UserGuid INTO @OutPutTable
        --OUTPUT INSERTED.[UserGuid] INTO @UserGuid
        VALUES
        (
		    @Username
        ,   @Password
        ,   @EmailAddress
        ,   @DefaultMemberShipIsApproved
        ,   @ConfirmationToken
        --,   0               -- Not confirmed
        --,   null            -- Never failed
        --,   0               -- never failed
        --,   null            -- Never changed
        --,   null            -- Never set
        --,   null            -- Never set
        );

        -- Get identity of the newly inserted record
        SELECT @UserGuid = UserGuid FROM @OutPutTable;

        -- Create account details
        INSERT INTO [user].Account
        (
            [UserGuid]
        ,   [Name]
        ,   [AccountStatus]
        ,   [LastAccountStatusChangedDate]
        ,   [AccountType]
        )
        VALUES
        (
            @UserGuid
        ,   @Name
        ,   @InitialAccountStatus
        ,   null
        ,   @DefaultAccountType
        );

        SELECT CAST(@UserGuid As varchar(36)) [UserGuid];

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        -- If the error renders the transaction as uncommittable or we have open transactions, we may want to rollback
        IF @@TRANCOUNT > 0
        BEGIN
            --print 'Rollback transaction'
            ROLLBACK TRANSACTION
        END

        DECLARE @ErrorSeverity  INT
        ,       @ErrorNumber    INT
        ,       @ErrorMessage   nvarchar(4000)
        ,       @ErrorState     INT
        ,       @ErrorLine      INT
        ,       @ErrorProc      nvarchar(200)
        ,       @ErrorTimeStamp smalldatetime
        ,       @StackTrace     nvarchar(max);

        -- Grab error information from SQL functions
        SET     @ErrorSeverity  = ERROR_SEVERITY();
        SET     @ErrorNumber    = ERROR_NUMBER();
        SET     @ErrorMessage   = ERROR_MESSAGE();
        SET     @ErrorState     = ERROR_STATE();
        SET     @ErrorLine      = ERROR_LINE();
        SET     @ErrorProc      = ERROR_PROCEDURE();
        SET     @ErrorMessage   = 'Problem updating users''s information.' + CHAR(13) + 'SQL Server Error Message is: ' + CAST(@ErrorNumber AS VARCHAR(10)) + ' in procedure: ' + @ErrorProc + ' Line: ' + CAST(@ErrorLine AS VARCHAR(10)) + ' Error text: ' + @ErrorMessage;
        SET     @ErrorTimeStamp = GETDATE();
        SET     @StackTrace     = CAST(@ErrorLine AS varchar(18));

        -- Not all errors generate an error state, to set to 1 if it's zero
        IF @ErrorState = 0
        BEGIN
            SET @ErrorState = 1;
        END

        EXEC [application].[Error_Insert]
            @ErrorMessage
        ,   @ErrorProc
        ,   @StackTrace
        ,   @Username
        ,   @ErrorTimeStamp;

        RAISERROR (@ErrorMessage , @ErrorSeverity, @ErrorState, @ErrorNumber);

        SELECT 'ERROR';

    END CATCH
    RETURN @@ERROR;
END
GO
GRANT EXECUTE
    ON OBJECT::[security].[Membership_CreateUserMembershipAndAccount] TO [UnauthorisedRole]
    AS [dbo];

