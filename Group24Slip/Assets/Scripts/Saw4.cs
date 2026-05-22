using UnityEngine;

public class Saw4 : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float movementSpeed;
    private bool movingLeft;
    private float leftBoundary;
    private float rightBoundary;

    private void Awake()
    {
        leftBoundary = transform.position.x - movementDistance;
        rightBoundary = transform.position.x + movementDistance;

        // Setting this to true forces the saw to start moving left first
        movingLeft = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftBoundary)
            {
                transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
            }
            else
            {
                movingLeft = false; // Reached left boundary, switch to moving right
            }
        }
        else
        {
            if (transform.position.x < rightBoundary)
            {
                transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
            }
            else
            {
                movingLeft = true; // Reached right boundary, switch to moving left
            }
        }
    }
}

