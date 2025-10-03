using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    //ladder
    public bool isLadder;
    public bool isOpen;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ladder"))
        {
            isLadder = true;
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("Ban da chet");
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ladder"))
        {

            isLadder = false;
        }



    }


}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

//COIN

