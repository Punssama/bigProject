using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    //ladder
    public bool isLadder;
    public bool isOpen;
    private Animator animator;
    private gameManager gameManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        gameManager = FindAnyObjectByType<gameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ladder"))
        {
            isLadder = true;
        }
        if (collision.gameObject.CompareTag("trap"))
        {
            gameManager.LoseScreen();
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ladder"))
        {

            isLadder = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            gameManager.LoseScreen();
        }
    }


}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

//COIN

