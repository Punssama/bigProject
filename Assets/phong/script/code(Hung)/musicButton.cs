using UnityEngine;

public class musicButton : MonoBehaviour
{
    public GameObject musicOnUI;   // Speaker (no cross)
    public GameObject musicOffUI;  // Speaker with cross

    private bool musicOn;

    private void Start()
    {
        // Load saved sound setting (default = ON)
        musicOn = PlayerPrefs.GetInt("musicOn", 1) == 1;

        // Apply sound state

        UpdateUI();
    }

    public void ToggleMusic()
    {
        musicOn = !musicOn;

        // Apply audio

        // Save
        PlayerPrefs.SetInt("musicOn", musicOn ? 1 : 0);
        PlayerPrefs.Save();

        UpdateUI();
    }

    private void UpdateUI()
    {
        musicOnUI.SetActive(musicOn);
        musicOffUI.SetActive(!musicOn);
    }

    private void OnEnable()
    {
        // Make sure it updates when scene reloads
        if (musicOnUI != null && musicOffUI != null)
        {
            musicOn = PlayerPrefs.GetInt("musicOn", 1) == 1;
            UpdateUI();
        }
    }
}
