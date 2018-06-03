using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeStructure
{
    public class BinarySearchTree
    {
        public Node Root { get; set; }

        /// <summary>
        /// Check if Binary Search Is Empty
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => Root == null;

        /// <summary>
        /// Check if Binary Search Is Valid Tree
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return CheckIfBinarySearchTreeIsValid(Root, Int32.MinValue, Int32.MaxValue);
;       }

        /// <summary>
        /// Insert into BST, this method not change the structer to balance the BST
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Insert(int value)
        {
            Root = Insert(Root, value);
        }

        /// <summary>
        /// Get Sorted Values of BST
        /// </summary>
        /// <returns></returns>
        public List<int> GetSortedValues()
        {
            List<int> values = new List<int>();
            GetSortedValues(Root, values);
            return values;
        }

        private void GetSortedValues(Node root, List<int> values)
        {
            if (root != null)
            {
                GetSortedValues(root.Left,values);
                values.Add(root.Data);
                GetSortedValues(root.Right,values);
            }
        }

        #region Private Members

        private static bool CheckIfBinarySearchTreeIsValid(Node node, int min,int max)
        {
            if (node == null)
                return true;

            if (node.Data < min || node.Data > max)
                return false;

            return (CheckIfBinarySearchTreeIsValid(node.Left, min, node.Data - 1) &&
                    CheckIfBinarySearchTreeIsValid(node.Right, node.Data + 1, max));
        }


        private static Node Insert(Node root, int key)
        {
            if (root == null)
            {
                root = new Node() {Data = key};
                return root;
            }

            if (key < root.Data)
                root.Left = Insert(root.Left, key);
            else if (key > root.Data)
                root.Right = Insert(root.Right, key);

            /* return the (unchanged) node pointer */
            return root;
        }

        #endregion

    }
}
