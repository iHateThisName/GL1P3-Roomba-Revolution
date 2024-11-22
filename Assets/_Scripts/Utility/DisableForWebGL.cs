using UnityEngine;

public class DisableForWebGL : MonoBehaviour {
    void Start() {
#if UNITY_WEBGL
        if (gameObject != null) {
            gameObject.SetActive(false);
        }
#endif
    }
}
