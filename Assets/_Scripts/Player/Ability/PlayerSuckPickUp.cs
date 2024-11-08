using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSuckPickUp : MonoBehaviour {
    public HashSet<Rigidbody> pickUpObjectsInZone { get; private set; } = new HashSet<Rigidbody>();

    private void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("SuckAndPickup") && collider.attachedRigidbody != null) {
            pickUpObjectsInZone.Add(collider.attachedRigidbody);
            //Debug.Log($"In pick up zone, {collider.gameObject.name}");
        }
    }

    private void OnTriggerExit(Collider collider) {
        if (pickUpObjectsInZone.Contains(collider.attachedRigidbody)) {
            pickUpObjectsInZone.Remove(collider.attachedRigidbody);
            //Debug.Log($"Left pick up zone, {collider.gameObject.name}");
        }
    }
}
