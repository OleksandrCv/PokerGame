﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerLibrary;
using NUnit.Framework;

namespace PokerLibraryTests
{
    [TestFixture]
    public class ValidatorTest
    {
        [Test]
        public void Validator_ValidateFormat_Positive() {
            //Arrange
            var input = "Joe, 3H,   4D,   5H, 6H, 8H";
            //Act
            var result = Validator.ValidateFormat(input);
            //Assert
            Assert.IsTrue(result); 
        }

        [Test]
        public void Validator_ValidateFormat_Negative()
        {
            //Arrange
            var input = "Joe, 3H, 12D, , 5H, 6H, 8H";
            //Act
            var result = Validator.ValidateFormat(input);
            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Validator_IsValidGameRules_Positive()
        {
            var players = TestHelper.CreateData(true);
            //var input2 = "Bob, JC, AD, 5S, 8C, 10D";
            //var input3 = " Sally , AC, 10C, 5C, 8S, 2C";
            
            //Act
            var result = Validator.IsValidGameRules(players);
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Validator_IsValidGameRules_Negative() {
            //Arrange
            var players = TestHelper.CreateData(false);
            //Act
            var result = Validator.IsValidGameRules(players);
            //Assert
            Assert.IsFalse(result);
        }
    }
}
