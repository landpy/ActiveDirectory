using System.Collections.Generic;
using System;
using System.DirectoryServices;
using System.Text;
using Landpy.ActiveDirectory.Entity.Object;

namespace Landpy.ActiveDirectory.Service
{
    public abstract class BaseService<ADObject> where ADObject : BaseADObject
    {
        #region Member Data

        protected OperatorSecurity operatorSecurity;

        #endregion

        #region Constructor Method

        protected BaseService(OperatorSecurity operatorSecurity)
        {
            this.operatorSecurity = operatorSecurity;
        }

        #endregion

        #region Interface Method

        public ICollection<ADObject> FindAll(string filter)
        {
            ICollection<ADObject> adObjects = new List<ADObject>();
            SearchResultCollection searchResults = this.GetSearchResultsByFilter(filter);
            foreach (SearchResult searchResult in searchResults)
            {
                if (searchResult != null)
                {
                    ADObject adObject = Activator.CreateInstance(typeof(ADObject), searchResult) as ADObject;
                    adObjects.Add(adObject);
                }
            }
            return adObjects;
        }

        public ADObject FindOne(string filter)
        {
            ADObject adObject = null;
            SearchResult searchResult = this.GetSearchResultByFilter(filter);
            if (searchResult != null)
            {
                adObject = Activator.CreateInstance(typeof(ADObject), searchResult) as ADObject;
            }
            return adObject;
        }

        public abstract ADObject FindObjectByCN(string cn);

        public abstract ADObject FindObjectByObjectGuid(Guid guid);

        public abstract ICollection<ADObject> FindObjectsByObjectClass(string objectClass);

        public abstract bool Save(ADObject adObject);

        #endregion

        #region Custom Method

        protected SearchResult GetSearchResultByFilter(string filter)
        {
            SearchResult searchResult = null;
            using (IADObjectReader adObjectReader = new ADObjectReader(this.operatorSecurity))
            {
                searchResult = adObjectReader.ReadSearchResultByFilter(filter);
            }
            return searchResult;
        }

        protected SearchResultCollection GetSearchResultsByFilter(string filter)
        {
            SearchResultCollection searchResultCollection = null;
            using (IADObjectReader adObjectReader = new ADObjectReader(this.operatorSecurity))
            {
                searchResultCollection = adObjectReader.ReadSearchResultsByFilter(filter);
            }
            return searchResultCollection;
        }

        protected string GetGUIDBinaryString(Guid guid)
        {
            byte[] guidBytes = guid.ToByteArray();
            StringBuilder guidBinary = new StringBuilder();
            foreach (byte guidByte in guidBytes)
            {
                guidBinary.AppendFormat(@"\{0}", guidByte.ToString("x2"));
            }
            return guidBinary.ToString();
        }

        #endregion
    }
}
