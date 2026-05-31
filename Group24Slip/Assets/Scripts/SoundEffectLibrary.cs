using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectLibrary : MonoBehaviour
{
    [SerializeField] private SoundEffectGroup[] soundEffectGroups;
    private Dictionary<string, List<AudioClip>> soundDictionary;

    private void Awake()
    {
        InitializeSoundDictionary();
    }

    private void InitializeSoundDictionary()
    {
        soundDictionary = new Dictionary<string, List<AudioClip>>();
        foreach (SoundEffectGroup soundEffectGroup in soundEffectGroups)
        {
            soundDictionary[soundEffectGroup.name] = soundEffectGroup.clip;
        }
    }

    public AudioClip GetRandomClip(string name)
    {
        if(soundDictionary.ContainsKey(name))
        {
            List<AudioClip> clips = soundDictionary[name];
            if(clips.Count > 0)
            {
                int randomIndex = UnityEngine.Random.Range(0, clips.Count);
                return clips[randomIndex];
            }
        }

        return null;
    }
      
}

[System.Serializable]//to make it viewable in the inspector

public struct SoundEffectGroup
{
    public string name;
    public List<AudioClip> clip;
}
