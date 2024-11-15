using UnityEngine;

public class BreakableObjectController : MonoBehaviour {

    [SerializeField] private GameObject Body;
    [SerializeField] private GameObject Shard;
    [SerializeField] private GameObject DestroyOnBreak;

    [SerializeField] private bool broken = false;

    [Header("On Break")]
    [SerializeField] private GameObject InstatiatedPrefab;
    [SerializeField] private Vector3 InstatiatedOffsetPosition;
    [SerializeField] private GameObject[] enableGameObjects;
    [SerializeField] private GameObject[] enableAndMoveGameObjects;
    [SerializeField] private Vector3 enableAndMoveOffsetPosition;

    private void Awake() {
        Body.SetActive(true);
        Shard.SetActive(false);
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
        CreateOnBreak();
        Shard.SetActive(true);
        Destroy(this.DestroyOnBreak.gameObject);
    }

    private void CreateOnBreak() {
        if (this.InstatiatedPrefab != null) {
            Instantiate(this.InstatiatedPrefab, transform.position + this.InstatiatedOffsetPosition, Quaternion.identity);
        }

        foreach (GameObject obj in enableGameObjects) {
            obj.SetActive(true);
        }

        foreach (GameObject obj in enableAndMoveGameObjects) {
            obj.transform.position = (transform.position + enableAndMoveOffsetPosition);
            obj.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider collider) {
        if (!collider.CompareTag("Untagged")) {
            Break();
        }
    }

}
