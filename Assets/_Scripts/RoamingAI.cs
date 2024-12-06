using Unity.VisualScripting;
using UnityEngine;

public class RoamingAI : MonoBehaviour
{
    public Transform[] points; // Array of predefined points
    public float speed = 3f;   // Movement speed
    public float maxTimeAtPoint = 10f; // Maximum time to spend at a point
    [SerializeField]
    private Rigidbody rb;

    private int currentPointIndex = 0;
    private float timeAtPoint = 0f;

    private void Update()
    {
        Transform targetPoint = points[currentPointIndex].transform;
        Vector3 lookDirection = new Vector3(targetPoint.position.x, transform.position.y, targetPoint.position.z);
        transform.LookAt(lookDirection);

        Vector3 direction = (new Vector3(targetPoint.position.x, transform.position.y, targetPoint.position.z) - transform.position).normalized;
        Vector3 newPosition = transform.position + direction * 3f * Time.deltaTime;
        rb.MovePosition(newPosition);

        if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                     new Vector3(targetPoint.position.x, 0, targetPoint.position.z)) < 0.1f)
        {
            timeAtPoint = 0f; 
            MoveToNextPoint(); 
        }
        else
        {
            timeAtPoint += Time.deltaTime;
            if (timeAtPoint >= maxTimeAtPoint)
            {
                timeAtPoint = 0f; 
                MoveToNextPoint();
            }
        }
    }
    private void MoveToNextPoint()
    {
        currentPointIndex = (currentPointIndex + 1) % points.Length;
    }
}
