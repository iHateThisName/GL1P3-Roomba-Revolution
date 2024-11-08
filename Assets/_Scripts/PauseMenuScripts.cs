using UnityEngine;

public class PauseMenuScripts : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseBlur;
    public void UnPause()
    {
        pauseMenu.SetActive(false);
        pauseBlur.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            pauseBlur.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void MainMenu()
    {
        GameManager.Instance.LoadScene(EnumScene.MainMenu);
    }

    public void QuitIngame()
    {
        GetComponent<PlayerBGone>().QuitGame();
    }
}
