using System;
using System.Collections.Generic;

namespace VectorGraphicEditor
{
	[Serializable()]
	class Quad : Figure
	{
		private List<Point> points;
		private bool Intersecting(Point p1, Point p2, Point p3, Point p4, ref Point cross)
		{
			double a1 = p1.x - p2.y;
			double b1 = p2.x - p1.x;
			double c1 = p1.x * p2.y - p2.x * p1.y;
			double a2 = p3.y - p4.y;
			double b2 = p4.x - p3.x;
			double c2 = p3.x * p4.y - p4.x * p3.y;
			double det = a1 * b2 - a2 * b1;
			if ((a1 / a2) == (b1 / b2))
			{
				Console.WriteLine("Lines parallel!");
				return false;
			}
			cross.x = (b1 * c2 - b2 * c1) / det;
			cross.y = (a2 * c1 - a1 * c2) / det;
			return true;
		}
		private void RearrangePoints()
		{
			double a1 = points[0].y - points[2].y;
			double a2 = points[1].y - points[3].y;
			double b1 = points[2].x - points[0].x;
			double b2 = points[3].x - points[1].x;
			if ((a1 / a2 < 0 && Double.IsNaN(b1 / b2)) || (Double.IsNaN(a1 / a2) && b1 / b2 < 0))
			{
				Point point_temp = points[1];
				points[1] = points[2];
				points[2] = point_temp;
			}
			else if ((a1 / a2 > 0 && Double.IsNaN(b1 / b2)) || (Double.IsNaN(a1 / a2) && b1 / b2 > 0))
			{
				Point point_temp = points[2];
				points[2] = points[3];
				points[3] = point_temp;
			}
		}
		public Quad(Point point1, Point point2, Point point3, Point point4, Color color_)
		{
			points = new List<Point>();
			points.Add(point1);
			points.Add(point2);
			points.Add(point3);
			points.Add(point4);
			RearrangePoints();
			color = color_;
		}
		public Quad()
		{
			points = new List<Point>();
			points.Add(new Point (0.0, 0.0));
			points.Add(new Point (0.0, 1.0));
			points.Add(new Point (1.0, 1.0));
			points.Add(new Point (1.0, 0.0));
			color = new Color();
		}
		public void setPoint(Point point, int number)
		{
			if (number < 1 || number > 4)
				throw new System.Exception($"Incorrect point number: number = {number}");
			points[number] = point;
			RearrangePoints();
		}
		public Point getPoint(int number)
		{
			if (number < 1 || number > 4)
				throw new System.Exception($"Incorrect point number: number = {number}");
			return points[number - 1];
		}
		public override void Scale(double k)
		{
			Point cross = new Point();
			Intersecting(points[0], points[2], points[1], points[3], ref cross);
			foreach(var point in points)
			{
				point.x -= cross.x;
				point.y -= cross.y;
				point.x *= k;
				point.y *= k;
				point.x += cross.x;
				point.y += cross.y;
			}
		}
		public override void Move(double x, double y)
		{
			foreach (var point in points)
			{
				point.x += x;
				point.y += y;
			}
		}
		public override void Rotate(double angle)
		{
			Point cross = new Point();
			Intersecting(points[0], points[2], points[1], points[3], ref cross); //порядок параметров был изменен для получения центра тяжести
			foreach (var point in points)
			{
				point.x -= cross.x;
				point.y -= cross.y;
				double temp_x = point.x;
				double temp_y = point.y;
				point.x = temp_x * Math.Cos(angle * Math.PI / 180) - temp_y * Math.Sin(angle * Math.PI / 180);
				point.y = temp_x * Math.Sin(angle * Math.PI / 180) + temp_y * Math.Cos(angle * Math.PI / 180);
				point.x += cross.x;
				point.y += cross.y;
			}
		}
		public override void ChangeFigure()
		{
			double x, y;
			int red, green, blue, opacity;
			Console.WriteLine("Changing quadrangle:");

			Color _color = Input.GetColor();
			color = _color;

			for (int i = 0; i < 4; i++)
			{
				int index = i + 1;
				Console.Write("Enter x of " + index + " point: ");
				x = Input.GetValue();
				Console.Write("Enter y of " + index + " point: ");
				y = Input.GetValue();
				points[i].x = x;
				points[i].y = y;
			}
		}
		public override double CalculatePerimeter()
		{
			double result = 0;
			result += Math.Sqrt(Math.Pow((points[0].x - points[1].x), 2) + Math.Pow((points[0].y - points[1].y), 2));
			result += Math.Sqrt(Math.Pow((points[1].x - points[2].x), 2) + Math.Pow((points[1].y - points[2].y), 2));
			result += Math.Sqrt(Math.Pow((points[2].x - points[3].x), 2) + Math.Pow((points[2].y - points[3].y), 2));
			result += Math.Sqrt(Math.Pow((points[3].x - points[0].x), 2) + Math.Pow((points[3].y - points[0].y), 2));
			return result;
		}
		public override double CalculateArea()
		{
			double result = 0;
			result += (points[0].x - points[1].x) * (points[0].y + points[1].y);
			result += (points[1].x - points[2].x) * (points[1].y + points[2].y);
			result += (points[2].x - points[3].x) * (points[2].y + points[3].y);
			result += (points[3].x - points[0].x) * (points[3].y + points[0].y);
			result = Math.Abs(result) / 2.0;
			return result;
		}
		public override string GetInfo()
		{
			string points_str = "";
			for (int i = 0; i < 4; i++)
			{
				points_str += "[" + points[i].x.ToString() + ", " + points[i].y.ToString() + "]\n";
			}
			return "Quadrangle with points:\n" + points_str;
		}
	}
}
