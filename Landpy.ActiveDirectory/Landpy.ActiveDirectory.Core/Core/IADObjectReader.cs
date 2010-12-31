using System;
using System.DirectoryServices;

namespace Landpy.ActiveDirectory
{
    public interface IADObjectReader : IDisposable
    {
        SearchResult ReadSearchResultByFilter(string filter);
        SearchResultCollection ReadSearchResultsByFilter(string filter);
    }
}
