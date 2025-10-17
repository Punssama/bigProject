using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mapCollision : MonoBehaviour
{
    private Animator animator;
    private gameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool isOpen = false;
    void Awake()
    {
        animator = GetComponent<Animator>();
        gameManager = FindAnyObjectByType<gameManager>();
    }
    void Start()

    {

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isOpen", isOpen);

    }
    async void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {


            isOpen = true;
            await Task.Delay(1000);
            gameManager.winScreen();
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOpen = false;
        }
    }
}
