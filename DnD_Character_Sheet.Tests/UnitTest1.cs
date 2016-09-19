using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DnD_Character_Sheet;

namespace DnD_Character_Sheet.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            AbilityScores scores = new AbilityScores();
            int i = 4;
            int[] testScore = new int[2] { i, -3 };
            scores.SetStat("Strength", i);
            Assert.AreEqual(testScore[1], scores.Scores["Strength"][1]);            
        }
    }
}
