using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting.Algortihms;

namespace Algorithms.Tests
{
  [TestClass]
  public class SortingAlgorithmsTest
  {
    [TestMethod]
    public void ShouldSwapValuesInBubleSort()
    {
      //Arrange
      BubleSort bubleSort = new BubleSort();
      int n1 = 100, n2 = 150;
      int expectedn1 = 150, expectedn2 = 100;
      //Act
      bubleSort.Swap(ref n1, ref n2);

      //Assert
      Assert.AreEqual(n1,expectedn1);
      Assert.AreEqual(n2, expectedn2);
    }

    [TestMethod]
    public void ShouldSortWithBubleSort()
    {
      //Arrange
      BubleSort bubleSort = new BubleSort();
      int n1 = 100, n2 = 150;
      int expectedn1 = 150, expectedn2 = 100;
      //Act
      bubleSort.Swap(ref n1, ref n2);

      //Assert
      Assert.AreEqual(n1, expectedn1);
      Assert.AreEqual(n2, expectedn2);
    }
  }
}
