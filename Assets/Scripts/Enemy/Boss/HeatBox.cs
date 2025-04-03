using UnityEngine;

public class HeatBox : MonoBehaviour
{

    public GameObject heatBox;
    public Vector3 startScale;
    public Vector3 endScale;

    float t = 0;
    public float shrink;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startScale = heatBox.transform.localScale;
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(heatBox.transform.localScale == startScale)
        {
            Shrink();
            t=0;
        }
        if (heatBox.transform.localScale == endScale)
        {
            Grow();
            t = 0;
        }

    }

    void Shrink()
    {
        heatBox.transform.localScale = endScale;
    }

    void Grow()
    {
        heatBox.transform.localScale = startScale;
    }
}
