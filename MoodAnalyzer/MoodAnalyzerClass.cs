using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyzer
{
    public class MoodAnalyzerClass
    {
        string moodRegex = ".*[ ][Ss][aA][dD][ ].*";
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
