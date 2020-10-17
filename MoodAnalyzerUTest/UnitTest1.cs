using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzer;

namespace MoodAnalyzerUTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void I_am_in_Sad_Mood_Should_Return_SAD()
        {
            //Arrange
            string expectedMood = "SAD";
            string inputMessage = "I am in Sad Mood";
            MoodAnalyzer.MoodAnalyzerClass moodObj = new MoodAnalyzer.MoodAnalyzerClass(inputMessage);

            //Act
            string result = moodObj.AnalyzeMood();

            //Assert
            Assert.AreEqual(result, expectedMood);

        }
        [TestMethod]
        public void I_am_in_Any_Mood_Should_Return_HAPPY()
        {
            string expectedMood = "HAPPY";
            string inputMessage = "I am in Any Mood";
            MoodAnalyzer.MoodAnalyzerClass moodObj = new MoodAnalyzer.MoodAnalyzerClass(inputMessage);

            //Act
            string result = moodObj.AnalyzeMood();

            //Assert
            Assert.AreEqual(result, expectedMood);
        }
        [TestMethod]
        public void Null_Should_Throw_NullExceptionCustomMessage_Mood_cannot_be_NULL()
        {
            try
            {

                string inputMessage = null;
                MoodAnalyzerClass moodObj = new MoodAnalyzerClass(inputMessage);
                string result = moodObj.AnalyzeMood();
            }
            catch(MoodAnalyzeCustomException e)
            {
                string expectedMessage = "Mood cannot be null";
                Assert.AreEqual(expectedMessage, e.Message);
            }
        }
        [TestMethod]
        public void Null_Should_Throw_EmptyMessageExceptionCustomMessage_Mood_cannot_be_Empty()
        {
            try
            {

                string inputMessage = "";
                MoodAnalyzerClass moodObj = new MoodAnalyzerClass(inputMessage);
                string result = moodObj.AnalyzeMood();
            }
            catch (MoodAnalyzeCustomException e)
            {
                string expectedMessage = "Mood cannot be Empty";
                Assert.AreEqual(expectedMessage, e.Message);
            }
        }
        [TestMethod]
        public void Given_MoodAnalyzer_Class_Name_Should_Return_MoodAnalyzer_Object()
        {
            try
            {
                string className = "MoodAnalyzer.MoodAnalyzerClass";
                string constructorName = "MoodAnalyzerClass";
                object expectedObj = new MoodAnalyzerClass();
                object result = MoodAnalyzerFactory.CreateMoodAnalyzerObject(className, constructorName);
                Assert.AreEqual(expectedObj.GetType(), result.GetType());
            }
            catch(MoodAnalyzeCustomException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
        [TestMethod]
        public void Given_Improper_MoodAnalyzer_Class_Name_Should_Throw_MoodAnalyzerException()
        {
            try
            {
                string className = "Mood.MoodAnalyzerClass";
                string constructorName = "MoodAnalyzerClass";
                object expectedObj = new MoodAnalyzerClass();
                object result = MoodAnalyzerFactory.CreateMoodAnalyzerObject(className, constructorName);
            }
            catch (MoodAnalyzeCustomException e)
            {
                string expected = "CLASS NOT FOUND";
                Assert.AreEqual(expected, e.Message);
            }
        }
        [TestMethod]
        public void Given_Improper_MoodAnalyzer_Constructor_Name_Should_Throw_MoodAnalyzerException()
        {
            try
            {
                string className = "MoodAnalyzer.MoodAnalyzerClass";
                string constructorName = "MoodAnalyzer";
                object expectedObj = new MoodAnalyzerClass();
                object result = MoodAnalyzerFactory.CreateMoodAnalyzerObject(className, constructorName);
            }
            catch (MoodAnalyzeCustomException e)
            {
                string expected = "CONSTRUCTOR NOT FOUND";
                Assert.AreEqual(expected, e.Message);
            }
        }
        [TestMethod]
        public void Given_MoodAnalyzer_In_Paratemized_Constructor_Should_Return_MoodAnalyzer_Object()
        {
            try
            {
                string className = "MoodAnalyzer.MoodAnalyzerClass";
                string constructorName = "MoodAnalyzerClass";
                object expectedObj = new MoodAnalyzerClass("Happy");
                object result = MoodAnalyzerFactory.CreateObjectOfMoodAnalyserUsingParameterizedConstructor(className, constructorName,"Happy");
                Assert.AreEqual(expectedObj.GetType(), result.GetType());
            }
            catch (MoodAnalyzeCustomException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
        [TestMethod]
        public void Given_Improper_MoodAnalyzer_Class_Name_With_Paratemized_Constructor_Should_Throw_MoodAnalyzerException()
        {
            try
            {
                string className = "Mood.MoodAnalyzerClass";
                string constructorName = "MoodAnalyzerClass";
                object expectedObj = new MoodAnalyzerClass("Happy");
                object result = MoodAnalyzerFactory.CreateObjectOfMoodAnalyserUsingParameterizedConstructor(className, constructorName,"Happy");
            }
            catch (MoodAnalyzeCustomException e)
            {
                string expected = "CLASS NOT FOUND";
                Assert.AreEqual(expected, e.Message);
            }
        }
        [TestMethod]
        public void Given_Improper_MoodAnalyzer_Constructor_Name_With_Paratemized_Constructor_Should_Throw_MoodAnalyzerException()
        {
            try
            {
                string className = "MoodAnalyzer.MoodAnalyzerClass";
                string constructorName = "MoodAnalyzer";
                object expectedObj = new MoodAnalyzerClass();
                object result = MoodAnalyzerFactory.CreateMoodAnalyzerObject(className, constructorName);
            }
            catch (MoodAnalyzeCustomException e)
            {
                string expected = "CONSTRUCTOR NOT FOUND";
                Assert.AreEqual(expected, e.Message);
            }
        }
        [TestMethod]
        public void Given_Happy_Message_Should_Return_HAPPY_Mood()
        {
            try
            {
                string methodName = "AnalyzeMood";
                string message = "I am in Happy mood";
                string expected = "HAPPY";
                string result = MoodAnalyserReflector.InvokeMethodUsingReflection(methodName, message);
                Assert.AreEqual(expected, result);
            }
            catch (MoodAnalyzeCustomException e)
            {
            }
        }
        [TestMethod]
        public void Given_Improper_Method_Name_Should_Throw_MoodAnalyzerException()
        {
            try
            {
                string methodName = "AnalyzeMod";
                string message = "I am in Happy mood";
                string result = MoodAnalyserReflector.InvokeMethodUsingReflection(methodName, message);
            }
            catch (MoodAnalyzeCustomException e)
            {
                string expected = "METHOD_NOT_FOUND";
                Assert.AreEqual(expected, e.Message);
            }
        }
        [TestMethod]
        public void Given_HAPPYMessage_WithReflector_Should_ReturnHAPPY()
        {
            string result = MoodAnalyserReflector.SetField("HAPPY", "message");
            Assert.AreEqual("HAPPY", result);
        }
    }
}
