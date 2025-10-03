using UnityEngine;

public class ItemHandling : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            Debug.Log("ban da an coin");
        }
    }
}
