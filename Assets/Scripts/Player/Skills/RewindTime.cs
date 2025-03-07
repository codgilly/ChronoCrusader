using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class RewindTime : MonoBehaviour
{

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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartRewind();
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            StopRewind();
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
}
