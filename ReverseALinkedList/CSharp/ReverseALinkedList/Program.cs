using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

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

    static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep)
    {
        while (node != null)
        {
            Console.Write(node.data);
            node = node.next;

            if (node != null)
            {
                Console.Write(sep);
            }
        }
    }

    static SinglyLinkedListNode reverse(SinglyLinkedListNode head)
    {
        if (head == null || head.next == null)
        {
            return head;
        }

        var currentNode = head;
        var previousNode = (SinglyLinkedListNode)null;

        while (true)
        {
            var nextNode = currentNode.next;
            currentNode.next = previousNode;
            
            if (nextNode == null)
            {
                return currentNode;
            }

            previousNode = currentNode;
            currentNode = nextNode;
        }
    }

    static void Main(string[] args)
    {
        var tests = int.Parse(Console.ReadLine());
        for (var i = 0; i < tests; i++)
        {
            var list = new SinglyLinkedList();
            var listCount = int.Parse(Console.ReadLine());

            for (var ii = 0; ii < listCount; ii++)
            {
                var listItem = int.Parse(Console.ReadLine());
                list.InsertNode(listItem);
            }

            var reversedList = reverse(list.head);

            PrintSinglyLinkedList(reversedList, " ");

            Console.ReadKey();
        }
    }
}