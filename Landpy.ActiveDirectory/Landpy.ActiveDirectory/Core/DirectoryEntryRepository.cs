using System;
using System.DirectoryServices;
using Landpy.ActiveDirectory.Core.Filter;
using Landpy.ActiveDirectory.Entity.Query;

namespace Landpy.ActiveDirectory.Core
{
    class DirectoryEntryRepository : IDisposable
    {
        private DirectoryEntry DirectoryEntry { get; set; }
        private QueryScopeType QueryScopeType { get; set; }

        public DirectoryEntryRepository(IADOperator adOperator)
            : this(adOperator, String.Empty, QueryScopeType.Subtree)
        {
        }

        public DirectoryEntryRepository(IADOperator adOperator, string ldapPath, QueryScopeType queryScopeType)
        {
            var adOperatorInfo = adOperator.GetOperatorInfo();
            string path;
            if (String.IsNullOrEmpty(ldapPath))
            {
                path = String.Format(@"LDAP://{0}", adOperatorInfo.OperateDomainName);
            }
            else
            {
                path = ldapPath;
            }
            if (!String.IsNullOrEmpty(adOperatorInfo.UserLoginName) && !String.IsNullOrEmpty(adOperatorInfo.Password))
            {
                this.DirectoryEntry = new DirectoryEntry(path, adOperatorInfo.UserLoginName, adOperatorInfo.Password);
            }
            else
            {
                this.DirectoryEntry = new DirectoryEntry(path);
            }
            this.QueryScopeType = queryScopeType;
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
                if (this.QueryScopeType == QueryScopeType.OneLevel)
                {
                    directorySearcher.SearchScope = SearchScope.OneLevel;
                }
                else if (this.QueryScopeType == QueryScopeType.Subtree)
                {
                    directorySearcher.SearchScope = SearchScope.Subtree;
                }
                directorySearcher.PageSize = Int32.MaxValue;
                directorySearcher.SizeLimit = Int32.MaxValue;
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
                if (this.QueryScopeType == QueryScopeType.OneLevel)
                {
                    directorySearcher.SearchScope = SearchScope.OneLevel;
                }
                else if (this.QueryScopeType == QueryScopeType.Subtree)
                {
                    directorySearcher.SearchScope = SearchScope.Subtree;
                }
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
