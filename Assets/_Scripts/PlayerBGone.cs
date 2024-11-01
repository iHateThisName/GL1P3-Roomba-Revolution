using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBGone : MonoBehaviour
{
public void QuitGame()
    {
        Application.Quit();

        Debug.Log("The game is exiting");
    }
}
