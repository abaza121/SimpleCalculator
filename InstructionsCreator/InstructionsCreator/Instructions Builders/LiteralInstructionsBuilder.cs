namespace InstructionsCreator
{
    /// <summary>
    /// Builds the instructions stack in literal way, no consideration for precedence of operators.
    /// </summary>
    class LiteralInstructionsBuilder : InstructionsBuilder
    {
        /// <summary>
        /// Builds the instructions array using the given elements and types
        /// </summary>
        /// <param name="elements">seperated operation elements</param>
        /// <param name="types">types of each element</param>
        /// <returns>the resulted array of instructions</returns>
        public override Instruction[] BuildInstructions(string[] elements, ElementType[] types)
        {
            var instructions = new Instruction[elements.Length + 1];

            for (int i = 0; i < elements.Length; i++)
            {
                if (types[i] == ElementType.Operator)
                {
                    var instructionType = this.DetermineOperatorType(elements[i][0]);
                    instructions[i] = new Instruction(elements[i + 1], InstructionType.PUSH);
                    instructions[i + 1] = new Instruction(string.Empty, instructionType);
                    i++;
                }
                else
                {
                    instructions[i] = new Instruction(elements[i], InstructionType.PUSH);
                }
            }

            instructions[elements.Length] = new Instruction(string.Empty, InstructionType.PRINT);
            return instructions;
        }
    }
}
