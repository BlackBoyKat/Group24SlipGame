using UnityEngine;


public class SlipMovement : MonoBehaviour
{
    private Rigidbody2D body;

    public float jump;

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
        //This is to get the raw input from the horizontal axis, which is the left and right movement, this is done by using the Input.GetAxisRaw method, which returns a value between -1 and 1, where -1 is left, 0 is no movement and 1 is right. The raw input is used to prevent any smoothing that might be applied to the input, which can make the movement feel more responsive.
        float rawHorizontal = Input.GetAxisRaw("Horizontal");
        axisMovement.x = Mathf.Max(0f, rawHorizontal);//cut out the negative values to prevent the player from moving left, this is done by using the Mathf.Max method, which returns the maximum of the two values, in this case 0 and the raw horizontal input, this means that if the raw horizontal input is negative, it will return 0, which will prevent the player from moving left.



        body.linearVelocity = new Vector2(axisMovement.x * slipFactor, body.linearVelocity.y); 

        if (Input.GetButtonDown("Jump") && isJumping == false) //this is a check to see if the player is pressing the jump button and if the player is not already jumping, this is to prevent the player from being able to jump multiple times in the air.
        {
            body.AddForce(new Vector2(body.linearVelocity.x, jump));

        }

    }
        
    private void FixedUpdate()
    {
        Move();
    }

    //This method is to make the player move, the method CheckFlipping was called here in the move method as it's relevant to the movement, it will be explained further domw.
    private void Move()
    {

        body.linearVelocity = new Vector2 (axisMovement.x * slipFactor, body.linearVelocity.y); //axis Movement is the x, y. Multiplying by the speed slipFactor makes it faster.
        //CheckForFlipping();

    }



    //This checks for the direction of the movement and flips the sprite accordingly, if the player is moving left it will flip the sprite to face left and if it's moving right it will flip the sprite to face right, this is done by changing the localScale of the transform, which is a common way to flip sprites in Unity.
    //private void CheckForFlipping()
    //{
    //    bool movingLeft = axisMovement.x < 0;
    //    bool movingRight = axisMovement.x > 0;
    //    if (movingLeft)
    //    {

    //        transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);

    //    }
    //    else if (movingRight)
    //    {

    //        transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);

    //    }
    //}

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

