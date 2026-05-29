namespace SolarSim.Core.Scene;

public readonly record struct Color(byte R, byte G, byte B, byte A = 255)
{
	public static Color Red => new(255, 0, 0);
	public static Color Green => new(0, 255, 0);
	public static Color Blue => new(0, 0, 255);
	public static Color Yellow => new(255, 255, 0);
	public static Color Cyan => new(0, 255, 255);
	public static Color Magenta => new(255, 0, 255);
	public static Color White => new(255, 255, 255);
	public static Color Black => new(0, 0, 0);
	public static Color Gray => new(128, 128, 128);
	public static Color DarkGray => new(192, 192, 192);
	public static Color LightGray => new(128, 128, 128);
	public static Color Clear => new(0, 0, 0, 0);
}
