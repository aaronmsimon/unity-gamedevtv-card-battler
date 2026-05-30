using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] private List<CardData> drawPile = new List<CardData>();

    [Header("Card Back")]
    [SerializeField] private GameObject cardBack;
    [SerializeField] private float cardBackOffset = 0.1f;

    private void Start()
    {
        Debug.Log(DrawCard());
        DeckDrawVisuals();
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

    private void DeckDrawVisuals()
    {
        for (int i = 0; i < drawPile.Count; i++)
        {
            GameObject newCardBack = Instantiate(cardBack, transform);
            newCardBack.transform.localPosition = new Vector3(0f, -i * cardBackOffset, 0f);
        }
    }
}
