using UnityEngine;

public class PlayZoneTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("playzone trigger");
        if (collision.TryGetComponent(out Card card))
        {
            Debug.Log("CARD");
        }
    }
}
