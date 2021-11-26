
using System;
using System.Collections.Generic;
using System.Linq;

class Delegates
{
	static void WriteListNumbers(ref IEnumerable<int> tab)
	{
		foreach (int nb in tab)
		{
			Console.WriteLine(nb);
		}
	}


	/*
	**	Strongly typed delegate
	*/
	delegate bool numberEquals(int x);

	/*
	**	Lambda expression can be written:
	**	parameters => expression
	**	or
	**	parameters => { block }
	**	Types are Predicate, Func and Action.
	**	Func is general, Predicate has boolean return value,
	**	and action has void return value.
	*/
	static void Main()
	{
		numberEquals five = x => x == 5;
		int[] tab = {0, 2, 3, 4, 5, 6};
		Func<int, int> squaredFunc = nb => nb * nb;
		Predicate<int> isFive = x => x == 5;
		int result = squaredFunc(4);
		Console.WriteLine(result);
		Predicate<string> isEmptyString = String.IsNullOrEmpty;
		if (!isEmptyString("hello"))
		{
			Console.WriteLine("Is not empty.");
		}
		Action<int> putNumber = Console.WriteLine;
		putNumber(5);
		/*
		**	So here's a pretty wild example. Where method requires Func class,
		**	so Predicate needs to be typecasted to Func class.
		**	That way we can use Where method and pass delegate isFive as
		**	a parameter, and finally square the result with delegate function squaredFunc.
		*/
		IEnumerable<int> squared = tab.Where(new Func<int, bool>(isFive)).Select(squaredFunc);
		WriteListNumbers(ref squared);
	}
}
