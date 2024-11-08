using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelNameApperance : MonoBehaviour
{
    public TMP_Text uiText;
    public GameObject uiTextObject;

    [SerializeField]
    private string[] currentLevelString;

    private static int currentLevelNumber = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string[] currentLevel = currentLevelString[currentLevelNumber].Split("#");

        StartCoroutine(LevelName(currentLevel));

        currentLevelNumber++;

        
    }

    IEnumerator LevelName(string[] currentLevel)
    {
        uiText.text = "";
        foreach (string line in currentLevel)
        {
            foreach (char c in line)
            {
                if (c == '+')
                {
                    uiText.text += "\n";
                    continue;
                }
                uiText.text += c;
                yield return new WaitForSeconds(0.04f);
            }
            yield return new WaitForSeconds(4f);
        }
        
        
        uiTextObject.SetActive(false);
        yield return null;
    }
}
