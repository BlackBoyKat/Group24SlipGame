using UnityEngine;
public class FinishLine : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject buttons;
     void Start()
    {
        winScreen.SetActive(false);
        buttons.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SFXManager.Play("win");
            winScreen.SetActive(true);
            buttons.SetActive(true);
        }
    }

}
