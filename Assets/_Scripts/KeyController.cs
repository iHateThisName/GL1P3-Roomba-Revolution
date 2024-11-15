using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class KeyController : MonoBehaviour {

    [SerializeField] private DoorController doorController;
    [SerializeField] private GameObject roomba;
    [SerializeField] private BoxCollider bc;
    //private Collider keyCollider;
    private Rigidbody rb; 

    void Start() {
        //keyCollider = GetComponent<Collider>();
        //rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.CompareTag("Door") && collision.gameObject == doorController.gameObject) {
            doorController.Unlock();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player")) {
            rb.isKinematic = true;
            bc.enabled = false;
        }
    }


}
