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
        transform.LookAt(targetPoint);

        Vector3 direction = (targetPoint.position - transform.position).normalized;
        Vector3 newPosition = transform.position + direction * 3f * Time.deltaTime;
        rb.MovePosition(newPosition);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            transform.LookAt(targetPoint);
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
