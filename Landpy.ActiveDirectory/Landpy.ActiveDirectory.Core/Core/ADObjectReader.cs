using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;

namespace Landpy.ActiveDirectory.Core
{
    /// <summary>
    /// The proxy of directory entry.
    /// </summary>
    public class ADObjectReader : IDisposable
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

        public SearchResult GetSearchResultByFilter(string filter)
        {
            DirectorySearcher directorySearcher = this.GetDirectorySearcher(filter);
            return directorySearcher.FindOne();
        }

        public SearchResultCollection GetSearchResultsByFilter(string filter)
        {
            DirectorySearcher directorySearcher = this.GetDirectorySearcher(filter);
            return directorySearcher.FindAll();
        }

        public void Close()
        {
            if (searchRoot != null)
            {
                searchRoot.Close();
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            this.Close();
        }

        #endregion

        #endregion

        #region Custom Method

        private DirectorySearcher GetDirectorySearcher(string filter)
        {
            return new DirectorySearcher(this.SearchRoot, filter);
        }

        #endregion
    }
}
