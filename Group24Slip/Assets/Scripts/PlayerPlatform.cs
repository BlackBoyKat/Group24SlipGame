using UnityEngine;

public class PlayerPlatform : MonoBehaviour
{
   public Transform Point1, Point2;
    public int speed;
    Vector2 targetPos;


    private void Update()
    {
        if (Vector2.Distance(transform.position,Point1.position) <.1f) targetPos = Point2.position;
        if (Vector2.Distance(transform.position, Point2.position) < .1f) targetPos = Point1.position;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed* Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.SetParent(this.transform);
    }
}
