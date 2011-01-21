using System;
using System.DirectoryServices;

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
            if (this.searchRoot != null)
            {
                this.searchRoot.Close();
            }
        }

        #endregion

    }
}
