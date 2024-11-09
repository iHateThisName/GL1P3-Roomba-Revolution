using UnityEngine;

public class DoorController : MonoBehaviour {
    [SerializeField] GameObject ChainsAndLocks;
    [SerializeField] GameObject Door;
    [SerializeField] GameObject DoorWithHinges;
    void Start() {
        Lock();
    }

    public void Unlock() {
        ChainsAndLocks.SetActive(false);
        Door.SetActive(false);
        DoorWithHinges.SetActive(true);
        GetComponent<BoxCollider>().enabled = false;
    }

    private void Lock() {
        ChainsAndLocks.SetActive(true);
        Door.SetActive(true);
        DoorWithHinges.SetActive(false);
        GetComponent<BoxCollider>().enabled = true;
    }
}
