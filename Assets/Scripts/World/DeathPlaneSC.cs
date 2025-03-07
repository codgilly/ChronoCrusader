using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlaneSC : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "nothing")
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
