using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void GoToScene(string sceneName) //loads new scene
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitApplication()
    {
        Application.Quit(); //to trigger closing the app (only works in the export)
        Debug.Log("Application Quit"); //for testing dw about it gng
    }  
}
