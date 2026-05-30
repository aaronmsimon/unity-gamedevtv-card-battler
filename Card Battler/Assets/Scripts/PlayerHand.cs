using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    [SerializeField] private Deck deck;
    [SerializeField] private Transform[] cardSlots;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private int startingHandSize = 2;

    private List<Card> cards = new List<Card>();

    private void Start()
    {
        for (int i = 0; i < startingHandSize; i++)
        {
            DrawNextCard();
        }
    }

    public void DrawNextCard()
    {
        if (cardSlots == null || cards.Count >= cardSlots.Length)
        {
            Debug.Log("Hand is full or slots are null");
            return;
        }

        CardData cardData = deck.DrawCard();
        if (cardData == null)
        {
            Debug.Log("Deck is empty");
            return;
        }

        int slotIndex = cards.Count;

        GameObject newCard = Instantiate(cardPrefab, cardSlots[slotIndex].position, Quaternion.identity);
        Card cardComponent = newCard.GetComponent<Card>();
        cardComponent.LoadCardData(cardData);
        cards.Add(cardComponent);
        cards[slotIndex].transform.SetParent(cardSlots[slotIndex]);
    }
}
