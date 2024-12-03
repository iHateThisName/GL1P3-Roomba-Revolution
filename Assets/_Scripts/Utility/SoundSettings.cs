using UnityEngine;

public class SoundSettings
{
    public AudioSource audioSource;
    public float defaultVolume;
    public int sceneIndex;

    public SoundSettings(AudioSource audioSource, float defaultVolume, int sceneIndex) {
        this.audioSource = audioSource;
        this.defaultVolume = defaultVolume;
        this.sceneIndex = sceneIndex;
    }

}
