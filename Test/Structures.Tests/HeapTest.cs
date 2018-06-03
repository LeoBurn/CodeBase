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
    public class HeapTest
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
            minHeap.Pop();
            var actualSize= minHeap.Capacity;

            //Assert
            Assert.Greater(actualSize, expectedSize);
        }


    }
}
