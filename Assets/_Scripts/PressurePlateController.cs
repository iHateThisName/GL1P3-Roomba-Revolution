using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    public Transform target;
    public Transform normal;
    public float moveSpeed = 0.5f;

    private bool isMovingToTarget = false;
    private bool isMovingBack = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (isMovingToTarget)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                transform.position = target.position;
                isMovingToTarget = false;
            }
        }

        if (isMovingBack)
        {
            transform.position = Vector3.Lerp(transform.position, normal.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, normal.position) < 0.1f)
            {
                transform.position = normal.position;
                isMovingBack = false;
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("SuckAndPickup"))
        {
            GetComponent<MeshRenderer>().material.color = Color.black;

            if (!isMovingToTarget && !isMovingBack)
            {
                isMovingToTarget = true;
            }
        }
    }
}
