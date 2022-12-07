namespace BinaryTreeSearchVisualizer.src
{
    internal static class Utils
    {
        public static long ExtractNumber(string input)
        {
            var success = long.TryParse(input, out long result);
            if (success)
            {
                return result;
            }
            throw new Exception("Entered value is not a number");
        }
    }
}
