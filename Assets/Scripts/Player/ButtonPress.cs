using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ButtonPress : MonoBehaviour
{
    public Animator anim;

    public GameObject UI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UI.gameObject.SetActive(false);

        anim.GetComponent<Animator>();
    }

    void OnMouseOver()
    {
        UI.gameObject.SetActive(true);

        if (Input.GetKeyDown(KeyCode.F))
        {
            UI.gameObject.SetActive(false);
            anim.SetBool("Open", true);
        }
    }

    void OnMouseExit()
    {
        UI.gameObject.SetActive(false);
    }
}
