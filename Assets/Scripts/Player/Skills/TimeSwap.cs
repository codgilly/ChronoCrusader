using UnityEngine;

public class TimeSwap : MonoBehaviour
{
    public bool isInPast;

    public GameObject player;

    public Transform pastPlane;
    public Transform futurePlane;

    CharacterController cc;
    void Start()
    {
       isInPast = true;
       cc= GetComponent<CharacterController>();
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Tab) )
        {
            //toggle the bool 
            isInPast = isInPast?false:true;

            if( isInPast)
            {
                GoToPast();
            }
            else
            {
                GoToFuture();

            }
        }
    }

    void GoToPast()
    {
        print("Method started - up");
        transform.position = new Vector3(transform.position.x, pastPlane.transform.position.y + 1.725f, transform.position.z);
        Physics.SyncTransforms();

    }

    void GoToFuture()
    {
        print("Method started - down");
        transform.position = new Vector3(transform.position.x, futurePlane.transform.position.y + 1.725f, transform.position.z);
        Physics.SyncTransforms();
    }


}
