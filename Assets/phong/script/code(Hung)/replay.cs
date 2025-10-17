using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class replay : MonoBehaviour
{
    public void onReplay()
    {
        string LastLevel = PlayerPrefs.GetString("LastLevel", "");

        if (!string.IsNullOrEmpty(LastLevel))
        {
            SceneManager.LoadScene(LastLevel);
        }
        else
        {
            SceneManager.LoadScene(1);
        }


    }

}
