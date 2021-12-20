using System;
using System.Collections.Generic;

namespace VectorGraphicEditor
{
	[Serializable]
	class VectorDoc
	{
		public List<Figure> figures = new List<Figure>();
		public bool IsEmpty()
		{
			if (figures.Count == 0)
				return true;
			else
				return false;
		}
		public int GetSize()
		{
			return figures.Count;
		}
		public void AddFigure(Figure figure)
		{
			figures.Add(figure);
		}
		public void DeleteFigure(int index)
		{
			if (index < 0)
				return;
			if (index >= figures.Count)
				return;
			figures.RemoveAt(index);
		}
		public void Scale(double k)
		{
			foreach (var figure in figures)
			{
				figure.Scale(k);
			}
		}
		public void Rotate(double k)
		{
			foreach (var figure in figures)
			{
				figure.Rotate(k);
			}
		}
		public void Move(double x, double y)
		{
			foreach (var figure in figures)
			{
				figure.Move(x, y);
			}
		}
		public string PrintInfo()
		{
			if (IsEmpty())
				return "No figures!";
			string result = "";
			result += "===FIGURE LIST===\n" + "Total figure(s): " + figures.Count + "\n\n";
			for (int i = 0; i < figures.Count; i++)
			{
				int index = i + 1;
				result += "==Figure №" + index + ":\n";
				result += figures[i].GetInfo();
			}
			result += "\n===LIST OVER===";
			return result;
		}
		public void ChangeFigure(int index)
		{
			if (index < 0 || index >= GetSize())
				return;
			figures[index].ChangeFigure();
		}
	}
}
