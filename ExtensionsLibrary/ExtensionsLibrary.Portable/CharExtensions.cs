namespace ExtensionsLibrary
{
    public static class CharExtensions
    {
        /// <summary>
        /// Whether the char is a letter between A and Z or not
        /// </summary>
        public static bool IsLetter(this char c)
        {
            return ('A' <= c && c <= 'Z') || ('a' <= c && c <= 'z');
        }

        /// <summary>
        /// Whether the char will create a space or not.
        /// c == '\r' || c == '\n' || c == '\t' || c == '\f' || c == ' '
        /// </summary>
        public static bool IsSpace(this char c)
        {
            return (c == '\r' || c == '\n' || c == '\t' || c == '\f' || c == ' ');
        }
    }
}
