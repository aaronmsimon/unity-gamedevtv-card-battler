using UnityEngine;

public class PlayZoneTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Card card))
        {
            Debug.Log("CARD entered");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Card card))
        {
            Debug.Log("CARD left");
        }
    }
}
