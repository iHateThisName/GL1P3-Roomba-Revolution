using UnityEngine;
using TMPro;

public class TextLookAtCamera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = Camera.main.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(cameraPos);
        transform.rotation = lookRotation * Quaternion.Euler(0f, 180f, 0f);
    }
}
