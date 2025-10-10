using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
public class gameManager : MonoBehaviour
{
    public int score = 0;
    private gameManager gm;
    private AudioManager audioManager;
    [SerializeField] private TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        gm = FindAnyObjectByType<gameManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    void Start()
    {

        update_score();
    }
    public void winScreen()
    {
        SceneManager.LoadScene("Win");
    }
    public void LoseScreen()
    {
        SceneManager.LoadScene("lose");
    }
    public void addPoint(int point)
    {
        score += point;
        audioManager.playCoinSound();
        update_score();

    }
    public void update_score()
    {
        scoreText.text = score.ToString();
    }
}
