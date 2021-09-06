using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Lesson_2
{
    class List
    {
        public class Node
        {
            public int Value { get; set; }
            public Node NextNode { get; set; }
            public Node PrevNode { get; set; }

        }

        //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
        public interface ILinkedList
        {
            int GetCount(); // возвращает количество элементов в списке
            void AddNode(int value);  // добавляет новый элемент списка
            void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
            void RemoveNode(int index); // удаляет элемент по порядковому номеру
            void RemoveNode(Node node); // удаляет указанный элемент
            Node FindNode(int searchValue); // ищет элемент по его значению
            void Print();
        }
        public class LinkedList : ILinkedList
        {
            Node head;
            Node tail;

            private int Count { get; set; }

            public void AddNode(int value)
            {
                var newNode = new Node { Value = value };

                if (head == null)
                {
                    head = newNode;
                    tail = newNode;
                    Count++;
                }
                else
                {
                    tail.NextNode = newNode;
                    newNode.PrevNode = tail;
                    tail = newNode;
                    Count++;
                }

            }

            public void AddNodeAfter(Node node, int value)
            {
                var newNode = new Node { Value = value };
                var tempNode = new Node();
                if (node == null)
                {
                    throw new NotImplementedException();
                }
                if (node == tail)
                {
                    tail.NextNode = newNode;
                    newNode.PrevNode = tail;
                    tail = newNode;
                    Count++;
                }
                else
                {
                    tempNode = node.NextNode;
                    newNode.PrevNode = node;
                    node.NextNode = newNode;
                    tempNode.PrevNode = newNode;
                    newNode.NextNode = tempNode;
                    Count++;
                }
            }

            public Node FindNode(int searchValue)
            {
                var tempNode = new Node();
                tempNode = head;
                while (tempNode != null)
                {
                    if (searchValue == tempNode.Value)
                    {
                        break;
                    }
                    tempNode = tempNode.NextNode;
                }
                if (tempNode == null)
                {
                    throw new NotImplementedException();
                }
                return tempNode;
            }

            public int GetCount()
            {
                return Count;
            }

            public void RemoveNode(int index)
            {
                var removeNode = new Node();
                var tempNode = new Node();

                removeNode = head;
                if (index <= 0)
                {
                    throw new NotImplementedException();
                }
                if (Count < index)
                {
                    throw new NotImplementedException();
                }
                if (index == 1)
                {
                    tempNode = head.NextNode;
                    head = tempNode;
                    tempNode = head.NextNode;
                    tempNode.PrevNode = head;
                    head.NextNode = tempNode;
                    removeNode = null;
                    Count--;
                }
                if (index == Count)
                {
                    tempNode = tail.PrevNode;
                    tail = tempNode;
                    tail.PrevNode = tempNode.PrevNode;
                    tempNode.PrevNode.NextNode = tail;
                    tail.NextNode = null;
                    Count--;
                }
                else
                {
                    for (int i = 0; i < index - 1; i++)
                    {
                        removeNode = removeNode.NextNode;
                    }
                    tempNode = removeNode.PrevNode;
                    tempNode.NextNode = removeNode.NextNode;
                    removeNode.NextNode.PrevNode = tempNode;
                    removeNode = null;
                    Count--;
                }

            }

            public void RemoveNode(Node node)
            {
                if (node == null)
                {
                    throw new NotImplementedException();
                }
                var tempNode = new Node();
                tempNode = head;
                if (head == node)
                {
                    head = head.NextNode;
                    head.PrevNode = null;
                    Count--;
                }
                if (tail == node)
                {
                    tail = tail.PrevNode;
                    tail.NextNode = null;
                    Count--;
                }
                while (tempNode != null)
                {
                    if (tempNode == node)
                    {
                        tempNode = node.PrevNode;
                        node = node.NextNode;
                        tempNode.NextNode = node;
                        node.PrevNode = tempNode;
                        Count--;
                        break;
                    }
                    tempNode = tempNode.NextNode;
                }
            }
            public void Print()
            {
                var body = new Node();
                body = head;
                if (head == null)
                {
                    throw new NotImplementedException();
                }
                while (body != null)
                {
                    Console.WriteLine(body.Value);
                    body = body.NextNode;
                }
            }
        }


        static void Main(string[] args)
        {
            LinkedList linked = new LinkedList();

            linked.AddNode(67);
            linked.AddNode(347);
            linked.AddNode(5);
            linked.AddNode(11);
            linked.AddNode(17);
            linked.AddNode(34);
            linked.AddNode(95);
            linked.AddNode(777);

            linked.RemoveNode(8);
            Node removeNode = linked.FindNode(17);
            linked.RemoveNode(removeNode);
            Node afterNode = linked.FindNode(5);
            linked.AddNodeAfter(afterNode, 10000);
            Console.WriteLine(linked.GetCount());
            linked.Print();
        }
    }
}

