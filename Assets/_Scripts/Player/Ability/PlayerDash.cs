using System;
using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour {

    [SerializeField] private float dashForce = 20f;
    [SerializeField] private float dashDuration = 1.0f;
    [SerializeField] private float dashCooldown = 1.0f;

    [SerializeField] private Transform dashDirectionTransform;

    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private float bounceBackForce = 10f;
    [SerializeField] private float elapsedTimeBounce = 0.5f;

    private bool canDash = true;

    void Update() {

        if (InputManager.Instance.isDashing && canDash) {
            StartCoroutine(Dash());
        }

    }
    private void OnCollisionEnter(Collision collision) {
        if (!canDash && (wallLayer.value & (1 << collision.gameObject.layer)) > 0) {
            StopCoroutine(Dash());
            StartCoroutine(SmoothBounceForce());
        } else if (!canDash && collision.collider.CompareTag(EnumTag.DashBreakable.ToString()) && collision.collider.GetComponent<TriggerBreak>().isBrokenByDash) {
            StopCoroutine(Dash());
            collision.collider.GetComponent<TriggerBreak>().BreakTrigger();
            StartCoroutine(SmoothBounceForce());
            //Debug.Log("DashBreak");
        }

        //Debug.Log("Collison " + collision.collider.tag);
    }

    private IEnumerator Dash() {
        this.canDash = false;
        this.playerMovement.enabled = false;
        Vector3 dashDirection = (dashDirectionTransform.position - transform.position).normalized;

        float elapsedTime = 0f;
        while (elapsedTime < this.dashDuration) {
            float forceThisFrame = (this.dashForce / this.dashDuration) * Time.deltaTime;

            // Apply incremental force
            this.playerRigidbody.AddForce(dashDirection * forceThisFrame, ForceMode.Force);

            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Dash Ended
        this.playerMovement.enabled = true;

        // Dash Cooldown
        yield return new WaitForSecondsRealtime(dashCooldown);
        canDash = true;
    }

    private IEnumerator SmoothBounceForce() {
        Vector3 dashDirection = -(dashDirectionTransform.position - transform.position).normalized;
        float elapsedTime = 0f;
        this.playerRigidbody.linearVelocity = Vector3.zero;
        this.playerMovement.enabled = true;

        while (elapsedTime < this.elapsedTimeBounce) {
            float forceThisFrame = (this.bounceBackForce / this.elapsedTimeBounce) * Time.deltaTime;

            // Apply incremental force
            this.playerRigidbody.AddForce(dashDirection * forceThisFrame, ForceMode.Force);

            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }
        this.canDash = true;
    }
}
