using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactPointController : MonoBehaviour
{
    [SerializeField] private Transform playerPickUpPoint;
    [SerializeField] private Transform eyePupil;
    public bool isLooking = false;
    // Start is called before the first frame update
    void Start()
    {
        if (playerPickUpPoint == null) {
            playerPickUpPoint = GameObject.FindGameObjectWithTag("PlayerPickUpPoint").transform;
        }

        if (eyePupil == null) {
            this.eyePupil = GetContactPoint();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLooking) {
            Vector3 directionToTarget = playerPickUpPoint.position - transform.position;
            transform.rotation = Quaternion.LookRotation(directionToTarget);
        }
    }

    public Transform GetContactPoint() {
        if (this.eyePupil != null) return this.eyePupil;
        return gameObject.transform.GetChild(0).transform;
    }
}
