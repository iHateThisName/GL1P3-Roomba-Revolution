using UnityEngine;

public class Spinner : MonoBehaviour
{
    // Rotation speed in degrees per second
    public float rotationSpeed = 100f;

    void Update()
    {
        // Check if the GameObject is active and enabled
        if (gameObject.activeInHierarchy)
        {
            // Rotate the object around its Y-axis at the specified rotation speed
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
