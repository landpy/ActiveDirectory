using System;
using System.DirectoryServices;
using Landpy.ActiveDirectory.Entity.Attribute;

namespace Landpy.ActiveDirectory
{
    public class ADObjectWriter : IADObjectWriter
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

        public ADObjectWriter(OperatorSecurity operatorSecurity)
        {
            this.operatorSecurity = operatorSecurity;
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IADObjectWriter Members

        bool IADObjectWriter.WriteSearchResult(SearchResult searchResult, string name, string schemaClassName, AttributeSet attributeSet)
        {
            bool isSuccessful = false;
            using (DirectoryEntry directoryEntry = searchResult.GetDirectoryEntry())
            {
                using (DirectoryEntry newDirectoryEntry = directoryEntry.Children.Add(name, schemaClassName))
                {
                    foreach (BaseAttribute attribute in attributeSet)
                    {
                        if (attribute is SingleLineAttribute)
                        {
                            newDirectoryEntry.Properties[attribute.Name].Value = attribute.Value;
                        }
                    }
                    newDirectoryEntry.CommitChanges();
                }
            }
            return isSuccessful;
        }

        #endregion
    }
}
