using System;

namespace InstructionsCreator
{
    /// <summary>
    /// Responsible for instructions stack building.
    /// </summary>
    abstract class InstructionsBuilder
    {
        public abstract Instruction[] BuildInstructions(string[] elements, ElementType[] types);

        protected InstructionType DetermineOperatorType(char operatorCharacter)
        {
            switch (operatorCharacter)
            {
                case '+':
                    return InstructionType.ADD;
                case '-':
                    return InstructionType.SUB;
                case '*':
                    return InstructionType.MUL;
                case '/':
                    return InstructionType.DIV;
                default:
                    Console.WriteLine("ASSERTION ERROR: this can't happen, someone really messed up");
                    return InstructionType.Invalid;
            }
        }
    }
}
