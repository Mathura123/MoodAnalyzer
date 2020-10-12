using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyzer
{
    public class MoodAnalyzer
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
