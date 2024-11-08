using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class TimerBattery : MonoBehaviour
{

    public Slider m_slider;
    public float timer;

    public Image m_FillImage;

    public Color m_fullTime = Color.green;
    public Color m_noTime = Color.red;

    static int currentScene;

    private float m_time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            m_time -= Time.deltaTime;
            m_slider.value = m_time / timer;
            if (m_slider.value <= 75)
            {
                m_FillImage.color = Color.Lerp (m_noTime, m_fullTime, m_time / timer);
            }
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
