using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public GameObject loseScreen;
    public GameObject buttons;

     void Start()
    {
        loseScreen.SetActive(false);
        buttons.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SFXManager.Play("lose");
            loseScreen.SetActive(true);
            buttons.SetActive(true);
        }
    }
}
