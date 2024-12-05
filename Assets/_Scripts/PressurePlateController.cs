using UnityEngine;

public class PressurePlateController : MonoBehaviour {
    [SerializeField] private string requiredTag = "Push";
    [SerializeField] private string requiredName;
    [SerializeField] private GameObject activateMe;


    private void OnTriggerEnter(Collider other) {
        if ((requiredTag != null && other.CompareTag(requiredTag)) || (requiredName != null && other.name == requiredName)) {
            activateMe.SetActive(false);
            GetComponent<MeshRenderer>().material.color = Color.black;
        }
    }

    private void OnTriggerExit(Collider other) {
        if ((requiredTag != null && other.CompareTag(requiredTag)) || (requiredName != null && other.name == requiredName)) {
            activateMe.SetActive(true);
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
