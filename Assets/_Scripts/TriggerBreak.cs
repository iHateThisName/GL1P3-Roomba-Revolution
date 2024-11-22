using Unity.VisualScripting;
using UnityEngine;

public class TriggerBreak : MonoBehaviour {
    [SerializeField] private BreakableObjectController controller;

    [Header("Tag")]
    [SerializeField] private EnumTag Tags;
    [SerializeField] bool TriggerCollider = true;
    [SerializeField] bool CollisionCollider = true;
    [SerializeField] string SpecificGameObjectName = string.Empty;

    [Header("Break")]
    [SerializeField] private GameObject BrokenPiece;

    private void Start() {
        if (this.BrokenPiece != null) {
            this.controller.MaxBreakCount++;
        }
    }

    private void OnTriggerEnter(Collider collider) {
        if (!TriggerCollider) return;
        if (SpecificGameObjectName != string.Empty) {
            if (collider.gameObject.name == SpecificGameObjectName) {
                BreakTrigger();
                //} else if (collider.CompareTag("Player")) {
                //    var t = collider.GetComponent<PlayerDash>();
                //    if (t != null && t.isDa)
            }
        } else if (IsTagInEnum(collider.tag, this.Tags)) {
            BreakTrigger();
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (!CollisionCollider) return;
        if (SpecificGameObjectName != string.Empty) {
            if (collision.gameObject.name == SpecificGameObjectName) {
                BreakTrigger();
            }
        } else if (IsTagInEnum(collision.collider.tag, this.Tags)) {
            BreakTrigger();
        }
    }

    private bool IsTagInEnum(string tag, EnumTag enumTags) {
        foreach (EnumTag enumTag in System.Enum.GetValues(typeof(EnumTag))) {
            if (enumTags.HasFlag(enumTag) && tag == enumTag.ToString()) {
                return true;
            }
        }
        return false;
    }

    public void BreakTrigger() {
        if (this.BrokenPiece != null) {
            controller.Break(gameObject, this.BrokenPiece);
        } else {
            controller.BreakAll();
        }
    }
}
