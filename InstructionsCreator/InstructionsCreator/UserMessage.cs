namespace InstructionsCreator
{
    /// <summary>
    /// Gathers all the user messages for console application.
    /// </summary>
    public static class UserMessage
    {
        public const string ElementsLessThanThree = "Elements count can't be less than three, maybe you forgot using spaces?";
        public const string FoundExtraSpace = "Found an extra space";
        public const string InvalidCharacter = "Found invalid character or extra operator";
        public const string CantStartWithOperator = "Can't start with an operator";
        public const string CantEndWithOperator = "Can't end with an operator";
        public const string NoSameConsElements = "Can't have consecutive elements of the same type";
    }
}
