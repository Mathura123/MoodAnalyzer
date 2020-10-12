using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyzer
{
    public class MoodAnalyzerClass
    {
        string moodRegex = ".*[ ][Ss][aA][dD][ ].*";
        string message;
        public MoodAnalyzerClass()
        {
        }
        public MoodAnalyzerClass(string message)
        {
            this.message = message;
        }

        public string AnalyzeMood()
        {
            if (Regex.IsMatch(message, moodRegex))
            {
                return "SAD";
            }
            else
                return "HAPPY";
        }
        public string AnalyzeMood(string statement)
        {
            if (Regex.IsMatch(statement, moodRegex))
            {
                return "SAD";
            }
            else
                return "HAPPY";
        }
    }
}
