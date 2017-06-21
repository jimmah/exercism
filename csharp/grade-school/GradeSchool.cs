using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class School
{
    private readonly IDictionary<int, IList<string>> _students = new Dictionary<int, IList<string>>();

    public void Add(string student, int grade)
    {
        if (_students.ContainsKey(grade))
        {
            _students[grade].Add(student);
        }
        else 
        {
            _students.Add(grade, new SortedList<string> {student});
        }
    }

    public IEnumerable<string> Roster()
    {
        var result = new List<string>();

        foreach (var grade in _students.OrderBy(s => s.Key))
        {
            result.AddRange(grade.Value);
        }

        return result;
    }

    public IEnumerable<string> Grade(int grade)
    {
        if (_students.TryGetValue(grade, out IList<string> students))
            return students;
        return Enumerable.Empty<string>();
    }

    private class SortedList<T> : IList<T>
    {
        private readonly List<T> _list = new List<T>();

        public T this[int index]
        {
            get => _list[index];
            set 
            {
                _list.RemoveAt(index);
                Add(value);
            }
        }

        public int Count => _list.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            _list.Insert(~_list.BinarySearch(item), item);
        }

        public void Insert(int index, T item)
        {
            throw new NotSupportedException();
        }

        public bool Remove(T item) => _list.Remove(item);

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public int IndexOf(T item) => _list.IndexOf(item);

        public bool Contains(T item) => _list.Contains(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();
    }
}