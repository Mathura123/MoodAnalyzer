using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using System.Text.RegularExpressions;

namespace MoodAnalyzer
{
    public class MoodAnalyzerFactory
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
        public static object CreateObjectOfMoodAnalyserUsingParameterizedConstructor(string className, string constructorName, string message = "")
        {
            Type type = typeof(MoodAnalyzerClass);
            if (type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo info = type.GetConstructor(new[] { typeof(string)} );
                    object instance = info.Invoke(new object[] { (message) });
                    return instance;
                }
                else
                    throw new MoodAnalyzeCustomException(MoodAnalyzeCustomException.ExceptionType.NO_SUCH_METHOD, "CONSTRUCTOR NOT FOUND");
            }
            else
                throw new MoodAnalyzeCustomException(MoodAnalyzeCustomException.ExceptionType.NO_SUCH_CLASS, "CLASS NOT FOUND");
        }
    }
}
