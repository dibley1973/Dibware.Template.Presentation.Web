using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dibware.Template.Infrastructure.SqlDataAccessTests.MockData
{
    public static class PasswordStrengthRuleData
    {
        public static class Rule1
        {
            public const Int32 Id = 1;
            public const String RegularExpression = @"(?=^.{8,25}$)";
            public const String Description = "Password length range from 8 to 25";
            public const String Notes = "The numbers are adjustable";
        }
        public static class Rule2
        {
            public const Int32 Id = 2;
            public const String RegularExpression = @"(?=(?:.*?[!@#$%*()_+^&}{:;?.]){1})";
            public const String Description = "At least 1 special characters (!@#$%*()_+^&}{:;?.})";
            public const String Notes = "This number is adjustable";
        }
        public static class Rule3
        {
            public const Int32 Id = 3;
            public const String RegularExpression = @"(?=(?:.*?\d){2})";
            public const String Description = "At least 2 digits";
            public const String Notes = "This number is adjustable";
        }
        public static class Rule4
        {
            public const Int32 Id = 4;
            public const String RegularExpression = @"(?=.*[a-z])";
            public const String Description = "'Characters a-z";
            public const String Notes = "";
        }
        public static class Rule5
        {
            public const Int32 Id = 5;
            public const String RegularExpression = @"(?=(?:.*?[A-Z]){2})";
            public const String Description = "At least 2 upper case characters";
            public const String Notes = "This number is adjustable";
        }
    }
}
