using System;
using Xunit;
using System.Text;


public class Kata
{
    public static string SpinWords(string sentence)
    {

        const int MinWordsToBeReversed = 5;
        StringBuilder builder = new StringBuilder();
        string[] words = sentence.Split(new char[] { ' ' });

        //foreach (string currentString in words)
        for(int x = 0; x < words.Length; x++)
        {
            string currentString = words[x];
            if (currentString.Length >= MinWordsToBeReversed)
            {
                StringBuilder reversedStringBuilder = new StringBuilder();
                for (int index = currentString.Length - 1; index >= 0; index--)
                {
                    reversedStringBuilder.Append(currentString[index]);
                }
                builder.Append(reversedStringBuilder);
                if (x != words.Length-1)
                    builder.Append(" ");
            }
            else
            {              
               builder.Append($"{currentString}");
               if (x != words.Length - 1)
                builder.Append(" ");
            }
        }

        return builder.ToString();
    }
}
    public class UnitTest1
    {
        [Fact]
        public static void Test1()
        {
            Assert.Equal("emocleW", Kata.SpinWords("Welcome"));
        }
        [Fact]
        public static void Test2()
        {
            Assert.Equal("Hey wollef sroirraw", Kata.SpinWords("Hey fellow warriors"));
        }
        [Fact]
        public static void Test3()
        {
            Assert.Equal("This is a test", Kata.SpinWords("This is a test"));
        }
        [Fact]
        public static void Test4()
        {
            Assert.Equal("This is rehtona test", Kata.SpinWords("This is another test"));
        }
        [Fact]
        public static void Test5()
        {
            Assert.Equal("You are tsomla to the last test", Kata.SpinWords("You are almost to the last test"));
        }

        [Fact]
        public static void Test6()
        {
            Assert.Equal("Just gniddik ereht is llits one more", Kata.SpinWords("Just kidding there is still one more"));
        }

}

