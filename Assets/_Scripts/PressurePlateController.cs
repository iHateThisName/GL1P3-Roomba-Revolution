using Unity.VisualScripting;
using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    public Vector3 originalPos;
    bool moveBack = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPos = transform.position;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.name == "SuckablePickableBall")
        {
            transform.Translate(0, 0, -0.01f);
            moveBack = false;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "SuckablePickableBall")
        {
            collision.transform.parent = transform;
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.name == "SuckablePickableBall")
        {
            transform.Translate(0, 0, 0.01f);
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
