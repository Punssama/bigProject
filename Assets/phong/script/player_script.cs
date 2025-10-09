using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class player_script : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    // [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float climbHeight = 4f;
    [SerializeField] private float acceleration = 20f;
    [SerializeField] private float deceleration = 25f;
    [SerializeField] private float minJumpForce = 10f; // The force applied when standing still
    [SerializeField] private float maxJumpForce = 20f; // The maximum possible jump force
    [SerializeField] private float speedToForceMultiplier = 0.5f; // How much speed adds to the jump
    [SerializeField] private float maxSpeed = 11f; // How much speed adds to the jump


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
        moveInput = Input.GetAxis("Horizontal");

        HandleJump();
        handleAnimation();
        handleClimb();

    }
    void FixedUpdate()
    {

        HandleMovement();
    }
    private void HandleMovement()
    {
        float targetSpeed = moveInput * maxSpeed;
        if (Mathf.Abs(targetSpeed) > 0.01f)

        {
            rb.linearVelocity = new Vector2(Mathf.MoveTowards(rb.linearVelocity.x, targetSpeed, acceleration * Time.deltaTime), rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(Mathf.MoveTowards(rb.linearVelocity.x, 0, deceleration * Time.deltaTime), rb.linearVelocity.y);

        }



        if (moveInput > 0)
            transform.localScale = new Vector2(1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector2(-1, 1);
    }

    private void HandleJump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            float bonusForce = Mathf.Abs(rb.linearVelocity.x) * speedToForceMultiplier;

            float totalJumpForce = Mathf.Clamp(minJumpForce + bonusForce, minJumpForce, maxJumpForce);

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * totalJumpForce, ForceMode2D.Impulse);
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


}
