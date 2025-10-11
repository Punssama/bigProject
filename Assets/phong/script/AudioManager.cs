using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource effectAudio;
    [SerializeField] private AudioSource loopingAudio;

    [SerializeField] private AudioClip backgroundClip;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip climingLadderClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        playBackgroundMusic();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void playBackgroundMusic()
    {
        backgroundMusic.clip = backgroundClip;
        backgroundMusic.Play();


    }
    public void playCoinSound()
    {
        effectAudio.PlayOneShot(coinClip);
    }
    public void playJumpSound()
    {
        effectAudio.PlayOneShot(jumpClip);
    }
    // public void playClimbingSound()
    // {
    //     effectAudio.PlayOneShot(jumpClip);
    // }


}
