using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqMapping
{
	class Program
	{
		class Student
		{
			public string Name { get; }

			public Student(string s)
			{
				Name = s;
			}
		}

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

		static string StudentSelector(Student s) => s.Name;
		static void Main()
		{
			string[] studentsA = {"bill", "mark", "frank", "lisa", "suvi", "emilie", "frank"};
			string[] studentsB = {"ellie", "mark", "frank", "lisa", "kalle", "emilie", "frank"};
			Student[] studentObjectsA = new Student[]
			{
				new Student("bill"),
				new Student("mark"),
				new Student("frank"),
				new Student("lisa"),
				new Student("suvi"),
				new Student("emilie"),
				new Student("frank")
			};
			Student[] studentObjectsB = new Student[]
			{
				new Student("hilla"),
				new Student("mark"),
				new Student("frank"),
				new Student("lisa"),
				new Student("suvi"),
				new Student("emilie"),
				new Student("frank")
			};
			//You can map lists using Distinct();
			IEnumerable<string> distinct = from student in studentsA.Distinct() orderby student ascending select student;
			WriteArrayStrings(ref distinct);
			//If you are handling object, you can also discriminate using DistinctBy
			// foreach (Student student in studentObjects.DistinctBy(s => s.Name))
			// {
			// 	Console.WriteLine(student.Name);
			// }
			IEnumerable<string> except = from student in studentsB.Except(studentsA) orderby student ascending select student;
			WriteArrayStrings(ref except);
			foreach (Student st in studentObjectsA.ExceptBy(
				studentObjectsB.Select(StudentSelector), StudentSelector))
			{
				Console.WriteLine(st.Name);
			}

		}
	}
}
