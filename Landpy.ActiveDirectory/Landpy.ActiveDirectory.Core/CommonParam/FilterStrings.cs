using System;
using System.Collections.Generic;
using System.Text;

namespace Landpy.ActiveDirectory.CommonParam
{
    public static class FilterStrings
    {
        public readonly static string UserFilter = String.Format(Expressions.EqualExpression, AttributeNames.ObjectCategory, AttributeValues.Person);
        public readonly static string ComputerFilter = String.Format(Expressions.EqualExpression, AttributeNames.ObjectCategory, AttributeValues.Computer);
        public readonly static string ContactFilter = String.Format(Expressions.EqualExpression, AttributeNames.ObjectCategory, AttributeValues.Contact);
    }
}
