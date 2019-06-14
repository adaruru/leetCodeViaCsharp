using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpStartTest
{
    class Day4_Class_vs_Instance
    {
        public static void main()
        {
            int T = int.Parse(Console.In.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int age = int.Parse(Console.In.ReadLine());
                Person p = new Person(age);
                p.amIOld();
                for (int j = 0; j < 3; j++)
                {
                    p.yearPasses();
                }
                p.amIOld();
                Console.WriteLine();
            }
        }
    }
    class Person
    {
        public int age;
        public Person(int initialAge)
        {
            // Add some more code to run some checks on initialAge
            if (initialAge < 0)
            {
                initialAge = 0;
            }
        }
        public void amIOld()
        {
            // Do some computations in here and print out the correct statement to the console 
        }

        public void yearPasses()
        {
            // Increment the age of the person in here
        }
    }
}
