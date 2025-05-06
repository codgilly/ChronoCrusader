using UnityEngine;

public class detecthitangle : MonoBehaviour
{
    public GameObject headHitBox;

    public Animator[] arms;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        headHitBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateHitBox()
    {
        for (int i = 0; i < arms.Length; i++)
        {
            arms[i].enabled = false;
        }

        headHitBox.SetActive(true);
    }

    public void DeactivateHitBox()
    {
        for (int i = 0; i < arms.Length; i++)
        {
            arms[i].enabled = true;
        }

        headHitBox.SetActive(false);
    }
}
