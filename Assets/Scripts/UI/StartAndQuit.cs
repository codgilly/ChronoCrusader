using UnityEngine;
using UnityEngine.SceneManagement;


public class StartAndQuit : MonoBehaviour
{
    private int nextSceneToLoad;
    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }
}
