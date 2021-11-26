# Notes for learning C#

## Compiling in Linux environment
- I use mcs for compiling C# scripts.

	mcs -out:hello.exe hello.cs

And execute programs by mono command.

	mono hello.exe

## Data type differences when compared to C

type | size | range
-----|----- | ------
`char` | 2 bytes | \x0058 (hex), or\u0058 (Unicode)
`string` | 2 bytes per character | \x0058 (hex), or\u0058 (Unicode)
`byte` | 1 byte | 0 to 255
`sbyte` | 1 byte | -128 to 127
`sshort` | 2 bytes | -32,768 to 32,767
`short` | 2 bytes | 0 to 65,535
`decimal` | 16 bytes | (+ or -)1.0 x 10e-28 to 7.9 x 10e28
`bool` | 1 byte | True or False
`DateTime` | - | 0:00:00am 1/1/01 to 11:59:59pm 12/31/9999

- Char and string types spend twice as more, since they need more space to fit into UTF-16 encoding.
- A floating point number can also be a scientific number with an "e" to indicate the power of 10.

	float nb = 2e5F;e

- `enum` is a special class that's member can be accessed with dot notation.

More comprehensive list is [here](https://www.tutorialsteacher.com/csharp/csharp-data-types)

## String concatenation using interpolation

	const string ability = "fly";
	string s = $"I'm a cat, and I can {ability}";

## Other useful methods for string manipulation

Method | Explanation
------|------
IndexOf('a') | Returns index of a.
Substring(pos) | Extracts characters from a string and returns a new string.

## Escaping characters

- You can escape characters with backslash.

Character | Escaped
----- | -----
tab | \t
space | \s
backspace | \b
newline | \n
single quote | \'
double quote | \"
backslash | \\\

## New

- New is used to create objects.

## Arrays

	string[] chapter = {"This will be the finest day of my life\n", ", if I make out of here alive.\n"};
	int[] tab = {10, 20, 30, 40};

- You can change array element by it's index, like in C.

## Array Methods

Method | Explanation
------|------
Array.Sort() | Sorts array alphabetically or in ascending order.
Array.Length() | Returns length of the array.

## LINQ Array Methods

Method | Explanation
------|------
tab.Max() | Returns the largest value in array.
tab.Min() | Returns the smallest value in array.
tab.Sum() | Returns the sum of elements.

## For each statement
- For each is readily available as an iterator for collections.

## Garbage collection
- Carbage collection is done by .NET framework.

## Why and when async functions should be used?
- They allow asynchronous execution while maintaining a regular, synchronous feel
- For example, if you are preparing a cake, you will turn your attention to tasks that are ready to be started, like first putting the oven on, warming the butter and mixing together dry ingridients. One can make a cake asynchronously by starting the next task before the first completes.
- Await doesn't wait for the associated call to complete. Await returns the result immidiately and synchroniously if operation has already completed.

## Access modifiers

type | explanation
---- | -----
`public` | The type or member can be accessed by any other code in the same assembly or another assembly that references it. The `accessibility` level of public members of a type is controlled by the accessibility level of the type itself.
`private` | The type or member can be accessed only by code in the same class or struct.
`protected` | The type or member can be accessed only by code in the same class, or in a class that is derived from that class
`internal` | The type or member can be accessed by any code in the same assembly, but not from another assembly.
`protected internal` | The type or member can be accessed by any code in the assembly in which it's declared, or from within a derived class in another assembly.
`private protected` | The type or member can be accessed only within its declaring assembly, by code in the same class or in a type that is derived from that class.
`sealed` | class cannot be inherited
`override` | overrides inherited method
`virtual` | makes possible for method to be inherited
`abstract` | restricted class that cannot be used to create objects (to access it, it must be inherited from another class)
`interface` | contains only abstract methods and properties with empty bodies. to implement multiple interfaces, we can seperate them with comma `class DemoClass : IFirstInterface, ISecondInterface`

## Common mistakes

	Pen pen1 = new Pen(Color.Black);
	Pen pen2 = pen1;
	pen2.Color = Color.Blue;
	Console.WriteLine(pen1.Color);     // Blue (or does this surprise you?)
	Console.WriteLine(pen2.Color);     // Blue

- In C Sharp programming, however, that decision is made by the programmer who wrote the object, not by the programmer who instantiates the object and assigns it to a variable. [Link](https://www.toptal.com/c-sharp/top-10-mistakes-that-c-sharp-programmers-make)

Using iterative (instead of declarative) statements to manipulate collections

	foreach (iterative method)
	decimal total = 0;
	foreach (Account account in myAccounts)
	{
		if (account.Status == "active")
		{
			total += account.Balance;
		}
	}
LINQ (declarative method)

	decimal total = (from account in myAccounts
		where account.Status == "active"
		select account.Balance).Sum();

- NOTE: there may be a trade-off in terms of performance, Iterative method can make decisions on the go.
- You can also use lambda expressions when you write LINQ in C#
	int[] numbers = {2, 3, 4, 5, 6};
	IEnumerable<int> squareOfEvenNumbers = from number in numbers where number % 2 == 0 select(number => number * number);
	foreach (int number in squareOfEvenNumbers)
	{
		Console.WriteLine(number);
	}

## Delegates
- Delegates works like function pointers in C and C++.

## Links

Asyncronous tasks in C# [Link] (https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/)
