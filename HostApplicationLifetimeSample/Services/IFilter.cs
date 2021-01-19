using System.Threading.Tasks;

namespace HostApplicationLifetimeSample.Services
{
    public interface IFilter
    {
        Task SelectAsync();
    }
}