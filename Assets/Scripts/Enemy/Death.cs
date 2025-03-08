using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Rigidbody rb;
    public GameObject areaOfAwarenss;
    public Behaviour AtackingSC;

    public GameObject linkedEnemy;

    public bool deathBool;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        deathBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Attacking")
        {
            DeadEnemy();
            linkedEnemy.GetComponent<Death>().DeadEnemy();
            gameObject.SetActive(false);
        }
    }

    public void DeadEnemy()
    {
        deathBool = true;
        rb.freezeRotation = false;
        areaOfAwarenss.SetActive(false);
        AtackingSC.enabled = false;
        print("dead");
    }
}
