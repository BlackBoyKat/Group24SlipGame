using UnityEngine;

public class IgnoreSpecificCollision2D : MonoBehaviour
{
    // Drag the GameObject you want to ignore into this field via the Inspector
    [SerializeField] private GameObject targetObject;

    void Start()
    {
        if (targetObject != null)
        {
            // Get the 2D colliders from both objects
            Collider2D myCollider = GetComponent<Collider2D>();
            Collider2D targetCollider = targetObject.GetComponent<Collider2D>();

            if (myCollider != null && targetCollider != null)
            {
                // Pass both colliders and set 'ignore' parameter to true
                Physics2D.IgnoreCollision(myCollider, targetCollider, true);
            }
        }
    }
}

