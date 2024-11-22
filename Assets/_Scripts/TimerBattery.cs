using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerBattery : MonoBehaviour
{

    public Slider m_slider;
    public float timer;
    public float batteryTimerFactor = 1.0f;
    private float batteryTimerFactorDefault;
    

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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        m_time -= Time.deltaTime;
        Debug.Log(timer);
        if (timer < 0)
        {
            Debug.Log("Man U dead as hell");
        }
        m_slider.value = timer;
        m_FillImage.color = Color.Lerp(m_fullTime, m_noTime, m_time);
        */

        if (m_time > 0)
        {
            m_time -= Time.deltaTime * batteryTimerFactor;
            m_slider.value = m_time / timer;
            if (m_slider.value <= 75)
            {
                m_FillImage.color = Color.Lerp (m_noTime, m_fullTime, m_time / timer);
            }

        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
