using System;

namespace Dibware.Template.Infrastructure.SqlDataAccessTests.MockData
{
    public static class RoleData
    {
        public static class RoleAdmin
        {
            public const String Key = "admin";
            public const String Name = "Admin";
        }
        public static class RoleMain
        {
            public const String Key = "main";
            public const String Name = "Main";
        }
        public static class RoleSuper
        {
            public const String Key = "super";
            public const String Name = "Super";
        }
        public static class RoleUnknown
        {
            public const String Key = "unknown";
            public const String Name = "Unknown";
        }
    }
}