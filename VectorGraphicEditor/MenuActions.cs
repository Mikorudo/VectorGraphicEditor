using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace VectorGraphicEditor
{
	/*
	 * {" 1 - Add figure to vector document", 
	 * " 2 - Delete figure by index to vector document", 
	 * " 3 - Serialize into file",	
	 * " 4 - Deserialize from file", 
	 * " 5 - Rotate all figures", 
	 * " 6 - Scale all figures", 
	 * " 7 - Move all figures", 
	 * " 8 - Print info about vector document", 
	 * " 9 - Change figure by index"," 0 - EXIT"};
	 */

	static class MenuActions
	{
		private static void EndAction()
		{
			Console.WriteLine("Press any key to continue");
			Console.ReadKey();
			Console.Clear();
		}
		public static void AddFigure(ref VectorDoc vectorDoc)
		{
			Console.WriteLine("Choose figure: (1) - quadrangle, (2) - circle");
			var input = Console.ReadKey();
			Console.WriteLine();
			switch (input.Key)
			{
				case ConsoleKey.NumPad1:
				case ConsoleKey.D1:
					{
						List<Point> points = new List<Point>();
						double x, y;
						Color color = Input.GetColor();

						for (int i = 0; i < 4; i++)
						{
							int index = i + 1;
							Console.WriteLine("Enter x of " + index + " point: ");
							x = Input.GetValue();
							Console.WriteLine("Enter y of " + index + " point: ");
							y = Input.GetValue();
							points.Add(new Point(x, y));
						}
						Quad quad = new Quad(points[0], points[1], points[2], points[3], color);
						vectorDoc.AddFigure(quad);
						break;
					}
				case ConsoleKey.NumPad2:
				case ConsoleKey.D2:
					{
						double x, y, radius;
						Color color = Input.GetColor();

						Console.WriteLine("Enter x of center: ");
						x = Input.GetValue();
						Console.WriteLine("Enter y of center: ");
						y = Input.GetValue();
						Console.WriteLine("Enter radius: ");
						radius = Input.GetValue();


						Circle circle = new Circle(new Point(x, y), radius, color);
						vectorDoc.AddFigure(circle);
						break;
					}
			}
			EndAction();
		}
		public static void DeleteFigure(ref VectorDoc vectorDoc)
		{
			if (!vectorDoc.IsEmpty())
			{
				Console.WriteLine("Enter index fo figure to delete: ");
				int index = Input.GetIndex();
				index--;
				if (index < 0 || index >= vectorDoc.GetSize())
				{
					Console.WriteLine("There is no such index");
					EndAction();
					return;
				}
				vectorDoc.DeleteFigure(index);
				Console.WriteLine("Successful deletion");
			}
			else Console.WriteLine("No figures!");
			EndAction();
		}
		public static void Serialize(ref VectorDoc vectorDoc)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream stream = new FileStream("test.dat", FileMode.OpenOrCreate))
			{
				try
				{
					formatter.Serialize(stream, vectorDoc);

				}
				catch (Exception)
				{
					Console.WriteLine("Error in serialization");
				}
				finally
				{
					Console.WriteLine("Serialization completed successfully");
				}
			}
			
			EndAction();
		}
		public static void Deserialize(ref VectorDoc vectorDoc)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream stream = new FileStream("test.dat", FileMode.OpenOrCreate))
			{
				try
				{
					vectorDoc = formatter.Deserialize(stream) as VectorDoc;
				}
				catch (Exception)
				{
					Console.WriteLine("Error in deserialization");
				}
				finally
				{
					Console.WriteLine("Deserialization completed successfully");
				}
			}
			EndAction();
		}
		public static void Rotate(ref VectorDoc vectorDoc)
		{
			if (!vectorDoc.IsEmpty())
			{
				Console.WriteLine("Enter the angle by which all figures will rotate: ");
				double angle = Input.GetValue();
				vectorDoc.Rotate(angle);
				Console.WriteLine("Successful rotation");
			}
			else Console.WriteLine("No figures!");
			EndAction();
		}
		public static void Scale(ref VectorDoc vectorDoc)
		{
			if (!vectorDoc.IsEmpty())
			{
				Console.WriteLine("Enter the coefficient by which all figures will scale: ");
				double k = Input.GetValue();
				vectorDoc.Scale(k);
				Console.WriteLine("Successful rotation");
			}
			else Console.WriteLine("No figures!");
			EndAction();
		}
		public static void Move(ref VectorDoc vectorDoc)
		{
			if (!vectorDoc.IsEmpty())
			{
				Console.WriteLine("Enter value of x by which all figures will move: ");
				double x = Input.GetValue();
				Console.WriteLine("Enter value of y by which all figures will move: ");
				double y = Input.GetValue();
				vectorDoc.Move(x, y);
				Console.WriteLine("Successful displacement");
			}
			else Console.WriteLine("No figures!");
			EndAction();
		}
		public static void PrintInfo(ref VectorDoc vectorDoc)
		{
			Console.WriteLine(vectorDoc.PrintInfo());
			EndAction();
		}
		public static void ChangeFigure(ref VectorDoc vectorDoc)
		{
			if (!vectorDoc.IsEmpty())
			{
				Console.WriteLine("Enter index fo figure to change: ");
				int index = Input.GetIndex();
				index--;
				if (index < 0 || index >= vectorDoc.GetSize())
				{
					Console.WriteLine("There is no such index");
					EndAction();
					return;
				}
				vectorDoc.ChangeFigure(index);
				Console.WriteLine("Successful сhange");
			}
			else Console.WriteLine("No figures!");
			EndAction();
		}
		public static void EXIT(ref VectorDoc vectorDoc)
		{
			Environment.Exit(0);
		}
	}
}
