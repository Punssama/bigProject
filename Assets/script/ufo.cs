using System.Collections;
using UnityEngine;

public class ufo : MonoBehaviour
{
    [SerializeField] private GameObject player;
    void hideUFO()
    {
        StartCoroutine(fadeout());

    }
    IEnumerator fadeout()
    {
        float duration = 0.75f;
        float t = 0f;
        Vector3 startScale = transform.localScale;

        while (t < duration)
        {
            t += Time.deltaTime;
            float scale = Mathf.Lerp(1f, 0f, t / duration);
            transform.localScale = startScale * scale;
            yield return null;
        }

        gameObject.SetActive(false);
        player.SetActive(true);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
}
