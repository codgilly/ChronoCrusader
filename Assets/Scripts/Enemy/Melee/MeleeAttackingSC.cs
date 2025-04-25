using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class MeleeAttackingSC : MonoBehaviour
{
    //public GameObject areaOfKnowldge;
    public GameObject player;
    public Transform playerposition;
    //public AwareAreaSC AreaSC;

    public TimeSwap TS;

    public bool isInPast;

    public Death death;

    public float speed;

    public GameObject spear;

    Rigidbody rb;
    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        StartCoroutine(MoveTowardsPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        if (TS.isInFuture == isInPast)
        {
            //anim.enabled = true;
            rb.rotation = player.transform.rotation;
            transform.LookAt(playerposition);
            StartCoroutine(MoveTowardsPlayer());
            MoveTowardsPlayer();
        }

        //death.GetComponent<Death>();

        if(death.deathBool == true)
        {
            SpearTag();
        }
    }

    private IEnumerator MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        yield return null;
    }

    public void SpearTag()
    {
        spear.gameObject.tag = "nothing";
    }

    public void SpearAttackingTag()
    {
        spear.gameObject.tag = "AttackedEnemy";
    }

}
