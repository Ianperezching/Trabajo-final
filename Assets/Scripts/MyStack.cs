using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack<T>
{
    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node(T t)
        {
            Value = t;
            Next = null;
            Previous = null;
        }
    }
    public void Push(T NewData)
    {
        Node NewNode = new Node(NewData);
        if (head == null)
        {
            NewNode.Previous = null;
            head = NewNode;
            top = NewNode;
            return;
        }
        top.Next = NewNode;
        NewNode.Previous = top;
        top = NewNode;
        length = length + 1;
    }
    public void pop()
    {
        if (length < 0)
        {
            top = top.Previous;
            top.Next = null;
            length = length + 1;
        }
        else
        {
            top = null;
            head = null;
        }
    }

    private Node head;
    private Node top;
    private int length = 0;

}
