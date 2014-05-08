-- Declare our initial configuration values
DECLARE @InitialAccountStatus	int
,       @DefaultAccountType		int
,		@DefaultRoleKey			nvarchar(25);
SELECT  @InitialAccountStatus	= 1
,		@DefaultAccountType		= 1
,		@DefaultRoleKey			= 'main';

-- Truncate the configuration table
TRUNCATE TABLE [application].[Configuration];

-- Add configuration data
INSERT INTO 
    [application].[Configuration]
    (
        [InitialAccountStatus]
    ,   [DefaultAccountType]
	,	[DefaultRoleKey]
    )
    VALUES
    (
        @InitialAccountStatus
    ,   @DefaultAccountType
	,	@DefaultRoleKey
    );
GO

