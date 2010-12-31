using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;

namespace Landpy.ActiveDirectory
{
    /// <summary>
    /// The proxy of directory entry.
    /// </summary>
    public class ADObjectReader : IADObjectReader
    {
        #region Field And Property

        private OperatorSecurity operatorSecurity;

        private DirectoryEntry searchRoot;

        private DirectoryEntry SearchRoot
        {
            get
            {
                if (searchRoot == null)
                {
                    searchRoot = new DirectoryEntry(
                        this.operatorSecurity.LdapPath,
                        this.operatorSecurity.UserName,
                        this.operatorSecurity.Password);
                }
                return searchRoot;
            }
        }

        #endregion

        #region Public Method

        public ADObjectReader(OperatorSecurity operatorSecurity)
        {
            this.operatorSecurity = operatorSecurity;
        }

        public void Close()
        {
            if (searchRoot != null)
            {
                searchRoot.Close();
            }
        }

        #endregion

        #region Custom Method

        private DirectorySearcher GetDirectorySearcher(string filter)
        {
            return new DirectorySearcher(this.SearchRoot, filter);
        }

        #endregion

        #region IADObjectReader Members

        SearchResult IADObjectReader.ReadSearchResultByFilter(string filter)
        {
            DirectorySearcher directorySearcher = this.GetDirectorySearcher(filter);
            return directorySearcher.FindOne();
        }

        SearchResultCollection IADObjectReader.ReadSearchResultsByFilter(string filter)
        {
            DirectorySearcher directorySearcher = this.GetDirectorySearcher(filter);
            return directorySearcher.FindAll();
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            this.Close();
        }

        #endregion
    }
}
