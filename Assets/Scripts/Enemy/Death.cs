using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Rigidbody rb;
    //public GameObject areaOfAwarenss;
    public Behaviour AtackingSC;

    public Collider enemyCollider;

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
        if(deathBool == true)
        {
            DeadEnemy();
            linkedEnemy.GetComponent<Death>().DeadEnemy();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(enemyCollider.GetComponent<Collider>() != null)
        {
            if (other.tag == "Attacking" || deathBool == true)
            {
                DeadEnemy();
                linkedEnemy.GetComponent<Death>().DeadEnemy();
                gameObject.SetActive(false);
            }
        }
    }

    public void DeadEnemy()
    {
        rb.freezeRotation = false;
        //areaOfAwarenss.SetActive(false);
        AtackingSC.enabled = false;
        print("dead");
        linkedEnemy.GetComponent<Animator>().enabled = false;
    }

    public void HitByRay()
    {
        print("rayhit deathSC");
        deathBool = true;
        gameObject.SetActive(false);
        linkedEnemy.GetComponent<Death>().DeadEnemy();
        AtackingSC.enabled = false;
        DeadEnemy();
        linkedEnemy.GetComponent<Animator>().enabled = false;
    }
}
