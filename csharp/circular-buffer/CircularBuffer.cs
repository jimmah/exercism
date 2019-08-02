using System;
using System.Collections.Generic;
using System.Linq;

public class CircularBuffer<T>
{
    private readonly int _capacity;
    private Queue<T> _queue;

    public CircularBuffer(int capacity)
    {
        _capacity = capacity;
        _queue = new Queue<T>(capacity);
    }

    public T Read() => _queue.Dequeue();

    public void Write(T value)
    {
        if (_queue.Count == _capacity)
            throw new InvalidOperationException();

        _queue.Enqueue(value);
    }

    public void Overwrite(T value)
    {
        if (_queue.Count < _capacity)
        {
            Write(value);
        }
        else 
        {
            _queue.Dequeue();
            _queue = new Queue<T>(_queue.Append(value));
        }
    }

    public void Clear() => _queue.Clear();
}