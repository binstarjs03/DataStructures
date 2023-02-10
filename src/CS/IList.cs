using System;

namespace binstarjs03.DataStructures;
public interface IList<T>
{
    /// <summary>
    /// Gets or sets the element at specified index
    /// </summary>
    /// <param name="index">The zero-based index of the element to get or set </param>
    /// <exception cref="ArgumentOutOfRangeException">when index is less than zero 
    /// or equal to or larger than <see cref="Count"/></exception>
    T this[int index] { get; set; }

    /// <summary>
    /// Gets the number of elements contained in this <see cref="IList{T}"/> 
    /// </summary>
    int Count { get; }

    /// <summary>
    /// Gets or the total number of elements this <see cref="IList{T}"/> 
    /// can hold without resizing
    /// </summary>
    int Capacity { get; }

    /// <summary>
    /// Adds an instance of <typeparamref name="T"/> to this <see cref="IList{T}"/>
    /// </summary>
    /// <param name="item">
    /// The item to add to this <see cref="IList{T}"/>
    /// </param>
    /// <exception cref="ArgumentNullException"></exception>
    void Add(T item);

    /// <summary>
    /// Inserts an element into this <see cref="IList{T}"/> at the specified index,
    /// shifting all the right-side elements of <paramref name="index"/> in
    /// this <see cref="IList{T}"/> (if any)
    /// </summary>
    /// <param name="index">The zero-based index of the element to insert</param>
    /// <param name="item">
    /// The object to insert to this <see cref="IList{T}"/>.
    /// Unlike <see cref="System.Collections.Generic.IList{T}"/>, the value 
    /// cannot be null for reference types.
    /// </param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    void Insert(int index, T item);

    /// <summary>
    /// Removes the first occurence of a specified object from this <see cref="IList{T}"/>
    /// </summary>
    /// <param name="item">
    /// The object to removed from this <see cref="IList{T}"/>.
    /// Unlike <see cref="System.Collections.Generic.IList{T}"/>, the value 
    /// cannot be null for reference types.
    /// </param>
    /// <returns>
    /// <see cref="true"/> if <paramref name="item"/> is successfully found and removed, 
    /// <see cref="false"/> if <paramref name="item"/> is not found
    /// </returns>
    bool Remove(T item);

    /// <summary>
    /// Removes the element at the specified index of this <see cref="IList{T}"/>
    /// </summary>
    /// <param name="index">The zero-based index of the element to remove</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    void RemoveAt(int index);

    /// <summary>
    /// Removes the last element in this <see cref="IList{T}"/> and return it
    /// </summary>
    /// <returns>The removed object</returns>
    /// <exception cref="InvalidOperationException"></exception>
    T Pop();

    /// <summary>
    /// Removes all elements in this <see cref="IList{T}"/>
    /// </summary>
    void Clear();

    /// <summary>
    /// Sets the capacity to the actual number of elements in this <see cref="IList{T}"/>
    /// </summary>
    void TrimExcess();
}
