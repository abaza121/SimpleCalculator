using System;
using System.Collections.Generic;

namespace InstructionsCreator
{
    /// <summary>
    /// Builds the instructions stack with operator precedence in mind.
    /// </summary>
    class PrecedenceInstructionsBuilder : InstructionsBuilder
    {
        /// <summary>
        /// Build the instructions based on the given elements and types.
        /// </summary>
        /// <param name="elements">the elements to process</param>
        /// <param name="types">the type of each element</param>
        /// <returns>The array of instructions built.</returns>
        public override Instruction[] BuildInstructions(string[] elements, ElementType[] types)
        {
            var instructions = new Instruction[elements.Length + 1];
            this.ConvertToPostfix(ref elements, ref types);
            for (int i = 0; i < elements.Length; i++)
            {
                if (types[i] == ElementType.Operator)
                {
                    var instructionType = this.DetermineOperatorType(elements[i][0]);
                    instructions[i] = new Instruction(string.Empty, instructionType);
                }
                else
                {
                    instructions[i] = new Instruction(elements[i], InstructionType.PUSH);
                }
            }

            instructions[elements.Length] = new Instruction(string.Empty, InstructionType.PRINT);
            return instructions;
        }

        /// <summary>
        /// Sorts elements to be postfix instead of infix.
        /// </summary>
        /// <param name="elements">elements to be sorted</param>
        /// <param name="types">types to be sorted in the same way</param>
        private void ConvertToPostfix(ref string[] elements, ref ElementType[] types)
        {
            var postfixElements = new string[elements.Length];
            var postfixTypes = new ElementType[elements.Length];
            var counter = 0;
            char arrival;
            Stack<char> operatorsStack = new Stack<char>();

            for (int i =0;i< elements.Length;i++)
            {
                switch(types[i])
                {
                    case ElementType.Number:
                        postfixElements[counter] = elements[i];
                        postfixTypes[counter] = types[i];
                        counter++;
                        break;
                    case ElementType.Operator:
                        var c = elements[i][0];
                        if (operatorsStack.Count != 0 && Predecessor(operatorsStack.Peek(), c))
                        {
                            // Found a predecessor with higher precedence, keep popping until the new operator is highest.
                            arrival = operatorsStack.Pop();
                            while (Predecessor(arrival, c))
                            { 
                                postfixElements[counter] = arrival.ToString();
                                postfixTypes[counter] = ElementType.Operator;
                                counter++;

                                if (operatorsStack.Count == 0)
                                    break;

                                if(Predecessor(operatorsStack.Peek(), c))
                                {
                                    arrival = operatorsStack.Pop();
                                }
                                else
                                {
                                    break;
                                }
                            }
                            operatorsStack.Push(c);
                        }
                        else
                        {
                            operatorsStack.Push(c);
                        }

                        break;
                    default:
                        Console.WriteLine("ASSERTION ERROR: This shouldn't happen, found invalid element type");
                        break;
                }
            }
         
            // Empty up the stack.
            while (operatorsStack.Count > 0)
            {
                arrival = operatorsStack.Pop();
                postfixElements[counter] = arrival.ToString();
                postfixTypes[counter] = ElementType.Operator;
                counter++;
            }

            elements = postfixElements;
            types = postfixTypes;
            return;
        }

        private bool Predecessor(char firstOperator, char secondOperator)
        {
            string opString = "+-*/";

            int firstPoint, secondPoint;

            int[] precedence = {12, 12, 13, 13};

            firstPoint = opString.IndexOf(firstOperator);
            secondPoint = opString.IndexOf(secondOperator);

            return (precedence[firstPoint] >= precedence[secondPoint]) ? true : false;
        }
    }
}
