namespace System.Collections.Generic;
public class Trie<T> where T : notnull
{
    public Dictionary<T, Trie<T>> Children { get; set; }
    public bool IsTerminal { get; set; }
    public Trie()
    {
        Children = new();
        IsTerminal = false;
    }
    public void Insert(IEnumerable<T> collection)
    {
        Trie<T> pointer = this;
        foreach (T item in collection)
        {
            pointer.Children.TryAdd(item, new());
            pointer = pointer.Children[item];
        }
        pointer.IsTerminal = true;
    }
    public bool Remove(IEnumerable<T> collection)
    {
        Trie<T> pointer = this;
        foreach (T item in collection)
        {
            if (pointer.Children.TryGetValue(item, out Trie<T>? next))
            {
                pointer = next;
            }
            else
            {
                return false;
            }
        }
        pointer.IsTerminal = false;
        return true;
    }
    public Trie<T>? Search(IEnumerable<T> collection)
    {
        Trie<T> pointer = this;
        foreach (T item in collection)
        {
            if (pointer.Children.TryGetValue(item, out Trie<T>? next))
            {
                pointer = next;
            }
            else
            {
                return null;
            }
        }
        return pointer.IsTerminal ? pointer : null;
    }
    public Trie<T>? SearchPrefix(IEnumerable<T> collection)
    {
        Trie<T> pointer = this;
        foreach (T item in collection)
        {
            if (pointer.Children.TryGetValue(item, out Trie<T>? next))
            {
                pointer = next;
            }
            else
            {
                return null;
            }
        }
        return pointer;
    }
}