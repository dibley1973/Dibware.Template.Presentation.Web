CREATE TABLE [application].[Notification]
(
    [NotificationId]    INT NOT NULL PRIMARY KEY IDENTITY, 
    [EffectiveFrom]     SMALLDATETIME NOT NULL, 
    [EffectiveTo]       SMALLDATETIME NOT NULL, 
    [Description]       VARCHAR(MAX) NOT NULL
)
