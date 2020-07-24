using System;

public class Class1
{
	public Class1()
	{
		public ushort ReadGridDimensions(char dimensionName)
		{
			ushort dimension = 0;
            Console.Write($"Please, enter Dimension {dimensionName}:");
			dimension = ushort.Parse(Console.ReadLine());
			return dimension; 
		}
	}
}
