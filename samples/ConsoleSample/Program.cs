using Jumble;
using System;

namespace ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a new hash generator
            var hashGenerator = new HashGenerator();

            Console.WriteLine("Enter a password: ");

            string input = Console.ReadLine();

            // generates a new hash
            var hash = hashGenerator.Generate(input);

            Console.WriteLine();

            // prints the hash
            Console.WriteLine($"Your hash is: {hash}");

            Console.WriteLine($"Hash length: {hash.ToString().Length}");

            Console.WriteLine();

            Console.WriteLine("Enter a password to see if it matches or -1 to quit.");

            while (true)
            {
                var match = Console.ReadLine();

                if (match == "-1")
                    break;

                Console.WriteLine();

                // validates the second input against the hash
                Console.WriteLine($"Password match: {hashGenerator.Validate(hash, match)}");
            }
        }
    }
}
