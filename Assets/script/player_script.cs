using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class player_script : MonoBehaviour
{
    public LayerMask groundLayer;
    public Transform groundCheck;
    public int groundLayerIndex;
    private float moveSpeed = 8f;
    public float jumpHeight = 16.75f;
    private float climbHeight = 4f;
    private float defaultGravity = 7f;
    public bool isGrounded;
    private Rigidbody2D rb;
    private Animator animator;

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
        Time.fixedDeltaTime = 0.01f;
    } // Update is called once per frame
    void Update()
    {
        handleMovement();
        handleJump();
        handleAnimation();
        handleClimb();

    }

    private void handleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }
    private void handleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.gravityScale = defaultGravity;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);

        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

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
