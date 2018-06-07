using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapStructure
{
    public abstract class Heap
    {
        public int Capacity { get; protected set; }

        public int[] Elements { get; protected set; }
        public int Size { get; protected set; }

        protected Heap(int capacity)
        {
            Capacity = capacity;
            Elements = new int[capacity];
            Size = 0;
        }

      

        /// <summary>
        /// Verifity if heap needs to GrowUp then insert element and after
        /// that heapifyUp element
        /// </summary>
        /// <param name="element"></param>
        public void Insert(int element)
        {
            //Validate If needs to GrowUp
            GrowUpHeap();

            Elements[Size] = element;
            ++Size;
            HeapifyUp(Size-1);
        }
        
        /// <summary>
        /// Return the root of heap without remove the element
        /// </summary>
        /// <returns></returns>
        public int Peek()
        {
            if(Size == 0) throw new InvalidOperationException("Empty Heap");
            return Elements[0];
        }

        /// <summary>
        /// Return the root of heap and remove the item
        /// </summary>
        /// <returns></returns>
        public int Pop()
        {
            if (Size == 0) throw new InvalidOperationException("Empty Heap");
            int item = Elements[0];
            Elements[0] = Elements[Size - 1];
            --Size;
            HeapifyDown(0);
            return item;
        }

        /// <summary>
        /// Delete Item specified and Heapify
        /// </summary>
        /// <param name="element"></param>
        public void Delete(int element)
        {
            if (Elements[Size - 1] == element)
            {
                --Size;
                return;
            }

            for (var i = 0; i < Size; ++i)
            {
                if (Elements[i] == element)
                {
                    Elements[i] = Elements[Size - 1];
                    --Size;
                    HeapifyDown(i);
                    return;
                }
            }

        }

        public bool IsEmpty => Size == 0;

        #region Abstract Members

        public abstract void HeapifyDown(int index);

        public abstract void HeapifyUp(int index);


        #endregion

        #region Private Members


        protected int Parent(int idx) => Elements[ParentIdx(idx)];
        protected int LeftChild(int idx) => Elements[LeftChildIdx(idx)];
        protected int RightChild(int idx) => Elements[RightChildIdx(idx)];

        protected int ParentIdx(int idx) => (idx - 1) / 2;
        protected int LeftChildIdx(int idx) => (idx * 2) + 1;
        protected int RightChildIdx(int idx) => (idx * 2) + 2;

        protected bool HasParent(int idx) => ParentIdx(idx) >= 0;
        protected bool HasLeftChild(int idx) => LeftChildIdx(idx) < Size;
        protected bool HasRightChild(int idx) => RightChildIdx(idx) < Size;

        private void GrowUpHeap()
        {
            if (Size == Capacity)
            {
                Capacity = Capacity * 2;
                var newHeap = new int[Capacity];
                Array.Copy(Elements, newHeap, Capacity / 2);
                Elements = newHeap;
            }
        }

        protected void Swap(int source, int dest)
        {
            var temp = Elements[source];
            Elements[source] = Elements[dest];
            Elements[dest] = temp;
        }

        #endregion


    }
}
