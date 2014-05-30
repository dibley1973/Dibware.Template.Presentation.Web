CREATE TABLE [application].[UserNotifications] (
    [UserNotificationId] INT              NOT NULL,
    [NotificationId]     INT              NOT NULL,
    [UserGuid]           UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_UserNotifications_UserNotificationId] PRIMARY KEY CLUSTERED ([UserNotificationId] ASC),
    CONSTRAINT [FK_Membership_UserNotifcations] FOREIGN KEY ([UserGuid]) REFERENCES [security].[Membership] ([UserGuid]) ON DELETE CASCADE,
    CONSTRAINT [FK_Notification_UserNotifcations] FOREIGN KEY ([NotificationId]) REFERENCES [application].[Notification] ([NotificationId]) ON DELETE CASCADE
);




