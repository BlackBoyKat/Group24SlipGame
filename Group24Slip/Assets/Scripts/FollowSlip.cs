using UnityEngine;

public class FollowSlip : MonoBehaviour
{
    public Transform Slip; // The target to follow
    public Vector3 Offset; // The offset from the target

    private void FixedUpdate()
    {
        transform.position = new Vector3(Slip.position.x + Offset.x, Slip.position.y + Offset.y, Offset.z);
    }

}
