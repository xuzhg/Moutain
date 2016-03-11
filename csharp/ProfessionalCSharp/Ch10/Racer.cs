using System;
using System.Collections.Generic;

namespace Wrox
{
	[Serializable]
	public class Racer : IComparable<Racer>, IFormattable
	{
		public int Id {get; private set;}
		public string FirstName {get;set;}
		public string LastName {get;set;}
		public string Country {get;set;}
		public int Wins{get;set;}
		public Racer(int id, string firstName, string lastName, string country)
		    : this(id, firstName, lastName, country, wins: 0)
		{
			
		}
		
		public Racer(int id, string firstName, string lastName, string country, int wins)
		{
			this.Id = id;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Country = country;
			this.Wins = wins;
		}
		
		public override string ToString()
		{
			return String.Format("{0} {1}", FirstName, LastName);
		}
		
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (format == null) 
			{
				format = "N";
			}
			switch(format)
			{
				case "N":
					return ToString();
				case "F": // first name
					return FirstName;
				case "L": // last name
					return LastName;
				case "W": // Wins
					return String.Format("{0}, Wins: {1}", ToString(), Wins);
				case "C": // country
					return String.Format("{0}, Country: {1}", ToString(), Country);
				case "A": // All
					return String.Format("{0}, {1} Wins: {2}", ToString(), Country, Wins);
				default:
					throw new FormatException(String.Format(formatProvider, "Format {0} is not supported", format));
			}
		}
		
		public string ToString(string format)
		{
			return ToString(format, null);
		}
		
		public int CompareTo(Racer other)
		{
			if (other == null) return -1;
			int compare = String.Compare(this.LastName, other.LastName);
			if (compare == 0)
				return String.Compare(this.FirstName, other.FirstName);
			return compare;
		}
	}
	
	class Program
	{
		static void Main()
		{
			List<int> intList = new List<int>();
			Console.WriteLine("intList count : {0}, intList capacity : {1}", intList.Count, intList.Capacity);
			intList.Add(1);
			Console.WriteLine("intList count : {0}, intList capacity : {1}", intList.Count, intList.Capacity);
			
			// Racer
			var graham = new Racer(7, "Graham", "Hill", "UK", 14);
			var emerson = new Racer(13, "Emerson", "Fittipaldi", "Brazil", 14);
			var mario = new Racer(16, "Mario", "Andretti", "USA", 12);
			var racers = new List<Racer>(20) { graham, emerson, mario};
			
			racers.Add(new Racer(24, "Michael", "Schumacher", "Germany", 91));
			racers.Add(new Racer(27, "Mika", "Hakkinen", "Finland", 20));
			
			racers.AddRange(new Racer[] {
				new Racer(14, "Niki", "Lauda", "Austria", 25),
				new Racer(21, "Alain", "Prost", "France", 51)});
				
			racers.ForEach(Console.WriteLine);
			racers.ForEach(c => Console.WriteLine("{0:A}", c));
		}
	}
}