using UnityEngine;

public class BreakableObjectController : MonoBehaviour {

    [SerializeField] private GameObject Body;
    [SerializeField] private GameObject Shard;
    [SerializeField] private GameObject DestroyOnBreak;

    [SerializeField] private bool broken = false;

    private void Awake() {
        Body.SetActive(true);
        Shard.SetActive(false);
    }
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (broken) {
            Break();
        }
    }

    private void Break() {
        Body.SetActive(false);
        Shard.transform.SetParent(null);
        Shard.SetActive(true);
        Destroy(this.DestroyOnBreak.gameObject);
    }
}
