using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hello_UnitTests
{
    /// <summary>
    /// Summary description for BirdTest
    /// </summary>
    [TestClass]
    public class BirdTest
    {
        [TestMethod]
        public void IsBird()
        {
            // Arrange
            var expected = true;

            // Act
            Bird bird = new Bird();

            // Assert
            Assert.AreEqual(expected, bird is IBird);
            Assert.AreNotEqual(expected, bird is IFish);
        }
    }
}
