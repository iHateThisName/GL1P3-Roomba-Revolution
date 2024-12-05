using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines.Interpolators;
using UnityEngine.UI;

public class LevelNameApperance : MonoBehaviour {
    public TMP_Text uiText;
    public GameObject uiTextObject;

    [SerializeField]
    private string[] currentLevelString;

    private static int currentLevelNumber = 0;
    private float elapsedTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        string[] currentLevel = currentLevelString[currentLevelNumber].Split("#");

        StartCoroutine(LevelName(currentLevel));

        //currentLevelNumber++;


    }

    IEnumerator LevelName(string[] currentLevel) {
        uiText.text = "";
        Color color = uiText.color;
        yield return new WaitForSeconds(1f);
        foreach (string line in currentLevel) {
            foreach (char c in line) {
                if (c == '+') {
                    uiText.text += "\n";
                    continue;
                }
                uiText.text += c;
                yield return new WaitForSeconds(0.06f);
            }
            while (elapsedTime < 4f) {
                elapsedTime += Time.deltaTime;
                color.a = Mathf.Lerp(1f, 0f, elapsedTime / 4f);
                uiText.color = color;
                yield return null;
            }
            color.a = 0f;
            yield return new WaitForSeconds(4f);
        }

        Destroy(gameObject);
    }


}
