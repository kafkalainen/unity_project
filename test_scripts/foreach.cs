
using System;
using System.Collections.Generic;


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
	**	List contents can be iterated with using ForEach method.
	**	public void ForEach (Action<T> action);
	**	However, it will only access the object in the list,
	**	not change it's value. It simply iterates over each
	**	item in the collection.
	*/
	static void Main()
	{
		List<int> tab = new List<int> {0, 2, 3, 4, 5, 6};
		int[] tab2 = {0, 2, 3, 4, 5, 6};
		WriteListNumbers(ref tab);
		tab.ForEach(WriteNumber);
		IncrementArrayItems(ref tab2);
		WriteArrayNumbers(ref tab2);
	}
}

	// decimal total = (from account in myAccounts
	// 	where account.Status == "active"
	// 	select account.Balance).Sum();
