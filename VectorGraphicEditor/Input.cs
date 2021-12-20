using System;

namespace VectorGraphicEditor
{
	static class Input
	{
		public static double GetValue()
		{
			for (; ; )
			{
				double result;
				string line;
				line = Console.ReadLine();
				try
				{
					result = Double.Parse(line);
				}
				catch (System.FormatException)
				{
					Console.WriteLine("The entered value does not correspond to a real number");
					continue;
				}
				return result;
			}
		}
		public static int GetRGB()
		{
			for(; ; )
			{
				int result;
				string line;
				line = Console.ReadLine();
				try
				{
					result = Int32.Parse(line);
				}
				catch (System.FormatException)
				{
					Console.WriteLine("The entered value does not correspond to an integer");
					continue;
				}
				if (result < 0 || result > 255)
				{
					Console.WriteLine("The entered value does not lie in the range 0..255");
					continue;
				}
				return result;
			}
		}
		public static int GetIndex()
		{
			for (; ; )
			{
				int result;
				string line;
				line = Console.ReadLine();
				try
				{
					result = Int32.Parse(line);
				}
				catch (System.FormatException)
				{
					Console.WriteLine("The entered value does not correspond to an integer");
					continue;
				}
				if (result < 0)
				{
					Console.WriteLine("The entered value is less than zero");
					continue;
				}
				return result;
			}
		}
		public static int GetOpacity()
		{
			for (; ; )
			{
				int result;
				string line;
				line = Console.ReadLine();
				try
				{
					result = Int32.Parse(line);
				}
				catch (System.FormatException)
				{
					Console.WriteLine("The entered value does not correspond to an integer");
					continue;
				}
				if (result < 0 || result > 100)
				{
					Console.WriteLine("The entered value does not lie in the range 0..100");
					continue;
				}
				return result;
			}
		}
		public static Color GetColor()
		{
			int red, green, blue, opacity;

			Console.Write("Enter red: ");
			red = GetRGB();

			Console.Write("Enter green: ");
			green = GetRGB();

			Console.Write("Enter blue: ");
			blue = GetRGB();

			Console.Write("Enter opacity: ");
			opacity = GetOpacity();

			return new Color(red, green, blue, opacity);
		}
	}
}
