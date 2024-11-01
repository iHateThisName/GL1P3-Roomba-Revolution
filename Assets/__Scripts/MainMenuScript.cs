using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    public void StartGame() {
        GameManager.Instance.LoadScene(EnumScene.Level01);
    }
}
