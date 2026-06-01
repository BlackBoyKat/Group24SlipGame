using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{


    public void GoToScene(string sceneName) //loads new scene
    {
        SFXManager.Play("Button Click");
        Time.timeScale = 1f; // unpause
        SceneManager.LoadScene(sceneName);
    }
    public void ResumeCurrentScene()
    {
        SFXManager.Play("Button Click");
        Time.timeScale = 1f; // unpause
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitApplication()
    {
        SFXManager.Play("Button Click");
        Application.Quit(); //to trigger closing the app (only works in the export)
        Debug.Log("Application Quit"); //for testing dw about it gng
    }  
}
