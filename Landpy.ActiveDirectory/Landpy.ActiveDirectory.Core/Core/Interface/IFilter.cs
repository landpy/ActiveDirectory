
namespace Landpy.ActiveDirectory.Filter
{
    public interface IFilter
    {
        string BuildFilter();
        void Add(IFilter filter);
        void Remove(IFilter filter);
    }
}
