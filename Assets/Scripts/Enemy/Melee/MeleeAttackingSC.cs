using UnityEngine;
using System.Collections;

public class MeleeAttackingSC : MonoBehaviour
{
    public GameObject areaOfKnowldge;
    public GameObject player;
    public Transform playerposition;
    public AwareAreaSC AreaSC;

    public float speed;

    Rigidbody rb;
    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        if (AreaSC != null)
        {
            print("script working");
        }
        else
        {
            print("womp womp");
        }

        StartCoroutine(MoveTowardsPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        if (AreaSC.canSeePlayer == true)
        {
            //print("script sees player");
            anim.SetBool("Spear", true);
            rb.rotation = player.transform.rotation;
            transform.LookAt(playerposition);
            StartCoroutine(MoveTowardsPlayer());
            MoveTowardsPlayer();
            //transform.position = new Vector3.MoveTowards(transform.position, playerposition, speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("Spear", false);
            StopCoroutine(MoveTowardsPlayer());
            //print("script doesn't see player");
        }
    }

    private IEnumerator MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        yield return null;
    }
}
