using Microsoft.Extensions.Configuration;
using SXDatabase;

namespace AXApi
{
    // Si j'utilise directement StartupAPI ca ne fonctionne pas
    // j'imagine � cause du fait que l'injection de d�pendance se fasse uniquement au sein d'un projet
    // � creuser
    public class Startup : StartupAPI
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
