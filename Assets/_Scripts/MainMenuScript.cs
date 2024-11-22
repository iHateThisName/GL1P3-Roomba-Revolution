using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    public void StartGame() {
        GameManager.Instance.LoadScene(EnumScene.Level01);
    }
    public void OnLoadLevelSelect()
    {
        GameManager.Instance.LoadScene(EnumScene.LevelSelectScene);
    }
    public void OnLoadLevel02() => GameManager.Instance.LoadScene(EnumScene.Level02);
   
    public void OnLoadLevel03() => GameManager.Instance.LoadScene(EnumScene.Level03);

    public void OnLoadLevel04() => GameManager.Instance.LoadScene(EnumScene.Level04);

    public void OnLoadLevel05() => GameManager.Instance.LoadScene(EnumScene.Level05);

    public void OnLoadMainMenu() => GameManager.Instance.LoadScene(EnumScene.MainMenu);
}
