using System.Collections.Generic;
using System;
using System.DirectoryServices;
using System.Text;
using Landpy.ActiveDirectory.Entity.Object;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Entity.Filter;
using Landpy.ActiveDirectory.CommonParam;

namespace Landpy.ActiveDirectory.Service
{
    public abstract class BaseService<ADObject> where ADObject : BaseADObject
    {
        #region Member Data

        protected OperatorSecurity operatorSecurity;
        protected IFilter filter;

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

        public ADObject FindObjectByCN(string cn)
        {
            filter = new IsFilterDecorator(filter, AttributeNames.CN, cn);
            filter = new AndFilterDecorator(filter);
            return this.FindOne(filter.BuildFilter());
        }

        public ADObject FindObjectByObjectGuid(Guid guid)
        {
            filter = new IsFilterDecorator(filter, AttributeNames.ObjectGUID, ConvertUtility.ConvertGuidToGuidBinaryString(guid));
            filter = new AndFilterDecorator(filter);
            return this.FindOne(filter.BuildFilter());
        }

        public ADObject FindObjectByName(string name)
        {
            filter = new IsFilterDecorator(filter, AttributeNames.Name, name);
            filter = new AndFilterDecorator(filter);
            return this.FindOne(filter.BuildFilter());
        }

        public ICollection<ADObject> FindObjectsByObjectClass(string objectClass)
        {
            filter = new IsFilterDecorator(filter, AttributeNames.ObjectClass, objectClass);
            filter = new AndFilterDecorator(filter);
            return this.FindAll(filter.BuildFilter());
        }

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
        #endregion
    }
}
