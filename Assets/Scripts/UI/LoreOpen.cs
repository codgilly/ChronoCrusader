using UnityEngine;
using UnityEngine;
public class LoreOpen : MonoBehaviour
{
    public GameObject lore;



    public GameObject interact;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lore.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
            interact.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "nothing")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                lore.SetActive(true);
                interact.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "nothing")
        {
            interact.SetActive(false);
            lore.SetActive(false);
        }
    }
}
