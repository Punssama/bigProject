using System.Collections;
using UnityEngine;

public class ufo : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float fadeDuration = 0.5f;
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void hideUFO()
    {
        StartCoroutine(fadeout());

    }
    IEnumerator fadeout()
    {
        Color color = sr.color;
        float startAlpha = color.a;
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, 0f, t / fadeDuration);
            sr.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        gameObject.SetActive(false);
        player.SetActive(true);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
}
