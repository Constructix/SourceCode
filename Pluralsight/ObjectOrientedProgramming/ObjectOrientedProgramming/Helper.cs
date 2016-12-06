using System.Text;

namespace ObjectOrientedProgramming
{
    public static class Helper
    {
        public static string InsertSpace(string source)
        {
            StringBuilder result = new StringBuilder();

            for (int index = 0; index < source.Length; index++)
            {
                if (index != 0)
                {
                    if (char.IsUpper(source[index]) && (source[index-1] !=' '))
                    {
                        result.Append(" ");
                    }
                }

                result.Append(source[index]);
            }
            return result.ToString();
        }

        public static string InsertSpaceWithCapitalSeparator(this string source)
        {
           return InsertSpace(source);
        }
    }
}