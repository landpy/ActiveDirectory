using System;

namespace Landpy.ActiveDirectory.Exception
{
    public class SearchResultOutOfBoundException : System.Exception
    {
        private int searchResultCount;

        public SearchResultOutOfBoundException(System.Exception innerException, int searchResultCount)
            : base(String.Empty, innerException)
        {
            this.searchResultCount = searchResultCount;
        }

        public override string Message
        {
            get
            {
                return String.Format("The count of search result({0}) is more than one.", this.searchResultCount);
            }
        }
    }
}
