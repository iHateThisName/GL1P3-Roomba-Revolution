using UnityEngine;

public class TriggerBreak : MonoBehaviour {
    [SerializeField] private BreakableObjectController controller;

    [Header("Tag")]
    [SerializeField] private EnumTag Tags;
    [SerializeField] bool TriggerCollider = true;
    [SerializeField] bool CollisionCollider = true;
    [SerializeField] string SpecificGameObjectName = string.Empty;


    private void OnTriggerEnter(Collider collider) {
        if (!TriggerCollider) return;
        if (SpecificGameObjectName != string.Empty) {
            if (collider.gameObject.name == SpecificGameObjectName) {
                controller.Break();
            }
        } else if (IsTagInEnum(collider.tag, this.Tags)) {
            controller.Break();
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (!CollisionCollider) return;
        if (SpecificGameObjectName != string.Empty) {
            if (collision.gameObject.name == SpecificGameObjectName) {
                controller.Break();
            }
        } else if (IsTagInEnum(collision.collider.tag, this.Tags)) {
            controller.Break();
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
}
