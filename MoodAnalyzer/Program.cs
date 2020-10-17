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
            MoodAnalyzerFactory.CreateMoodAnalyzerObject("MoodAnalyzer.MoodAnalyzerClass", "MoodAnalyzerClass");
            MoodAnalyzerFactory.CreateObjectOfMoodAnalyserUsingParameterizedConstructor("MoodAnalyzer.MoodAnalyzerClass", "MoodAnalyzerClass");
            Console.WriteLine(MoodAnalyserReflector.InvokeMethodUsingReflection("AnalyzeMood", "i am any mood")); 


            //MoodAnalyzerClass moodObj = new MoodAnalyzerClass(statement);
            //Console.WriteLine(moodObj.AnalyzeMood());
        }
    }
}
