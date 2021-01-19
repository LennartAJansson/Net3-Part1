using System.Threading.Tasks;

namespace CronSample
{
    public interface IWorker
    {
        Task RunAsync();
    }
}