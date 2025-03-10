using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class MeleeAttackingSC : MonoBehaviour
{
    //public GameObject areaOfKnowldge;
    public GameObject player;
    public Transform playerposition;
    //public AwareAreaSC AreaSC;

    Death death;

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
        
        //print("script sees player");
        anim.SetBool("Spear", true);
        rb.rotation = player.transform.rotation;
        transform.LookAt(playerposition);
        StartCoroutine(MoveTowardsPlayer());
        MoveTowardsPlayer();
        //transform.position = new Vector3.MoveTowards(transform.position, playerposition, speed * Time.deltaTime);

        death.GetComponent<Death>();

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
