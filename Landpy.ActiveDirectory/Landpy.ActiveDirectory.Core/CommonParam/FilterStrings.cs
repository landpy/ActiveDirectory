using System;

namespace Landpy.ActiveDirectory.CommonParam
{
    public static class FilterStrings
    {
        public readonly static string UserFilter = String.Format(ExpressionTemplates.IsExpression, AttributeNames.ObjectCategory, AttributeValues.Person);
        public readonly static string ComputerFilter = String.Format(ExpressionTemplates.IsExpression, AttributeNames.ObjectCategory, AttributeValues.Computer);
        public readonly static string ContactFilter = String.Format(ExpressionTemplates.IsExpression, AttributeNames.ObjectCategory, AttributeValues.Contact);
        public readonly static string OrganizationalUnitFilter = String.Format(ExpressionTemplates.IsExpression, AttributeNames.ObjectCategory, AttributeValues.OrganizationalUnit);
    }
}
