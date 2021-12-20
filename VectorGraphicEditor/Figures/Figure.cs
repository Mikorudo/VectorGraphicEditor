using System;

namespace VectorGraphicEditor
{
    [Serializable]
	abstract class Figure
	{
        public Color color;
		public abstract void Scale(double k);
		public abstract void Rotate(double angle);
        public abstract void Move(double x, double y);
        public abstract void ChangeFigure();
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
        public abstract string GetInfo();
    }
}
