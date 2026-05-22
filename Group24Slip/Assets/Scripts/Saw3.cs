using UnityEngine;

public class MoveUpDown : MonoBehaviour
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
        movingUp = false; // Start by moving down first so it can cycle up
    }

    void Update()
    {
        if (movingUp)
        {
            // Move up until we reach upBoundary
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
            // Move down until we reach downBoundary, then start going up
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
