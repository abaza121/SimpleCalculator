namespace InstructionsCreator
{
    /// <summary>
    /// Responsible for formatting and wrapping instruction related data.
    /// </summary>
    class Instruction
    {
        private string parameter;
        private InstructionType type;

        public Instruction(string parameter, InstructionType type)
        {
            this.parameter = parameter;
            this.type = type;
        }

        public override string ToString()
        {
            return this.type.ToString() + " " + this.parameter.ToString();
        }
    }
}
