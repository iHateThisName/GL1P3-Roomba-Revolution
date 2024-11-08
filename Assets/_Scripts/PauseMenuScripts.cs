using UnityEngine;

public class PauseMenuScripts : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseBlur;
    public void UnPause()
    {
        pauseMenu.SetActive(false);
        pauseBlur.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseMenu.SetActive(true);
            pauseBlur.SetActive(true);
            Time.timeScale = 0f;
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
