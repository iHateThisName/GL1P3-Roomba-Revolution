using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSuckAndBlow : MonoBehaviour {

    private HashSet<Rigidbody> pullableObjectsInZone = new HashSet<Rigidbody>();
    private bool isHolding = false;
    private bool isPullForcedApplied = false;
    private bool isPushForcedApplied = false;
    private bool isHoldingWaitTimeFinished = true;

    [SerializeField] private float addedForce = 50.0f;
    [SerializeField] private PlayerSuckPickUp playerSuckPickUp;
    [SerializeField] private Transform pickUpLocation;
    [SerializeField] private InputManager inputManager;
    void Update() {
        if (this.inputManager.isSucking && !this.isHolding) {
            foreach (Rigidbody pickableRigidBody in playerSuckPickUp.pickUpObjectsInZone) {
                if (!this.isHolding) {
                    //Debug.Log($"{pickableRigidBody.gameObject.name} picked up");
                    this.isHolding = true;
                    PickUp(pickableRigidBody);
                } else {
                    AppliePullForce(pickableRigidBody);
                }
            }

            foreach (Rigidbody pullableRigidBody in this.pullableObjectsInZone) {
                AppliePullForce(pullableRigidBody);
            }
            this.isPullForcedApplied = true;
        } else {
            this.isPullForcedApplied = false;
        }

        if (this.inputManager.isBlowing) {

            float effectiveForce = this.isPushForcedApplied ? this.addedForce : this.addedForce * 0.8f;
            if (HasPickUp()) {
                DropPickUpItem();
                this.isHolding = false;
                this.isHoldingWaitTimeFinished = false;
                StartCoroutine(PushWaitTime(0.5f));

            } else if (this.isHoldingWaitTimeFinished) {
                // Applies the push force
                foreach (Rigidbody pullableRigidBody in this.pullableObjectsInZone) {
                    pullableRigidBody.AddForce(transform.forward * effectiveForce, ForceMode.Force);
                    Debug.Log("Pushing");
                }
            }
            this.isPushForcedApplied = true;
        } else {
            this.isPushForcedApplied = false;
            this.isHoldingWaitTimeFinished = true;
        }

    }

    private ContactPointController DropPickUpItem() {
        GameObject childGameObject = this.pickUpLocation.GetChild(0).gameObject;
        Rigidbody childRb = childGameObject.GetComponent<Rigidbody>();
        ContactPointController cp = childGameObject.GetComponentInChildren<ContactPointController>();
        childGameObject.transform.SetParent(null);
        childRb.isKinematic = false;
        return cp;
    }

    private void PickUp(Rigidbody pickableRigidBody) {
        ContactPointController cp = pickableRigidBody.gameObject.transform.GetComponentInChildren<ContactPointController>();
        pickableRigidBody.isKinematic = true;

        if (cp != null) {
            Transform Offset = cp.GetContactPoint();
            Vector3 offsetPosition = pickUpLocation.position - (Offset.position - pickableRigidBody.transform.position);
            pickableRigidBody.transform.SetPositionAndRotation(offsetPosition, pickUpLocation.rotation * Quaternion.Inverse(Offset.parent.localRotation));
        } else {
            // Fallback
            pickableRigidBody.transform.SetPositionAndRotation(pickUpLocation.position, transform.parent.parent.rotation);
        }
        pickableRigidBody.transform.SetParent(pickUpLocation);
    }

    private void AppliePullForce(Rigidbody pullableRigidBody) {
        ContactPointController cp = pullableRigidBody.GetComponentInChildren<ContactPointController>();
        Vector3 direction = (pickUpLocation.position - pullableRigidBody.position).normalized; // Fallback
        if (cp != null) {
            direction = (pickUpLocation.position - cp.GetContactPoint().position).normalized;
        }
        float effectiveForce = isPullForcedApplied ? addedForce * 0.8f : addedForce;
        pullableRigidBody.AddForce(direction * effectiveForce, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider collider) {
        if ((collider.CompareTag("Suckable") || collider.CompareTag("SuckAndPickup")) && collider.attachedRigidbody != null) {
            pullableObjectsInZone.Add(collider.attachedRigidbody);
            //Debug.Log($"In suck zone, {collider.gameObject.name}");

            ContactPointController cp = collider.GetComponentInChildren<ContactPointController>();
            if (cp != null) {
                cp.isLooking = true;
            }
        }
    }

    private void OnTriggerExit(Collider collider) {
        if (pullableObjectsInZone.Contains(collider.attachedRigidbody)) {
            pullableObjectsInZone.Remove(collider.attachedRigidbody);
            //Debug.Log($"Left suck zone, {collider.gameObject.name}");

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

    private IEnumerator PushWaitTime(float seconds) {
        yield return new WaitForSeconds(seconds);
        this.isHoldingWaitTimeFinished = true;
    }

}
