using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwordSC : MonoBehaviour
{
    Animator anim;

    //public GameObject blade;
    public Renderer bladeRenderer;

    public Color bladeOGColour;
    public Color bladeParryColour;
    public Color bladeAttackColour;
    void Start()
    {
        anim = GetComponent<Animator>();
        //bladeRenderer = GetComponent<Renderer>();

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Swing");
        }
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetTrigger("Parry");
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == ("Attacking"))
        {
            bladeRenderer.material.color = bladeAttackColour;
        }
        if (gameObject.tag == ("Parrying"))
        {
            bladeRenderer.material.color = bladeParryColour;
        }
    }
    public void StartAttack()
    {
        gameObject.tag = ("Attacking");
       // bladeRenderer.material.color = bladeAttackColour;

    }
    public void EndAttack()
    {
        gameObject.tag = ("nothing");
        bladeRenderer.material.color = bladeOGColour;
    }
    public void StartParry()
    {
        gameObject.tag = ("Parrying");
        //bladeRenderer.material.color = bladeAttackColour;

    }
    public void EndParry()
    {
        gameObject.tag = ("nothing");
        bladeRenderer.material.color = bladeOGColour;
    }
}
