using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthHit : MonoBehaviour
{
    public List<GameObject> imageList;

    public GameObject goBack;

    public int Sharedhealth;

    private int nextSceneToLoad;

    public HealthHit linkedBoss;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Sharedhealth = imageList.Count - 1;

        goBack.SetActive(false);

        linkedBoss = GetComponent<HealthHit>();
        if(linkedBoss == null)
        {
            print("Boo");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(linkedBoss.Sharedhealth <= Sharedhealth)
        {
            linkedBoss.Sharedhealth = Sharedhealth;
        }
        

        if (linkedBoss.Sharedhealth >= Sharedhealth)
        {
            Sharedhealth = linkedBoss.Sharedhealth;
        }
        

        
        if (Sharedhealth <= 0)
        {
            print("WON");
            nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneToLoad);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Attacking")
        {
            print("hit");

            if(Sharedhealth >= 0)
            {
                imageList[Sharedhealth].gameObject.SetActive(false);
                Sharedhealth--;
                goBack.SetActive(true);

                Invoke("GoBack", 0.1f);
            }
        }
    }
    public bool allInActive()
    {
        bool response = true;

        
        return response;
    }
    void GoBack()
    {
        goBack.SetActive(false);
    }
}
