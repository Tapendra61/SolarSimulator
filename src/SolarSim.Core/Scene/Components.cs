using Silk.NET.Maths;

namespace SolarSim.Core.Scene;

public struct Transform
{
	public Vector2D<double> Position;
	public double Rotation;
}

public struct RigidBody
{
	public Vector2D<double> Velocity;
	public Vector2D<double> Acceleration;
	public Vector2D<double> ForceAccumulator;
	public double Mass;
	public double InverseMass;
	public bool IsTestParticle;
	public bool IsFixed;

	public void SetMass(double mass)
	{
		Mass = mass;
		InverseMass = mass > 0.0 ? 1.0 / mass : 0.0;
	}
}

public struct Renderable
{
	public Color Color;
	public float RadiusPixels;
	public int RenderLayer;
	public bool Visible;
}

public struct Name
{
	public string Value;
}

public struct Tag
{
	public string Value;
}
