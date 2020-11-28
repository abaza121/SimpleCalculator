using System;

namespace InstructionsCreator
{
    /// <summary>
    /// The main console program class
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var process = true;
            var parser = new Parser();

            // The user should be able to choose how the instructions builder acts.
            Console.WriteLine("Use precedence or literal? (p/l) precedence is used by default");
            InstructionsBuilder instructionsBuilder;
            var choice = Console.ReadLine();
            if (choice == "l")
            {
                Console.WriteLine("--Using literal builder--");
                instructionsBuilder = new LiteralInstructionsBuilder();
            }
            else
            {
                Console.WriteLine("--Using precedence builder--");
                instructionsBuilder = new PrecedenceInstructionsBuilder();
            }

            while (process)
            {
                var line = Console.ReadLine();
                var elements = ProcessLine(line);

                // Validate the given mathematical operation.
                var statusLevel = parser.CheckElements(elements);
                if (statusLevel == StatusLevel.Error)
                {
                    Console.WriteLine("Error Found, Do you want to retry? \"y\" if u want to retry");
                    if (Console.ReadLine() == "y")
                        continue;
                    else
                        break;
                }

                // Build the instructions.
                var instructions = instructionsBuilder.BuildInstructions(elements, parser.ElementTypes);
                WriteInstructions(instructions);

                // Ask the user is he wants to repeat
                Console.WriteLine("\n\n ---- SUCCESS ----");
                Console.WriteLine("Do you want to retry? \"y\" if u want to retry");
                if (Console.ReadLine() == "y")
                    process = true;
                else
                    process = false;
            }
        }

        /// <summary>
        /// Writes the instruction from each array of instructions.
        /// </summary>
        /// <param name="instructions">The array to write from.</param>
        static void WriteInstructions(Instruction[] instructions)
        {
            foreach (var instruction in instructions)
            {
                Console.WriteLine(instruction);
            }
        }

        /// <summary>
        /// Process the line into seperate elements.
        /// </summary>
        /// <param name="line"0>The line to process</param>
        /// <returns>The processed elements</returns>
        static string[] ProcessLine(string line)
        {
            return line.Split(' ');
        }
    }
}
