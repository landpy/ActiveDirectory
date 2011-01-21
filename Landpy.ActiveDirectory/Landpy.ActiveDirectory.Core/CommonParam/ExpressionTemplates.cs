
namespace Landpy.ActiveDirectory.CommonParam
{
    public static class ExpressionTemplates
    {
        /// <summary>
        /// ({0}={1}*)
        /// </summary>
        public readonly static string StartWithExpression = "({0}={1}*)";
        /// <summary>
        /// ({0}=*{1})
        /// </summary>
        public readonly static string EndWithExpression = "({0}=*{1})";
        /// <summary>
        /// ({0}=*)
        /// </summary>
        public readonly static string HasAValueExpression = "({0}=*)";
        /// <summary>
        /// (!{0}=*)
        /// </summary>
        public readonly static string HasNoValueExpression = "(!{0}=*)";
        /// <summary>
        /// ({0}={1})
        /// </summary>
        public readonly static string IsExpression = "({0}={1})";
        /// <summary>
        /// (!{0}={1})
        /// </summary>
        public readonly static string IsNotExpression = "(!{0}={1})";
        /// <summary>
        /// (&amp;{0})
        /// </summary>
        public readonly static string And = "(&{0})";
        /// <summary>
        /// (|{0})
        /// </summary>
        public readonly static string Or = "(|{0})";
        /// <summary>
        /// ({0})
        /// </summary>
        public readonly static string Parenthesis = "({0})";
        /// <summary>
        /// "{0}{1}"
        /// </summary>
        public readonly static string Join = "{0}{1}";
    }
}
