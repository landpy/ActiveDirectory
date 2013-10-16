using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.Entity.TypeAdapter;

namespace Landpy.ActiveDirectory.Entity.Object
{
    /// <summary>
    /// The person AD object.
    /// </summary>
    public abstract class PersonObject : ADObject
    {
        private byte[] thumbnailPhoto;
        private byte[] thumbnailLogo;
        private string email;
        private string co;
        private string c;
        private string company;
        private int countryCode;
        private string department;
        private string fax;
        private IList<string> otherFaxes;
        private string givenName;
        private string homePhone;
        private IList<string> otherHomePhones;
        private string notes;
        private string initials;
        private string ipPhone;
        private IList<string> otherIpPhones;
        private string city;
        private string manager;
        private IList<string> memberOf;
        private string mobile;
        private IList<string> otherMobiles;
        private string pager;
        private IList<string> otherPagers;
        private string telephone;
        private IList<string> otherTelephones;
        private string lastName;
        private string stateOrProvince;
        private string streetAddress;
        private string jobTitle;
        private UserObject userObject;

        /// <summary>
        /// The thumbnailPhoto.
        /// </summary>
        public byte[] ThumbnailPhoto
        {
            get
            {
                if (this.thumbnailPhoto == null)
                {
                    this.thumbnailPhoto =
                        new ByteArrayAdapter(this.SearchResult.Properties[PersonAttributeNames.ThumbnailPhoto]).Value;
                }
                return this.thumbnailPhoto;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.ThumbnailPhoto].Value = value;
                this.thumbnailPhoto = value;
            }
        }

        /// <summary>
        /// The thumbnailLogo.
        /// </summary>
        public byte[] ThumbnailLogo
        {
            get
            {
                if (this.thumbnailLogo == null)
                {
                    this.thumbnailLogo =
                        new ByteArrayAdapter(this.SearchResult.Properties[PersonAttributeNames.ThumbnailLogo]).Value;
                }
                return this.thumbnailLogo;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.ThumbnailLogo].Value = value;
                this.thumbnailLogo = value;
            }
        }

        /// <summary>
        /// The email.
        /// </summary>
        public string Email
        {
            get
            {
                if (String.IsNullOrEmpty(this.email))
                {
                    this.email = new SingleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.Mail]).Value;
                }
                return this.email;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.Mail].Value = value;
                this.email = value;
            }
        }

        /// <summary>
        /// The country or region.
        /// </summary>
        public string CO
        {
            get
            {
                if (String.IsNullOrEmpty(this.co))
                {
                    this.co = new SingleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.CO]).Value;
                }
                return this.co;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.CO].Value = value;
                this.co = value;
            }
        }

        /// <summary>
        /// The country or region abbreviation (eg: CN).
        /// </summary>
        public string C
        {
            get
            {
                if (String.IsNullOrEmpty(this.c))
                {
                    this.c = new SingleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.C]).Value;
                }
                return this.c;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.C].Value = value;
                this.c = value;
            }
        }

        /// <summary>
        /// The company.
        /// </summary>
        public string Company
        {
            get
            {
                if (String.IsNullOrEmpty(this.company))
                {
                    this.company = new SingleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.Company]).Value;
                }
                return this.company;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.Company].Value = value;
                this.company = value;
            }
        }

        /// <summary>
        /// The country code;
        /// </summary>
        public int CountryCode
        {
            get
            {
                if (this.countryCode != -1)
                {
                    this.countryCode = new IntegerAdapter(this.SearchResult.Properties[PersonAttributeNames.CountryCode]).Value;
                }
                return this.countryCode;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.CountryCode].Value = value;
                this.countryCode = value;
            }
        }

        /// <summary>
        /// The department.
        /// </summary>
        public string Department
        {
            get
            {
                if (String.IsNullOrEmpty(this.department))
                {
                    this.department =
                        new SingleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.Department]).Value;
                }
                return this.department;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.Department].Value = value;
                this.department = value;
            }
        }

        /// <summary>
        /// The fax number.
        /// </summary>
        public string Fax
        {
            get
            {
                if (String.IsNullOrEmpty(this.fax))
                {
                    this.fax = new SingleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.FacsimileTelephoneNumber]).Value;
                }
                return this.fax;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.FacsimileTelephoneNumber].Value = value;
                this.fax = value;
            }
        }

        /// <summary>
        /// Other fax numbers.
        /// </summary>
        public IList<string> OtherFaxes
        {
            get
            {
                if (this.otherFaxes == null)
                {
                    this.otherFaxes = new MultipleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.OtherFacsimileTelephoneNumber]).Value;
                }
                return this.otherFaxes;
            }
            set
            {
                SetAttributeValue(PersonAttributeNames.OtherFacsimileTelephoneNumber, value);
                this.otherFaxes = value;
            }
        }

        /// <summary>
        /// The given name.
        /// </summary>
        public string GivenName
        {
            get
            {
                if (String.IsNullOrEmpty(this.givenName))
                {
                    this.givenName = new SingleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.GivenName]).Value;
                }
                return this.givenName;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.GivenName].Value = value;
                this.givenName = value;
            }
        }

        /// <summary>
        /// The home phone number.
        /// </summary>
        public string HomePhone
        {
            get
            {
                if (String.IsNullOrEmpty(this.homePhone))
                {
                    this.homePhone = new SingleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.HomePhone]).Value;
                }
                return this.homePhone;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.HomePhone].Value = value;
                this.homePhone = value;
            }
        }

        /// <summary>
        /// The other home phone numbers.
        /// </summary>
        public IList<string> OtherHomePhones
        {
            get
            {
                if (this.otherHomePhones == null)
                {
                    this.otherHomePhones = new MultipleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.OtherHomePhone]).Value;
                }
                return this.otherHomePhones;
            }
            set
            {
                SetAttributeValue(PersonAttributeNames.OtherHomePhone, value);
                this.otherHomePhones = value;
            }
        }

        /// <summary>
        /// The notes.
        /// </summary>
        public string Notes
        {
            get
            {
                if (String.IsNullOrEmpty(this.notes))
                {
                    this.notes = new SingleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.Info]).Value;
                }
                return this.notes;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.Info].Value = value;
                this.notes = value;
            }
        }

        /// <summary>
        /// The initals.
        /// </summary>
        public string Initials
        {
            get
            {
                if (String.IsNullOrEmpty(this.initials))
                {
                    this.initials = new SingleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.Initials]).Value;
                }
                return this.initials;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.Initials].Value = value;
                this.initials = value;
            }
        }

        /// <summary>
        /// The IP phone number.
        /// </summary>
        public string IpPhone
        {
            get
            {
                if (String.IsNullOrEmpty(this.ipPhone))
                {
                    this.ipPhone = new SingleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.IpPhone]).Value;
                }
                return this.ipPhone;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.IpPhone].Value = value;
                this.ipPhone = value;
            }
        }

        /// <summary>
        /// The other IP phone numbers.
        /// </summary>
        public IList<string> OtherIpPhones
        {
            get
            {
                if (this.otherIpPhones == null)
                {
                    this.otherIpPhones = new MultipleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.OtherIpPhone]).Value;
                }
                return this.otherIpPhones;
            }
            set
            {
                SetAttributeValue(PersonAttributeNames.OtherIpPhone, value);
                this.otherIpPhones = value;
            }
        }

        /// <summary>
        /// The city.
        /// </summary>
        public string City
        {
            get
            {
                if (String.IsNullOrEmpty(this.city))
                {
                    this.city = new SingleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.L]).Value;
                }
                return this.city;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.L].Value = value;
                this.city = value;
            }
        }

        /// <summary>
        /// The manager.
        /// </summary>
        public string Manager
        {
            get
            {
                if (String.IsNullOrEmpty(this.manager))
                {
                    this.manager = new SingleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.Manager]).Value;
                }
                return this.manager;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.Manager].Value = value;
                this.manager = value;
            }
        }

        /// <summary>
        /// The manager user object.
        /// </summary>
        public UserObject ManagerUser
        {
            get
            {
                if (this.userObject == null)
                {
                    this.userObject = FindOneByDN(this.ADOperator, this.Manager) as UserObject;
                }
                return this.userObject;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.Manager].Value = value.Manager;
                this.userObject = value;
            }
        }

        /// <summary>
        /// The member of groups.
        /// </summary>
        public IList<string> MemberOf
        {
            get
            {
                if (this.memberOf == null)
                {
                    this.memberOf = new MultipleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.MemberOf]).Value;
                }
                return this.memberOf;
            }
            set
            {
                SetAttributeValue(PersonAttributeNames.MemberOf, value);
                this.memberOf = value;
            }
        }

        /// <summary>
        /// The mobile number.
        /// </summary>
        public string Mobile
        {
            get
            {
                if (String.IsNullOrEmpty(this.mobile))
                {
                    this.mobile = new SingleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.Mobile]).Value;
                }
                return this.mobile;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.Mobile].Value = value;
                this.mobile = value;
            }
        }

        /// <summary>
        /// Other mobile numbers.
        /// </summary>
        public IList<string> OtherMobiles
        {
            get
            {
                if (this.otherMobiles == null)
                {
                    this.otherMobiles = new MultipleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.OtherMobile]).Value;
                }
                return this.otherMobiles;
            }
            set
            {
                SetAttributeValue(PersonAttributeNames.OtherMobile, value);
                this.otherMobiles = value;
            }
        }

        /// <summary>
        /// The pager number.
        /// </summary>
        public string Pager
        {
            get
            {
                if (String.IsNullOrEmpty(this.pager))
                {
                    this.pager = new SingleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.Pager]).Value;
                }
                return this.pager;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.Pager].Value = value;
                this.pager = value;
            }
        }

        /// <summary>
        /// The other pager numbers.
        /// </summary>
        public IList<string> OtherPagers
        {
            get
            {
                if (this.otherPagers == null)
                {
                    this.otherPagers = new MultipleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.OtherPager]).Value;
                }
                return this.otherPagers;
            }
            set
            {
                SetAttributeValue(PersonAttributeNames.OtherPager, value);
                this.otherPagers = value;
            }
        }

        /// <summary>
        /// The telephone number.
        /// </summary>
        public string Telephone
        {
            get
            {
                if (String.IsNullOrEmpty(this.telephone))
                {
                    this.telephone = new SingleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.TelephoneNumber]).Value;
                }
                return this.telephone;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.TelephoneNumber].Value = value;
                this.telephone = value;
            }
        }

        /// <summary>
        /// The other telephone numbers.
        /// </summary>
        public IList<string> OtherTelephones
        {
            get
            {
                if (this.otherTelephones == null)
                {
                    this.otherTelephones = new MultipleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.OtherTelephone]).Value;
                }
                return this.otherTelephones;
            }
            set
            {
                SetAttributeValue(PersonAttributeNames.OtherTelephone, value);
                this.otherTelephones = value;
            }
        }

        /// <summary>
        /// The last name.
        /// </summary>
        public string LastName
        {
            get
            {
                if (String.IsNullOrEmpty(this.lastName))
                {
                    this.lastName = new SingleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.SN]).Value;
                }
                return this.lastName;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.SN].Value = value;
                this.lastName = value;
            }
        }

        /// <summary>
        /// The state / province.
        /// </summary>
        public string StateOrProvince
        {
            get
            {
                if (String.IsNullOrEmpty(this.stateOrProvince))
                {
                    this.stateOrProvince = new SingleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.ST]).Value;
                }
                return this.stateOrProvince;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.ST].Value = value;
                this.stateOrProvince = value;
            }
        }

        /// <summary>
        /// The address of street.
        /// </summary>
        public string StreetAddress
        {
            get
            {
                if (String.IsNullOrEmpty(this.streetAddress))
                {
                    this.streetAddress = new SingleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.StreetAddress]).Value;
                }
                return this.streetAddress;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.StreetAddress].Value = value;
                this.streetAddress = value;
            }
        }

        /// <summary>
        /// The job title.
        /// </summary>
        public string JobTitle
        {
            get
            {
                if (String.IsNullOrEmpty(this.jobTitle))
                {
                    this.jobTitle = new SingleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.Title]).Value;
                }
                return this.jobTitle;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.Title].Value = value;
                this.jobTitle = value;
            }
        }

        /// <summary>
        /// The constructor with AD operator and SearchResult params.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="searchResult"></param>
        protected PersonObject(IADOperator adOperator, SearchResult searchResult)
            : base(adOperator, searchResult)
        {
        }
    }
}
