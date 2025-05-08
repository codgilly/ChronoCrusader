using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TutorialText : MonoBehaviour
{
    public TMP_Text tutorialText;
    public string tutorialHint;

    public KeyCode key;
    public KeyCode key1;
    public KeyCode key2;
    public KeyCode key3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tutorialText.text = tutorialHint;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key) || Input.GetKeyDown(key1) || Input.GetKeyDown(key2) || Input.GetKeyDown(key3))
        {
            ChangeText();
        }
    }

    void ChangeText()
    {
        tutorialText.text = "";
    }

}
