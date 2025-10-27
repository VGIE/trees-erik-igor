

//TODO #1: Copy your List<T> class (List.cs) to this project and overwrite this file.
using Lists;
using System.Collections;

public class ListNode<T>
{
    public T Value;
    public ListNode<T> Next = null;

    

    public ListNode(T value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

public class List<T> : IList<T>
{
    ListNode<T> First = null;
    ListNode<T> Last = null;
    int m_numItems = 0;

    public override string ToString()
    {
        ListNode<T> node = First;
        string output = "[";

        while (node != null)
        {
            output += node.ToString() + ",";
            node = node.Next;
        }
        output = output.TrimEnd(',') + "] " + Count() + " elements";

        return output;
    }

    public int Count()
    {
        //TODO #1: return the number of elements on the list
        ListNode<T> node = First;
        int count = 0;
            while (node != null)
            {
                node = node.Next;
                count++;
            }
        return count;
    }

    public T Get(int index)
    {
        //TODO #2: return the element on the index-th position. O if the position is out of bounds
        ListNode<T> node = First;
            int count = 0;
            while (node != null && count != index)
            {
                node = node.Next;
                count++;
            }
            if (node == null)
            {
                return default(T);
            }
            else
            {
                return node.Value;
            }
    }

    public void Add(T value)
    {
        //TODO #3: add a new integer to the end of the list
        ListNode<T> node = First;
        ListNode<T> addedNode = new ListNode<T>(value);

            if (First == null)
            {
                First = addedNode;
                return;
            }
            while (node.Next != null)
            {
                node = node.Next;
            }
            node.Next = addedNode;
    }

    public T Remove(int index)
    {
        //TODO #4: remove the element on the index-th position. Do nothing if position is out of bounds
        ListNode<T> node = First;
        int count = 0;
        if (index < 0 || First == null)
        {
            return default(T);
        }
        T valorRemovido;

        if (index == 0)
        {
            valorRemovido = First.Value;
            First = First.Next;
            return valorRemovido;
        }

        while (node != null && count + 1 < index)
        {
            node = node.Next;
            count++;
        }

        if (node == null || node.Next == null)
        {
            return default(T);
        }
            
        valorRemovido = node.Next.Value;
        node.Next = node.Next.Next;
            
        return valorRemovido;
    }

    public void Clear()
    {
        //TODO #5: remove all the elements on the list
        ListNode<T> node = First;
        First = null;
    }

    public IEnumerator GetEnumerator()
    {
        //TODO #6 : Return an enumerator using "yield return" for each of the values in this list
        ListNode<T> node = First;
        while (node != null)
        {
            yield return node.Value;
            node = node.Next;
        }
    }
}