using System;
using System.Threading.Tasks;
public class Catapult
{

};

public class Archer
{

};

class Asyncing
{
	async static Task<Catapult> CatapultFire()
	{
		Console.WriteLine("Fire catapult");
		Console.WriteLine("Reloading.");
		await Task.Delay(3000);
		Console.WriteLine("Ready to fire.");
		return (new Catapult());
	}

	async static Task<Archer> ArchersFire()
	{
		Console.WriteLine("Nock.");
		await Task.Delay(1000);
		Console.WriteLine("Draw.");
		await Task.Delay(1000);
		Console.WriteLine("Loose!");
		return (new Archer());
	}

	static void ReissueCommand(Archer archer)
	{
		Console.WriteLine("Archers! Fire!");
	}

	static void ReissueCommand(Catapult catapult)
	{
		Console.WriteLine("Catapult! Fire!");
	}

	/*
	** This code doesn't block while the Catapult is firing.
	** Result is that catapult is fired only once.
	** Since Catapult task is still completing, Archers task won't start
	** and this code runs to it's end.
	*/
	async static void Battle()
	{
		Console.WriteLine("There will be only one king in the North!");
		await CatapultFire();
		await ArchersFire();
	}

	/*
	** This code runs to it's end since, Task<Catapult> is stored to variable.
	** That task is then awaited asyncroniously.
	*/
	async static Task BattleAsync()
	{
		Console.WriteLine("There will be only one king in the North!");
		Task<Catapult> commandCatapult = CatapultFire();
		Task<Archer> commandArchers = ArchersFire();
		Catapult catapult = await commandCatapult;
		Archer archer = await commandArchers;
		ReissueCommand(catapult);
		ReissueCommand(archer);
	}

	//Wait is used here to
	static void Main()
	{
		// Battle();
		// BattleAsync();
		BattleAsync();
	}
}
