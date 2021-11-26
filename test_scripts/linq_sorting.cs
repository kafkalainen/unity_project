using System;
using System.Collections.Generic;
using System.Linq;

namespace Linqing
{
		class Program
	{

		static void WriteArrayStrings(ref string[] strings)
		{
			Console.WriteLine("IENumerable string printing: ");
			foreach (string str in strings)
			{
				Console.WriteLine(str);
			}
		}
		static void WriteArrayStrings(ref IEnumerable<string> strings)
		{
			Console.WriteLine("IENumerable string printing: ");
			foreach (string str in strings)
			{
				Console.WriteLine(str);
			}
		}
		static void Main()
		{
			string[] story = {"quick", "brown", "fox", "jumped", "over", "fence", "fennec"};
			//You can use orderby to order alphabetically.
			IEnumerable<string> orderedAscending = from str in story orderby str select str;
			WriteArrayStrings(ref orderedAscending);
			IEnumerable<string> orderedByLength = from str in story orderby str.Length select str;
			WriteArrayStrings(ref orderedByLength);
			IEnumerable<string> orderedDescending = from str in story orderby str descending select str;
			WriteArrayStrings(ref orderedDescending);
			IEnumerable<string> orderedDescendingBySecondLetter = from str in story orderby str.Substring(0, 2) descending select str;
			WriteArrayStrings(ref orderedDescendingBySecondLetter);
			IEnumerable<string> orderedMultipleConditions = from str in story orderby str.Length, str.Substring(0, 2) descending select str;
			WriteArrayStrings(ref orderedMultipleConditions);
		}
	}
}
