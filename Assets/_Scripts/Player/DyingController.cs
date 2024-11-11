using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class DyingController : MonoBehaviour
{
    public float timerReductionFactor = 5f; // Default reduction is set to times 5, changeable in the inspector
    private TimerBattery timerBattery;
    public void OnTriggerEnter(Collider collider)
    {
        if ((collider.CompareTag("Player")))
        {
            Debug.Log("Entered puddle, faster battery drain");
            timerBattery.batteryTimerFactor = timerReductionFactor; // Makes the battery drain faster when you enter the puddle
        }
    }
    public void OnTriggerExit(Collider collider)
    {
        if ((collider.CompareTag("Player")))
        {
            Debug.Log("Exited puddle, default battery drain"); // Stops draining the batter when you go out
            timerBattery.ResetBatteryFactor();
        }
    }

    void Awake() // Gets the timer battery prefab
    {
        timerBattery = GameObject.FindAnyObjectByType<TimerBattery>();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
