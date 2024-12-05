using UnityEngine;

public class ExitController : MonoBehaviour {
    [SerializeField] private EnumScene scene = EnumScene.MainMenu;

    [SerializeField]
    private GameObject fadeOutPrefab;

    private float newTime;
    private bool doorOpened = false;
    private void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player")) {
            InputManager.Instance.OnDisableInput();
            Instantiate(fadeOutPrefab);
            newTime = 0;
            doorOpened = true;
        }
    }

    private void Update() {
        newTime += Time.deltaTime;

        if (newTime > 3 && doorOpened) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GameManager.Instance.LoadScene(scene);
        }
    }
}