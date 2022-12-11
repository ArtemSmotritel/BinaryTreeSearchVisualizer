namespace BinaryTreeSearchVisualizer.src
{
    internal static class Utils
    {
        public static long GetNumber(TextBox textBox)
        {
            var success = long.TryParse(textBox.Text, out long result);
            if (success)
            {
                return result;
            }
            throw new Exception("Entered value is not a number");
        }
    }
}
