using System.Collections;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    Vector2 checkpointPos;
    Rigidbody2D playerRb;
    CameraController cam;
    Quaternion playerRotation;
    SlipMovement playerMovement;

    public GameObject gameOverScreen;
    public GameObject failedImage;
    public GameObject finishLine;
    public GameObject outOfBounds;

    public void Start()
    {
        SlipHealth.onPlayerDeath += GameOverScreen;
        gameOverScreen.SetActive(false);
        failedImage.SetActive(false);
        checkpointPos = transform.position;
        playerRotation = transform.rotation;
    }

    void GameOverScreen()
    {
        SFXManager.Play("lose");
        gameOverScreen.SetActive(true);
        failedImage.SetActive(true);
    }

    public void ResetGame()
    { 
        gameOverScreen.SetActive(false);
        failedImage.SetActive(false);
    }
    public void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        playerMovement = GetComponent<SlipMovement>();
        playerRb = GetComponent<Rigidbody2D>();
    }


    public void Die()
    {
        if (gameObject.CompareTag("Player"))
        {
            GameOverScreen();
            gameObject.SetActive(false);
        }
    }
}
