using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.Splines.Interpolators;

public class TimerBattery : MonoBehaviour
{
    public Animator animator;
    public PlayerMovement playerMovement;
    [SerializeField]
    private PlayerSuckAndBlow playerSuckAndBlow;
    [SerializeField]
    private PlayerDash playerDash;

    public Slider m_slider;
    public float timer;
    public float batteryTimerFactor = 1.0f;
    private float batteryTimerFactorDefault;
    private float deathTimer = 0f;

    public Image m_FillImage;

    public Color m_fullTime = Color.green;
    public Color m_noTime = Color.red;

    static int currentScene;

    private float m_time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake() // Sets the battery timer factor to default before the level starts
    {
        batteryTimerFactorDefault = batteryTimerFactor;
    }
    void Start()
    {
        m_time = timer;
        m_slider.value = m_time;
        playerMovement.moveSpeed = 7f;
        ParticleEffectsManager.Instance.isDead = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (m_time > 0)
        {
            m_time -= Time.deltaTime * batteryTimerFactor;
            m_slider.value = m_time / timer;
            if (m_slider.value <= 75)
            {
                m_FillImage.color = Color.Lerp(m_noTime, m_fullTime, m_time / timer);
            }

        }
        else if (m_time < 0)
        {
            playerMovement.moveSpeed = 0f;
            deathTimer += Time.deltaTime;
            ParticleEffectsManager.Instance.isDead = true;
            bool currentValue = animator.GetBool("FadeOut");
            playerSuckAndBlow.enabled = false;
            playerDash.enabled = false;
            animator.SetBool("FadeOut", true);
            if (deathTimer > 3)
            {
                Debug.Log("Loading new scene");
                //Helper.currentScene = (EnumScene)SceneManager.GetActiveScene().buildIndex;
                GameManager.Instance.LoadScene((EnumScene)SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    public void ResetBatteryFactor()
    {
        batteryTimerFactor = batteryTimerFactorDefault;
    }
    public void AddTime(float time)
    {
        if (m_time + time > timer)
        {
            m_time = timer;
        }
        else
        {
        m_time += time;
        }
    }
}
