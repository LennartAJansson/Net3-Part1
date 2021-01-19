using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using System.Threading.Tasks;

namespace ConsolePropertyInjectionSample
{
    internal interface IService
    {
        ILogger Logger { get; set; }

        IConfiguration Configuration { get; set; }

        Task ExecuteAsync();
    }
}