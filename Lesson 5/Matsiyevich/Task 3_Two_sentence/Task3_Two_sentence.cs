using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace Task_3_Two_sentence
{
    internal class Task3_Two_sentence
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first sentence: ");
            string firstSentence = Console.ReadLine();

            Console.WriteLine("Enter second sentence: ");
            string secondSentence = Console.ReadLine();
            Console.WriteLine("\n");

            string firstClean = Regex.Replace(firstSentence.ToLower(), "[^a-zа-я0-9 ]", "");
            string secondClean = Regex.Replace(secondSentence.ToLower(), "[^a-zа-я0-9 ]", "");

            string[] firstWords = firstClean.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] secondWords = secondClean.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            bool areEqual = firstSentence.Equals(secondSentence, StringComparison.OrdinalIgnoreCase);

            var commonWords = firstWords.Intersect(secondWords);

            /*Здесь я сравниваю длинну предложений по СИМВОЛАМ. Т.к. пробелы считаются как сивол, я не исклюючаю их из расчётов*/
            if (secondSentence.Length > firstSentence.Length)
            {
                Console.WriteLine($"1. Length of the second sentence is {secondSentence.Length}. " +
                    $"And this is more then the first setnense length ({firstSentence.Length})");
            }
            else if (secondSentence.Length < firstSentence.Length)
            {
                Console.WriteLine($"1. Length of the first sentence is {firstSentence.Length}. " +
                    $"And this is more then the second setnense length (Lenth of second sentence: {secondSentence.Length})");
            }
            else
            {
                Console.WriteLine("1. Length of the sentences is equal" + "\n" + "Lenth of first sentence: "
                    + firstSentence.Length + "\n" + "Lenth of second sentence: " + secondSentence.Length);
            }

          /*  if (firstSentence == secondSentence)
            {
                Console.WriteLine("2. Same context");
            }
            else
            {
                Console.WriteLine("2. Different context");
            }*/
                        
            if (areEqual)
            {
                Console.WriteLine("2. Sentence are equal with ignoring case");
            }
            else
            {                
                Console.WriteLine("2. Sentence are different with ignoring case");
            }

            Console.WriteLine("3.");
            Console.WriteLine($"a) Words in the first sentence: {firstWords.Length}");
            Console.WriteLine($"b) Words in the second sentence: {secondWords.Length}");

            Console.WriteLine($"4. Count of a same words: {commonWords.Count()}");

        }
    }
}
