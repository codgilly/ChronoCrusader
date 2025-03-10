using UnityEngine;

public class TimeSwap : MonoBehaviour
{
    public bool isInFuture;

    //public Transform player;

    public Transform pastPlane;
    public Transform futurePlane;

    CharacterController cc;
    void Start()
    {
        isInFuture = true;
       cc= GetComponent<CharacterController>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) )
        {
            //toggle the bool 
            isInFuture = isInFuture ?false:true;

            if( isInFuture)
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
        Vector3 myPositionY = transform.position;
        Vector3 futurePlaneDistanceY = futurePlane.transform.position;
        //float yDistance = Mathf.Abs(myPosition.y - otherPosition.y);

        float distance = Mathf.Abs(myPositionY.y - futurePlaneDistanceY.y);

        print("Method started - up");
        transform.position = new Vector3(transform.position.x, pastPlane.transform.position.y + distance, transform.position.z);
        Physics.SyncTransforms();

    }

    void GoToFuture()
    {
        Vector3 myPosition = transform.position;
        Vector3 pastPlaneDistance = pastPlane.transform.position;

        float distance = Mathf.Abs(myPosition.y - pastPlaneDistance.y);

        print("Method started - down");
        transform.position = new Vector3(transform.position.x, futurePlane.transform.position.y + distance, transform.position.z);
        Physics.SyncTransforms();
    }


}
