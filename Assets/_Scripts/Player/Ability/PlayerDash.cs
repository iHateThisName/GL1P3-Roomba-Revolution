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

    private bool canDash = true;

    void Update() {

        if (InputManager.Instance.isDashing && canDash) {
            StartCoroutine(Dash());
        }

    }

    private IEnumerator Dash() {
        this.canDash = false;
        this.playerMovement.enabled = false;
        Vector3 dashDirection = (dashDirectionTransform.position - transform.position).normalized;

        // Applying dash force
        this.playerRigidbody.AddForce(dashDirection * dashForce, ForceMode.VelocityChange);

        // Dash duration
        yield return new WaitForSecondsRealtime(this.dashDuration);

        // Dash Ended
        this.playerMovement.enabled = true;

        // Dash Cooldown
        yield return new WaitForSecondsRealtime(dashCooldown);
        canDash = true;
    }
}
