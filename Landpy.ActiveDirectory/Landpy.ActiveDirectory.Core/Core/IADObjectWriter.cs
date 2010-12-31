using System.DirectoryServices;
using Landpy.ActiveDirectory.Entity.Attribute;
using System;

namespace Landpy.ActiveDirectory
{
    interface IADObjectWriter : IDisposable
    {
        bool WriteSearchResult(SearchResult searchResult, string name, string schemaClassName, AttributeSet attributeSet);
    }
}
