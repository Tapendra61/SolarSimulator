using Serilog;
using SolarSim.Core.Logging;

namespace SolarSim.App;

internal static class Program
{
	private static void Main(string[] args)
	{
		LoggerFactory.Configure();
		Log.Information("Starting Sirius Solar Simulator");

		Application app = new();
		app.Run();

		Log.CloseAndFlush();
	}
}
