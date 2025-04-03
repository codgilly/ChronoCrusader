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

    public float worldTimer;

    public float reviveTimer;

    public DeathPv2 rewindChecker;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Rangedenemy = GetComponent<RangeAtackingSC>();
        deathBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (deathBool == true)
        {
            //HitByRay();
            linkedEnemy.GetComponent<Death>().HitByRay();
        }

        if (this.gameObject.activeSelf == false)
        {
            linkedEnemy.GetComponent<Death>().HitByRay();
        }

        //works
        if (rewindChecker.isRewinding == false)
        {
            worldTimer += Time.deltaTime;
        }
        else
        {
            worldTimer -= Time.deltaTime;
        }

        CheckDeadEnemy();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(enemyCollider.GetComponent<Collider>() != null)
        {
            if (other.tag == "Attacking" || deathBool == true)
            {
                deathBool = true;

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
        reviveTimer = worldTimer;
        
    }

    public void deathGO()
    {
        deathBool = true;
        linkedEnemy.GetComponent<Death>().HitByRay();
        

        this.gameObject.SetActive(false);
    }
    void CheckDeadEnemy()
    {
        if (worldTimer <= reviveTimer)
        {
            //print("respawn");
            RespawnkilledEnemy();
            linkedEnemy.GetComponent<Death>().RespawnkilledEnemy();

        }
    }

    public void RespawnkilledEnemy()
    {
        this.linkedEnemy.SetActive(true);
        //worldTimer -= Time.deltaTime;
        if (isRanged == true)
        {
            Rangedenemy.StartCoroutine("ShootCoroutine");
        }
        rb.freezeRotation = true;
        rb.transform.rotation = new Quaternion(0,0,0,0);
        AtackingSC.enabled = true;
        print("revived");
        linkedEnemy.GetComponent<Animator>().enabled = true;
        reviveTimer = 0;
        deathBool = false;

        reviveTimer = 0;
    }

}
