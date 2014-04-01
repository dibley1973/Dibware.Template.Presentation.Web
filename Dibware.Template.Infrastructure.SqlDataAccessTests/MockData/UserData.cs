using System;

namespace Dibware.Template.Infrastructure.SqlDataAccessTests.MockData
{
    internal static class UserData
    {
        internal static class InvalidUser
        {
            public const String Username = "Sponklefield";
            public const String Password = "anaplaster";

        }
        internal static class UserDave
        {
            public static Guid Guid = new Guid();
            public const String Username = "Dave01";
            public const String Name = "Dave";
            public const String AccountConfirmationToken = "EABC#";
            public const String Answer = "Mondeo";
            public const String Email = "dave@anywhere.com";
            public const String Password = "Dave's Password";
            public const String PasswordQuestion = "Whats my pet?";
            public const String PasswordAnswer = "A fluffy little goldfish";
            public const String Token = "yfduisf";
        }
        internal static class UserJane
        {
            public static Guid Guid = new Guid();
            public const String Username = "Jane02";
            public const String Name = "Jane";
            public const String AccountConfirmationToken = "DFDA#";
            public const String Answer = "My little pony";
            public const String Email = "jane@anywhere.com";
            public const String Password = "Jane's Password";
            public const String Token = "ljdfiue";
        }
        internal static class UserPete
        {
            public static Guid Guid = new Guid();
            public const String Username = "Pete03";
            public const String Name = "Pete";
            public const String AccountConfirmationToken = "FEBC#";
            public const String Answer = "Alpha";
            public const String Email = "pete@anywhere.com";
            public const String Password = "Pete's Password";
            public const String PasswordQuestion = "Fav colour?";
            public const String PasswordAnswer = "Red";
            public const String Token = "yeopjdf";
        }
    }
}