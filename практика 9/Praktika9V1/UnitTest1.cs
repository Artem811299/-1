using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice9_Variant1;
using Praktika9;

namespace Practice9_Variant1.Tests
{
    [TestClass]
    public class ProgramTests
    {
        // Тесты для задания 1
        [TestMethod]
        public void f_TwoDigitNumber_ReturnsCorrectSum()
        {
            Assert.AreEqual(9, Program.f(45));
            Assert.AreEqual(5, Program.f(23));
            Assert.AreEqual(18, Program.f(99));
            Assert.AreEqual(1, Program.f(10));
        }

        [TestMethod]
        public void f_InvalidNumber_ReturnsMinusOne()
        {
            Assert.AreEqual(-1, Program.f(5));   // Однозначное
            Assert.AreEqual(-1, Program.f(100)); // Трехзначное
            Assert.AreEqual(-1, Program.f(-10)); // Отрицательное
        }

        // Тесты для задания 2
        [TestMethod]
        public void IsPrime_PrimeNumbers_ReturnsPrime()
        {
            Assert.AreEqual("Простое число", Program.IsPrime(2));
            Assert.AreEqual("Простое число", Program.IsPrime(3));
            Assert.AreEqual("Простое число", Program.IsPrime(7));
            Assert.AreEqual("Простое число", Program.IsPrime(13));
            Assert.AreEqual("Простое число", Program.IsPrime(17));
        }

        [TestMethod]
        public void IsPrime_CompositeNumbers_ReturnsComposite()
        {
            Assert.AreEqual("Составное число", Program.IsPrime(1));
            Assert.AreEqual("Составное число", Program.IsPrime(4));
            Assert.AreEqual("Составное число", Program.IsPrime(10));
            Assert.AreEqual("Составное число", Program.IsPrime(15));
            Assert.AreEqual("Составное число", Program.IsPrime(25));
        }

        // Тесты для задания 3
        [TestMethod]
        public void CalculateInternetCost_TrafficWithinLimit_ReturnsBasePrice()
        {
            Assert.AreEqual(100, Program.CalculateInternetCost(100, 10, 12, 1));
            Assert.AreEqual(100, Program.CalculateInternetCost(100, 10, 12, 10));
            Assert.AreEqual(50, Program.CalculateInternetCost(50, 20, 5, 15));
        }

        [TestMethod]
        public void CalculateInternetCost_TrafficExceedsLimit_ReturnsCorrectCost()
        {
            Assert.AreEqual(160, Program.CalculateInternetCost(100, 10, 12, 15));
            Assert.AreEqual(130, Program.CalculateInternetCost(100, 10, 10, 13));
            Assert.AreEqual(75, Program.CalculateInternetCost(50, 5, 5, 10));
        }

        [TestMethod]
        public void CalculateInternetCost_BoundaryValues_WorksCorrectly()
        {
            Assert.AreEqual(100, Program.CalculateInternetCost(100, 100, 100, 100));
            Assert.AreEqual(200, Program.CalculateInternetCost(100, 50, 2, 100));

            // Нулевые и минимальные значения
            Assert.AreEqual(100, Program.CalculateInternetCost(100, 10, 12, 0));
        }
    }
}