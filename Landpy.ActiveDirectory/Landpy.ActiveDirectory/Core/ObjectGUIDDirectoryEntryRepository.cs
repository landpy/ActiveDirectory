using System;
using System.DirectoryServices;

namespace Landpy.ActiveDirectory.Core
{
    class ObjectGUIDDirectoryEntryRepository : IDisposable
    {
        private DirectoryEntry DirectoryEntry { get; set; }

        public ObjectGUIDDirectoryEntryRepository(IADOperator adOperator, Guid objectGuid)
        {
            var adOperatorInfo = adOperator.GetOperatorInfo();
            this.DirectoryEntry = new DirectoryEntry(String.Format(@"LDAP://<GUID={0}>", objectGuid), adOperatorInfo.UserLoginName, adOperatorInfo.Password);
        }

        public SearchResult GetSearchResult()
        {
            SearchResult searchResult;
            using (var directorySearcher = new DirectorySearcher(this.DirectoryEntry))
            {
                searchResult = directorySearcher.FindOne();
            }
            return searchResult;
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
