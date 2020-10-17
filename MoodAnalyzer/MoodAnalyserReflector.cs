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
        public static string SetField(string message,string fieldName)
        {
            try
            {
                MoodAnalyzerClass moodAnalyze = new MoodAnalyzerClass();
                Type type = typeof(MoodAnalyzerClass);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new MoodAnalyzeCustomException(MoodAnalyzeCustomException.ExceptionType.NO_SUCH_FIELD, "MESSAGE SHOULD NOT BE NULL");
                }
                field.SetValue(moodAnalyze, message);
                return moodAnalyze.message;
            }
            catch(NullReferenceException)
            {
                throw new MoodAnalyzeCustomException(MoodAnalyzeCustomException.ExceptionType.NO_SUCH_FIELD, "FIELD IS NOT FOUND");
            }
        }
    }
}
