using System;

namespace InstructionsCreator
{
    /// <summary>
    /// The status of the validation.
    /// </summary>
    enum StatusLevel
    {
        Accepted,
        Error
    }

    /// <summary>
    /// Responible for parsing and validating the mathematical operation, validating at element level.
    /// </summary>
    class Parser
    {
        public ElementType[] ElementTypes
        {
            get;
            private set;
        }

        /// <summary>
        /// Used for determining character types.
        /// </summary>
        private Checker checker = new Checker();

        /// <summary>
        /// Validates and instantiate <see cref="ElementTypes"/>.
        /// </summary>
        /// <param name="elements">The elements to process</param>
        /// <returns>Validation status level</returns>
        public StatusLevel CheckElements(string[] elements)
        {
            this.ElementTypes = new ElementType[elements.Length];
            if(elements.Length < 3 )
            {
                Console.WriteLine(UserMessage.ElementsLessThanThree);
                return StatusLevel.Error;
            }

            for(int i = 0;i<elements.Length;i++)
            {
                var element = elements[i];
                if(element == string.Empty)
                {
                    Console.WriteLine(UserMessage.FoundExtraSpace);
                    return StatusLevel.Error;
                }

                var type = this.checker.GetType(elements[i]);
                if(type == ElementType.Invalid)
                {
                    Console.WriteLine(UserMessage.InvalidCharacter);
                    return StatusLevel.Error;
                }

                this.ElementTypes[i] = type;
            }

            return this.TestElementTypes(ElementTypes);
        }

        /// <summary>
        /// Validates the consistency of the element types.
        /// </summary>
        /// <param name="elementTypes">the array to validate</param>
        /// <returns>Validation Status level.</returns>
        private StatusLevel TestElementTypes(ElementType[] elementTypes)
        {
            if(this.ElementTypes[0] == ElementType.Operator)
            {
                Console.WriteLine(UserMessage.CantStartWithOperator);
                return StatusLevel.Error;
            }

            if (this.ElementTypes[elementTypes.Length - 1] == ElementType.Operator)
            {
                Console.WriteLine(UserMessage.CantEndWithOperator);
                return StatusLevel.Error;
            }

            for (int i =0;i<elementTypes.Length -1;i++)
            {
                if(elementTypes[i] == elementTypes[i+1])
                {
                    Console.WriteLine(UserMessage.NoSameConsElements);
                    return StatusLevel.Error;
                }
            }

            return StatusLevel.Accepted;
        }
    }
}
