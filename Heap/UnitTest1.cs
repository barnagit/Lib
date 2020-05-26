using System;
using Xunit;
using Barna.Lib;
using System.Linq;
using System.Collections.Generic;

namespace Heap
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            MinHeapComparer c = new MinHeapComparer();
            Heap<int> h = new Heap<int>(c);
            h.Add(6);
            h.Add(2);
            h.Add(3);
            h.Add(1);
            h.Add(5);
            h.Add(0);
            Assert.True(h[0]==0);
        }
    }

    internal class MinHeapComparer : IComparer<int>{
        public int Compare(int a, int b){
            return b-a;
        }
    }
}
