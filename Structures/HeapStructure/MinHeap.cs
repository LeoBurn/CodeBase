﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapStructure
{
    public class MinHeap :  Heap
    {
        public MinHeap(int capacity) : base(capacity)
        {
        }

        public override void HeapifyDown(int index)
        {
            while (HasLeftChild(index))
            {
                int smallValueIndex = LeftChildIdx(index);
                if (HasRightChild(index) && RightChild(index) < LeftChild(index))
                    smallValueIndex = RightChildIdx(index);

                if (Elements[index] < Elements[smallValueIndex])
                    break;
                else
                {
                    Swap(index,smallValueIndex);
                }
                index = smallValueIndex;
            }
        }

        public override void HeapifyUp(int index)
        {
            while (HasParent(index) && Elements[index] < Parent(index))
            {
                Swap(index, ParentIdx(index));
                index = ParentIdx(index);
            }
        }
       
    }
}
