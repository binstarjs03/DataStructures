using System;

namespace binstarjs03.DataStructures;
public class List<T> : IList<T>
{
    private T[] _array;
    private int _count = 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="List{T}"/> 
    /// class that is empty and has the default initial  capacity.
    /// </summary>
    public List()
    {
        _array = new T[4];
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="List{T}"/> 
    /// class that is empty and has the specified initial capacity.
    /// </summary>
    public List(int capacity)
    {
        _array = new T[capacity];
    }

    public T this[int index]
    {
        get
        {
            if (index >= Count || index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));
            return _array[index];
        }
        set
        {
            if (index >= Count || index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));
            _array[index] = value;
        }
    }

    public int Count
    {
        get => _count;
        private set => _count = value;
    }
    
    public int Capacity => _array.Length;

    public void Add(T item)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        if (Capacity == Count)
            Resize(Capacity * 2, Count);
        _array[Count++] = item;
    }

    public void Clear()
    {
        for (int i = 0; i < Count; i++)
            _array[i] = default!;
        Count = 0;
    }
    
    public void Insert(int index, T item)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        // we can insert at exactly end of the list (after last item),
        // but not overflowing it, so comparison is not "equal to or larger"
        if (index > Count || index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));
        if (Capacity == Count)
            Resize(Capacity * 2, Count);
        ShiftInsertItem(index);
        _array[index] = item;
        Count++;
    }
    
    public T Pop()
    {
        if (Count < 0)
            throw new InvalidOperationException();
        int index = Count - 1;
        T result = _array[index];
        _array[index] = default!;
        Count--;
        return result;
    }
    
    public bool Remove(T item)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        bool removed = false;
        for (int index = 0; index < Count; index++)
        {
            if (!_array[index]!.Equals(item))
                continue;
            _array[index] = default!;
            removed = true;
            ShiftEmptyItem(index);
            Count--;
            break;
        }
        return removed;
    }
    
    public void RemoveAt(int index)
    {
        if (index >= Count || index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));
        _array[index] = default!;
        ShiftEmptyItem(index);
        Count--;
    }

    public void TrimExcess()
    {
        Resize(Count, Count);
    }

    private void Resize(int newCapacity, int oldItemCount)
    {
        T[] newArray = new T[newCapacity];
        _array = Relocate(newArray, _array, oldItemCount);
    }

    private static T[] Relocate(T[] newArray, T[] oldArray, int itemCount)
    {
        for (int i = 0; i < itemCount; i++)
            newArray[i] = oldArray[i];
        return newArray;
    }

    private void ShiftEmptyItem(int emptyIndex)
    {
        // shift deleted item from left to right, this is to fill the empty space
        int tailPos = Count - 1;
        for (int index = emptyIndex; index < tailPos; index++)
            (_array[index], _array[index + 1]) = (_array[index + 1], _array[index]);
    }

    private void ShiftInsertItem(int insertionIndex)
    {
        // shift empty space from right to left, this is to make a room for insertion
        int emptyIndex = Count;
        for (int index = emptyIndex; index > insertionIndex; index--)
            (_array[index], _array[index - 1]) = (_array[index - 1], _array[index]);
    }
}