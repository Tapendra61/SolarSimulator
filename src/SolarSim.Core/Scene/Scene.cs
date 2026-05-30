using System;
using Arch.Core;

namespace SolarSim.Core.Scene;

public sealed class Scene : IDisposable
{
	public World World { get; } = World.Create();

	public void Dispose()
	{
		World.Destroy(World);
	}
}
