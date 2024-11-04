using UnityEngine;

public class ExitController : MonoBehaviour {
    [SerializeField] private EnumScene scene = EnumScene.MainMenu;
    private void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player")) {
            Debug.Log("Goal");
            GameManager.Instance.LoadScene(scene);
        }
    }
}