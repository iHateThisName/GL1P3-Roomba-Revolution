using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScripts : MonoBehaviour {
    public GameObject pauseMenu;
    private bool isPaused = false;
    public static PauseMenuScripts Instance { get; private set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }
    private void Start() {
        isPaused = false;
        Time.timeScale = 1f;
    }
    public void UnPause() {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    public void MainMenu() {
        Time.timeScale = 1f;
        GameManager.Instance.LoadScene(EnumScene.MainMenu);
    }

    public void QuitIngame() {
        GetComponent<PlayerBGone>().QuitGame();
    }

    public void Pause() {
        if (isPaused) {
            UnPause();
            return;
        }
        if (!isPaused) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseMenu.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
        }
    }
    public void OnRestart() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
