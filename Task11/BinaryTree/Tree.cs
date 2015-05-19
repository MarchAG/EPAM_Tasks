using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    [Serializable]
    public class Tree<T> : IEnumerable<T>,ICollection<T>
        where T : IComparable, ICloneable
    {
        [Serializable]
        class Node<T> 
        {
            public T Value{get; set;}
            public Node<T> ChildLeft { get; set; }
            public Node<T> ChildRight { get; set; }
            public Node(T value)
            {
                this.Value = value;
            }
        }

        private static int count;
        private Node<T> root;

        public Tree()
        {
            count = 0;
        }

        public void Add(T value)
        {
            Node<T> node = new Node<T>(value);
            count++;

            if (root == null)
            {
                root = node;
                return;
            }

            Node<T> current = root, parent = null;

            while (current != null)
            {
                parent = current;
                if (value.CompareTo(current.Value) < 0)
                    current = current.ChildLeft;
                else
                    current = current.ChildRight;
            }

            if (value.CompareTo(parent.Value) < 0)
                parent.ChildLeft = node;
            else
                parent.ChildRight = node;
        }

        private Node<T> Next(Node<T> value,out Node<T> parent)
        {
            parent = value;
            while(value.ChildLeft != null)
            {
                parent = value;
                value = value.ChildLeft;
            }
            return value;
        }

        public IEnumerable<T> GetElements()
        {
            Node<T> current = root.ChildLeft;
            Stack<Node<T>> previous = new Stack<Node<T>>();
            previous.Push(root);
            while (previous.Count > 0 || current != null)
            {
                if (current == null)
                {
                    current = previous.Pop();
                    yield return current.Value;
                    current = current.ChildRight;
                }
                else
                {
                    previous.Push(current);
                    current = current.ChildLeft;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetElements().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            root = null;
            count = 0;
        }

        public bool Contains(T item)
        {
            Node<T> current = root;

            while (current != null)
            {
                if (current.Value.CompareTo(item) > 0)
                {
                    current = current.ChildLeft;
                    continue;
                }

                if (current.Value.CompareTo(item) == 0)
                    return true;

                current = current.ChildRight;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int i = arrayIndex;
            foreach(T value in this)
            {
                array[i] = (T)value.Clone();
                i++;
            }
        }

        public int Count
        {
            get { return count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            if (!Contains(item))
                return false;
            Node<T> current = root, parent = null;
            while (current.Value.CompareTo(item) != 0)
            {
                parent = current;
                if (current.Value.CompareTo(item) > 0)
                    current = current.ChildLeft;
                else if (current.Value.CompareTo(item) < 0)
                    current = current.ChildRight;
            }
            if (current.ChildLeft == null && current.ChildRight == null)
            {
                if (parent.ChildLeft == current)
                    parent.ChildLeft = null;
                else
                    parent.ChildRight = null;
                return true;
            }

            if (current.ChildLeft == null)
            {
                if (parent.ChildLeft == current)
                    parent.ChildLeft = current.ChildRight;
                else
                    parent.ChildRight = current.ChildRight;
                return true;
            }
            if (current.ChildRight == null)
            {
                if (parent.ChildLeft == current)
                    parent.ChildLeft = current.ChildLeft;
                else
                    parent.ChildRight = current.ChildLeft;
                return true;
            }

            Node<T> previous;
            Node<T> next = Next(current.ChildRight, out previous);
            current.Value = next.Value;
            current = current.ChildRight;
            previous.ChildLeft = next.ChildLeft;
            return true;
        }
    }
}
