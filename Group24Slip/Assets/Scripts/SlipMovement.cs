using UnityEngine;


public class SlipMovement : MonoBehaviour
{
    private Rigidbody2D body;

    public float jump;
    public float jumpForceZ = 0f;

    [SerializeField] private float slipFactor = 5f;
    private Vector2 axisMovement;

    private bool isJumping;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        body = GetComponent<Rigidbody2D>();
        body.constraints = RigidbodyConstraints2D.FreezeRotation;

    }

    // Update is called once per frame
    void Update()
    {

        axisMovement.x = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(axisMovement.x * slipFactor, body.velocity.y); 

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            body.AddForce(new Vector2(body.velocity.x, jump));

        }

    }
        
    private void FixedUpdate()
    {
        Move();
    }

    //This method is to make the player move, the method CheckFlipping was called here in the move method as it's relevant to the movement, it will be explained further domw.
    private void Move()
    {

        body.velocity = new Vector2 (axisMovement.x * slipFactor, body.velocity.y); //axis Movement is the x, y. Multiplying by the speed slipFactor makes it faster.
        CheckForFlipping();

    }

 

    //This checks for the direction of the movement and flips the sprite accordingly, if the player is moving left it will flip the sprite to face left and if it's moving right it will flip the sprite to face right, this is done by changing the localScale of the transform, which is a common way to flip sprites in Unity.
    private void CheckForFlipping() 
    {
        bool movingLeft = axisMovement.x < 0;
        bool movingRight = axisMovement.x > 0;
        if  (movingLeft)
        {

            transform.localScale = new Vector3(-1f, transform.localScale.y, jumpForceZ);

        }
        else if (movingRight)
        {

            transform.localScale = new Vector3(1f,transform.localScale.y, jumpForceZ);

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = true;
        }
    }
}

