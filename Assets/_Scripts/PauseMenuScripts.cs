using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScripts : MonoBehaviour {
    public GameObject soundEffectManager;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private TMP_Text muteButton;

    //private bool isPaused = false;
    private bool isMuted = false;

    private void Start() {
        //isPaused = false;
        Time.timeScale = 1f;
    }
    public void UnPause() {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //isPaused = false;
        pauseMenu.SetActive(false);
        InputManager.Instance.UnPause();
    }

    public void MainMenu() {
        Time.timeScale = 1f;
        GameManager.Instance.LoadScene(EnumScene.MainMenu);
    }

    public void QuitIngame() {
        GetComponent<PlayerBGone>().QuitGame();
    }

    public void Pause(bool isPaused) {
        if (!isPaused) {
            UnPause();
            return;
        }
        if (isPaused) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (pauseMenu == null) { 
                //Debug.Log("Wtf is going on?"); 
            }
            else {
                pauseMenu.SetActive(true);
            }
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

    public void OnLoadSettingsScene(){
        Helper.currentScene = (EnumScene)SceneManager.GetActiveScene().buildIndex;
        GameManager.Instance.LoadScene(EnumScene.SettingsScene);
    } 

    public void Mute() {
        if (!isMuted){
            soundEffectManager.SetActive(false);
            isMuted = true;
            muteButton.text = "Unmute";
        }
        else if (isMuted){
            soundEffectManager.SetActive(true);
            isMuted = false;
            muteButton.text = "Mute";
        }
    }

}
