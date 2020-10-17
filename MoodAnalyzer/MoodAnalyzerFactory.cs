using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using System.Text.RegularExpressions;

namespace MoodAnalyzer
{
    class MoodAnalyzerFactory
    {
        public static object CreateMoodAnalyzerObject(string className,string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match match = Regex.Match(className,pattern);
            if(match.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type type = assembly.GetType(className);
                    return Activator.CreateInstance(type);
                }
                catch
                {
                    throw new MoodAnalyzeCustomException(MoodAnalyzeCustomException.ExceptionType.NO_SUCH_CLASS, "CLASS NOT FOUND");
                }
            }
            else
            {
                throw new MoodAnalyzeCustomException(MoodAnalyzeCustomException.ExceptionType.NO_SUCH_METHOD, "CONSTRUCTOR NOT FOUND");
            }
        }
    }
}
