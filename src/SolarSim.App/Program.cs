using System;
using Raylib_cs;
using Serilog;
using SolarSim.Core.Logging;

namespace SolarSim.App;

sealed class Program
{
	private static void Main(string[] args)
	{
		LoggerFactory.Configure();
		Log.Information("Starting Sirius Solar Simulator");

		Raylib.InitWindow(1280, 720, "Sirius Solar Simulator");
		Raylib.SetTargetFPS(144);

		while (!Raylib.WindowShouldClose())
		{
			Raylib.BeginDrawing();
			Raylib.ClearBackground(Color.RayWhite);
			Raylib.DrawText("Sirius Solar Simulator", 300, 100, 24, Color.Gray);

			Raylib.EndDrawing();
		}

		Raylib.CloseWindow();
		Log.CloseAndFlush();
	}
}
