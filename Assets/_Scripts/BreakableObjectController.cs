using UnityEngine;


public class BreakableObjectController : MonoBehaviour {

    [SerializeField] private GameObject Body;
    [SerializeField] private GameObject[] Pieces;
    [SerializeField] private GameObject DestroyOnBreak;

    [Header("On Break")]
    [SerializeField] private GameObject InstatiatedPrefab;
    [SerializeField] private Vector3 InstatiatedOffsetPosition;
    [SerializeField] private GameObject[] EnableGameObjects;
    [SerializeField] private GameObject[] EnableAndMoveGameObjects;
    [SerializeField] private Vector3 enableAndMoveOffsetPosition;
    public int MaxBreakCount = 0;
    private int BreakCount = 0;


    private void Awake() {
        Body.SetActive(true);
        foreach (var go in Pieces) {
            go.SetActive(false);
        }
    }

    public void BreakAll() {
        Body.SetActive(false);
        //Pieces.transform.SetParent(null);
        CreateOnBreak();
        //Pieces.SetActive(true);

        foreach (var go in this.Pieces) {
            go.transform.SetParent(null);
            go.SetActive(true);
        }

        Destroy(this.DestroyOnBreak.gameObject);
    }

    public void Break(GameObject go, GameObject piece) {
        this.BreakCount++;
        if (this.BreakCount >= this.MaxBreakCount) {
            BreakAll();
        } else {
            go.SetActive(false);
            piece.SetActive(true);
        }
    }

    private void CreateOnBreak() {
        if (this.InstatiatedPrefab != null) {
            Instantiate(this.InstatiatedPrefab, transform.position + this.InstatiatedOffsetPosition, Quaternion.identity);
        }

        foreach (GameObject obj in EnableGameObjects) {
            obj.SetActive(true);
        }

        foreach (GameObject obj in EnableAndMoveGameObjects) {
            obj.transform.position = (transform.position + enableAndMoveOffsetPosition);
            obj.SetActive(true);
        }
    }
}
