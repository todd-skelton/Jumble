using Jumble;
using System;

namespace ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // salt options: length.
            var saltOptions = new SaltGeneratorOptions(32);

            // salt generator
            var saltGenerator = new SaltGenerator(saltOptions);

            // hash options: iterations and length.
            var hashOptions = new HashGeneratorOptions(32, 256);

            // hash generator: options and salt generator.
            var hashGenerator = new HashGenerator(hashOptions, saltGenerator);

            Console.WriteLine("Enter a password: ");

            string input = Console.ReadLine();

            // generates a new hash
            var hash = hashGenerator.Generate(input);

            Console.WriteLine();

            // prints the hash
            Console.WriteLine($"Your hash is: {hash}");

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
