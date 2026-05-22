using Serilog;
using System.Globalization;

namespace SolarSim.Core.Logging;

public static class LoggerFactory
{
	public static void Configure()
	{
		Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
			.WriteTo.Console(formatProvider: CultureInfo.InvariantCulture)
			.WriteTo.File(path: "logs/solarsim-.log",
				rollingInterval: RollingInterval.Day,
				formatProvider: CultureInfo.InvariantCulture,
				retainedFileCountLimit: 30)
			.CreateLogger();
	}
}
