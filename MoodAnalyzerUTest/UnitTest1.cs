using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            MoodAnalyzer.MoodAnalyzerClass moodObj = new MoodAnalyzer.MoodAnalyzerClass();

            //Act
            string result = moodObj.AnalyzeMood(inputMessage);

            //Assert
            Assert.AreEqual(result, expectedMood);

        }
    }
}
