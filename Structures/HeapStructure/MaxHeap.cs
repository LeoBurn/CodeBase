using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapStructure
{
    public class MaxHeap : Heap
    {
        public MaxHeap(int capacity) : base(capacity)
        {
        }

        public override void HeapifyDown(int index)
        { 

            while (HasLeftChild(index))
            {
                var bigestValueIdx = LeftChildIdx(index);
                if (HasRightChild(index) && RightChild(index) > LeftChild(index))
                    bigestValueIdx = RightChildIdx(index);

                if (Elements[index] > Elements[bigestValueIdx])
                    break;
                else
                {
                    Swap(index, bigestValueIdx);
                }
                index = bigestValueIdx;
            }
        }

        public override void HeapifyUp(int index)
        {
            while (HasParent(index) && Elements[index] > Parent(index))
            {
                Swap(index, ParentIdx(index));
                index = ParentIdx(index);
            }
        }

        
    }
}
