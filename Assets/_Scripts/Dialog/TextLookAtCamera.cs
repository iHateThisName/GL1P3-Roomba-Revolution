using UnityEngine;
using TMPro;

public class TextLookAtCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject Camera;

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = Camera.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(cameraPos);
        transform.rotation = lookRotation * Quaternion.Euler(0f, 180f, 0f);
    }
}
