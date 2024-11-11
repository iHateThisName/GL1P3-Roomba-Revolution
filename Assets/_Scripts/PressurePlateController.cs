using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    [SerializeField] private string requiredTag = "SuckAndPickup";
    [SerializeField] private Material whenActive;            
    [SerializeField] private Material whenNotActive; 
    [SerializeField] private GameObject activateMe;
    
    private bool isActivated = true;

    // Start is called once before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().material = whenNotActive;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(requiredTag))
        {
            ActivatePressurePlate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(requiredTag))
        {
            DeactivatePressurePlate();
        }
    }

    // Activate the pressure plate
    private void ActivatePressurePlate()
    {
        if (!isActivated)
        {
            isActivated = true;

            GetComponent<MeshRenderer>().material = whenActive;

            if (activateMe != null)
            {
                activateMe.SetActive(false);
            }
            Debug.Log("Pressure plate activated.");
        }
    }

    private void DeactivatePressurePlate()
    {
        if (isActivated)
        {
            isActivated = false;

            GetComponent<MeshRenderer>().material = whenNotActive;

            if (activateMe != null)
            {
                activateMe.SetActive(true);
            }
            Debug.Log("Pressure plate deactivated.");
        }
    }
}
