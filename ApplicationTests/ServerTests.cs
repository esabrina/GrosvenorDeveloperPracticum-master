using Application;
using Domain;
using Domain.Interfaces;
using Infrastructure.Repositories;
using NUnit.Framework;

namespace ApplicationTests
{
    [TestFixture]
    public class ServerTests
    {
        private Server _sut;
        private IDishRepository _repository;
        const string expectedTextError = "error";

        [SetUp]
        public void Setup()
        {
            _repository = new DishRepository();
            _sut = new Server(new DishManager(_repository));
        }

        [TearDown]
        public void Teardown()
        {

        }

        [Test]
        public void ErrorGetsReturnedWithBadInput()
        {
            var order = "one";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expectedTextError, actual);
        }

        [Test]
        public void CanServeSteak()
        {
            var order = Menu.evening + ",1";
            string expected = "steak";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanServe2Potatoes()
        {
            var order = Menu.evening + ",2,2";
            string expected = "potato(x2)";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanServeSteakPotatoWineCake()
        {
            var order = Menu.evening + ",1,2,3,4";
            string expected = "steak,potato,wine,cake";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanServeSteakPotatox2Cake()
        {
            var order = Menu.evening + ",1,2,2,4";
            string expected = "steak,potato(x2),cake";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanGenerateErrorWithWrongDish()
        {
            var order = Menu.evening + ",1,2,3,5";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expectedTextError, actual);
        }

        [Test]
        public void CanGenerateErrorWhenTryingToServerMoreThanOneSteak()
        {
            var order = Menu.evening + ",1,1,2,3";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expectedTextError, actual);
        }

        [TestCase(",1,3,3", "x2")]
        [TestCase(",1,3,3,3", "x3")]
        [TestCase(",3,1,3,3", "x3")]
        public void CanServeMultipleCoffeeInMorningMenu(string orderedDishes, string expectedCount)
        {
            var order = Menu.morning + orderedDishes;
            string expected = $"egg,coffee({expectedCount})";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanGenerateErrorWhenTryingToServerMoreThanOneEgg()
        {
            var order = Menu.morning + ",1,1,3";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expectedTextError, actual);
        }

        [Test]
        public void CanOrderDessertInEveningMenu()
        {
            var order = Menu.evening + ",1,3,4";
            var expected = "steak,wine,cake";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CanGenerateErrorWhenDessertIsOrderedInMorningMenu()
        {
            var order = Menu.morning + ",1,3,4";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expectedTextError, actual);
        }

        [Test]
        public void CanAcceptInputWithWhitespaces()
        {
            var order = Menu.evening + ",1  ,3 ,4";
            var expected = "steak,wine,cake";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }
    }
}