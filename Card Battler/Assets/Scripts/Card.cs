using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
using UnityEngine.InputSystem;

public class Card : MonoBehaviour
{
    [SerializeField] private SpriteRenderer illustrationRenderer;
    [SerializeField] private TextMeshPro cardNameText;
    [SerializeField] private TextMeshPro descriptionText;
    [SerializeField] private TextMeshPro actionsText;

    [SerializeField] private float hoverScale = 2f;
    [SerializeField] private float hoverOffset = 2f;

    private Vector3 originalScale;
    private Vector3 originalPos;

    private SortingGroup sortingGroup;
    private int originalSortOrder;

    private static bool isBeingDragged = false; // static so in case raycast goes through one card to another

    private CardData cardData;

    private void Awake()
    {
        sortingGroup = GetComponent<SortingGroup>();
    }

    private void Start()
    {
        originalScale = transform.localScale;
        originalPos = transform.localPosition;
        originalSortOrder = sortingGroup.sortingOrder;
    }

    public void LoadCardData(CardData cardData)
    {
        this.cardData = cardData;
        illustrationRenderer.sprite = cardData.illustration;
        cardNameText.text = cardData.cardName;
        descriptionText.text = cardData.description;
        actionsText.text = cardData.actionCost.ToString();
    }

    public void OnMouseEnter()
    {
        if (isBeingDragged) return;

        Debug.Log("Mouse entered");
        transform.localScale = originalScale * hoverScale;
        transform.localPosition += new Vector3(0f, hoverOffset, 0f);
        sortingGroup.sortingOrder += 1;
    }

    public void OnMouseExit()
    {
        if (isBeingDragged) return;

        Debug.Log("Mouse exited");
        transform.localScale = originalScale;
        transform.localPosition = originalPos;
        sortingGroup.sortingOrder = originalSortOrder;
    }

    private void OnMouseDrag()
    {
        isBeingDragged = true;
        gameObject.transform.position = GetMousePosition();
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        mousePosition.z = transform.position.z - Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void OnMouseUp()
    {
        Debug.Log("Mouse up");
        isBeingDragged = false;
        transform.localScale = originalScale;
        transform.localPosition = originalPos;
        sortingGroup.sortingOrder = originalSortOrder;        
    }

    public CardData GetCardData() => cardData;
}
