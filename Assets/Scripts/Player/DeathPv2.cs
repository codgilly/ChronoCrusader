using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine.Audio;

public class DeathPv2 : MonoBehaviour
{
    public float timer;
    bool timerON;

    bool hitCheckPoint;

    public float maxRewindDuration = 5f;
    public float rewindSpeed = 2f;
    private bool isRewinding = false;

    private List<TimeSnapShot> timeSnapshots = new List<TimeSnapShot>();

    GameObject[] checkpoints;

    private struct TimeSnapShot
    {
        public Vector3 position;
        public Quaternion rotation;

        public TimeSnapShot(Vector3 pos, Quaternion rot)
        {
            position = pos;
            rotation = rot;

        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerON = true;

        if (timerON == true)
        {
            timer += Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    private void FixedUpdate()
    {
        if (!isRewinding)
        {
            RecordSnapshot();
        }

        else
        {
            RewindTimes();
        }
    }

    void StartRewind()
    {
        isRewinding = true;
    }

    void StopRewind()
    {
        isRewinding = false;
    }

    void RecordSnapshot()
    {
        timeSnapshots.Insert(0, new TimeSnapShot(transform.position, transform.rotation));
        Physics.SyncTransforms();

        if(timeSnapshots.Count > Mathf.Round(maxRewindDuration / Time.deltaTime))
        {
            timeSnapshots.RemoveAt(timeSnapshots.Count - 1);
        }
    }

    void RewindTimes()
    {
        if(timeSnapshots.Count > 0)
        {
            TimeSnapShot snapshot = timeSnapshots[0];
            transform.position = snapshot.position;
            transform.rotation = snapshot.rotation;
            Physics.SyncTransforms();

            timeSnapshots.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("AttackedEnemy") && gameObject.tag != ("Parrying"))
        {
            StartRewind();

            if (hitCheckPoint == false)
            {
                timer -= Time.deltaTime;

                if (timer == 0)
                {
                    StopRewind();
                    timer += Time.deltaTime;
                }
            }

            if (other.gameObject.tag == ("CheckPoint") && hitCheckPoint == true)
            {
                StopRewind();
            }
        }

        if (other.tag == "DeathZone")
        {
            StartRewind();

            if (hitCheckPoint == false)
            {
                timer -= Time.deltaTime;

                if (timer == 0)
                {
                    StopRewind();
                    timer += Time.deltaTime;
                }
            }

            if (other.gameObject.tag == ("CheckPoint") && hitCheckPoint == true)
            {
                StopRewind();
            }
        }

       if (other.tag == ("checkpoint"))
       {
            hitCheckPoint = true;
            timerON = false;
       }
    }
}
