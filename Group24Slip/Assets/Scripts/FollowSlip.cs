using UnityEngine;

public class FollowSlip : MonoBehaviour
{
    public static FollowSlip Instance;

    [Header("Controls for lerping the Y Damping during player fall and jump")]
    [SerializeField] private float fallPanAmount = 0.25f;
    [SerializeField] private float fallYPanTime = 0.25f;
    public float _fallSpeedYDampingChangeThreshold = 15f;

    public bool isLerpingYDamping { get; private set; }
    public bool lerpedFromPlayerFalling { get; set; }

    private Coroutine _lerpYPanCoroutine;


}
