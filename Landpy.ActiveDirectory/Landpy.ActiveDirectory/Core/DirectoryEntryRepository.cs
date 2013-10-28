using System;
using System.DirectoryServices;
using Landpy.ActiveDirectory.Core.Filter;

namespace Landpy.ActiveDirectory.Core
{
    class DirectoryEntryRepository : IDisposable
    {
        private DirectoryEntry DirectoryEntry { get; set; }

        public DirectoryEntryRepository(IADOperator adOperator)
        {
            var adOperatorInfo = adOperator.GetOperatorInfo();
            string path = String.Format(@"LDAP://{0}", adOperatorInfo.OperateDomainName);
            if (!String.IsNullOrEmpty(adOperatorInfo.UserLoginName) && !String.IsNullOrEmpty(adOperatorInfo.Password))
            {
                this.DirectoryEntry = new DirectoryEntry(path, adOperatorInfo.UserLoginName, adOperatorInfo.Password);
            }
            else
            {
                this.DirectoryEntry = new DirectoryEntry(path);
            }
        }

        public DirectoryEntryRepository(DirectoryEntry directoryEntry)
        {
            this.DirectoryEntry = directoryEntry;
        }

        public SearchResultCollection GetSearchResultCollection(IFilter filter, string[] propertiesToLoad)
        {
            SearchResultCollection searchResultCollection;
            DirectorySearcher directorySearcher = null;
            if (propertiesToLoad == null)
            {
                directorySearcher = new DirectorySearcher(this.DirectoryEntry, filter.BuildFilter());
            }
            else
            {
                directorySearcher = new DirectorySearcher(this.DirectoryEntry, filter.BuildFilter(), propertiesToLoad);
            }
            using (directorySearcher)
            {
                searchResultCollection = directorySearcher.FindAll();
            }
            return searchResultCollection;
        }

        public SearchResultCollection GetSearchResultCollection(IFilter filter)
        {
            return this.GetSearchResultCollection(filter, null);
        }

        public SearchResult GetSearchResult(IFilter filter, string[] propertiesToLoad)
        {
            SearchResult searchResult;
            DirectorySearcher directorySearcher = null;
            if (propertiesToLoad == null)
            {
                directorySearcher = new DirectorySearcher(this.DirectoryEntry, filter.BuildFilter());
            }
            else
            {
                directorySearcher = new DirectorySearcher(this.DirectoryEntry, filter.BuildFilter(), propertiesToLoad);
            }
            using (directorySearcher)
            {
                searchResult = directorySearcher.FindOne();
            }
            return searchResult;
        }

        public SearchResult GetSearchResult(IFilter filter)
        {
            return this.GetSearchResult(filter, null);
        }

        public void Dispose()
        {
            if (this.DirectoryEntry != null)
            {
                this.DirectoryEntry.Close();
            }
        }
    }
}
