using System;
using System.DirectoryServices;

namespace Landpy.ActiveDirectory.Core
{
    class ObjectGUIDDirectoryEntryRepository : IDisposable
    {
        private DirectoryEntry DirectoryEntry { get; set; }

        public bool Exists { get; private set; }

        public ObjectGUIDDirectoryEntryRepository(IADOperator adOperator, Guid objectGuid)
        {
            var adOperatorInfo = adOperator.GetOperatorInfo();
            string path = String.Format(@"LDAP://{0}/<GUID={1}>", adOperatorInfo.OperateDomainName, objectGuid);
            try
            {
                if (!String.IsNullOrEmpty(adOperatorInfo.UserLoginName) && !String.IsNullOrEmpty(adOperatorInfo.Password))
                {
                    this.DirectoryEntry = new DirectoryEntry(path, adOperatorInfo.UserLoginName, adOperatorInfo.Password);
                }
                else
                {
                    this.DirectoryEntry = new DirectoryEntry(path);
                }
                var directoryEntryId = this.DirectoryEntry.Guid;
                this.Exists = true;
            }
            catch
            {
                this.Exists = false;
            }
        }

        public SearchResult GetSearchResult()
        {
            SearchResult searchResult = null;
            if (this.Exists)
            {
                using (var directorySearcher = new DirectorySearcher(this.DirectoryEntry))
                {
                    searchResult = directorySearcher.FindOne();
                }
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
