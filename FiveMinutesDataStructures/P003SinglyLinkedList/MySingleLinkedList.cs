using System;

namespace P003SingleLinkedList
{
    /// <summary>
    /// 单链表模拟实现
    /// </summary>
    public class MySingleLinkedList<T>
    {
        /// <summary>
        /// 当前链表的头结点
        /// </summary>
        private Node<T> _head;

        /// <summary>
        /// 当前链表节点个数
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// 索引器
        /// </summary>
        public T this[int index]
        {
            get => GetNodeByIndex(index).Item;
            set => GetNodeByIndex(index).Item = value;
        }

        public MySingleLinkedList()
        {
            Count = 0;
            _head = null;
        }

        // Method01:根据索引获取节点
        private Node<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "索引超出范围");
            }

            Node<T> tempNode = _head;
            for (var i = 0; i < index; i++)
            {
                tempNode = tempNode.Next;
            }

            return tempNode;
        }

        // Method02:在尾节点后插入新节点
        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (_head == null)
            {
                // 如果链表当前为空则置为头结点
                _head = newNode;
            }
            else
            {
                Node<T> prevNode = GetNodeByIndex(Count - 1);
                prevNode.Next = newNode;
            }

            Count++;
        }

        // Method03:在指定位置插入新节点
        public void Insert(int index, T value)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "索引超出范围");
            }

            Node<T> tempNode;

            if (index == 0)
            {
                if (_head == null)
                {
                    tempNode = new Node<T>(value);
                    _head = tempNode;
                }
                else
                {
                    tempNode = new Node<T>(value) { Next = _head };
                    _head = tempNode;
                }
            }
            else
            {
                Node<T> prevNode = GetNodeByIndex(index - 1);
                tempNode = new Node<T>(value) { Next = prevNode.Next };
                prevNode.Next = tempNode;
            }

            Count++;
        }

        // Method04：移除指定位置的节点
        public void RemoveAt(int index)
        {
            if (index == 0)
            {
                _head = _head.Next;
            }
            else
            {
                Node<T> prevNode = GetNodeByIndex(index - 1);
                if (prevNode.Next == null)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "索引超出范围");
                }

                Node<T> deleteNode = prevNode.Next;
                prevNode.Next = deleteNode.Next;

                // deleteNode = null;
            }

            Count--;
        }
    }
}