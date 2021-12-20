using System;

namespace VectorGraphicEditor
{
	[Serializable]
	class Point
	{
		public Point()
		{
			x = 0;
			y = 0;
		}
		public Point(double _x, double _y)
		{
			x = _x;
			y = _y;
		}
		public double x;
		public double y;
	}
}
