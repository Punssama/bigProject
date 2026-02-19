using UnityEngine;
public class ItemHandling : MonoBehaviour
{
    private gameManager gm;
    private void Awake()
    {
        gm = FindAnyObjectByType<gameManager>();

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            // Debug.Log("ban da an coin");
            gm.addPoint(1);
        }
    }
}
