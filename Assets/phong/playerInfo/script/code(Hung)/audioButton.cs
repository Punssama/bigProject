using UnityEngine;

public class SoundToggleUI : MonoBehaviour
{
    public GameObject soundOnUI;   // Speaker (no cross)
    public GameObject soundOffUI;  // Speaker with cross

    public bool soundOn;

    private void Start()
    {
        // Load saved sound setting (default = ON)
        soundOn = PlayerPrefs.GetInt("SoundOn", 1) == 1;

        // Apply sound state

        UpdateUI();
    }

    public void ToggleSound()
    {
        soundOn = !soundOn;

        // Apply audio

        // Save
        PlayerPrefs.SetInt("SoundOn", soundOn ? 1 : 0);
        PlayerPrefs.Save();

        UpdateUI();
    }

    private void UpdateUI()
    {
        soundOnUI.SetActive(soundOn);
        soundOffUI.SetActive(!soundOn);
    }

    private void OnEnable()
    {
        // Make sure it updates when scene reloads
        if (soundOnUI != null && soundOffUI != null)
        {
            soundOn = PlayerPrefs.GetInt("SoundOn", 1) == 1;
            UpdateUI();
        }
    }
}
