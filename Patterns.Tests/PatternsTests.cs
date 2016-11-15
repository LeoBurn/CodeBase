using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singleton.Pattern;
using TemplateMethod.Pattern.Employee;
using TemplateMethod.Pattern.Worker;

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

    [TestMethod]
    public void ShouldTestTemplateMethodPattern()
    {
      //Arrange
      Employee employee1 = new Mechanic();
      Employee employee2 = new Plumber();

      IWorker mechanicWorker;
      IWorker plumberWorker;

      //Act
      mechanicWorker = employee1.DoWork();
      plumberWorker = employee2.DoWork();

      //Assert
      Assert.AreEqual(mechanicWorker.GetType(),typeof(MechanicWorker));
      Assert.AreEqual(plumberWorker.GetType(), typeof(PlumberWorker));


    }
  }
}
