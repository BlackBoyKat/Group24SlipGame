using UnityEngine;

public class JumpPad2 : MonoBehaviour
{
    [SerializeField] private float horizontalBounce = 20f;
    [SerializeField] private float verticalBounce = 8f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        // safer: use the attached Rigidbody2D provided by the collision
        Rigidbody2D rb = collision.rigidbody;
        if (rb == null) return;

        // Apply an instantaneous impulse to push the player right and up
        Vector2 impulse = new Vector2(Mathf.Abs(horizontalBounce), verticalBounce);
        rb.AddForce(impulse, ForceMode2D.Impulse);
    }
}