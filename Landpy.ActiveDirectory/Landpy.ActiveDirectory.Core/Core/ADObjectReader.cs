using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Object;

namespace Landpy.ActiveDirectory
{
    /// <summary>
    /// The proxy of directory entry.
    /// </summary>
    public class ADObjectReader<ADObject> : IADObjectReader<ADObject>, IDisposable where ADObject : BaseADObject
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

        ICollection<ADObject> IADObjectReader<ADObject>.ReadADObjectsByFilter(IFilter filter)
        {
            ICollection<ADObject> adObjects = new List<ADObject>();
            SearchResultCollection searchResults = this.ReadSearchResultsByFilter(filter.BuildFilter());
            foreach (SearchResult searchResult in searchResults)
            {
                if (searchResult != null)
                {
                    ADObject adObject = Activator.CreateInstance(typeof(ADObject), searchResult, this.operatorSecurity) as ADObject;
                    adObjects.Add(adObject);
                }
            }
            return adObjects;
        }

        ADObject IADObjectReader<ADObject>.ReadADObjectByFilter(IFilter filter)
        {
            ADObject adObject = null;
            SearchResult searchResult = this.ReadSearchResultByFilter(filter.BuildFilter());
            if (searchResult != null)
            {
                adObject = Activator.CreateInstance(typeof(ADObject), searchResult, this.operatorSecurity) as ADObject;
            }
            return adObject;
        }

        #endregion

        #region Custom Method

        private DirectorySearcher GetDirectorySearcher(string filter)
        {
            return new DirectorySearcher(this.SearchRoot, filter);
        }

        private SearchResult ReadSearchResultByFilter(string filter)
        {
            DirectorySearcher directorySearcher = this.GetDirectorySearcher(filter);
            return directorySearcher.FindOne();
        }

        private SearchResultCollection ReadSearchResultsByFilter(string filter)
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
