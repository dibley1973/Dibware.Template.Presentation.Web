-- Declare our initial configuration values
DECLARE @InitialAccountStatus int
,       @DefaultAccountType int;
SELECT  @InitialAccountStatus = 1;
SELECT  @DefaultAccountType = 1;

-- Truncate the configuration table
TRUNCATE TABLE [application].[Configuration];

-- Add configuration data
INSERT INTO 
    [application].[Configuration]
    (
        [InitialAccountStatus]
    ,   [DefaultAccountType]
    )
    VALUES
    (
        @InitialAccountStatus
    ,   @DefaultAccountType
    );
GO

