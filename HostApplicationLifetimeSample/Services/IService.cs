using System.Threading.Tasks;

namespace HostApplicationLifetimeSample.Services
{
    public interface IService
    {
        Task RunServiceAsync();
    }
}