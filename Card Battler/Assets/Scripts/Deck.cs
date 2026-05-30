using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] private List<CardData> drawPile = new List<CardData>();

    private void Start()
    {
        Debug.Log(DrawCard());
    }

    public CardData DrawCard()
    {
        if (drawPile.Count > 0)
        {
            // Draw and remove top card
            int topIndex = drawPile.Count - 1;
            CardData data = drawPile[topIndex];
            drawPile.RemoveAt(topIndex);
            return data;
        }

        return null;
    }
}
