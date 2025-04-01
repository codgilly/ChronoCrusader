using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine.Audio;

public class DeathPv2 : MonoBehaviour
{
    public float starttimer;
    bool timerON;

    //turn of movemnt 
    public Behaviour dash;
    public Behaviour movemnt;

    public float maxRewindDuration = 5f;
    public float rewindSpeed = 2f;
    private bool isRewinding = false;

    private List<TimeSnapShot> timeSnapshots = new List<TimeSnapShot>();

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
    }

    // Update is called once per frame
    void Update()
    {
        if (timerON == true)
        {
            starttimer += Time.deltaTime;
        }

        if(isRewinding == true)
        {
            starttimer -= Time.deltaTime;

            if (starttimer <= 0)
            {
                StopRewind();
                timerON = true;
            }
        }

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
        movemnt.enabled = false;
        dash.enabled = false;
        isRewinding = true;
        timerON = false;
    }

    void StopRewind()
    {
        movemnt.enabled = true;
        dash.enabled = true;
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
            print("rewinding");

            StartRewind();
        }

        if (other.gameObject.tag == "DeathZone")
        {
            starttimer -= Time.deltaTime;

            StartRewind();
        }

       if (other.gameObject.tag == "CheckPoint")
       {
            print("checkpointhit");
         
            starttimer = 0;
       }
    }
}
