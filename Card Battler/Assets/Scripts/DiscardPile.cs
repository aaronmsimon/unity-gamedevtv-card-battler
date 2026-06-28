using System.Collections.Generic;
using UnityEngine;

public class DiscardPile : MonoBehaviour
{
    [SerializeField] private List<CardData> discardPile = new List<CardData>();
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private float cardOffset = 0.1f;

    public void DiscardCard(CardData cardData)
    {
        Debug.Log($"Discard card {cardData}");
        discardPile.Add(cardData);

        DiscardDrawVisuals(cardData);
    }

    private void DiscardDrawVisuals(CardData cardData)
    {
        RemoveDiscards();

        for (int i = 0; i < discardPile.Count; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, transform);
            newCard.GetComponent<Card>().LoadCardData(cardData);
            Debug.Log($"Added card {cardData} to discard pile.");
            newCard.transform.SetParent(transform);
            newCard.transform.localPosition = new Vector3(0f, -i * cardOffset, 0f);
        }
    }

    private void RemoveDiscards()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(transform.GetChild(i).gameObject);
        }
    }
}
