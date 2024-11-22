using UnityEngine;

public class BatteryPickupManager : MonoBehaviour
{
    [SerializeField] private TimerBattery timerBattery;
    public float addTime = 10f;
    public void OnTriggerEnter(Collider collider)
    {
        if ((collider.CompareTag("Player")))
        {
            timerBattery.AddTime(addTime);
            Debug.Log("BatteryCollected!");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
