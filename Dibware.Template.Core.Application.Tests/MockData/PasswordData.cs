using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dibware.Template.Core.Application.Tests.MockData
{
    public static class PasswordData
    {
        public static class InitialData
        {
            public static readonly char[] DELIMITER = { ':' };
            public const Int32 PBKDF2_INDEX = 2;
            public const Int32 HashByteSize = 24;
            public const Int32 SaltByteSize = 24;
            public const Int32 Pbkdf2Iterations = 1000;
            public const Int32 ConfirmationTokenLength = 64;
            public const Int32 MinRequiredPasswordLength = 8;
            public const Int32 MinRequiredNonAlphanumericCharacters = 1;
            public const String PasswordStrengthRegularExpression = @"(?=^.{8,25}$)(?=(?:.*?\d){2})(?=.*[a-z])(?=(?:.*?[A-Z]){2})(?=(?:.*?[!@#$%*()_+^&}{:;?.]){1})(?!.*\s)[0-9a-zA-Z!@#$%*()_+^&]*$";
            // REf: http://www.codeproject.com/Tips/141802/ASP-NET-Password-Strength-Regular-Expression
        }

        public static class TestData
        {
            public const String ValidPassword = "E!ghtyS3vEN";
        }
    }
}
