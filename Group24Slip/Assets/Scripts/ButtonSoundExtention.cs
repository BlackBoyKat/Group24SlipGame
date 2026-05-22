using UnityEngine;

public class ButtonSoundExtention : MonoBehaviour
{
    public static ButtonSoundExtention Instance;

    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlaySoundEffectClip(AudioClip clip, Transform spawnTransform, float volume)
    {
        //Spawn in gameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        
        //assign the clip
        audioSource.clip = clip;

        //assign volume
        audioSource.volume = volume;    

        //play the sound
        audioSource.Play();

        //get the length of the sfx clip
        float clipLength = audioSource.clip.length;

        //destroys the gameObject after the specified time
        Destroy(audioSource.gameObject, clipLength);
    }
}
