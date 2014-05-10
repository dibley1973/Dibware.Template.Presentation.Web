-- Declare our initial configuration values
DECLARE @InitialAccountStatus	        int
,       @DefaultAccountType		        int
,		@DefaultRoleKey			        nvarchar(25)
,       @DefaultMemberShipIsApproved    bit;
SELECT  @InitialAccountStatus	        = 1
,		@DefaultAccountType		        = 1
,		@DefaultRoleKey			        = 'main'
,       @DefaultMemberShipIsApproved    = 1;

-- Truncate the configuration table
TRUNCATE TABLE [application].[Configuration];

-- Add configuration data
INSERT INTO 
    [application].[Configuration]
    (
        [InitialAccountStatus]
    ,   [DefaultAccountType]
	,	[DefaultRoleKey]
    ,   [DefaultMemberShipIsApproved]
    )
    VALUES
    (
        @InitialAccountStatus
    ,   @DefaultAccountType
	,	@DefaultRoleKey
    ,   @DefaultMemberShipIsApproved
    );
GO

