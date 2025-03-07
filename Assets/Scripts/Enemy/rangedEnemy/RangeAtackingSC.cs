using UnityEngine;
using System.Collections;

public class RangeAtackingSC : MonoBehaviour
{
    [Header("settings")]
    public GameObject areaOfKnowldge;
    public GameObject player;
    public AwareAreaSC AreaSC;

    [Header("shooting")]
    public GameObject bullet;
    public Transform spawnPoint;
    public float waitTime; 
    public float reloadTime;
    public int ammo;
    public int maxAmmo;
    public float bulletSpeed = 10f;
    public Transform playerposition;

    Rigidbody rb;

    //public bool canSeePlayer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartCoroutine("ShootCoroutine");

        if (AreaSC != null)
        {
            print("script working");
        }
        else
        {
            print("womp womp");
        }

    }

    void Update()
    {
        
        if(AreaSC.canSeePlayer == true)
        {
            //print("script sees player");
            rb.rotation = player.transform.rotation;
            transform.LookAt(playerposition);
            
        }
        else
        {
            //print("script doesn't see player");
        }
      
    }

    private IEnumerator ShootCoroutine()
    {
        while (true)
        {
            if (AreaSC.canSeePlayer == true)
            {
                GameObject bulletObj = Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
                Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
                bulletRig.AddForce(bulletRig.transform.forward * bulletSpeed);
                Destroy(bulletObj, 2f);

                yield return new WaitForSeconds(waitTime);

                //wait for 0.5 seconds

                ammo--;

                if(ammo <= 0)
                {
                    ammo = maxAmmo;
                    yield return new WaitForSeconds(reloadTime);
                }

            }

            yield return null;

        }


        yield return null;



    }
}
