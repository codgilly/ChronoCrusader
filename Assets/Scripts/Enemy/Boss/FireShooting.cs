using UnityEngine;
using System.Collections;
using UnityEngine.Animations;

public class FireShooting : MonoBehaviour
{
    public GameObject[] platforms;
    GameObject platformToAttack;

    public GameObject enemyHead;

    int index;

    [Header("shooting")]
    public GameObject bullet;
    public Transform spawnPoint;
    public float waitTime;
    public float reloadTime;
    public int ammo;
    public int maxAmmo;
    public float bulletSpeed = 10f;
    public Transform platformPosition;

    public GameObject heatBox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        platforms = GameObject.FindGameObjectsWithTag("PastPlatforms");

        StartCoroutine("ShootCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private IEnumerator ShootCoroutine()
    {
        while (true) 
        {
            ChosePlatform();
            GameObject bulletObj = Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
            Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
            bulletRig.AddForce(bulletRig.transform.forward * bulletSpeed);
            Destroy(bulletObj, 2f);

            yield return new WaitForSeconds(waitTime);

            ammo--;
            heatBox.transform.localScale -= new Vector3(4, 5, 6);
            if (ammo <= 0)
            {
                heatBox.transform.localScale = new Vector3(0, 0, 0);
                ammo = maxAmmo;
                yield return new WaitForSeconds(reloadTime);
                heatBox.transform.localScale = new Vector3(99.800293f, 108.522842f, 135.937988f);
            }

            yield return null;
        }

        //yield return null;
    }

    void ChosePlatform()
    {
        index = Random.Range(0, platforms.Length);
        platformToAttack = platforms[index];
        Vector3 targetPosition = platformToAttack.transform.position;
        print(platformToAttack.name);
       
        Vector3 directionToPlatform = targetPosition - transform.position;
        directionToPlatform.y = 0f;
        transform.rotation = Quaternion.LookRotation(directionToPlatform.normalized * Time.deltaTime);
        //enemyHead.transform.LookAt(directionToPlatform.normalized);

    }
    public void StopSpawn() => StartCoroutine("ShootCoroutine");

}
