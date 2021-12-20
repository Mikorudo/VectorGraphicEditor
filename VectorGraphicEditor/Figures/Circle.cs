using System;

namespace VectorGraphicEditor
{
	[Serializable()]
	class Circle : Figure
	{
		public double Radius { get; set; }
		private Point center;
		public Circle()
		{
			center = new Point(0, 0);
			Radius = 1;
			color = new Color();
		}
		public Circle(Point _center, double r, Color _color)
		{
			Radius = r;
			center = _center;
			color = _color;
		}
		public void setCenter(double x, double y)
		{
			center.x = x;
			center.y = y;
		}
		public override void Scale(double k)
		{
			Radius *= k;
		}
		public override void Rotate(double k)
		{
			//How to rotate the circle?
		}
		public override void Move(double x, double y)
		{
			center.x += x;
			center.y += y;
		}
		public override void ChangeFigure()
		{
			double x, y, radius;
			Console.WriteLine("Changing quadrangle:");

			Color _color = Input.GetColor();
			color = _color;

			Console.Write("Enter x of center: ");
			x = Input.GetValue();
			Console.Write("Enter y of center: ");
			y = Input.GetValue();
			setCenter(x, y);

			Console.WriteLine("Enter radius: ");
			radius = Input.GetValue();
			Radius = radius;
		}
		public double GetCenterX()
		{
			return center.x;
		}
		public double GetCenterY()
		{
			return center.y;
		}
		public override double CalculatePerimeter()
		{
			return Math.PI * 2 * Radius;
		}
		public override double CalculateArea()
		{
			return Math.PI * Radius * Radius;
		}
		public override string GetInfo()
		{
			return "Circle in: [" + GetCenterX().ToString() + ", " + GetCenterY().ToString() + "], with radius of " + Radius.ToString() + "\n";
		}
	}
}
