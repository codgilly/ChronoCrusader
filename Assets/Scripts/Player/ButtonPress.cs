using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ButtonPress : MonoBehaviour
{
    public Animator anim;

    public GameObject UI;

    public bool floorButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UI.gameObject.SetActive(false);

        anim.GetComponent<Animator>();
    }

    void OnMouseOver()
    {
        if(floorButton == false)
        {
            print("debugtest");
            UI.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                UI.gameObject.SetActive(false);
                anim.SetBool("Open", true);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(floorButton == true)
        {
            if(other.gameObject.tag == ("Enemy") || other.gameObject.tag == ("Box"))
            {
                anim.SetBool("Open", true);
            }
        }
        else
        {
            print("Wrong One");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (floorButton == true)
        {
            if (other.gameObject.tag == ("Enemy") || other.gameObject.tag == ("Box"))
            {
                anim.SetBool("Open", false);
            }
        }
        else
        {
            print("Wrong One");
        }
    }

    void OnMouseExit()
    {
        UI.gameObject.SetActive(false);
    }
}
