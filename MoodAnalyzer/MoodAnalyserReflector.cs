using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MoodAnalyzer
{
    public class MoodAnalyserReflector
    {
        public static string InvokeMethodUsingReflection(string methodName, string message)
        {
            Type type = typeof(MoodAnalyzerClass);
            try
            {
                object moodAnalyzeClassObj = MoodAnalyzerFactory.CreateObjectOfMoodAnalyserUsingParameterizedConstructor(type.FullName, type.Name, message);
                MethodInfo method = type.GetMethod(methodName, new Type[0]);
                object mood = method.Invoke(moodAnalyzeClassObj, null);
                return mood.ToString();
            }
            catch
            {
                throw new MoodAnalyzeCustomException(MoodAnalyzeCustomException.ExceptionType.NO_SUCH_METHOD, "METHOD_NOT_FOUND");
            }
        }
    }
}
