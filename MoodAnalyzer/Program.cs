using System;

namespace MoodAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mood Analyzer");
            Console.WriteLine("Enter your statement to analyze your mood");
            string statement = Console.ReadLine();
            MoodAnalyzer moodObj = new MoodAnalyzer();
            Console.WriteLine(moodObj.AnalyzeMood(statement));
        }
    }
}
