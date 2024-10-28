using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSuckAndBlow : MonoBehaviour {

    private HashSet<Rigidbody> pullableObjectsInZone = new HashSet<Rigidbody>();
    private bool isHolding = false;

    [SerializeField]
    private PlayerSuckPickUp playerSuckPickUp;

    [SerializeField]
    private Transform pickUpLocation;
    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse1) && !isHolding) {
            foreach (Rigidbody pickableRigidBody in playerSuckPickUp.pickUpObjectsInZone) {
                if (!isHolding) {
                    Debug.Log($"{pickableRigidBody.gameObject.name} picked up");
                    isHolding = true;
                    StartCoroutine(MoveToPosition(pickableRigidBody));
                } else {
                    AppliePullForce(pickableRigidBody);
                }
            }

            foreach (Rigidbody pullableRigidBody in pullableObjectsInZone) {
                AppliePullForce(pullableRigidBody);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) {

            if (HasPickUp()) {
                GameObject childGameObject = pickUpLocation.GetChild(0).gameObject;
                Rigidbody childRb = childGameObject.GetComponent<Rigidbody>();
                ContactPointController cp = childGameObject.GetComponentInChildren<ContactPointController>();

                childGameObject.transform.SetParent(null);
                childRb.isKinematic = false;

                // Appling Push Force
                if (cp != null) {
                    childRb.AddForce(transform.forward, ForceMode.Impulse);
                } else {
                    childRb.AddForce(transform.forward, ForceMode.Impulse);
                }
                isHolding = false;
            } else {
                // Applies the push force
                foreach (Rigidbody pullableRigidBody in pullableObjectsInZone) {
                    pullableRigidBody.AddForce(transform.forward, ForceMode.Impulse);
                }
            }
        }
    }

    private void AppliePullForce(Rigidbody pullableRigidBody) {
        ContactPointController cp = pullableRigidBody.GetComponentInChildren<ContactPointController>();
        Vector3 direction = (pickUpLocation.position - pullableRigidBody.position).normalized; // Fallback
        if (cp != null) {
            direction = (pickUpLocation.position - cp.GetContactPoint().position).normalized;
        }
        pullableRigidBody.AddForce(direction, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider collider) {
        if ((collider.CompareTag("Suckable") || collider.CompareTag("SuckAndPickup")) && collider.attachedRigidbody != null) {
            pullableObjectsInZone.Add(collider.attachedRigidbody);
            Debug.Log($"In suck zone, {collider.gameObject.name}");

            ContactPointController cp = collider.GetComponentInChildren<ContactPointController>();
            if (cp != null) {
                cp.isLooking = true;
            }
        }
    }

    private void OnTriggerExit(Collider collider) {
        if (pullableObjectsInZone.Contains(collider.attachedRigidbody)) {
            pullableObjectsInZone.Remove(collider.attachedRigidbody);
            Debug.Log($"Left suck zone, {collider.gameObject.name}");

            ContactPointController cp = collider.GetComponentInChildren<ContactPointController>();
            if (cp != null) {
                cp.isLooking = false;
            }
        }
    }

    private IEnumerator MoveToPosition(Rigidbody pullableRigidBody) {
        pullableRigidBody.isKinematic = true; // Stops gravity
        pullableRigidBody.transform.SetParent(pickUpLocation); // Attach to player to follow the player movment

        ContactPointController cp = pullableRigidBody.gameObject.transform.GetComponentInChildren<ContactPointController>();

        Vector3 startPosition = pullableRigidBody.position; // Fallback position
        if (cp != null) {
            startPosition = cp.GetContactPoint().position;
        }

        float elapsedTime = 0f;
        float duration = 0.8f;

        while (elapsedTime < duration) {

            Vector3 targetPosition = pickUpLocation.position; // Position in front

            pullableRigidBody.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        pullableRigidBody.MovePosition(pickUpLocation.position);
    }


    public bool HasPickUp() {
        return pickUpLocation.childCount > 0;
    }

}
