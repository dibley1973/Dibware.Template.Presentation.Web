using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dibware.Template.Infrastructure.SqlDataAccessTests.MockData
{
    public static class ErrorData
    {
        public static class NullReferenceError
        {
            public const String Message = "Null Reference Error";
            public const String Source = "MyDll";
            public const String StackTrace = "Ctor.MyDll";
        }
        public static class InvalidOperationError
        {
            public const String Message = "Invalid Opertaion Error";
            public const String Source = "MyOtherDll";
            public const String StackTrace = "Ctor.MyOtherDll";
        }
    }
}