using UnityEngine;

public class ParticleEffectsManager : MonoBehaviour {


    [SerializeField] private ParticleSystem SuckEffect;
    [SerializeField] private ParticleSystem BlowEffect;

    private void Update() {

        if (InputManager.Instance.isSucking) {
            if (SuckEffect.isStopped) SuckEffect.Play();
        } else if (SuckEffect.isPlaying) {
            SuckEffect.Stop();
        }

        if (InputManager.Instance.isBlowing) {
            if (BlowEffect.isStopped) BlowEffect.Play();
        } else if (BlowEffect.isPlaying) {
            BlowEffect.Stop();
        }
    }

}
