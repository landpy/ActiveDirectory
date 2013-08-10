using System;

namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    public class Or : Decorator
    {
        public Or(params IFilter[] filters)
            : base(filters)
        {
        }

        protected override string BuildExpresion(string childrenFilterString)
        {
            return String.Format(ExpressionTemplates.Or, childrenFilterString);
        }
    }
}
