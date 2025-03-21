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

    public bool isRanged;

    public RangeAtackingSC Rangedenemy;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Rangedenemy = GetComponent<RangeAtackingSC>();
        deathBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(deathBool == true)
        {
            HitByRay();
            linkedEnemy.GetComponent<Death>().HitByRay();
        }

        if(this.gameObject.activeSelf == false)
        {
            linkedEnemy.GetComponent<Death>().HitByRay();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(enemyCollider.GetComponent<Collider>() != null)
        {
            if (other.tag == "Attacking" || deathBool == true)
            {
                HitByRay();
                linkedEnemy.GetComponent<Death>().HitByRay();
                gameObject.SetActive(false);
            }
        }
    }

    public void HitByRay()
    {
        if (isRanged == true)
        {
            Rangedenemy.StopAllCoroutines();
        }
        rb.freezeRotation = false;
        AtackingSC.enabled = false;
        print("dead");
        linkedEnemy.GetComponent<Animator>().enabled = false;
    }

    public void deathGO()
    {
        linkedEnemy.GetComponent<Death>().HitByRay();

        this.gameObject.SetActive(false);
    }

}
