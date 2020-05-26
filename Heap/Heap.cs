using System;
using System.Collections.Generic;

namespace Barna.Lib
{
    public class Heap<T>
    {
        List<T> _heap;
        IComparer<T> _comparer;
        public Heap(IComparer<T> comparer) {
            _heap = new List<T>();
            _comparer = comparer;
        }
        public void Add(T e) {
            _heap.Add(e);
            int i=_heap.Count-1;

            while (i != 0) {
                int p = Parent(i);
                if (_comparer.Compare(_heap[i],_heap[p]) > 0) {
                    T t = _heap[p];
                    _heap[p] = _heap[i];
                    _heap[i] = t;
                }
                i = p;
            }
        }
        public void Remove() {
            _heap[0] = _heap[_heap.Count-1];
            _heap.RemoveAt(_heap.Count-1);
            int i = 0;
            while (i < _heap.Count) {
                int l = Left(i);
                int r = Right(i);
                if (l < _heap.Count && _comparer.Compare(_heap[l],_heap[i]) > 0) {
                    T t = _heap[i];
                    _heap[i] = _heap[l];
                    _heap[l] = t;
                    i = l;
                }
                else if (r <_heap.Count && _comparer.Compare(_heap[r],_heap[i]) > 0) {
                    T t = _heap[i];
                    _heap[i] = _heap[r];
                    _heap[r] = t;
                    i = r;
                }
                else break;
            }
        }
        public void Remove(T e) {
            int i = 0;
            while (!_heap[i].Equals(e)) {
                i++;
            }
            while (i<_heap.Count-1) {
                _heap[i] = _heap[i+1];
                i++;
            }
            _heap.RemoveAt(i);
            i--;

            while (i>0) {
                int r,l,p;
                T t;
                if (i%2==0) {// right element 
                    r = i;
                    l = i-1;
                    p = Parent(l);
                    if (_comparer.Compare(_heap[r],_heap[l]) > 0) {
                        if (_comparer.Compare(_heap[l],_heap[p]) > 0) {
                            t = _heap[p];
                            _heap[p] = _heap[l];
                            _heap[l] = t;
                            if (Left(i) < _heap.Count) {
                                if (Right(i) < _heap.Count) i = Right(i);
                                else if (Left(i) < _heap.Count) i = Left(r);
                            }
                        }
                        else {
                            i-=2;
                        }
                    }
                    else {
                        if (_comparer.Compare(_heap[r],_heap[p]) > 0) {
                            t = _heap[p];
                            _heap[p] = _heap[r];
                            _heap[l] = t;
                            if (Left(i) < _heap.Count) {
                                if (Right(i) < _heap.Count) i = Right(i);
                                else if (Left(i) < _heap.Count) i = Left(r);
                            }
                        }
                        else {
                            i-=2;
                        }
                    }
                } 
                else { //left element only - but this is the very last element.
                    l = i;
                    p = Parent(i);
                    if (_comparer.Compare(_heap[l],_heap[p]) > 0) {
                        t = _heap[p];
                        _heap[p] = _heap[l];
                        _heap[l] = t;
                    }
                    else {
                        i-=2;
                    }
                }
            }
        }
        private int Parent(int n) {
            return (n-1)/2;
        }
        private int Left(int n) {
            return 2*n+1;
        }
        private int Right(int n) {
            return 2*n+2;
        }
        public T this[int i] {
            get {return _heap[i];}
        }

        public int Count {
            get {return _heap.Count;}
        }

    }

    public class MinHeapComparer : IComparer<int>{
        public int Compare(int a, int b){
            return b-a;
        }
    }
    public class MaxHeapComparer : IComparer<int>{
        public int Compare(int a, int b) {
            return a-b;
        }
    }
}
