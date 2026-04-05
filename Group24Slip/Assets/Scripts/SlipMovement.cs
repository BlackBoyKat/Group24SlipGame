using UnityEngine;


public class SlipMovement : MonoBehaviour
{
    private Rigidbody2D body;

    public float jumpForceZ = 0f;
    public float jumpFoce = 10f;

    [SerializeField] private float slipFactor = 5f;
    private Vector2 axisMovement;

    bool jumpRequested;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        axisMovement.x = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump"))
        {
           jumpRequested = true;
        }

    }
        
    private void FixedUpdate()
    {

        Move();
        
    }

    //This method is to make the player move, the method CheckFlipping was called here in the move method as it's relevant to the movement, it will be explained further domw.
    private void Move()
    {

        body.linearVelocity = axisMovement.normalized * slipFactor; //axis Movement is the x, y. Multiplying by the speed slipFactor makes it faster.

        if (Input.GetButtonDown("Jump") && Mathf.Abs(body.linearVelocity.y) < 0.001f) //This checks if the player is pressing the jump button and if the player is on the ground, this is done by checking if the y velocity is close to zero, which means the player is not moving up or down.
        {
            body.AddForce(new Vector2(2f, jumpFoce), ForceMode2D.Impulse); //This adds an impulse force to the player, which makes it jump, the force is applied in the y direction and has a magnitude of 5.
        }

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
}

