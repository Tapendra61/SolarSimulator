using Arch.Core;
using Arch.Core.Extensions;
using Silk.NET.Maths;
using SolarSim.Core.Scene;
using Xunit;

namespace SolarSim.Core.Tests.Scene;

public class SceneTests
{

	[Fact]
	public void NewSceneHasNoEntities()
	{
		using Core.Scene.Scene scene = new();
		QueryDescription query = new QueryDescription().WithAll<Transform>();
		Assert.Equal(0, scene.World.CountEntities(in query));
	}

	[Fact]
	public void CreateEntityIsQueryableAndReadable()
	{
		using Core.Scene.Scene scene = new();

		Entity body = scene.World.Create(
			new Transform { Position = new Vector2D<double>(1, 0)},
			new RigidBody { Velocity = new Vector2D<double>(3, 0)},
			new Name { Value = "Drifter" }
			);

		QueryDescription query = new QueryDescription().WithAll<Transform, RigidBody>();
		Assert.Equal(1, scene.World.CountEntities(in query));
		Assert.Equal("Drifter", body.Get<Name>().Value);
	}
}
