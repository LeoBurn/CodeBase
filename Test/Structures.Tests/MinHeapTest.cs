using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeapStructure;

namespace Structures.Tests
{
    [TestFixture]
    public class MinHeapTest
    {
        [Test]
        public void ShouldInsertElementInEmptyMinHeap()
        {
            //Arrange
            int value = 1;
            int capacity = 3;
            MinHeap minHeap = new MinHeap(capacity);

            //Act
            minHeap.Insert(value);
            var result = minHeap.Peek();

            //Assert
            Assert.True(IsHeap(minHeap.Elements, minHeap.Size));
            Assert.AreEqual(value,result);
        }

        [Test]
        public void ShouldGrowUpHeap()
        {
            //Arrange
            int value = 1;
            int capacity = 2;
            MinHeap minHeap = new MinHeap(capacity);

            //Act
            minHeap.Insert(value);
            minHeap.Insert(value*2);
            minHeap.Insert(value * 2);
            var actualCapacity = minHeap.Capacity;

            //Assert
            Assert.True(IsHeap(minHeap.Elements, minHeap.Size));
            Assert.Greater(actualCapacity, capacity);
        }

        [Test]
        public void ShouldDeleteInsertedElement()
        {
            //Arrange
            int value = 1;
            int capacity = 2;
            MinHeap minHeap = new MinHeap(capacity);
            var expectedSize = 0;

            //Act
            minHeap.Insert(value);
            var deleteElement = minHeap.Pop();
            var actualSize = minHeap.Size;

            //Assert
            Assert.True(IsHeap(minHeap.Elements, minHeap.Size));
            Assert.AreEqual(actualSize, expectedSize);
            Assert.AreEqual(value, deleteElement);
        }

        [Test]
        public void ShouldInsertBunchOfElements()
        {
            //Arrange
            int capacity = 5;
            MinHeap minHeap = new MinHeap(capacity);
            var values = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 55, 5, 45, 110 };
            var expectedValue = new int[] { 5, 20, 10, 40, 50, 30, 70, 80, 90, 100, 55, 60, 45, 110 };
            var expectedSize = values.Length;

            //Act
            foreach (var val in values)
                minHeap.Insert(val);

            //Assert
            Assert.True(IsHeap(minHeap.Elements, minHeap.Size));
            Assert.AreEqual(expectedSize, minHeap.Size);
            CollectionAssert.AreEqual(expectedValue, minHeap.Elements.Take(minHeap.Size));
        }

        [Test]
        public void ShouldDeleteSpecifiedValue()
        {
            //Arrange
            int capacity = 5;
            MinHeap maxHeap = new MinHeap(capacity);
            var values = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 55, 5, 45, 110 };
            var expectedValue = new int[] { 5, 40, 10, 80, 50 ,30 , 70, 110, 90, 100, 55, 60, 45};
            var expectedSize = values.Length - 1;
            var deleteValue = 20;

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
                    if (arr[i] > arr[2 * i + 1])
                        return false;
                }
                if (2 * i + 2 < n)
                {
                    if (arr[i] > arr[2 * i + 2])
                        return false;
                }

            }
            return true;
        }


    }
}
