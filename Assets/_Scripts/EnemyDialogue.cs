using UnityEngine;

public class EnemyDialogue : MonoBehaviour {
    private bool isTalking = false;

    [SerializeField]
    private GameObject textBouble;

    [SerializeField]
    private DialogTemplate dialogTemplate;

    [SerializeField]
    protected RoamingAI roamingAI;

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Player")) {
            if (!isTalking) {
                isTalking = true;
                textBouble.SetActive(true);
                dialogTemplate.DialougeStart();
                roamingAI.enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider Collider) {
        if (Collider.CompareTag("Player")) {
            dialogTemplate.StopAllCoroutines();
            dialogTemplate.DialougeLeft();
            textBouble.SetActive(false);
            roamingAI.enabled = true;
            isTalking = false;
        }
    }

    public void onDeath() {
        //OnTriggerExit();
    }
}
