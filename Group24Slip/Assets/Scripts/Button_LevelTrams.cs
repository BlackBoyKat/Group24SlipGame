using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_LevelTrams : MonoBehaviour
{
    
   
     public void LoadLevel() 
    { 
        SceneManager.LoadSceneAsync(1);
    }
}