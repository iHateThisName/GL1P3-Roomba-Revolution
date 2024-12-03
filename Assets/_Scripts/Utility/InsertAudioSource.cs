using System.Collections.Generic;
using UnityEngine;

public class InsertAudioSource : MonoBehaviour
{
    [SerializeField] private List <AudioSource> audioSources = new List <AudioSource>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start");
            foreach (var audioSource in audioSources)
            {
                if(audioSource != null) SoundManager.Instance.AddSoundSetting(audioSource);
            }
    }
}
