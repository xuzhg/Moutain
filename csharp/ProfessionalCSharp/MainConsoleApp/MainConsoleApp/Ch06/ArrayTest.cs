using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainConsoleApp.Ch06
{
    public class ArrayTest : AbstractTest
    {
        public ArrayTest(): base ("ArrayTest")
        {
        }

        protected override bool RunInternal()
        {
            int[] myArray = {4, 7, 11, 2};
            int v1 = myArray[0];
            int v2 = myArray[2];

            Console.WriteLine("V1: " + v1);
            Console.WriteLine("V2: " + v2);

            for (int i = 0; i < myArray.Length; i++)
            {
                Console.Write(myArray[i] + " ");
            }

            foreach (var i in myArray)
            {
                Console.Write(i + " | ");
            }
            Console.WriteLine();

            Person[] myPersons = new Person[2];
            myPersons[0] = new Person {FirstName = "Ayrton", LastName = "Senna"};
            myPersons[1] = new Person {FirstName = "Michael", LastName = "Schumacher"};

            foreach (var p in myPersons)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("The Rank of myPersons is " + myPersons.Rank);
            Console.WriteLine("The LongLenth of myPersons is " + myPersons.LongLength);


            Person[] persons =
            {
                new Person {FirstName = "Damon", LastName = "Hill"},
                new Person {FirstName = "Niki", LastName = "Lauda"},
                new Person {FirstName = "Ayrton", LastName = "Senna"},
                new Person {FirstName = "Graham", LastName = "Hill"},
            };
            Array.Sort(persons);
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }

            return true;
        }
    }
}
