using System.Diagnostics;
using Raylib_cs;

namespace SolarSim.App;

internal readonly struct AppConfig(int width, int height, string windowTitle, int fps, int physicsFrames)
{
	public readonly int Width = width;
	public readonly int Height = height;
	public readonly string WindowTitle = windowTitle;
	public readonly int Fps = fps;
	public readonly int PhysicsFrames = physicsFrames;

	public AppConfig() : this(1280, 720, "Sirius Solar Simulator", 144, 60) { }
}

internal sealed class Application
{
	private readonly AppConfig _appConfig;

	// Physics Step attributes
	private readonly double _simulationStep;
	private const double _maxFrameTime = 0.25;

	internal bool IsRunning { get; private set; }
	internal AppConfig AppConfig => _appConfig;
	internal double TimeScale { get; set; } = 1.0;

	public Application() : this(new AppConfig()) { }

	private Application(AppConfig appConfig)
	{
		_appConfig = appConfig;
		_simulationStep = 1.0 / appConfig.PhysicsFrames;
	}

	public void Run()
	{
		IsRunning = true;
		Raylib.InitWindow(_appConfig.Width, _appConfig.Height, _appConfig.WindowTitle);
		Raylib.SetTargetFPS(_appConfig.Fps);

		double accumulator = 0.0;

		Stopwatch stopwatch = Stopwatch.StartNew();
		double lastTime = stopwatch.Elapsed.TotalSeconds;

		while (IsRunning)
		{
			if (Raylib.WindowShouldClose())
			{
				IsRunning = false;
				break;
			}

			// Calculate real clock frame time and accumulator
			double currentTime = stopwatch.Elapsed.TotalSeconds;
			double frameTime = currentTime - lastTime;
			lastTime = currentTime;

			if (frameTime > _maxFrameTime) frameTime = _maxFrameTime;
			accumulator += frameTime * TimeScale;

			while (accumulator >= _simulationStep)
			{
				// TODO: Physics Tick
				accumulator -= _simulationStep;
			}

			double alpha = accumulator / _simulationStep;

			Raylib.BeginDrawing();
			Raylib.ClearBackground(Color.White);

			// TODO: renderer.draw(scene, alpha)

			Raylib.EndDrawing();
		}

		ShutDown();
	}

	private static void ShutDown()
	{
		Raylib.CloseWindow();
	}

}
