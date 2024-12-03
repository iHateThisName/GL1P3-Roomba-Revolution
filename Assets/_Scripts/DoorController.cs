using UnityEngine;

public class DoorController : MonoBehaviour {
    [SerializeField] private GameObject ChainsAndLocks;
    [SerializeField] private GameObject Door;
    [SerializeField] private GameObject DoorWithHinges;
    [SerializeField] private Outline MainLockOutline;
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

    public Outline GetOutline() {
        return this.MainLockOutline;
    }

    public void SetLockMaterial(Material material) {
        this.MainLockOutline.GetComponent<MeshRenderer>().material = material;
    }
}
