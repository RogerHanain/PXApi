using Microsoft.Extensions.Configuration;
using SXDatabase;

namespace AXApi
{
    // Si j'utilise directement StartupAPI ca ne fonctionne pas
    // j'imagine à cause du fait que l'injection de dépendance se fasse uniquement au sein d'un projet
    // à creuser
    public class Startup : StartupAPI
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
