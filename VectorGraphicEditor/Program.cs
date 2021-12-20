using System;

namespace VectorGraphicEditor
{
	class Program
	{
		static void Main(string[] args)
		{
			Menu();
		}

		public static void Menu()
		{
			VectorDoc vectorDoc = new VectorDoc();
			string[] actions = {" 1 - Add figure to vector document", " 2 - Delete figure by index to vector document", " 3 - Serialize into file",	" 4 - Deserialize from file", " 5 - Rotate all figures", " 6 - Scale all figures", " 7 - Move all figures", " 8 - Print info about vector document", " 9 - Change figure by index"," 0 - EXIT"};
			for (; ; )
			{
				Console.WriteLine("--------------------GRAPHICAL EDITOR----------------");
				foreach (var action in actions)
					Console.WriteLine(action);
				var input = Console.ReadKey();
				Console.WriteLine();
				switch (input.Key)
				{
					case ConsoleKey.NumPad1:
					case ConsoleKey.D1:
						MenuActions.AddFigure(ref vectorDoc);
						break;
					case ConsoleKey.NumPad2:
					case ConsoleKey.D2:
						MenuActions.DeleteFigure(ref vectorDoc);
						break;
					case ConsoleKey.NumPad3:
					case ConsoleKey.D3:
						MenuActions.Serialize(ref vectorDoc);
						break;
					case ConsoleKey.NumPad4:
					case ConsoleKey.D4:
						MenuActions.Deserialize(ref vectorDoc);
						break;
					case ConsoleKey.NumPad5:
					case ConsoleKey.D5:
						MenuActions.Rotate(ref vectorDoc);
						break;
					case ConsoleKey.NumPad6:
					case ConsoleKey.D6:
						MenuActions.Scale(ref vectorDoc);
						break;
					case ConsoleKey.NumPad7:
					case ConsoleKey.D7:
						MenuActions.Move(ref vectorDoc);
						break;
					case ConsoleKey.NumPad8:
					case ConsoleKey.D8:
						MenuActions.PrintInfo(ref vectorDoc);
						break;
					case ConsoleKey.NumPad9:
					case ConsoleKey.D9:
						MenuActions.ChangeFigure(ref vectorDoc);
						break;
					case ConsoleKey.NumPad0:
					case ConsoleKey.D0:
						MenuActions.EXIT(ref vectorDoc);
						break;
					default:
						Console.Clear();
						break;
				}
			}
	}
		}
}
