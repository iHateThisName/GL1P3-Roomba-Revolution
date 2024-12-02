using UnityEngine;

public class SoundSettings : MonoBehaviour
{
    private bool isMuted;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isMuted = PlayerPrefs.GetInt("MUTED") == 1;
        AudioListener.pause = isMuted;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MuteSound() {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);
    }
}
