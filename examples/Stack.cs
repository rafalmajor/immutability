using System;
using System.Collections.Generic;

namespace examples
{
    public class Stack<T>
    {
        private List<T> items = new List<T>();
        public int Count => this.items.Count;
        public T Top  
        {
            get
            {
                if (this.Count == 0)
                    throw new InvalidOperationException();
                return items[this.Count - 1];
            }
        }
        public void Pop()
        {
            if (this.Count == 0)
                throw new InvalidOperationException();
            this.items.RemoveAt(this.Count - 1);
        }
        public void Push(T newTop)
        {
            this.items.Add(newTop);
        }
    }

public interface IStack<T>
{
    internal class NotEmpty<T> : IStack<T>
    {
        private T top;
        private IStack<T> tail;
        public NotEmpty(T newTop, IStack<T> previous)
        {
            this.top = newTop;
            this.tail = previous;
        }
        public int Count => 1 + this.tail.Count;
        public T Top => this.top;
        public IStack<T> Pop()
        { return this.tail; }
        public IStack<T> Push(T newTop)
        { return new NotEmpty<T>(newTop, this.tail); }
    }

    class Empty<T> : IStack<T>
    {
        public int Count => 0;
        public T Top => throw new InvalidOperationException();
        public IStack<T> Pop()
        { throw new InvalidOperationException(); }
        public IStack<T> Push(T newTop)
        { return new NotEmpty<T>(newTop, this); }
        
    }
    int Count { get; }
    T Top { get; }
    IStack<T> Pop();
    IStack<T> Push(T newTop);
}

    internal class NotEmpty<T> : IStack<T>
    {
        private T top;
        private IStack<T> tail;
        public NotEmpty(T newTop, IStack<T> previous)
        {
            this.top = newTop;
            this.tail = previous;
        }
        public int Count => 1 + this.tail.Count;
        public T Top => this.top;
        public IStack<T> Pop()
        { return this.tail; }
        public IStack<T> Push(T newTop)
        { return new NotEmpty<T>(newTop, this.tail); }
    }
}