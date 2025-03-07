using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Rigidbody rb;
    public GameObject areaOfAwarenss;
    public Behaviour AtackingSC;

    RangeAtackingSC stopAttacking;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //stopAttacking = GetComponent<RangeAtackingSC>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Attacking")
        {
            rb.freezeRotation = false;
            areaOfAwarenss.SetActive(false);
            AtackingSC.enabled = false;
            stopAttacking.StopCoroutine("ShootCoroutine");
            print("dead");
        }
    }
}
