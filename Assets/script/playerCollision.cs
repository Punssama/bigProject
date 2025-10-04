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
        gameManager = GetComponent<gameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ladder"))
        {
            isLadder = true;
        }
        if (collision.gameObject.CompareTag("trap"))
        {
            Debug.Log("dead");
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
            Debug.Log("dead");

        }
    }


}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

//COIN

