using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    [SerializeField] private string requiredTag = "Push";
    [SerializeField] private GameObject activateMe;
    
    private bool isActivated = true;

    // Start is called once before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(requiredTag))
        {
            activateMe.SetActive(false);
            GetComponent<MeshRenderer>().material.color = Color.black;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(requiredTag))
        {
            activateMe.SetActive(true);
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
