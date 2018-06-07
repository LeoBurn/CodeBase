using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeapStructure;
using NUnit.Framework;

namespace Structures.Tests
{
    [TestFixture]
    public class MaxHeapTest
    {
        [Test]
        public void ShouldInsertElementInEmptyMinHeap()
        {
            //Arrange
            int value = 1;
            int capacity = 3;
            MaxHeap maxHeap = new MaxHeap(capacity);

            //Act
            maxHeap.Insert(value);
            var result = maxHeap.Peek();

            //Assert
            Assert.True(IsHeap(maxHeap.Elements, maxHeap.Size));
            Assert.AreEqual(value, result);
        }

        [Test]
        public void ShouldGrowUpHeap()
        {
            //Arrange
            int value = 1;
            int capacity = 2;
            MaxHeap maxHeap = new MaxHeap(capacity);

            //Act
            maxHeap.Insert(value);
            maxHeap.Insert(value * 2);
            maxHeap.Insert(value * 2);
            var actualCapacity = maxHeap.Capacity;

            //Assert
            Assert.True(IsHeap(maxHeap.Elements, maxHeap.Size));
            Assert.Greater(actualCapacity, capacity);
        }

        [Test]
        public void ShouldDeleteInsertedElement()
        {
            //Arrange
            int value = 1;
            int capacity = 2;
            MaxHeap maxHeap = new MaxHeap(capacity);
            var expectedSize = 0;

            //Act
            maxHeap.Insert(value);
            var deleteElement = maxHeap.Pop();
            var actualSize = maxHeap.Size;

            //Assert
            Assert.True(IsHeap(maxHeap.Elements, maxHeap.Size));
            Assert.AreEqual(actualSize, expectedSize);
            Assert.AreEqual(value, deleteElement);
        }

        [Test]
        public void ShouldInsertBunchOfElements()
        {
            //Arrange
            int capacity = 5;
            MaxHeap maxHeap = new MaxHeap(capacity);
            var values = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 55, 5, 45, 110 };
            var expectedValue = new int[] { 110, 90, 100, 70, 80, 45, 60, 10, 40, 30, 55, 5, 20, 50 };
            var expectedSize = values.Length;

            //Act
            foreach (var val in values)
                maxHeap.Insert(val);

            //Assert
            Assert.True(IsHeap(maxHeap.Elements,maxHeap.Size));
            Assert.AreEqual(expectedSize, maxHeap.Size);
            CollectionAssert.AreEqual(expectedValue, maxHeap.Elements.Take(maxHeap.Size));
        }

        [Test]
        public void ShouldDeleteSpecifiedValue()
        {
            //Arrange
            int capacity = 5;
            MaxHeap maxHeap = new MaxHeap(capacity);
            var values = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 55, 5, 45, 110 };
            var expectedValue = new int[] { 110, 80, 100, 70, 55, 45, 60, 10, 40, 30, 50, 5, 20};
            var expectedSize = values.Length - 1;
            var deleteValue = 90;

            //Act
            foreach (var val in values)
                maxHeap.Insert(val);

            maxHeap.Delete(deleteValue);


            //Assert
            Assert.True(IsHeap(maxHeap.Elements, maxHeap.Size));
            Assert.AreEqual(expectedSize, maxHeap.Size);
            CollectionAssert.AreEqual(expectedValue, maxHeap.Elements.Take(maxHeap.Size));
        }

        private bool IsHeap(int[] arr, int n)
        {
            int i;

            for (i = 0; i <= (n - 2) / 2; i++)
            {
                if (2 * i + 1 < n)
                {
                    if (arr[i] < arr[2 * i + 1])
                        return false;
                }
                if (2 * i + 2 < n)
                {
                    if (arr[i] < arr[2 * i + 2])
                        return false;
                }

            }
            return true;
        }
    }
}
