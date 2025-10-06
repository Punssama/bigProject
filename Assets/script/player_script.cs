using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class player_script : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    // [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpHeight = 13.5f;
    [SerializeField] private float climbHeight = 4f;
    [SerializeField] private float acceleration = 15f;
    [SerializeField] private float deceleration = 10f;
    [SerializeField] private float maxSpeed = 11.5f;
    [SerializeField] private float jumpBoost = 0.25f;

    private float defaultGravity = 7f;
    private bool isGrounded;
    private Rigidbody2D rb;
    private Animator animator;
    private float moveInput;


    private playerCollision playerCollision;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); animator = GetComponent<Animator>();
        playerCollision = FindAnyObjectByType<playerCollision>();
    }
    void Start()
    {
        rb.gravityScale = 7f;
    } // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        handleJump();
        handleAnimation();
        handleClimb();

    }
    void FixedUpdate()
    {

        HandleMovement();
    }

    private void HandleMovement()
    {

        // Target velocity we want to reach
        float targetSpeed = moveInput * maxSpeed;

        // Smooth acceleration and deceleration
        if (Mathf.Abs(targetSpeed) > 0.01f)
        {
            // Accelerate toward target speed
            rb.linearVelocity = new Vector2(
                Mathf.MoveTowards(rb.linearVelocity.x, targetSpeed, acceleration * Time.fixedDeltaTime),
                rb.linearVelocity.y
            );
        }
        else
        {
            // Natural slow down (inertia effect)
            rb.linearVelocity = new Vector2(
                Mathf.MoveTowards(rb.linearVelocity.x, 0, deceleration * Time.fixedDeltaTime),
                rb.linearVelocity.y
            );
        }

        // Flip sprite based on direction
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void handleJump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.gravityScale = defaultGravity;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight + jumpBoost * Mathf.Abs(rb.linearVelocity.x));

        }

    }
    private void handleClimb()
    {
        if (playerCollision.isLadder)
        {
            rb.gravityScale = 0;
            float v = 0;
            if (Input.GetKey(KeyCode.W))
            {
                v = climbHeight;
            }
            else if (Input.GetKey(KeyCode.S))
            {

                v = -climbHeight;

            }
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, v);
        }
        else
        {
            rb.gravityScale = defaultGravity;
        }
    }

    private void handleAnimation()
    {


        bool isRunning = Mathf.Abs(rb.linearVelocity.x) > 0.1f;
        bool isJumping = !isGrounded;
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);

    }


    // private void OnCollisionEnter2D(Collision2D collision)

    // {
    //     if (collision.gameObject.CompareTag("ground"))
    //     {
    //         isGrounded = true;
    //     }
    // }
    // private void OnCollisionExit2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("ground"))
    //     {
    //         isGrounded = false;
    //     }
    // }
}
