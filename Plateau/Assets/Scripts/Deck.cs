using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck<T>
{
    private List<T> _deck;
    private List<T> _graveyard;

    public Deck()
    {
        _deck = new();
        _graveyard = new();
    }

    public void FillDeck(T[] array)
    {
        foreach (T item in array)
        {
            _deck.Add(item);
        }
    }

    public T Draw()
    {
        if (_deck.Count == 0 && _graveyard.Count > 0)
        {
            ShuffleGraveyardIntoDeck();
        }

        if (_deck.Count > 0)
        {
            T t = _deck[0];
            _deck.Remove(t);

            return t;
        }
        else
        {
            return default;
        }
    }

    private void ShuffleGraveyardIntoDeck()
    {
        foreach (T t in _graveyard)
        {
            _deck.Add(t);
        }

        _graveyard.Clear();
    }

    public void PutInGraveyard(T t)
    {
        _graveyard.Add(t);
    }
}
