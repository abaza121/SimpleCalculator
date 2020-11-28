using System.Linq;

namespace InstructionsCreator
{
    /// <summary>
    /// The type of an element
    /// </summary>
    enum ElementType
    {
        Number,
        Operator,
        Invalid
    }


    /// <summary>
    /// Responsible for validating and determining Element types, validating at character level.
    /// </summary>
    class Checker
    {
        /// <summary>
        /// The type of a character that is part of an element.
        /// </summary>
        private enum CharacterType
        {
            Number,
            Operator,
            InvalidCharacter
        }

        /// <summary>
        /// Gets the type of the given elemnt.
        /// </summary>
        /// <param name="element">the element to validate</param>
        /// <returns>the element type</returns>
        public ElementType GetType(string element)
        {
            var characterTypes = new CharacterType[element.Length];
            for(int i =0;i<element.Length;i++)
            {
                characterTypes[i] = this.DetermineCharacterType(element[i]);
            }

            if(characterTypes.All(type => type == CharacterType.Number))
            {
                return ElementType.Number;
            }
            else if(characterTypes[0] == CharacterType.Operator && element.Length == 1)
            {
                return ElementType.Operator;
            }
            else
            {
                return ElementType.Invalid;
            }

        }

        private CharacterType DetermineCharacterType(char c)
        {
            if(this.IsNumber(c))
            {
                return CharacterType.Number;
            }
            else if(this.IsOperator(c))
            {
                return CharacterType.Operator;
            }
            else
            {
                return CharacterType.InvalidCharacter;
            }
        }

        private bool IsNumber(char character)
        {
            return char.IsDigit(character);
        }

        private bool IsOperator(char character)
        {
            switch (character)
            {
                case '+':
                case '-':
                case '*':
                case '/':
                    return true;
                default:
                    return false;
            }
        }
    }
}
