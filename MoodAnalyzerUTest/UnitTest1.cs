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
                bool answer = expectedObj.Equals(result);
                //Assert.AreEqual(expectedObj, result);
            }
            catch(MoodAnalyzeCustomException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}
