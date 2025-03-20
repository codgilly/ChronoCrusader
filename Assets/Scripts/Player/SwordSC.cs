using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwordSC : MonoBehaviour
{
    Animator anim;

    public GameObject player;

    [Header("SFX")]
    public AudioClip Kill;
    public AudioClip Parry;
    public AudioSource audioSource;
    //public GameObject blade;

    [Header("blade colour")]
    public Renderer bladeRenderer;

    public Color bladeOGColour;
    public Color bladeParryColour;
    public Color bladeAttackColour;

    [Header("Parry Seetings")]
    public Camera cam;
    private LineRenderer lr;

    Death enemyDeath;
    void Start()
    {
        anim = GetComponent<Animator>();
        //bladeRenderer = GetComponent<Renderer>();

        lr = GetComponent<LineRenderer>();

        //cam = GetComponent<Camera>();

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
        if (gameObject.tag == ("Attacking") && other.gameObject.tag == ("Enemy") || other.gameObject.tag == ("AttackedEnemy"))
        {
            bladeRenderer.material.color = bladeAttackColour;
            audioSource.PlayOneShot(Kill);
        }
        if (gameObject.tag == ("Parrying") && other.gameObject.tag == ("AttackedEnemy"))
        {
            ParryBullet();
            other.gameObject.tag = ("nothing");
            bladeRenderer.material.color = bladeParryColour;
            audioSource.PlayOneShot(Parry);
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
        player.gameObject.tag = ("Parrying");
        //bladeRenderer.material.color = bladeAttackColour;
    }
    public void EndParry()
    {
        gameObject.tag = ("nothing");
        player.gameObject.tag = ("nothing");
        bladeRenderer.material.color = bladeOGColour;
    }

    public void ParryBullet()
    {
        RaycastHit rayHit;
        Debug.DrawRay(cam.transform.position, cam.transform.forward, Color.green);

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out rayHit))
        {
            if (rayHit.transform.gameObject.tag == "Enemy")
            {
                rayHit.transform.SendMessage("deathGO");
                rayHit.transform.SendMessage("HitByRay");
                print("hit");
            }
        }
    }
}
