using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthHit : MonoBehaviour
{

    public GameObject goBack;

    public int Sharedhealth;

    private int nextSceneToLoad;

    public HealthHit linkedBoss;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        goBack.SetActive(false);

        //linkedBoss = GetComponent<HealthHit>();
        if (linkedBoss == null)
        {
            print("Boo");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Sharedhealth <= 0)
        {
            print("WON");
            nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneToLoad);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Attacking")
        {
            print("hit");

            Sharedhealth--;
            linkedBoss.Sharedhealth = Sharedhealth;
            goBack.SetActive(true);

            Invoke("GoBack", 0.1f);
        }
    }
    
    void GoBack()
    {
        goBack.SetActive(false);
    }
}
