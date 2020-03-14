using System.Collections.Generic;
using System.IO;

class Solution
{

    class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    class SinglyLinkedList
    {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
        }
    }

    static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter)
    {
        while (node != null)
        {
            textWriter.Write(node.data);

            node = node.next;

            if (node != null)
            {
                textWriter.Write(sep);
            }
        }
    }

    static bool hasCycle(SinglyLinkedListNode head)
    {
        if (head == null || head.next == null)
        {
            return false;
        }

        var nodeValues = new HashSet<SinglyLinkedListNode>
        {
            head
        };

        var nextNode = head.next;

        while(nextNode != null)
        {
            if (nodeValues.Contains(nextNode))
            {
                return true;
            }

            nodeValues.Add(nextNode);
            nextNode = nextNode.next;
        }

        return false;
    }

    static void Main(string[] args)
    {
        
    }
}