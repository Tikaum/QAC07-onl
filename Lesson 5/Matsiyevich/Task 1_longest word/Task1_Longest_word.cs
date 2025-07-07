namespace Task_1_longest_word
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userText = Console.ReadLine();
            
            string[] strings = userText.Split(' ');
            //Console.WriteLine(string.Join("\n", strings));

            string longesrWord = "";            
            
            foreach (string s in strings)
            {
               
                if (s.Length > longesrWord.Length)
                {
                    longesrWord = s;
                }
            }
            Console.WriteLine(longesrWord);
        }
    }
}
