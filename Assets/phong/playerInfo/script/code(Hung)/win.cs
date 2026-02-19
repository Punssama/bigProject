using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    public void thang()
    {
        string LastLevel = PlayerPrefs.GetString("LastLevel", "");

        if (LastLevel == "Level2")
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(5);
        }
    }

    public void thua()
    {
        SceneManager.LoadScene(2);
    }
}
