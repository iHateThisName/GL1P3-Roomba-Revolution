using UnityEngine;

public class PauseMenuScripts : MonoBehaviour
{
    public GameObject pauseMenu;
    public void UnPause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    void Pause()
    {
        if (Input.GetButtonDown("Escape"))
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    }
}
