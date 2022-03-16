using System.Collections;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public SinglyLinkedListNode<T> Head { get; set; }
        public int Count { get; set; }
        private bool isHeadNull => Head == null;

        public SinglyLinkedList()
        {
            Head = null;
            Count = 0;
        }

        public SinglyLinkedList(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
            {
                AddFirst(item);
            }
        }

        public void AddFirst(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);
            if (isHeadNull)
            {
                Head = newNode;
                Count++;
                return;
            }
            newNode.Next = Head;
            Head = newNode;
            Count++;
            return;
        }
        public void AddLast(T value)
        {
            SinglyLinkedListNode<T> node = new SinglyLinkedListNode<T>(value);
            SinglyLinkedListNode<T> temp = Head;

            node.Value = value;
            node.Next = null;

            if (Head == null)
            {
                Head = node;
                Count++;
            }
            else if (Head != null)
            {
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = node;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public List<T> ToList() => new List<T>(this);
    }
}
