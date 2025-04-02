using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] enemies;

    public float worldTimer;
    //public float deathtimer;

    public DeathPv2 rewindChecker;

    public Death enemyReseet;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (rewindChecker.isRewinding == false)
        {
            worldTimer += Time.deltaTime;
        }
        else
        {
            worldTimer -= Time.deltaTime;
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            //print(enemies[i].activeInHierarchy);
            if (enemies[i].activeInHierarchy == false)
            {
                CheckDeadEnemy();
            }
        }

       
        //if death timer = world timer - respawn
    }

    void CheckDeadEnemy()
    {
        float deathtimer = worldTimer;

        if(rewindChecker.isRewinding == true)
        {
            if (deathtimer == worldTimer)
            {
                print("respawn");
            }
        }
    }

    void RespawnkilledEnemy()
    {
        //worldTimer -= Time.deltaTime;
        //set active true
        enemyReseet.deathBool = false;
    }

    void RespawnlinkedEnemy()
    {
        //worldTimer -= Time.deltaTime;
        //rotate 0 
        enemyReseet.deathBool = false;
    }
}
