using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
        gameManager = GetComponent<gameManager>();
    }
    void Start()

    {

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isOpen", isOpen);

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOpen = true;
            SceneManager.LoadScene("Win");
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
