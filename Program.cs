
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Net.Quic;
using System.Runtime.CompilerServices;
internal class Program
{
    private static void Main(string[] args)
    {
        IntQueue queue = new IntQueue(5);
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        Console.WriteLine(queue.Dequeue()); //expect 1

        Stack<int> stack = new Stack<int>(5);
        stack.Push(1);
        stack.Push(4);
        stack.Push(1);
        stack.Push(3);
        Console.WriteLine(stack.Pop()); //Expect


        SimpleHashTable hashTable = new SimpleHashTable();
        hashTable.Insert("Alice",25);
        hashTable.Insert("Bob",30);
        hashTable.Insert("Bob",31);
        Console.WriteLine(hashTable.GetValue("Bob")); //expect 25

        //using built in collections
        Queue<int> builtInQueue = new Queue<int>();
        builtInQueue.Enqueue(5);
        builtInQueue.Enqueue(6);
        builtInQueue.Enqueue(3);
        builtInQueue.Enqueue(4);
        Console.WriteLine(builtInQueue.Dequeue());//expect 5

        Stack<int> stack1 = new Stack<int>(10);
        stack1.Push(1);
        stack1.Push(2);
        stack1.Push(3);
        stack1.Push(4);
        Console.WriteLine(stack1.Pop()); //expect 4

        Dictionary<string,string> dict1 = new Dictionary<string, string>();
        dict1.Add("txt","notepad.exe");
        dict1.Add("bmp","paint.exe"); 
        Console.WriteLine(dict1["txt"]);//expect notepad.exe



    }
}





public class SimpleHashTable
{
    private int size =10;
    private string[] keys;
    private int[] values;
    public SimpleHashTable()
    {
        keys = new string[size]; //stores keys
        values = new int[size]; //stores values
    }
    public int GetHash(string key)
    {
        int hash = 0;
        foreach (char c in key)
        {
            hash +=c;
        }
        return hash % size;
    }
    public void Insert(string key, int value)
    {
        int index = GetHash(key);
        Console.WriteLine("index"+index);
        // If the key matches , overwrite the value?
        if (keys[index]==key||keys[index]==null)
        {
            keys[index] = key;
            values[index]=value;
        }
        else
        {
            throw new InvalidOperationException("Hash collision");
        }
    }
    public int? GetValue(string key)
    {
        int index = GetHash(key);
        return values[index];
    }
}


public class Stack<T>
{
    public int size;
    public T Value {get;set;}
    public int len=0;
    private T[] stack;
    public Stack(int size){
        this.size=size;
        stack = new T[size];
        }

    public bool IsEmpty(){
        if (len==0) return true;
        else return false;
    }
    public void Push(T element){
        if (len>size){
            throw new Exception("Stack Overflow");
        }
        stack[len]=element;
        len++;
    }
    public T Pop(){
        if(IsEmpty()){
            throw new Exception("Stack Overflow");
        }
        else
        {
            len--;
            return stack[len];
        }
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


