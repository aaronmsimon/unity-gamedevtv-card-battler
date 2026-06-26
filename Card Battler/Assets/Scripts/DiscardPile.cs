using System.Collections.Generic;
using UnityEngine;

public class DiscardPile : MonoBehaviour
{
    [SerializeField] private List<CardData> discardPile = new List<CardData>();
    [SerializeField] private GameObject cardPrefab;

    public void DiscardCard(CardData cardData)
    {
        Debug.Log($"Discard card {cardData}");
        discardPile.Add(cardData);
    }
}
