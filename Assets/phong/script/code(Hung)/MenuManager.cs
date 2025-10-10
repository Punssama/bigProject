using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject playAudio;
    [SerializeField] private GameObject playMusic;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void onPlayMusic()
    {
        playMusic.SetActive(true);
    }
    public void muteMusic()
    {
        playMusic.SetActive(false);
    }
    public void onAudio()
    {
        playAudio.SetActive(true);
    }
    public void muteAudio()
    {
        playAudio.SetActive(false);
    }
}
