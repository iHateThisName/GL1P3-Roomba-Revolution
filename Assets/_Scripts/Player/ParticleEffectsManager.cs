using UnityEngine;

public class ParticleEffectsManager : MonoBehaviour {


    [SerializeField] private ParticleSystem SuckEffect;
    [SerializeField] private ParticleSystem BlowEffect;
    [SerializeField] private ParticleSystem DeathEffect;
    [SerializeField] private ParticleSystem Electrocuted;

    public bool isWet = false;
    public bool isDead = false;

    public static ParticleEffectsManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StoppEffects();
    }
    private void Update()
    {

        if (isDead)
        {
            if (DeathEffect.isStopped)
            {
                StoppEffects();
                DeathEffect.Play();
            }

        } else
        {
            PlayEffects();
        }
    }

    private void PlayEffects()
    {
        if (InputManager.Instance.isSucking)
        {
            if (SuckEffect.isStopped) SuckEffect.Play();
        }
        else if (SuckEffect.isPlaying)
        {
            SuckEffect.Stop();
        }

        if (InputManager.Instance.isBlowing)
        {
            if (BlowEffect.isStopped) BlowEffect.Play();
        }
        else if (BlowEffect.isPlaying)
        {
            BlowEffect.Stop();
        }

        if (isWet)
        {
            if (Electrocuted.isStopped) Electrocuted.Play();
            SoundEffectController.Instance.isInWater = true;
        }
        else if (Electrocuted.isPlaying)
        {
            SoundEffectController.Instance.isInWater = false;
            Electrocuted.Stop();
        }
    }

    private void StoppEffects()
    {
        SuckEffect.Stop();
        BlowEffect.Stop();
        Electrocuted.Stop();
        DeathEffect.Stop();
    }
}
