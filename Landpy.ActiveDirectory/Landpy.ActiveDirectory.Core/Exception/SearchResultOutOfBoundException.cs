using System;
using System.Collections.Generic;
using System.Text;

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
                string message = String.Format("The count of search result({0}) is more than one.", this.searchResultCount);
                return message;
            }
        }
    }
}
