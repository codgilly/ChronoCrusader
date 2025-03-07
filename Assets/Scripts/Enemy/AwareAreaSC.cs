using UnityEngine;

public class AwareAreaSC : MonoBehaviour
{
    public bool canSeePlayer;

    private void Start()
    {
        canSeePlayer = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            canSeePlayer = true;
            //print("can see player");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            canSeePlayer = false;
            //print("can't see player");
        }
    }

}
