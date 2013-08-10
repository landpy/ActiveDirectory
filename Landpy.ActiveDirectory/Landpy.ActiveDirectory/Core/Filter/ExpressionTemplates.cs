namespace Landpy.ActiveDirectory.Core.Filter
{
    /// <summary>
    /// The templates of expression.
    /// </summary>
    class ExpressionTemplates
    {
        /// <summary>
        /// The start with expression. eg: "({0}={1}*)".
        /// </summary>
        public readonly static string StartWithExpression = "({0}={1}*)";

        /// <summary>
        /// The end with expression. eg: "({0}=*{1})".
        /// </summary>
        public readonly static string EndWithExpression = "({0}=*{1})";

        /// <summary>
        /// The has a value expression. eg: "({0}=*)".
        /// </summary>
        public readonly static string HasAValueExpression = "({0}=*)";

        /// <summary>
        /// The has no value expression. eg: "(!{0}=*)".
        /// </summary>
        public readonly static string HasNoValueExpression = "(!{0}=*)";

        /// <summary>
        /// The is expression. eg: "({0}={1})".
        /// </summary>
        public readonly static string IsExpression = "({0}={1})";

        /// <summary>
        /// The is not expression. eg: "(!{0}={1})".
        /// </summary>
        public readonly static string IsNotExpression = "(!{0}={1})";

        /// <summary>
        /// The and expression. eg: "(&amp;{0})".
        /// </summary>
        public readonly static string And = "(&{0})";
        /// <summary>
        /// The or expression. eg: "(|{0})".
        /// </summary>
        public readonly static string Or = "(|{0})";

        /// <summary>
        /// The parenthesis expression. eg: "({0})".
        /// </summary>
        public readonly static string Parenthesis = "({0})";

        /// <summary>
        /// The join expression. eg: "{0}{1}".
        /// </summary>
        public readonly static string Join = "{0}{1}";
    }
}
