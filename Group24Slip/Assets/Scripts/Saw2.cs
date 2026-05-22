using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float movementSpeed;

    private bool movingUp;
    private float upBoundary;
    private float downBoundary;

    private void Awake()
    {
        // Set correct boundaries based on the starting Y position
        downBoundary = transform.position.y - movementDistance;
        upBoundary = transform.position.y + movementDistance;
    }

    void Start()
    {
        movingUp = true; // Start by moving up
    }

    void Update()
    {
        if (movingUp)
        {
            // Check Y coordinate to see if we reached upBoundary
            if (transform.position.y < upBoundary)
            {
                transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
            }
            else
            {
                movingUp = false;
            }
        }
        else
        {
            // Check Y coordinate to see if we reached downBoundary
            if (transform.position.y > downBoundary)
            {
                transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
            }
            else
            {
                movingUp = true;
            }
        }
    }
}
