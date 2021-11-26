
using System;
using System.Collections.Generic;
using System.Linq;


/*
**	For each statement is directly available in C#.
*/
class ForEaching
{
	static void WriteListNumbers(ref List<int> tab)
	{
		foreach (int nb in tab)
		{
			Console.WriteLine(nb);
		}
	}

	/*
	**	To change contents of an array I could use for loop,
	**	with for each statement change is not possible.
	*/
	static void IncrementArrayItems(ref int[] tab)
	{
		for (int i = 0; i < tab.Length; i++)
		{
			tab[i]++;
		}
	}

	/*
	**	For just accessing elements it is possible to
	**	to use foreach.
	*/
	static void WriteArrayNumbers(ref int[] tab)
	{
		Console.WriteLine("Int array printing: ");
		foreach (int nb in tab)
		{
			Console.WriteLine(nb);
		}
	}

	static void WriteArrayNumbers(ref IEnumerable<int> tab)
	{
		Console.WriteLine("IENumerable printing: ");
		foreach (int nb in tab)
		{
			Console.WriteLine(nb);
		}
	}

	static void WriteArrayNumbers(int[] tab)
	{
		Console.WriteLine("Without reference IENumerable printing: ");
		foreach (int nb in tab)
		{
			Console.WriteLine(nb);
		}
	}

	static void WriteArrayNumbers(IEnumerable<int> tab)
	{
		Console.WriteLine("Without reference IENumerable printing: ");
		foreach (int nb in tab)
		{
			Console.WriteLine(nb);
		}
	}

	static void WriteNumber(int nb)
	{
		Console.WriteLine(nb);
	}

	/*
	**	List contents can be manipulated more better by using LINQ,
	**	making code more readable and evading a great number of loops.
	**	LINQ statements work on any object that implements IEnumerable.
	**	You have to note, that if you create a query, it is applied
	**	when you execute the query.
	**	Execution is done when you access IEnumberable list.
	**	In following example that happens when calling WriteArrayNumbers
	**	method.
	*/
	static void Main()
	{
		List<int> tab = new List<int> {0, 2, 3, 4, 5, 6};
		int[] tab2 = {0, 2, 3, 4, 5, 6};
		WriteListNumbers(ref tab);
		IEnumerable<int> tab3 = from number in tab2 select number; // result is 0, 2, 3, 4, 5, 6
		IEnumerable<int> odd_numbers = from number in tab2 where number % 2 != 0 select number; // result is 3, 5
		tab.ForEach(WriteNumber);
		IncrementArrayItems(ref tab2);
		// IEnumerable result keeps reference to the original collection, it just queries the data source.
		WriteArrayNumbers(ref tab2); // result is 1, 3, 4, 6, 7
		WriteArrayNumbers(ref tab3); // result is 1, 3, 4, 6, 7, result is updated!
		WriteArrayNumbers(ref odd_numbers); // result is 1, 3, 7
	}
}
