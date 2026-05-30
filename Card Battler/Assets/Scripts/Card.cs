using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    [SerializeField] private SpriteRenderer illustrationRenderer;
    [SerializeField] private TextMeshPro cardNameText;
    [SerializeField] private TextMeshPro descriptionText;
    [SerializeField] private TextMeshPro actionsText;

    [SerializeField] private CardData tempCardData;

    private void Start()
    {
        LoadCardData(tempCardData);
    }

    public void LoadCardData(CardData cardData)
    {
        illustrationRenderer.sprite = cardData.illustration;
        cardNameText.text = cardData.cardName;
        descriptionText.text = cardData.description;
        actionsText.text = cardData.actionCost.ToString();
    }
}
