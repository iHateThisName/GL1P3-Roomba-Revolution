using System.Collections;
using UnityEngine;

public class LastSceneController : MonoBehaviour {

    [SerializeField] private float timeToWait = 45f;
    [SerializeField] private float fadeBeforeEnd = 1f;
    [SerializeField] private Animator animator;
    IEnumerator Start() {
        yield return new WaitForSecondsRealtime(timeToWait - fadeBeforeEnd);
        if (animator != null) animator.SetBool("FadeOut", true);
        yield return new WaitForSecondsRealtime(fadeBeforeEnd);
        GameManager.Instance.LoadScene(EnumScene.MainMenu);
        yield break;
    }
}
