using TMPro;
using UnityEngine;

public class TuroialText2 : MonoBehaviour
{
    public TMP_Text tutorialText1;

    public TMP_Text tutorialText2;
    public string tutorialHint;
    public bool canSpawn;


    public KeyCode key;
    public KeyCode key1;
    public KeyCode key2;
    public KeyCode key3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canSpawn = false;
        tutorialText2.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialText1.text == "")
        {
            tutorialText2.text = tutorialHint;
        }

        if (Input.GetKeyDown(key) || Input.GetKeyDown(key1) || Input.GetKeyDown(key2) || Input.GetKeyDown(key3))
        {
            ChangeText();
        }
    }

    void ChangeText()
    {
        tutorialHint = "";
    }

}
