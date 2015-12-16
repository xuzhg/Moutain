using System;
using System.Collections.Generic;

namespace Wrox.ProCSharp
{
	class BubbleSorter
	{
		static public void Sort<T>(IList<T> sortArray, Func<T, T, bool> comparison)
		{
			bool swapped = true;
			do
			{
				swapped = false;
				for (int i = 0; i < sortArray.Count - 1; i++)
				{
					if (comparison(sortArray[i+1], sortArray[i]))
					{
						T temp = sortArray[i];
						sortArray[i] = sortArray[i+1];
						sortArray[i+1] = temp;
						swapped = true;
					}
				}
			} while(swapped);
		}
	}
	
	class Employee
	{
		public Employee(string name, decimal salary)
		{
			this.Name = name;
			this.Salary = salary;
		}
		
		public string Name {get; private set;}
		public decimal Salary {get; private set;}
		
		public override string ToString()
		{
			return String.Format("{0}, {1:C}", Name, Salary);			
		}
		
		public static bool CompareSalary(Employee e1, Employee e2)
		{
			return e1.Salary < e2.Salary;
		}
	}
	
	class Program
	{
		static void Main()
		{
            Employee[] employees = 
			{
				new Employee("Bugs Bunny", 20000),
				new Employee("Elmer Fudd", 10000),
				new Employee("Daffy Duck", 25000),
				new Employee("Wile Coyote", 100000.38m),
				new Employee("Foghorn Leghorn", 23000),
				new Employee("Road Runner", 50000),
			};
			
			BubbleSorter.Sort(employees, Employee.CompareSalary);
			
			foreach(var employee in employees)
			{
				Console.WriteLine(employee);
			}
		}
	}
}