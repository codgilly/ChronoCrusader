using UnityEngine;


public class DeathPlaneSC : MonoBehaviour
{

    public GameObject DeathScreen;

    private void Start()
    {
        DeathScreen.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "nothing")
        {
            DeathScreen.SetActive(true);
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
