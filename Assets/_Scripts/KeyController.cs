using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class KeyController : MonoBehaviour {

    [SerializeField] private DoorController doorController;
    [SerializeField] private GameObject roomba;
    [SerializeField] private BoxCollider bc;
    private Rigidbody rb; 

    void Start() {
       
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.CompareTag("Door") && collision.gameObject == doorController.gameObject) {
            doorController.Unlock();
            Destroy(gameObject);
        }
    }
}
