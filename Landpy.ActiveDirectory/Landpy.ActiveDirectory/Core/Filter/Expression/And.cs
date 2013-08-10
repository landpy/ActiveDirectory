using System;

namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    public class And : Decorator
    {
        public And(params IFilter[] filters)
            : base(filters)
        {
        }

        protected override string BuildExpresion(string childrenFilterString)
        {
            return String.Format(ExpressionTemplates.And, childrenFilterString);
        }
    }
}
