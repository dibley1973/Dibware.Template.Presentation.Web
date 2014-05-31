CREATE TABLE [application].[Notification]
(
    [NotificationId]    INT             NOT NULL IDENTITY (1,1), 
    [EffectiveFrom]     SMALLDATETIME   NOT NULL, 
    [EffectiveTo]       SMALLDATETIME   NOT NULL, 
    [Description]       VARCHAR(MAX)    NOT NULL,
    CONSTRAINT [PK_Notification_NotificationId] PRIMARY KEY CLUSTERED ([NotificationId] ASC)
)
