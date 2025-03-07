using UnityEngine;

public class Hold : MonoBehaviour
{
    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    private GameObject heldObj;
    private Rigidbody heldObjRB;

    [Header("Physics Paramaters")]
    public float pickupRange = 5.0f;
    public float pickupForce = 150.0f;

    
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {

                    PickUpObject(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }

        }
        if (heldObj != null)
        {
            MoveObjcet();
        }
    }


    void MoveObjcet()
    {
        if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 MoveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(MoveDirection * pickupForce);
        }
    }

  

    void PickUpObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.linearDamping = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjRB.transform.parent = holdArea;
            heldObj = pickObj;
        }
    }


    void DropObject()
    {
        heldObjRB.useGravity = true;
        heldObjRB.linearDamping = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObjRB.transform.parent = null;
        heldObj = null;

    }

}
