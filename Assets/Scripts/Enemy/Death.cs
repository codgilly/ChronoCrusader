using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Rigidbody rb;
    public GameObject areaOfAwarenss;
    public Behaviour AtackingSC;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            print("dead");
        }
    }
}
