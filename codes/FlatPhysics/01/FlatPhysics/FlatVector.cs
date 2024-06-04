using System;

namespace FlatPhysics
{
	public readonly struct FlatVector
	{
		public readonly float X;
		public readonly float Y;
		
		public FlatVector(float x, float y)
		{
			this.X = x;
			this.Y = y;
		}

		public static FlatVector operator + ( FlatVector a, FlatVector b )
		{
			return new FlatVector(a.X+b.X,a.Y+b.Y);

        }
	}
}