﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Randomizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Model.Tests
{
    [TestClass()]
    public class RandomizerEngineTests
    {

        [TestMethod()]
        public void GetElementsTest()
        {
            //Arrange
            var testCollection = new List<IRandomElement>();

            for (int i = 1; i <= 100; i++)
            {
                var element = new RandomElement(i);
                testCollection.Add(element);
            }

            //Act
            var randomizerEngine = new RandomizerEngine();
            var randomElements = randomizerEngine.GetElements(testCollection.AsQueryable(), 3);

            Assert.IsTrue(!randomElements.Except(testCollection).Any());
        }

        [TestMethod()]
        public void GetElementTest()
        {
            //Arrange
            var testCollection = new List<IRandomElement>();

            for (int i = 1; i <= 100; i++)
            {
                var element = new RandomElement(i);
                testCollection.Add(element);
            }

            //Act
            var randomizerEngine = new RandomizerEngine();
            var randomElement = randomizerEngine.GetElement(testCollection.AsQueryable());

            Assert.IsTrue(testCollection.Any(e => e.ID == randomElement.ID));
        }

        [TestMethod()]
        public void ShuffleTest()
        {
            //Arrange
            var testCollection = new List<IRandomElement>();

            for (int i = 1; i <= 100; i++)
            {
                var element = new RandomElement(i);
                testCollection.Add(element);
            }

            //Act
            var randomizerEngine = new RandomizerEngine();
            var shuffledElements = randomizerEngine.Shuffle(testCollection.AsQueryable());

            Assert.IsTrue(testCollection.SequenceEqual(shuffledElements.OrderBy(e => e.ID).ToList()));
        }
    }
}