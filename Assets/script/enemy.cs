using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float distance = 3f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] Transform player;
    [SerializeField] private bool isChasing;

    private bool MovingRight = true;
    private Vector3 currentEnPos;
    void Start()
    {
        currentEnPos = transform.position;
    }
    void Update()
    {
        if (isChasing)
        {
            chasingMode();
        }
        else
        {
            patrollingMode();
        }
    }
    void flip()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
    void patrollingMode()
    {

        float leftBound = currentEnPos.x - distance;
        float rightBound = currentEnPos.x + distance;

        if (MovingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            if (transform.position.x >= rightBound)
            {
                MovingRight = false;
                flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            if (transform.position.x <= leftBound)
            {
                MovingRight = true;
                flip();
            }
        }
    }
    void chasingMode()
    {
        Vector3 distance = (player.position - transform.position).normalized;
        transform.Translate(distance * moveSpeed * Time.deltaTime);
        if (distance.x > 0 && !MovingRight)
        {
            MovingRight = true;
            flip();
        }
        if (distance.x < 0 && MovingRight)
        {
            MovingRight = false;
            flip();
        }
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isChasing = true;

        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isChasing = false;
        }
    }
}
