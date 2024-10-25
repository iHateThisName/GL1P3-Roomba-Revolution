using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerSuckAndBlow : MonoBehaviour {

    [SerializeField]
    private float suckSpeed = 10f;
    private HashSet<Rigidbody> pullableObjectsInZone = new HashSet<Rigidbody>();
    private bool isSucking = false;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse1)) {

            if (pullableObjectsInZone.Count > 0) {
                foreach (Rigidbody pullableRigidBody in pullableObjectsInZone) {

                    if (pullableRigidBody.mass < 0.9f && !isSucking) {
                        // Pick Up the Item
                        Debug.Log($"{pullableRigidBody.gameObject.name} picked up");
                        isSucking = true;
                        StartCoroutine(MoveToPosition(pullableRigidBody));

                    } else {
                        // Applies the push force
                        Vector3 direction = (transform.position - pullableRigidBody.position).normalized;
                        pullableRigidBody.AddForce(direction * suckSpeed, ForceMode.Force);

                    }

                }

            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && hasPickUp()) {
            GameObject childGameObject = gameObject.transform.GetChild(0).gameObject;
            Rigidbody childRb = childGameObject.GetComponent<Rigidbody>();

            childGameObject.transform.SetParent(null);
            childRb.isKinematic = false;

            // Appling Push Force
            //Vector3 direction = (transform.position - childRb.position).normalized;
            childRb.AddForce(Vector3.forward * suckSpeed, ForceMode.Force);
            isSucking = false;
        }
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Suckable") && collider.attachedRigidbody != null) {
            pullableObjectsInZone.Add(collider.attachedRigidbody);
            Debug.Log($"In suck zone, {collider.gameObject.name}");
        }
    }

    private void OnTriggerExit(Collider collider) {
        if (pullableObjectsInZone.Contains(collider.attachedRigidbody)) {
            pullableObjectsInZone.Remove(collider.attachedRigidbody);
            Debug.Log($"Left suck zone, {collider.gameObject.name}");
        }
    }

    private IEnumerator MoveToPosition(Rigidbody pullableRigidBody) {
        // Set the rigidbody to kinematic to prevent interference from physics
        pullableRigidBody.isKinematic = true;

        pullableRigidBody.transform.SetParent(transform); // Attach to player to follow the player movment

        Vector3 startPosition = pullableRigidBody.position;
        Vector3 targetPosition = transform.position; // Position in front

        float elapsedTime = 0f;
        float duration = 1f;

        while (elapsedTime < duration) {
            pullableRigidBody.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        pullableRigidBody.position = targetPosition;
    }

    public bool hasPickUp() {
        return gameObject.transform.childCount > 0;
    }

}
