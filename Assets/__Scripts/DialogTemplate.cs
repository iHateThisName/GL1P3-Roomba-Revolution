using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogTemplate : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textBox;
    // holds the text
    public string[] dialogText;

    public int currentDialogElement = 0;

    //The speed at which letters appear
    private float typingSpeed = 0.04f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            string[] currentDialog = dialogText[currentDialogElement].Split('#');

            StartCoroutine(TypeText(currentDialog));

        }
    }
    IEnumerator TypeText(string[] currentDialog)
    {
        textBox.text = "";

        foreach (string line in currentDialog)
        {


            foreach (char c in line)
            {
                if (c == '+')
                {
                    textBox.text += "\n";
                    continue;
                }


                textBox.text += c;
                // Randomizes appearance
                float randomizeSpeed = typingSpeed * Random.Range(0.6f, 1.4f);
                yield return new WaitForSeconds(randomizeSpeed);


            }
            yield return new WaitForSeconds(2f);
            textBox.text = "";

        }
    }
}
