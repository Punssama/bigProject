using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class replay : MonoBehaviour
{
    public void onReplay()
    {
        SceneManager.LoadScene("Game");

    }

}
