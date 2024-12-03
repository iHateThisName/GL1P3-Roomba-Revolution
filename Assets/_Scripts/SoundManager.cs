using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [SerializeField] private List <SoundSettings> sceneAudioSources = new List<SoundSettings>();
    [SerializeField] private GameObject soundEffectManager;
    
    private float mainVolumeSlider = 1f; // Backing field
    
    // Property to control access
    [Range(0f, 2f)] public float MainVolumeSlider
    {
        get => mainVolumeSlider;
        set
        {
            mainVolumeSlider = Mathf.Clamp(value, 0f, 2f);
            UpdateSound();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   private void Awake() {
        if (Instance == null) {
            Instance = this;
            transform.SetParent(null);

        } 
        else {
            Destroy(gameObject);
        }
    }

    public void AddSoundSetting(AudioSource audioSource) {
        SoundSettings soundSettings = new SoundSettings(audioSource, audioSource.volume, SceneManager.GetActiveScene().buildIndex);
        sceneAudioSources.Add(soundSettings);
        Debug.Log(audioSource.gameObject.name);
        UpdateSound();
    }

    public void UpdateSound() {
        Debug.Log("Sound changed to " + (100 * mainVolumeSlider) + "%");
        foreach (SoundSettings sound in sceneAudioSources)
        {
            sound.audioSource.volume = sound.defaultVolume * mainVolumeSlider;
        }
    }


    public void Mute() {
        soundEffectManager.SetActive(false);
    }
}

