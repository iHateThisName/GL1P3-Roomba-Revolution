using UnityEngine;

public class SoundEffectController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    private bool haveSucked = false;
    private bool haveBlown = false;

    [Header("Audio")]
    [SerializeField] private AudioSource suckStart;
    [SerializeField] private AudioSource suckContinue;
    [SerializeField] private AudioSource suckEnd;
    [SerializeField] private AudioSource suckAttach;
    [SerializeField] private AudioSource blowStart;
    [SerializeField] private AudioSource blowContinue;
    [SerializeField] private AudioSource blowEnd;



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
        if (isBlowing && !this.blowStart.isPlaying && !haveBlown)
        {
            blowStart.Play();
            haveBlown = true;
        }
        else if (isBlowing && !blowStart.isPlaying && !blowContinue.isPlaying && haveBlown)
        {
            blowContinue.Play();
        }
        else if (!isBlowing && haveBlown)
        {
            blowStart.Stop();
            blowContinue.Stop();
            blowEnd.Play();
            haveBlown = false;
        }

    }
}
