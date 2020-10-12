using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using SXDatabase;
using System.Runtime.CompilerServices;

namespace AXApi
{
    public class Program
    {
        private static HostRunner hostRunner;
        public static HostRunner TestHostRunner => hostRunner;

        public static void Main(string[] args)
        {
            hostRunner = new HostRunner(new PXHostBuilder<Startup>());
            
            hostRunner.Run(args);
        }
    }
}
