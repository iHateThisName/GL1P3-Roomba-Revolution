using UnityEngine;


public class BreakableObjectController : MonoBehaviour {

    [SerializeField] private GameObject Body;
    [SerializeField] private GameObject Pieces;
    [SerializeField] private GameObject DestroyOnBreak;

    [Header("On Break")]
    [SerializeField] private GameObject InstatiatedPrefab;
    [SerializeField] private Vector3 InstatiatedOffsetPosition;
    [SerializeField] private GameObject[] enableGameObjects;
    [SerializeField] private GameObject[] enableAndMoveGameObjects;
    [SerializeField] private Vector3 enableAndMoveOffsetPosition;

    private void Awake() {
        Body.SetActive(true);
        Pieces.SetActive(false);
    }

    public void Break() {
        Body.SetActive(false);
        Pieces.transform.SetParent(null);
        CreateOnBreak();
        Pieces.SetActive(true);
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
}
