using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Movement Settings")]
    public LayerMask groundLayer;
    public Transform groundCheck;
    public Transform groundCheck2;
    public bool isGrounded, isGrounded2;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 3.5f;
    public float moveDistance = 3f;

    [Header("Detection Settings")]
    public float detectionRange = 5f;
    public Transform player;

    private Vector2 startPos;
    private int direction = 1;

    private enum EnemyState { Patrolling, Chasing, Returning }
    private EnemyState currentState = EnemyState.Patrolling;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        isGrounded2 = Physics2D.OverlapCircle(groundCheck2.position, 0.2f, groundLayer);

        // --- State transitions ---
        if (distanceToPlayer <= detectionRange)
        {
            currentState = EnemyState.Chasing;
        }
        else if (currentState == EnemyState.Chasing && distanceToPlayer > detectionRange)
        {
            currentState = EnemyState.Returning;
        }

        // --- State behaviors ---
        switch (currentState)
        {
            case EnemyState.Patrolling:
                Patrol();
                break;

            case EnemyState.Chasing:
                Chase();
                break;

            case EnemyState.Returning:
                ReturnToStart();
                break;
        }
    }

    void Patrol()
    {
        // Move enemy left-right
        transform.Translate(Vector2.right * direction * patrolSpeed * Time.deltaTime);

        // Change direction when reaching patrol limit
        if (Vector2.Distance(startPos, transform.position) >= moveDistance || !isGrounded || !isGrounded2)
        {
            direction *= -1;
        }

        // Rotate sprite
        RotateSprite(direction);
    }

    void Chase()
    {
        // Move towards player (only on X axis)
        Vector2 target = new Vector2(player.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target, chaseSpeed * Time.deltaTime);

        // Rotate towards player
        float moveDir = player.position.x - transform.position.x;
        RotateSprite(moveDir);
    }

    void ReturnToStart()
    {
        // Move back to starting point
        transform.position = Vector2.MoveTowards(transform.position, startPos, patrolSpeed * Time.deltaTime);

        // Rotate towards start position
        float moveDir = startPos.x - transform.position.x;
        RotateSprite(moveDir);

        // When close enough, switch back to patrol
        if (Vector2.Distance(transform.position, startPos) < 0.1f)
        {
            currentState = EnemyState.Patrolling;
        }
    }

    void RotateSprite(float moveDir)
    {
        if (moveDir > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);   // Face right
        else if (moveDir < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0); // Face left
    }
}
