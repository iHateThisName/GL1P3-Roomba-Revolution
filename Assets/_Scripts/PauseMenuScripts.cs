using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScripts : MonoBehaviour
{
    public GameObject pauseMenu;

    private bool isPaused = false;

    public static PauseMenuScripts Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void UnPause()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("Unpausing");
        isPaused = false;
        pauseMenu.SetActive(false);
        Debug.Log(isPaused);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        GameManager.Instance.LoadScene(EnumScene.MainMenu);
    }

    public void QuitIngame()
    {
        GetComponent<PlayerBGone>().QuitGame();
    }

    public void Pause()
    {
        if (isPaused)
        {
            UnPause();
            return;
        }
        if (!isPaused)
        {
            Debug.Log("Pausing");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseMenu.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
        }
    }
}
