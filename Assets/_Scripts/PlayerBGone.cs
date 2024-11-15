using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBGone : MonoBehaviour {
    public void QuitGame() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
