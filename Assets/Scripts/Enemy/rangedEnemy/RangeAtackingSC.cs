using UnityEngine;
using System.Collections;

public class RangeAtackingSC : MonoBehaviour
{
    [Header("settings")]
    public GameObject player;

    [Header("shooting")]
    public GameObject bullet;
    public Transform spawnPoint;
    public float waitTime; 
    public float reloadTime;
    public int ammo;
    public int maxAmmo;
    public float bulletSpeed = 10f;
    public Transform playerposition;

    public Death deathSC;

   

    Rigidbody rb;

    //public bool canSeePlayer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartCoroutine("ShootCoroutine");

       
    }

    void Update()
    {
        
            //print("script sees player");
            rb.rotation = player.transform.rotation;
            transform.LookAt(playerposition);
            
      
    }

    private IEnumerator ShootCoroutine()
    {
        while (true)
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

                if (deathSC.deathBool == true)
                {
                    StopCoroutine("ShootCoroutine");
                    //yield return null;
                }
        }
            yield return null;

        if (deathSC.deathBool == true)
        {
            this.enabled = false;
            StopCoroutine("ShootCoroutine");
        }
        yield return null;
    }

    public void StopSpawn() => StartCoroutine("ShootCoroutine");
}
