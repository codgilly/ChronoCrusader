using UnityEngine;
using System.Collections;

public class FireShooting : MonoBehaviour
{
    public GameObject[] platforms;
    GameObject platformToAttack;

    GameObject enemyHead;

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
        ChosePlatform();
        GameObject bulletObj = Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * bulletSpeed);
        Destroy(bulletObj, 2f);

        yield return new WaitForSeconds(waitTime);

        ammo--;
        if (ammo <= 0)
        {
            ammo = maxAmmo;
            yield return new WaitForSeconds(reloadTime);
        }


        yield return null;
    }

    void ChosePlatform()
    {
        index = Random.Range(0, platforms.Length);
        platformToAttack = platforms[index];
        print(platformToAttack.name);
        Vector3 directionToPlayer = platformPosition.transform.position - transform.position;
        directionToPlayer.y = 0f;
        transform.rotation = Quaternion.LookRotation(directionToPlayer.normalized);
    }
}
