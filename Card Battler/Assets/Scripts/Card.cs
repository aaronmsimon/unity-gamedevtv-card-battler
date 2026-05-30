using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class Card : MonoBehaviour
{
    [SerializeField] private SpriteRenderer illustrationRenderer;
    [SerializeField] private TextMeshPro cardNameText;
    [SerializeField] private TextMeshPro descriptionText;
    [SerializeField] private TextMeshPro actionsText;

    [SerializeField] private CardData tempCardData;

    [SerializeField] private float hoverScale = 2f;
    [SerializeField] private float hoverOffset = 2f;

    private Vector3 originalScale;
    private Vector3 originalPos;

    private SortingGroup sortingGroup;
    private int originalSortOrder;

    private void Awake()
    {
        sortingGroup = GetComponent<SortingGroup>();
    }

    private void Start()
    {
        originalScale = transform.localScale;
        originalPos = transform.localPosition;
        originalSortOrder = sortingGroup.sortingOrder;

        LoadCardData(tempCardData);
    }

    public void LoadCardData(CardData cardData)
    {
        illustrationRenderer.sprite = cardData.illustration;
        cardNameText.text = cardData.cardName;
        descriptionText.text = cardData.description;
        actionsText.text = cardData.actionCost.ToString();
    }

    private void OnMouseEnter()
    {
        Debug.Log("Mouse entered");
        transform.localScale = originalScale * hoverScale;
        transform.localPosition += new Vector3(0f, hoverOffset, 0f);
        sortingGroup.sortingOrder += 1;
    }

    private void OnMouseExit()
    {
        Debug.Log("Mouse exited");
        transform.localScale = originalScale;
        transform.localPosition = originalPos;
        sortingGroup.sortingOrder = originalSortOrder;
    }
}
