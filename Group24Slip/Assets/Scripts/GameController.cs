using System.Collections;
using TMPro.Examples;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 checkpointPos;
    Rigidbody2D playerRb;
    CameraController cam;
    Quaternion playerRotation;
    SlipMovement playerMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        playerMovement = GetComponent<SlipMovement>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        checkpointPos = transform.position;
        playerRotation = transform.rotation;
    }



    public void Die()
    {
        //StartCoroutine(Respawn(.5f));
    }
    IEnumerable Respawn(float duration)
    {
        yield return new WaitForSeconds(duration);
        transform.position = checkpointPos;
        transform.rotation = playerRotation;
        playerRb.linearVelocity = Vector2.zero;
    }
}
