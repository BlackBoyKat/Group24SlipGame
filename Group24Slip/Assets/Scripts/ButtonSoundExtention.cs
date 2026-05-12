using UnityEngine;

public class ButtonSoundExtention : MonoBehaviour
{
    public static bool musicOn = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (musicOn)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            musicOn = true;
        }
    }
}
