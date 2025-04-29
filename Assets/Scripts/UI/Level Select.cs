using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;



public class LevelSelect : MonoBehaviour
{
    public void OpenLevel(int levelID)
    {
        string levelName = "" + levelID;
        SceneManager.LoadScene(levelName);
    }
}
