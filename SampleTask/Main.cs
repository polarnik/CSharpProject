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
			var refactoring = new RefactoringClass();
			float firstResult, secondResult;
			refactoring.Foo(+7, +7, out firstResult, out secondResult);
			Console.WriteLine ("Refactoring Task: " + firstResult + " " + secondResult);
			
			Console.WriteLine ("Duplicate Task:");
			var arrayClass = new ArrayClass();
			var intArray = arrayClass.GetArray(10);
			arrayClass.Print(intArray);
			arrayClass.Print(arrayClass.GetDuplicatesWithLinq(intArray));
			arrayClass.Print(arrayClass.GetDuplicates(intArray));
		}
	}
	
	public class RefactoringClass
	{		
		public void Foo(int firstDivider, int secondDivider, out float firstResult, out float secondResult)
		{
			var count = 10;
			var x = 5;
			var y = 3;
			
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
			var intArray = new int[arraySize];
			
			var random = new Random();
			for(var i = 0; i < arraySize; i++)
			{
				intArray[i] = random.Next(0, 9);
			}
			return intArray;			
		}
		
		public void Print(int [] intArray)
		{
			foreach(var item in intArray)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine("=========");
		}
		
		public int [] GetDuplicates(int[] intArray)
		{			
			var valuesAndCountDict = new Dictionary<int, uint>();
			for(var i = 0; i < intArray.Length; i++)
			{
				var intItem = intArray[i];
				if(valuesAndCountDict.ContainsKey(intItem))
				{
					valuesAndCountDict[intItem] = valuesAndCountDict[intItem] + 1;
				}
				else
				{
					valuesAndCountDict.Add(intItem, 1);
				}
			}
			var result = new List<int>();
			foreach(var key in valuesAndCountDict.Keys)
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
