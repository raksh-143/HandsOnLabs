using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using RecommendationEngine.CoreRecommender;
using System.Collections.Generic;

namespace Recommender.UnitTesting
{
    [TestClass]
    public class PearsonCoefficient_Test
    {
        private PearsonCoefficient pc = null;
        [TestInitialize]
        public void Init()
        {
           pc = new PearsonCoefficient();
        }
        [TestCleanup]
        public void CleanUp()
        {
            pc = null;
        }
        [TestMethod]
        public void TestListsOfSameLength()
        {
            double actual = pc.GetCorrelation(new List<int> { 10,4,7 },new List<int> { 10,8,9 });
            Assert.AreEqual(1,actual);
        }
        [TestMethod]
        public void TestListsOfBaseLengthLarger_1()
        {
            double actual = pc.GetCorrelation(new List<int> { 2,9,5,8 }, new List<int> { 9,3,6});
            Assert.AreEqual(-0.9724, actual);
        }
        [TestMethod]
        public void TestListsOfBaseLengthLarger_2()
        {
            double actual = pc.GetCorrelation(new List<int> { 2, 9, 5, 10 }, new List<int> { 9, 3, 6 });
            Assert.AreEqual(-0.9918, actual);
        }
        [TestMethod]
        public void TestListsOfOtherLengthLarger_1()
        {
            double actual = pc.GetCorrelation(new List<int> { 2, 9, 5 }, new List<int> { 9, 3, 6,7 });
            Assert.AreEqual(-0.9966, actual);
        }
        [TestMethod]
        public void TestListsOfOtherLengthLarger_2()
        {
            double actual = pc.GetCorrelation(new List<int> { 2, 9, 5 }, new List<int> { 9, 3, 6, 10 });
            Assert.AreEqual(-0.9966, actual);
        }
        [TestMethod]
        public void TestListsWithZeros()
        {
            double actual = pc.GetCorrelation(new List<int> { 2, 9, 5 ,0}, new List<int> { 9, 0, 6, 7 });
            Assert.AreEqual(-0.9733, actual);
        }
        
        [TestMethod]
        public void TestListsWithTen()
        {
            double actual = pc.GetCorrelation(new List<int> { 2, 10, 5, 0 }, new List<int> { 9, 0, 6, 10 });
            Assert.AreEqual(-1, actual);
        }
    }
}
