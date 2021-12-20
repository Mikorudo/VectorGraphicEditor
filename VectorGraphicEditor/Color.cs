using System;

namespace VectorGraphicEditor
{
	[Serializable]
	class Color
	{
		public int Red { get; private set; }
		public int Green { get; private set; }
		public int Blue { get; private set; }
		private int opacity;
		public int Opacity
		{
			get { return opacity; }
			set {
				if (opacity > 100 || opacity < 0)
					throw new System.Exception($"Incorrect opacity: opacity = {opacity}");
				opacity = value;
			}
		}
		public void setRGB(int red, int green, int blue)
		{
			if (red > 255 || red < 0)
				throw new System.Exception($"Incorrect color: red = {red}");
			if (green > 255 || green < 0)
				throw new System.Exception($"Incorrect color: green = {green}");
			if (blue > 255 || blue < 0)
				throw new System.Exception($"Incorrect color: blue = {blue}");
			Red = red;
			Green = green;
			Blue = blue;
		}

		public Color()
		{
			Red = 0;
			Green = 0;
			Blue = 0;
			Opacity = 100;
		}
		public Color(int red, int green, int blue, int opacity)
		{
			setRGB(red, green, blue);
			Opacity = opacity;
		}
	}
}
