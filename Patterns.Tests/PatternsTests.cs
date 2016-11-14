using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singleton.Pattern;

namespace Patterns.Tests
{
  [TestClass]
  public class PatternsTests
  {
    [TestMethod]
    public void ShouldTestSingleTonPatternSingleThread()
    {
      //Arrange
      Service serviceOne, serviceTwo;
      int serviceOneHashCode, serviceTwoHashCode;

      //Act
      serviceOne = Service.Instance;
      serviceTwo = Service.Instance;

      serviceOneHashCode = serviceOne.GetHashCode();
      serviceTwoHashCode = serviceTwo.GetHashCode();

      //Assert
      Assert.AreEqual(serviceOneHashCode,serviceTwoHashCode);
    }
  }
}
