using System;
[System.Serializable]
public class SimplyLinkedList<T>
{
    class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        public Node(T value)
        {
            this.Value = value;
            Next = null;
        }
    }
    Node Head;
    public int length = 0;

    public void InsertNodeAtStart(T value)
    {
        if (Head == null)
        {
            Node newNode = new Node(value);
            Head = newNode;
            length = length + 1;
        }
        else
        {
            Node newNode = new Node(value);
            newNode.Next = Head;
            Head = newNode;
            length = length + 1;
        }
    }

    public void InsertNodeAtEnd(T value)
    {
        if (Head == null)
        {
            InsertNodeAtStart(value);
        }
        else
        {
            Node last = Head;
            while (last.Next != null)
            {
                last = last.Next;
            }
            Node newNode = new Node(value);
            last.Next = newNode;
            length = length + 1;
        }
    }

    public void InsertNodeAtPosition(T value, int position)
    {
        if (position == 0)
        {
            InsertNodeAtStart(value);
        }
        else if (position == length - 1)
        {
            InsertNodeAtEnd(value);
        }
        else if (position >= length)
        {
            Console.WriteLine("No existe esa posicion.");
        }
        else
        {
            Node previus = Head;
            int iterator = 0;
            while (iterator < position - 1)
            {
                previus = previus.Next;
                iterator = iterator + 1;
            }
            Node next = previus.Next;
            Node newNode = new Node(value);
            previus.Next = newNode;
            newNode.Next = next;
            length = length + 1;
        }
    }

    public void ModifyAtStart(T value)
    {
        if (Head == null)
        {
            Console.WriteLine("No se puede.");
        }
        else
        {
            Head.Value = value;
        }
    }

    public void ModifyAtEnd(T value)
    {
        if (Head == null)
        {
            ModifyAtStart(value);
        }
        else
        {
            Node last = Head;
            while (last.Next != null)
            {
                last = last.Next;
            }
            last.Value = value;
        }
    }

    public void ModifyAtPosition(T value, int position)
    {
        if (position == 0)
        {
            ModifyAtStart(value);
        }
        else if (position == length - 1)
        {
            ModifyAtEnd(value);
        }
        else if (position >= length)
        {
            Console.WriteLine("No existe esa posicion.");
        }
        else
        {
            Node nodePosition = Head;
            int iterator = 0;
            while (iterator < position)
            {
                nodePosition = nodePosition.Next;
                iterator = iterator + 1;
            }
            nodePosition.Value = value;
        }
    }
    public T ObtainNodeAtStart()
    {
        if (Head == null)
        {
            throw new Exception("La lista se encuentra vacia.");
        }
        else
        {
            return Head.Value;
        }
    }

    public T ObtainNodeAtEnd()
    {
        if (Head == null)
        {
            return ObtainNodeAtStart();
        }
        else
        {
            Node last = Head;
            while (last.Next != null)
            {
                last = last.Next;
            }
            return last.Value;
        }
    }

    public T ObtainNodeAtPosition(int position)
    {
        if (position == 0)
        {
            return ObtainNodeAtStart();
        }
        else if (position == length - 1)
        {
            return ObtainNodeAtEnd();
        }
        else if (position >= length)
        {
            throw new Exception("No existe esa posicion.");
        }
        else
        {
            Node nodePosition = Head;
            int iterator = 0;
            while (iterator < position)
            {
                nodePosition = nodePosition.Next;
                iterator = iterator + 1;
            }
            return nodePosition.Value;
        }
    }

    public void DeleteAtStart()
    {
        if (Head == null)
        {
            throw new Exception("La lista se encuentra vacia.");
        }
        else
        {
            Node newHead = Head.Next;
            Head.Next = null;
            Head = newHead;
            length = length - 1;
        }
    }

    public void DeleteAtEnd()
    {
        if (Head == null)
        {
            DeleteAtStart();
        }
        else
        {
            Node previusLastNode = Head;
            while (previusLastNode.Next.Next != null)
            {
                previusLastNode = previusLastNode.Next;
            }
            Node lastNode = previusLastNode.Next;
            lastNode = null;
            previusLastNode.Next = null;
            length = length - 1;
        }
    }

    public void DeleteNodeAtPosition(int position)
    {
        if (position == 0)
        {
            DeleteAtStart();
        }
        else if (position == length - 1)
        {
            DeleteAtEnd();
        }
        else if (position >= length)
        {
            throw new Exception("No existe esa posicion.");
        }
        else
        {
            Node previous = Head;
            int iterator = 0;
            while (iterator < position - 1)
            {
                previous = previous.Next;
                iterator = iterator + 1;
            }
            Node next = previous.Next.Next;
            Node nodePosition = previous.Next;
            nodePosition.Next = null;
            nodePosition = null;
            previous.Next = null;
            previous.Next = next;
            length = length - 1;
        }
    }

    public void PrintAllNodes()
    {
        Node tmp = Head;
        while (tmp != null)
        {
            Console.Write(tmp.Value + " ");
            tmp = tmp.Next;
        }
        Console.WriteLine();
    }
}

