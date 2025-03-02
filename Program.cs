
using System;
internal class Program
{
    private static void Main(string[] args)
    {
        IntQueue queue = new IntQueue(5);
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        Console.WriteLine(queue.Dequeue());

    }
}

public class IntQueue
{
    private int[] elements;
    private int size;
    public IntQueue(int capacity)
    {
        elements = new int[capacity];
        size = 0;
    }

    public void Enqueue(int item)
    {
        if (size == elements.Length)
        {throw new InvalidOperationException("Queue is full");}

        elements[size] = item;
        size++;
    }
    public int Dequeue()
    {
        if (size==0){
            throw new InvalidOperationException("Queue is empty");
        }
        int item = elements[0];
        for (int i=1;i<size ; i++)
        {
            elements[i-1]=elements[i];
        }
        size--;
        return item;
    }
    public int Peek()
    {
        if (size==0) throw new InvalidOperationException("Queue is empty");

        return elements[0]; 
    }
    public bool IsEmpty(){
        return size==0;
    }
}



