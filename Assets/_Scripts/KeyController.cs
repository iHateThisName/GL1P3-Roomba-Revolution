using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class KeyController : MonoBehaviour {

    [SerializeField] private DoorController doorController;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Door") && collision.gameObject == doorController.gameObject) {
            doorController.Unlock();
            Destroy(gameObject);
        }
    }

    public bool HighLightDoor() {
        if (doorController != null && doorController.GetOutline() != null) {
            doorController.GetOutline().enabled = true;
            //doorController.GetOutline().OutlineColor = gameObject.AddComponent<Outline>().OutlineColor;
            return true;
        } else {
            return false;
        }
    }
}
