using TMPro;
using UnityEngine;
public class LoreOpen : MonoBehaviour
{
    public TMP_Text lore;

    public string loreText;

    bool canOpen;

    public GameObject interact;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lore.text = "";
        canOpen = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canOpen == true)
        {
            lore.text = loreText;
            interact.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
            interact.SetActive(true);
            canOpen = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "nothing")
        {
            canOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "nothing")
        {
            interact.SetActive(false);
            lore.text = "";
            canOpen = false;
        }
    }
}
