using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathP : MonoBehaviour
{
    public int health = 1;

    public GameObject DeathScreen;

    //public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DeathScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(DeathScreen == true)
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                Time.timeScale = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("AttackedEnemy") && gameObject.tag != ("Parrying"))
        {
            DeathScreen.SetActive(true);
           // print("Dead Player");
        }

        if (other.tag == "DeathZone")
        {
            DeathScreen.SetActive(true);
        }
    }
}
