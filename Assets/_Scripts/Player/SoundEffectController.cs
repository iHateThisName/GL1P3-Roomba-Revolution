using UnityEngine;

public class SoundEffectController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    private bool haveSucked = false;

    [Header("Audio")]
    [SerializeField] private AudioSource suckStart;
    [SerializeField] private AudioSource suckContinue;
    [SerializeField] private AudioSource suckEnd;
    [SerializeField] private AudioSource suckAttach;



    // Update is called once per frame
    void Update()
    {
        bool isSucking = this.inputManager.isSucking;
        bool isBlowing = this.inputManager.isBlowing;

        if (isSucking && !this.suckStart.isPlaying && !haveSucked)
        {
            suckStart.Play();
            haveSucked = true;
        } else if(isSucking && !suckStart.isPlaying && !suckContinue.isPlaying && haveSucked) {
            suckContinue.Play();
        } else if(!isSucking && haveSucked) {
            suckStart.Stop();
            suckContinue.Stop();
            suckEnd.Play();
            haveSucked = false;
        }
    }
}
