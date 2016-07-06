using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace SampleTask
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			RefactoringClass refactoring = new RefactoringClass();
			float firstResult, secondResult;
			refactoring.Foo(+7, +7, out firstResult, out secondResult);
			Console.WriteLine ("Refactoring Task: " + firstResult + " " + secondResult);
			
			Console.WriteLine ("Duplicate Task: ");
			ArrayClass arrayClass = new ArrayClass();
			int [] intArray = arrayClass.GetArray(10);
			arrayClass.Print(intArray);
			arrayClass.Print(arrayClass.GetDuplicatesWithLinq(intArray));
			arrayClass.Print(arrayClass.GetDuplicates(intArray));
		}
		

	}
	
	public class RefactoringClass
	{		
		public void Foo(int firstDivider, int secondDivider, out float firstResult, out float secondResult)
		{
			const int count = 10;
			const int x = 5;
			const int y = 3;
			
			if (firstDivider <= 0)
				throw new ArgumentException("Only positive values is valid", "firstDivider");
			if (secondDivider <= 0)
				throw new ArgumentException("Only positive values is valid", "secondDivider");

			firstResult = 1.0f * count * x / firstDivider;
			secondResult = 1.0f * count * y / secondDivider;
		}		
	}
	
	public class ArrayClass
	{
		public int[] GetArray(byte arraySize = 10)
		{
			int[] intArray = new int[arraySize];
			
			Random random = new Random();
			for(int i = 0; i < arraySize; i++)
			{
				intArray[i] = random.Next(0, 9);
			}
			return intArray;			
		}
		
		public void Print(int [] intArray)
		{
			foreach(int item in intArray)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine("=========");
		}
		
		public int [] GetDuplicates(int[] intArray)
		{			
			System.Collections.Generic.Dictionary<int, uint> valuesAndCountDict = 
				new System.Collections.Generic.Dictionary<int, uint>();
			for(int i = 0; i < intArray.Length; i++)
			{
				int intItem = intArray[i];
				if(valuesAndCountDict.ContainsKey(intItem))
				{
					valuesAndCountDict[intItem] = valuesAndCountDict[intItem] + 1;
				}
				else
				{
					valuesAndCountDict.Add(intItem, 1);
				}
			}
			List<int> result = new List<int>();
			foreach(int key in valuesAndCountDict.Keys)
			{
				if(valuesAndCountDict[key] > 1)
					result.Add(key);
			}
			return result.ToArray();
		}
		
		public int [] GetDuplicatesWithLinq(int[] intArray)
		{
			var duplicates = intArray
					.GroupBy(intItem => intItem)
					.Where(intGroupItem => intGroupItem.Count() > 1)
					.Select(intGroupItem => intGroupItem.Key);
			
			return duplicates.ToArray();
		}
	}
}
