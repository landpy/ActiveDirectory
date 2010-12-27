using System;
using System.Collections.Generic;
using System.Text;

namespace Landpy.ActiveDirectory.CommonParam
{
    public static class Expressions
    {
        public readonly static string EqualExpression = "{0}={1}";
        public readonly static string StartWithExpression = "{0}={1}*";
        public readonly static string EndWithExpression = "{0}=*{1}";
        public readonly static string HasAValueExpression = "{0}=*";
        public readonly static string HasNoValueExpression = "!{0}=*";
        public readonly static string IsExpression = "{0}={1}";
        public readonly static string IsNotExpression = "!{0}={1}";
    }
}
