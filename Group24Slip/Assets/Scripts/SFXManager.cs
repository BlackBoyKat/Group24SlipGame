using System;
using UnityEngine;
using UnityEngine.UI;

public class SFXManager : MonoBehaviour
{
    private static SFXManager instance;

    private static AudioSource audioSource;
    private static SoundEffectLibrary soundEffectLibrary;
    [SerializeField] private Slider sfxSlider;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
            soundEffectLibrary = GetComponent<SoundEffectLibrary>();
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void Play(string soundName)
    {
       AudioClip audioClip = soundEffectLibrary.GetRandomClip(soundName);
        if(audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
   
}
