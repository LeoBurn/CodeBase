using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearchTree.Tests
{
    [TestClass]
    public class BinarySearchTreeTest
    {
        [TestMethod]
        public void ShouldInsertIntoBinarySearchTreeWithoutRoot()
        {
            //Arrange
            int value = 3;
            BinarySearchTree bst = new BinarySearchTree();
            
            //Act
            bst.Insert(value);
            var result = bst.Root;
            
            //Assert
            Assert.AreEqual(value,result.Data);
        }

        [TestMethod]
        public void ShouldGetSortedValuesFromBinarySearchTree()
        {
            //Arrange
            BinarySearchTree bst = new BinarySearchTree();
            Node root = new Node()
            {
                Data = 4,
                Left = new Node()
                {
                    Data = 2,
                    Left = new Node() { Data = 1 },
                    Right = new Node() { Data = 3 }
                },
                Right = new Node()
                {
                    Data = 6,
                    Left = new Node() { Data = 5 },
                    Right = new Node() { Data = 7 }
                }
            };
            bst.Root = root;
            var expectedValue = new int[] {1, 2, 3, 4, 5, 6, 7}.ToList();

            //Act
            List<int> result = bst.GetSortedValues();

            //Assert
            CollectionAssert.AreEqual(expectedValue,result);
        }
    }
}
