using UnityEngine;

public class RoamingAI : MonoBehaviour
{
    public Transform[] points; // Array of predefined points
    public float speed = 3f;   // Movement speed
    public float maxTimeAtPoint = 10f; // Maximum time to spend at a point

    private int currentPointIndex = 0;
    private float timeAtPoint = 0f;

    private void Update()
    {
        Transform targetPoint = points[currentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
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
