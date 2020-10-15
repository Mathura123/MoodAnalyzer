using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyzer
{
    public class MoodAnalyzerClass
    {
        string moodRegex = "(.*[ ])*[Ss][aA][dD]([ ].*)*";
        string message;
        public MoodAnalyzerClass()
        {
        }
        public MoodAnalyzerClass(string message)
        {
            this.message = message;
        }
        public string AnalyzeMood(string statement)
        {
            try
            {
                if (Regex.IsMatch(statement, moodRegex))
                {
                    return "SAD";
                }
                else
                    return "HAPPY";
            }
            catch
            {
                return "HAPPY";
            }
        }
        public string AnalyzeMood()
        {
            try
            {
                if(message.Equals(string.Empty))
                {
                    throw new MoodAnalyzeCustomException(MoodAnalyzeCustomException.ExceptionType.EMPTY_MESSAGE, "Mood cannot be Empty");
                }
                else if (Regex.IsMatch(message, moodRegex))
                {
                    return "SAD";
                }
                else
                    return "HAPPY";
            }
            catch(NullReferenceException)
            {
                throw new MoodAnalyzeCustomException(MoodAnalyzeCustomException.ExceptionType.NULL_EXCEPTION, "Mood cannot be null");
            }
        }
    }
}
