using UnityEngine;

public class DeathP : MonoBehaviour
{
    public int health = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == ("Bullet"))
        {
            print("Dead Player");
        }
    }
}
