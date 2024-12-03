using UnityEngine;

public class EnableOnPlay : MonoBehaviour {
    [SerializeField] private GameObject go;
    private void Start() {
        if (go != null) {
            go.SetActive(true);
        } else {
            gameObject.SetActive(true);
        }
    }
}
