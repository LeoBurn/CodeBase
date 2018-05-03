using System;
using Adapter.Pattern.Bear;
using Adapter.Pattern.Dog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singleton.Pattern;
using TemplateMethod.Pattern.Employee;
using TemplateMethod.Pattern.Worker;

namespace Patterns.Tests
{
  [TestClass]
  public class PatternsTests
  {
    /// <summary>
    /// The instance of (Service) it's the same in every single call of Instance Propertie.
    /// </summary>
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

    /// <summary>
    /// I haver a generic abstract class Employee that have a implementation of method work that returns the result of doWork ( abstract method)
    //  the implementation of doWork only be implementated in specified Employee( Mechanic, Plumber).
    /// </summary>
    [TestMethod]
    public void ShouldTestTemplateMethodPattern()
    {
      //Arrange
      Employee employee1 = new Mechanic();
      Employee employee2 = new Plumber();

      IWorker mechanicWorker;
      IWorker plumberWorker;

      //Act
      mechanicWorker = employee1.Work();
      plumberWorker = employee2.Work();

      //Assert
      Assert.AreEqual(mechanicWorker.GetType(),typeof(MechanicWorker));
      Assert.AreEqual(plumberWorker.GetType(), typeof(PlumberWorker));


    }
    /// <summary>
    /// In This test our application only have Bears , but i need to include dogs in this application without modify existing contracts
    /// The DogAdapter it's a Bear
    /// </summary>
    [TestMethod]
    public void ShouldTestAdapterPatterns()
    {
      //Arrange
      IBear polarBear = new PolarBear();
      IDog borderCollie = new BorderCollie();
      IBear dogAdapter = new DogAdapter(borderCollie);

      string polarBearRoar, borderCollieBark, dogAdapterRoar;

      //Act
      polarBearRoar = polarBear.Roar;
      borderCollieBark = borderCollie.Bark;
      dogAdapterRoar = dogAdapter.Roar;

      //Assert
      Assert.IsNotNull(polarBearRoar);
      Assert.AreEqual(borderCollieBark, dogAdapterRoar);

    }
  }
}
