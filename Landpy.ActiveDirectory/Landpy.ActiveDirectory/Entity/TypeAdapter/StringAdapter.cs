using System.DirectoryServices;

namespace Landpy.ActiveDirectory.Entity.TypeAdapter
{
    abstract class StringAdapter : IString
    {
        public string Value { get; protected set; }

        protected ResultPropertyValueCollection ResultPropertyValueCollection { get; private set; }
        protected SearchResult SearchResult { get; private set; }
        protected string PropertyName { get; private set; }

        protected StringAdapter(ResultPropertyValueCollection resultPropertyValueCollection)
        {
            this.ResultPropertyValueCollection = resultPropertyValueCollection;
        }

        protected StringAdapter(SearchResult searchResult, string propertyName)
        {
            this.SearchResult = searchResult;
            this.PropertyName = propertyName;
        }
    }
}
