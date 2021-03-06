﻿CREATE TABLE [application].[Status] (
    [StatusId] INT           IDENTITY (1, 1) NOT NULL,
    [State]    INT           NOT NULL,
    [Message]  VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED ([StatusId] ASC)
);






GO
GRANT SELECT
    ON OBJECT::[application].[Status] TO [UnauthorisedRole]
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[application].[Status] TO [MainRole]
    AS [dbo];

