using UnityEngine;


public class SlipMovement : MonoBehaviour
{
    private Rigidbody2D body;

    public float jumpPower = 4f;

    [SerializeField] private float slipSpeed = 5f;
    private Vector2 axisMovement;

    bool isGrounded = false;

    private Animator animator;
    bool isJumping = false;
    bool isPushing = false;
    bool isGrinding = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 Move = Vector3.zero;
        isJumping = false;
        isPushing = false;
        isGrinding = false;

        //This is to get the raw input from the horizontal axis, which is the left and right movement, this is done by using the Input.GetAxisRaw method, which returns a value between -1 and 1, where -1 is left, 0 is no movement and 1 is right. The raw input is used to prevent any smoothing that might be applied to the input, which can make the movement feel more responsive.

        float rawHorizontal = Input.GetAxisRaw("Horizontal");
        axisMovement.x = Mathf.Max(0f, rawHorizontal);//cut out the negative values to prevent the player from moving left, this is done by using the Mathf.Max method, which returns the maximum of the two values, in this case 0 and the raw horizontal input, this means that if the raw horizontal input is negative, it will return 0, which will prevent the player from moving left.



        axisMovement.x = Input.GetAxisRaw("Horizontal");
       

        //Allow jump only when grounded
        if (Input.GetButtonDown("Jump") && isGrounded) //this is a check to see if the player is pressing the jump button and if the player is not already jumping, this is to prevent the player from being able to jump multiple times in the air.
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower); // Set the vertical velocity to the jump power, this will make the player jump.
            
            isGrounded = false; // Set isGrounded to false when the player jumps 

            Move.y = 1f;
            isJumping = true; // Set isJumping to true when the player jumps

        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
        { 
            Move.x -= 1f;
            isPushing = true;
            transform.localScale = new Vector3(-1, transform.localScale.y);
        
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
        {
            Move.x += 1f;
            isPushing = true;
            transform.localScale = new Vector3(1, transform.localScale.y);
        
        }

        transform.position += Move.normalized * slipSpeed * Time.deltaTime;

        //transform.position += Move.normalized * moveSpeed * Time.deltaTime;
        animator.SetBool("isJumping", isJumping);
        animator.SetBool("Push", isPushing);
    }
        
    private void FixedUpdate()
    {
        Move();
        //animator.SetFloat("xVelocity", Mathf.Abs(body.linearVelocity.x));
        //animator.SetFloat("yVelocity", body.linearVelocity.y);
    }

    //This method is to make the player move, the method CheckFlipping was called here in the move method as it's relevant to the movement, it will be explained further domw.
    private void Move()
    {

        body.linearVelocity = new Vector2 (axisMovement.x * slipSpeed, body.linearVelocity.y); //axis Movement is the x, y. Multiplying by the speed slipFactor makes it faster.
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            isGrounded = true;
            animator.SetBool("isJumping", !isGrounded);
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
        animator.SetBool("isJumping", isGrounded);
    }


}

