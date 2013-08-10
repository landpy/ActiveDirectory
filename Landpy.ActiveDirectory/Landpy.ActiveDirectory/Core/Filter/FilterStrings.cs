using System;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.Entity.Attribute.Value;

namespace Landpy.ActiveDirectory.Core.Filter
{
    static class FilterStrings
    {
        public readonly static string UserFilter = String.Format(ExpressionTemplates.IsExpression, AttributeNames.ObjectClass, UserAttributeValues.User);
        public readonly static string ContactFilter = String.Format(ExpressionTemplates.IsExpression, AttributeNames.ObjectClass, ContactAttributeValues.Contact);
        public readonly static string PersonFilter = String.Format(ExpressionTemplates.IsExpression, AttributeNames.ObjectClass, PersonAttributeValues.Person);
        public readonly static string ComputerFilter = String.Format(ExpressionTemplates.IsExpression, AttributeNames.ObjectClass, ComputerAttributeValues.Computer);
        public readonly static string OrganizationalUnitFilter = String.Format(ExpressionTemplates.IsExpression, AttributeNames.ObjectClass, OrganizationalUnitAttributeValues.OrganizationalUnit);
        public readonly static string ContainerFilter = String.Format(ExpressionTemplates.IsExpression, AttributeNames.ObjectClass, ContainerAttributeValues.Container);
        public readonly static string GroupFilter = String.Format(ExpressionTemplates.IsExpression, AttributeNames.ObjectClass, GroupAttributeValues.Group);
        public readonly static string DomainFilter = String.Format(ExpressionTemplates.IsExpression, AttributeNames.ObjectClass, DomainAttributeValues.DomainDNS);
        public readonly static string PasswordSettingsFilter = String.Format(ExpressionTemplates.IsExpression, AttributeNames.ObjectClass, PasswordSettingsAttributeValues.MsDs_PasswordSettings);
    }
}
