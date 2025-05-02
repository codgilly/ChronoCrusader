using UnityEngine;
using UnityEngine.SceneManagement;


public class StartAndQuit : MonoBehaviour
{
    private int nextSceneToLoad;

    private int thisScene;

    public GameObject pauseScreen;

    public bool titleScreen;
    void Start()
    {
        thisScene = SceneManager.GetActiveScene().buildIndex;
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;

        if(titleScreen == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && thisScene != 0)
        {
            pauseScreen.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }

    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }


    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
