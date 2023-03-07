using System;
using System.Collections.Generic;
using System.Linq;
using Application;
using Domain;
using Domain.Interfaces;
using Infrastructure.Repositories;
using NUnit.Framework;


namespace ApplicationTests
{
    [TestFixture]
    public class DishManagerTests
    {
        private DishManager _sut;
        private IDishRepository _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new DishRepository();
            _sut = new DishManager(_repository);
        }

        [Test]
        public void EmptyListReturnsEmptyList()
        {
            var expected = 0;
            var order = new Order(Menu.morning.ToString());
            var actual = _sut.GetDishes(order);

            Assert.AreEqual(expected, actual.Count);
        }

        [Test]
        public void ListWith1ReturnsOneSteak()
        {
            var expected = 1;
            var expectedName = "steak";

            var order = new Order(Menu.evening.ToString())
            {
                Dishes = new List<int> {1}
            };
            var actual = _sut.GetDishes(order);

            Assert.AreEqual(expected, actual.Count);
            Assert.AreEqual(expectedName, actual.First().DishName);
            Assert.AreEqual(expected, actual.First().Count);
        }

        [Test]
        public void EmptyMenuReturnsError()
        {
            var expected = $"Menu {string.Empty} does not exist";
            var ex = Assert.Throws<ArgumentException>(() => new Order(string.Empty));
            Assert.That(ex.Message, Does.Contain(expected));
        }

        [Test]
        public void InvalidMenuReturnsError()
        {
            var order = "afternoon";
            var expected = $"Menu {order} does not exist";
            var ex = Assert.Throws<ArgumentException>(() => new Order(order));
            Assert.That(ex.Message, Does.Contain(expected));
        }
    }
}
