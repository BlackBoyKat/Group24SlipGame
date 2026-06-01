using System;
using System.Collections;
using UnityEngine;


public class SlipMovement : MonoBehaviour
{
    [Header("Components")]
    private SpriteRenderer SpriteRenderer;
    private Rigidbody2D body;

    [Header("Movement")]
    public float jumpPower = 4f;
    [SerializeField] private float slipSpeed = 5f;
    private Vector2 axisMovement;

    [Header("Animations")]
    private Animator animator;
    bool isJumping = false;
    bool isPushing = false;
    bool isHit = false;
    bool isFalling = false;
    bool isGrounded = false;

    [Header("Better Jumping")]
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    [Header("Coyote Time")]
    public float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    [Header("Acceleration")]
    public float acceleration = 70f;
    public float deceleration = 50f;
    public float maxSpeed = 15f;
    public float currentSpeed = 0f;
    public float currentForwardDirection = 1;
    private Coroutine hitCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

        Vector3 Move = Vector3.zero;
        isJumping = false;
        isPushing = false;
        isHit = false;
        isFalling = false;

        //Coyote Time
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime; // Reset the coyote time counter when grounded
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime; // Decrease the coyote time counter when not grounded
        }


        //This is to get the raw input from the horizontal axis, which is the left and right movement, this is done by using the Input.GetAxisRaw method, which returns a value between -1 and 1, where -1 is left, 0 is no movement and 1 is right. The raw input is used to prevent any smoothing that might be applied to the input, which can make the movement feel more responsive.

        float rawHorizontal = Input.GetAxisRaw("Horizontal");
        axisMovement.x = Mathf.Max(0f, rawHorizontal);//cut out the negative values to prevent the player from moving left, this is done by using the Mathf.Max method, which returns the maximum of the two values, in this case 0 and the raw horizontal input, this means that if the raw horizontal input is negative, it will return 0, which will prevent the player from moving left.



        axisMovement.x = Input.GetAxisRaw("Horizontal");


        //Allow jump only when grounded or within coyote time
        if (Input.GetButtonDown("Jump") && coyoteTimeCounter > 0f) //this is a check to see if the player is pressing the jump button and if the player is not already jumping, this is to prevent the player from being able to jump multiple times in the air.
        {
            SFXManager.Play("Jump Effects");
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower); // Set the vertical velocity to the jump power, this will make the player jump.
            isGrounded = false; // Set isGrounded to false when the player jumps 
            Move.y = 1f;
            isJumping = true; 
            isFalling = true;
            coyoteTimeCounter = 0f; // Reset coyote time counter when the player jumps
        }

        if(body.linearVelocity.y < 0) //Falling
        {
            body.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1f) * Time.deltaTime; 
        }
        else if(body.linearVelocity.y > 0 && !Input.GetButton("Jump")) //Rising but jump button is released
        {
            body.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1f) * Time.deltaTime;
        }

        //Left Right movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Move.x -= 1f;
            isPushing = true;

            //flips without resizing
            SpriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Move.x += 1f;
            isPushing = true;

            SpriteRenderer.flipX = false;
        }

        transform.position += Move.normalized * slipSpeed * Time.deltaTime;

        //transform.position += Move.normalized * moveSpeed * Time.deltaTime;
        animator.SetBool("isJumping", isJumping);
        animator.SetBool("isPushing", isPushing);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {

        body.linearVelocity = new Vector2(axisMovement.x * currentSpeed, body.linearVelocity.y); //axis Movement is the x, y. Multiplying by the speed slipFactor makes it faster.


        //Acceleration and Deceleration
        CaculateSpeed(axisMovement);

        if (axisMovement.x > 0.5)
        {
            currentForwardDirection = 1;
        }
        else if (axisMovement.x < -0.5)
        {
            currentForwardDirection = -1;
        }
    }

    private void CaculateSpeed(Vector2 movementVector)
    {
        if (Mathf.Abs(axisMovement.x) > 0) // If there is input
        {
            currentSpeed += acceleration * Time.fixedDeltaTime; // Accelerate
        }
        else // No input
        {
            currentSpeed -= deceleration * Time.fixedDeltaTime; // Decelerate
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Obstacles"))
        {
            SetHitForSeconds(.5f);
        }

        isGrounded = true;
        isFalling = false;

        animator.SetBool("isFalling", isFalling);
        animator.SetBool("isJumping", isGrounded);

    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Obstacles"))
        {
            SetHitForSeconds(.5f);
        }

        isGrounded = false;
        isFalling = true;

        animator.SetBool("isFalling", isFalling);
        animator.SetBool("isJumping", isGrounded);
    }

    public void SetHitForSeconds(float duration)
    {
        if (hitCoroutine != null)
            StopCoroutine(hitCoroutine);
        hitCoroutine = StartCoroutine(HitRoutine(duration));
    }

    private IEnumerator HitRoutine(float duration)
    {
        isHit = true;
        animator.SetBool("isHit", true);
        yield return new WaitForSeconds(duration);
        isHit = false;
        animator.SetBool("isHit", false);
        hitCoroutine = null;
    }


}

