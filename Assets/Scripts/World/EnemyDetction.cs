using UnityEngine;

public class EnemyDetction : MonoBehaviour
{
    public GameObject SpawnRoom;

    public bool noEnemies;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnRoom.SetActive(false);
    }

    private void Update()
    {
        if (noEnemies == true)
        {
            SpawnRoom.SetActive (true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == ("Enemy"))
        {
            noEnemies = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("Enemy"))
        {
            noEnemies = true;
        }
    }
}
